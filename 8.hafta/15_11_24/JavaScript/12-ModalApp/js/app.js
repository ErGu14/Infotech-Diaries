const btnModalOpen= document.getElementById("btn-modal-open");
const mainModel = document.querySelector(".main-modal");
const btnModalYes= document.querySelector(".btn-modal-yes");
const btnModalNo= document.querySelector(".btn-modal-no");
const btnModalClose = document.querySelector(".btn-modal-close");

btnModalOpen.addEventListener("click", function(){
    mainModel.classList.remove("main-modal-none");
});

//evet butonuna tıklayınca kappatma

btnModalYes.addEventListener("click", function(){
    //gerekli dosyayı silme vs. işlemler
    
    alert("silme işlemi başarıyla tamamlanmıştır");
    CloseModel();
});

//modal kapatma fonksiyonu

function CloseModel () {
    mainModel.classList.add("main-modal-none");
}

//Hayır butonuna tıklayınca kapatma

btnModalNo.addEventListener("click", CloseModel);

// Çarpıya vasınca kapatma
btnModalClose.addEventListener("click", CloseModel); //parantez içine 'e' yazmak yapılan eventi çağırmak demek

// arka kısma tıklayınca kapanma
// eğer arka plana tıklayınca kapatılması istenmiyorsa kod yazılmaz
mainModel.addEventListener("click", function(e){
    if(e.target.classList.contains("main-modal")){
        CloseModel();
    };
});