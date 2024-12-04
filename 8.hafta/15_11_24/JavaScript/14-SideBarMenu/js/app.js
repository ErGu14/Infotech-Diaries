const sideNav = document.querySelector(".menu-links");

function toggleNav(){
    if(window.getComputedStyle(sideNav).width == "0px"){
        sideNav.style.width = "250px";
    }else{
        sideNav.style.width ="0";
    };
};

