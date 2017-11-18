import Model = require("Sub/Model");

var person = new Model.Person();
person.FirstName = "Andreas";
person.LastName = "Savva";
console.log(person.FirstName);
console.log(person.LastName);

$("#id").html("apple");