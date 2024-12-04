const slides = document.querySelectorAll(".slide");
const prevButton = document.querySelector(".prev");
const nextButton = document.querySelector(".next");

let curentIndex = 0;
let intervalTime = 3000; 
let interval;


function showSlide(index){
    slides.forEach(function(slide,i){
        slide.classList.remove("active");
        if(i==index){
            slide.classList.add("active");
        }
    });
};

nextButton.addEventListener("click",function(){
    nextSlide();
    stopAutoSlide();
    startAutoSlide();
});

function nextSlide() {
    curentIndex = (curentIndex + 1) % slides.length;
    showSlide(curentIndex);
};

function prevSlide() {
    curentIndex = (curentIndex -1 + slides.length) % slides.length;
    showSlide(curentIndex);
};

prevButton.addEventListener("click",function(){
   prevSlide();
   stopAutoSlide();
    startAutoSlide();
});

// otomatik geçişi başlatan fonksiyon
function startAutoSlide(){
   interval = setInterval(nextSlide,intervalTime);
}
// otomatik geçişi durduran fonksiyon
function stopAutoSlide(){
    clearInterval(interval);
}

showSlide(curentIndex);
startAutoSlide();

