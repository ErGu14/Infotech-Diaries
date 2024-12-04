using Microsoft.AspNetCore.Mvc;

namespace Proje05_AspNetCoreEmpty.Controllers
{
    public class AboutController : Controller
    {
        private readonly string _about;
        public AboutController()
        {
            _about = "<span style=\"font-weight:bold;color:red;\">Lorem Ipsum</span>, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur.";

        }
        public IActionResult Index()
        {
            ViewBag.about = _about;
            return View();
        }
    }
}
