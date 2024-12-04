// let numbers = [];
// numbers[0]="Iphone 12";
// numbers[1]="Iphone 13";
// numbers[3]="Iphone 14";
// numbers[5]=34;
// numbers[7]=true;
// numbers[9]=new Date();
// numbers[10]="Iphone 13";
// console.log(numbers);

let students = ["Ayşen","Umay","Ceyda","Begüm"];
let result;
result = students.length;
result = students;
result = students.toString();
result = students.join("-");
result = result.split("-");

let products1 = ["ürün1","Ürün2","Ürün3"];
let products2 = ["ürün4","Ürün5"];

result = products1.concat(products2);

students.push("ahmet"); //sona eleman ekler
students.unshift("murat"); // başa eleman ekler
students.pop(); // son elemanı siler
students.shift(); // ilk elemanı siler

let index = students.indexOf("Ceyda");
students[index] = "ceren";

let deleted = students.splice(index,1);


result = students;

console.log(result);
console.log(deleted);