using ECommerce.Businnes.Abstract;
using ECommerce.Businnes.Configuration;
using ECommerce.Entity.Concrete;
using ECommerce.Shared.Dtos.AuthDTOs;
using ECommerce.Shared.ResponseDTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Businnes.Concrete
{
    
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager; //user bilgilerini alıyorum
        private readonly IConfiguration _configuration; //appsettings.jsona ulaşıcam
        private readonly JWTConfig _jWTConfig; // token ayarlamalarını yapıcam

        //burda IOptions kullanma sebebim şu:  benim appsettingsdeki değerlerim ile jwtconfig de olan bilgileri birbirine entegre ediyorum ki ben classdan bir işlem yaptığım zaman appsettings.jsona gerekli bilgileri göndersin
        public AuthService(UserManager<ApplicationUser> userManager, IConfiguration configuration, IOptions<JWTConfig> jWTConfig)
        {
            _userManager = userManager; 
            _configuration = configuration;
            _jWTConfig = jWTConfig.Value; // burda şunu diyoruz kardeşim ben appsetting.jsondan bilgileri aldım sende ordaki VALUElere burda uygulayacağım şeyleri işle dicez
        }

        public async Task<ResponseDTO<TokenDTO>> Login(LoginDTO loginDTO)
        {
            // Şimdi burda kullanıcı giriş yapma işlemlerini yapıcaz. Kullanıcı eposta ve şifresini gircek eğer doğruysa herşey tıkırındaysa ona bir token oluşturucam ve oluşturma işlemini zatten ben aşağıda generateToken metoduyla yaptım burda kod okunurluğu için tek bir satırda göstericem ve login yapan kullanıcıya bu tokeni vericem ve al kardeşim sen bu kadar süre boyunca bu tokenle işlemlerini yapabilirsin dicem tabi ona verdiğim izinler boyunca :)

            // ilk öncelikle klasik eposta kontrolünü sağlicaz aynı registerde yaptığım gibi

            var user = await _userManager.FindByEmailAsync(loginDTO.Email);
            if (user == null)
            {
                return ResponseDTO<TokenDTO>.Fail("E-Posta Bulunamadı", 404); // eğer kullanıcının girdiği email bilgisi hatalı gelirse yani sistemde kayıtlı olmayan bir eposta gelirse hatta döndürücem
            }
            var isValidPass = await _userManager.CheckPasswordAsync(user,loginDTO.Password); // user bilgisi içindeki şifreyi sistemde kontrol et diyoruz
            if (!isValidPass)
            {

                return ResponseDTO<TokenDTO>.Fail("Şifre Hatalı", 404); // userden gelen şifre sistemdekiyle uyuşmuyorsa hata döndürücez
            }
            var tokenDTO = await GenerateTokenAsync(user); //eğer şifre ve eposta doğruysa user bilgisine ait token oluştur diyoruz  ve claime epostasını yazdık ve id sini şifreleyerek yazmış olduk
            return ResponseDTO<TokenDTO>.Success(tokenDTO, 200); // eğer herşey tamamsa başarılı işlem döndür,tokeni kullanıcıya yansıt 
        }

        public async Task<ResponseDTO<NoContent>> Register(RegisterDTO registerDTO)
        {
            // kullanıcı kayıt etme işlemlerimiz burada olucak

            // ilk öncelikle elime kullanıcı adı olarak bu senaryoda tabi emaili alıcam eğer dışardan gelen email bilgisi ile sistemde hali hazırda kayıtlı bir eposta varsa uyarı olarak dicem ki sistemde zaten kayıtlı bir eposta var

            var existUser = await _userManager.FindByEmailAsync(registerDTO.Email); // reister dtodan gelen email bilgisini sistemden bul 

            if (existUser != null) {

                return ResponseDTO<NoContent>.Fail("Böyle bir Eposta adresi mevcuttur", 400);
            }
            var applicationUser = new ApplicationUser()
            {
                Email = registerDTO.Email,
                FirstName = registerDTO.FirstName,
                LastName = registerDTO.LastName,
                UserName = registerDTO.Email,
                Address = registerDTO.Address,
                City = registerDTO.City,
                Gender = registerDTO.Gender,
                DateOfBirth = registerDTO.DateOfBirth
            }; // eğer kullanıcı girdiği epostaya ait sistemde bir kayıt yoksa bu bilgileri doldurucam  ama şifreyi burda tutmicam yine bir güvenlik önlemi olarak şifre arka planda kaydedilece (arka planda dediğim kısım zaten altta create derken olucak)   ne kadar bilgisi varsa kullanıcıda burda olucak  tabi burda şifre bilgisi yok tanımlamadık o yüzden güvenlik artmış oluyor
            var result = await _userManager.CreateAsync(applicationUser,registerDTO.Password); //hashleme yani şifreleme işlemini zaten user manager metodu benim yerime yapıcak  burası benim artık kullanıcıyı kaydetme metodum add  ve saveChanges işlemlerini arka planda benim yerime yapıyor arkadaş

            if (!result.Succeeded)
            {

                return ResponseDTO<NoContent>.Fail(result.Errors.Select(x => x.Description).ToList(), 400); // eğer kaydetme sırasında bir hata olursa ne bileyim geçersiz şifre veya geçersiz doğum bilgileri gibi burda diyorum ki resulttaki erorleri seç diyorum sonra errorlerin tek tek açıklamarını seç ve listeye dönüştür diyorum bu sayede liste olarak hata döndürebilen responsemiz bunu kolayca anlıyor 
            }
            // şimdi kullanıcıyı kaydettim ama ben varsayılan olarak bir role atamadım şuana kadar User diye şimdi bu açıklamanın bir aşağısında tol ekliyorum
            result = await _userManager.AddToRoleAsync(applicationUser, registerDTO.Role); // burda rol ekleme metodunu kullnarak oluşan kullanıcıya yani appUsere role ekle diyorum role bilgiside registerDTO dan gelen role bilgisinden   bu arada role bilgisi otomatik olarak atadığımız için ben ekstra şu rolü ekle demem gerek yok zaten arkada tanımlı olan rolü eklemiş oluyorum 
            if (!result.Succeeded)
            {

                return ResponseDTO<NoContent>.Fail(result.Errors.Select(x => x.Description).ToList(), 400); // burdada rol eklerken bir hata olursa diyerekten ne bileyim sunucu hatası olur kullanıcı tam birşeyi yaparken bi sorun olur onu görmek için burayı ekliyoruz yukardaki if ile aynısı erroleri liste olarak göster ve kodu göster

            }
            return ResponseDTO<NoContent>.Success(201); // eğer kullanıcı kayıt olabildiyse herşey tamamsa artık başarılı işlemini yolla başarılı işlemi yollarken zaten sistemde işte kişisel bilgileri rolü gibi şeyler kaydeilmiş olucak productdaki gibi vs tek tek update ve save dememize gerek yok kütüphane bizim yerimize yapıcak zaten bu işlemi :)
        }






        //token oluşturrma işlemimizi yapıyoruz

        // repsonse dto kullanmama sebebim ben adama direkt oluşturduktan sonra al kardeşim oluşan işlevsiz bir token vermicem ki o yüzden response a gerek yok
        private async Task<TokenDTO> GenerateTokenAsync(ApplicationUser user)
        {
            var roles = await _userManager.GetRolesAsync(user); //amacım kullanıcının rol bilgilerini çekip nelere ne yetkisi var onları ayarlamamı sağlıyor o yüzden dicem ki misal kardeşim sen işte usersin adında ahmet  sen user rolüne sahip olduğundan sadece şu şu yetkilerin var demek için rolleri çekiyorum

            // şimdi ise claimleri yani yeni oluşan kullanıcının bilgilerini tokene gömmek istiyorum bu sayede mvc de gömülü token ile cookiler ile rahatça işlem yapabilcem
            // claim demek kimlik doğrulama demek yani ben içerisinde eposta tutucam ve kullanıcının yazdığı eposta ile sistemdeki eposta dicem eşit ise ilerde misal login olurken öyle girişini sağlicam sisteme 
            var claim = new[] {

                new Claim(ClaimTypes.NameIdentifier,user.Id), // kullanıcı Id sini benzersiz bir şekilde olucak diyoruz bak OLUCAK henüz oluşturmadım
                new Claim(ClaimTypes.Email,user.Email), // benim tokenimde görüncek şey kullanıcının e postası böyle yerlere şifre konulmaz eğer konulursa kolayca KVKK suçu işlemiş olursun
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()) // burda kullanıcının benzersiz kimliğini oluşturuyoruz ordaki jti JWWT ID yi temsil ediyor yani tokenin Id kısmını rastgele karakterler ile oluşturuyoruz ve ID gibi bilgileri biz Identityden dolayı string yapmıştık ondan dolayı yeni oluşan bu değerleri stringe çevirerek Idlerimizi biz burda oluşturmuş olduk     üstekinde user.ıd ile userlerin Id kısmını belirttik burda ise yukardakinin ıd değerlerini bu kurala göre yap demiş oluyoruz tabi eposta yerine istersen user name ekleyerek de ekstra burda bunuda göster diyebiliriz yani tokene görünebilecek şeyleri ekleyebiliriz  he bu arada bu kod 1 kere oluştuktan sonra benzersizlik yaşanacağı için  Idlerimiz sorun çıkarmicaktır bize aa kardeşim bunlar benziyor demicek ve güvenlik sağlamış oluyoruz
            }.Union(roles.Select(r => new Claim(ClaimTypes.Role, r))); //union demek mevcut olan Arrayin içindeki rolleri tek tek seç diyoruz ve seçili rollerin hepsine claim türü role lan bilgileri tek tek işliyoruz admine admin  usere user satıcıya örnek veriyorum seller gibi     buradaki roles yukardaki aldığımız role bilgilerinden geliyor  ve rolleri bir dizinin içerisine alıyorum ve hepsine tek tek claim ekliyorum burası sadece oluşacak yeni bir kullanıcının rol bilgilerini tokene gömmek için kullanıcam  aslında union demek olduğu dizinin içerisine de yeni bilgileride ekle demek

            //şimdi token oluşturmadan önce tokendeki   key   credential(kimlik keyi) ve expiration(expiry yani ne kadar süre de durucağını burda yapıcam hatırlarsan ben app.jsonda sadece 60 diye sayı verdim yanında saniye dakika veya ay gibi zaman dilimi yok işte onu burda oluştururken vericem o yüzden misal yukarda config bilgilerini aldım eğer almasaydım ben bunu burda kullanamazdım)

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jWTConfig.Secret)); // burdaki işlem şu ya kardeşim sen tokeni oluşturucaksın okey ama ben senin sunucu sahibi tokenin olduğunu burdan anlicam ama bunları şifreli şekilde bana veriyorsun yani bir byte arrayi türünde ben bunu çözümlicem dicek uygulamam

            var credential = new SigningCredentials(key,SecurityAlgorithms.HmacSha256); // kardeşim ben senin sunucu keyini byte dizisi türünde aldım ama bu byte türündeki bilgiler çok açık yani 10 dediğimde sen örnek veriyorum A kelimesini anlicaksın ben senin için burda hmacsha256 adında yaygın bir şifrelem algoritması kullanarak bana gelen şifreli bilgiyi daha üst düzey şifrelicem

            var expiry= DateTime.Now.AddMinutes(_jWTConfig.Expiration); // benim yeni oluşan tokenimin kullanım süresi


            // şimdi aşağıda yapacağım işlemler şu olucak  1- yenib ir token oluşturma işlemi yapıcam   2- ben yeni oluşturduğum tokenin sadece token bilgisini ve ne kadar süre duracağını belirtmek istiyorum o yüzden TokenDTO ya çevirim bu dtoyu döndürücem     tabiki sunucu keyini şifreledim ve ne kadar süre kullanma bilgisinide yukarda ayrı bir şekilde belirttim

            //1- yeni token yaratma işlemi

            var token = new JwtSecurityToken(
                
                issuer: _jWTConfig.Issuer, // token oluştururken sunucu sahibi adı lazım onun bilgisini appsettingsden al
                audience:_jWTConfig.Audience, // sunucuya kimler erişebilir bilgisi
                claims : claim, // claim yani tokenin içerisinde bulunacak olan bilgileri nerden alıcaksın dediğimizde yukardan oluşturduğumu al dicem
                expires: expiry, // tokenin kullanım süresi ne kadar olacak
                signingCredentials: credential // sunucu sahibi keyini nerden alıcam
                
                
                ); // diyorum ki bana yeni bir jwt nin olduğu güvenli bir token oluştur    burda tektek sunucu kime ait, kimler kullanabilir, saahip anahtarı,token token süresi ve tokende bulunacak bilgileri kullanıyoruz

            // 2- elimdeki tokeni kullanıcıya her bir bilgisini göstermemem lazım yani sadece ne kadar süre kullanabilir ve tokenin kendisini  göstermiliyim bu yüzden dtoya çeviriyoruz

            var tokenDTO = new TokenDTO { 
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token), // erişilebilir tokenin içine yeni ir ele alınabilir bir token yaz ve yukarda tanımladığım token bilgisini içine yaz dedim
                ExpirationDate = expiry // klasik token ne kadar süre durcak
            };
            return tokenDTO; // artık token oluşunca sadece dışarrıya görünen bir token olucak


        }


    }
}

