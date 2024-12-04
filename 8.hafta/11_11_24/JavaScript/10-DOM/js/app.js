// DOM = Document Object Model

// 1) Single Element

// let result;
// result = document.getElementById("Task-List");
// result = document.querySelector("#Task-List");
// result.style.backgroundColor = "blue";
// result.style.color = "white";

// const baslik = document.getElementById("page-title"); //değiştirilemez yapmak için
// baslik.style.color = "green";
// baslik.style.backgroundColor = "yellow";
// baslik.style.fontFamily = "Tahoma";
// baslik.style.padding = "15px";


// console.log(result)

// const taskItem = document.querySelector("#Task-List-2 .task-item");
// console.log(taskItem)

// 2) Multi Elements

// let result;

// result = document.getElementsByClassName("card-title");
// result = document.getElementsByClassName("task-item");
// result = document.getElementsByTagName("div");
// result = document.getElementsByTagName("ul");
// result = document.querySelectorAll(".task-item");
// console.log(result);

// ÖDEV : HTMLCollection ile NodeList Arasındaki farkları/benzerlikleri araştırın.


// 2) TRAVERSING

// const taskList = document.getElementById("Task-List");
// let result; 
// result =  taskList.children;
// console.log(result);

// const header = document.querySelector(".card-Header")
// let result;
// result = header.children;

// const body = document.querySelector("body");
// result = body.children;
// console.log(result);

// const taskList = document.getElementById("Task-List");
// let result; 
// result =  taskList.lastElementChild;
// result =  taskList.firstChild;

// result = taskList.children[2];

// result = result.parentElement.parentElement;

 const firstTask =document.getElementById("Task-List").firstElementChild;
result = firstTask.previousElementSibling;

//  result = firstTask.textContent;
//  result = firstTask.nextElementSibling.nextElementSibling;
//  result = firstTask.previousElementSibling;

const lastTask =document.getElementById("Task-List").lastElementChild;
result = lastTask.nextElementSibling;
 
 console.log(result);
