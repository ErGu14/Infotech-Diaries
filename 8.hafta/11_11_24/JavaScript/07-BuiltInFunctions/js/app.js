// ***** STRING *****

// let title = 'String Functions';

// console.log('Başlık: '+ title);
// console.log('Uzunluk: '+ title.length);
// console.log('Başlığın 3. Karakteri: '+ title.charAt(2));
// console.log('BAŞLIK: '+ title.toUpperCase());
// console.log('başlık: '+ title.toLowerCase());
// console.log('Başlığın İlk 6 Karakteri: '+ title.slice(0,6));
// console.log("Başlık'ın 8.karakterinden sonrası: "+ title.slice(7));
// console.log("Yerine Koy: "+ title.replace("n","N"));

// let message = "              Merhaba            ";
//  console.log("Trim Left: "+ message.trimStart());
//  console.log("Trim Right: "+ message.trimEnd());
//  console.log("Trim: "+ message.trim());

//  console.log("g harfi kaçıncı sırada?: " + title.indexOf("-"));
//  console.log("S harfi ile başlıyor mu?: " + title.startsWith("St") );
//  console.log("s harfi ile bitiyor mu?: " + title.endsWith("s"));

// let title = "Başakşehir Futbol Kulübü Tur Atladı";

// let titleArray = title.split(" ");
// let titleResult = titleArray.join("-");
// console.log(titleResult);

// ***** Number ****

// let result;
// result = parseInt(10.78);
// result = parseInt("10.78");
// result = parseInt("     10asdas.78asdasd");
// result = parseInt("a10asdas.78asdasd");
// result = parseFloat("10.78.87sssad");

// let number = 10.387459
// result = number.toFixed(4);
// result = number.toPrecision(6);

// result = Math.round(2.4);
// result = Math.round(2.5);
// result = Math.ceil(2.1);
// result = Math.floor(2.9);

// result = Math.pow(5,2);
// result = Math.pow(5,5);
// result = Math.sqrt(25);
// result = Math.abs(-40);

// result = Math.min(20,10,30,40,50);
// result = Math.max(20,10,30,40,50);

// result = Math.random();
// result = parseInt(Math.random()*100)+1 ;
// console.log(result);

// ***** DATE *****

let result ;
let now;

now = new Date();
// result = now;

// result = now.getDate();
// result = now.getMonth();
// result = now.getDay();
// result = now.getFullYear();
// result = now.getHours();
// result = now.getTime();

let birthDate = new Date(2006,3,14);
let year = birthDate.getFullYear();  //2006
let month = birthDate.getMonth(); // 04
let day = birthDate.getDate(); // 14
result = "Sen " + year + " Yılının " + (month+1) +".ayının " + day + ".gününde doğmuşsun."
console.log(result);

