(function (factory) {
    if (typeof module === "object" && typeof module.exports === "object") {
        var v = factory(require, exports);
        if (v !== undefined) module.exports = v;
    }
    else if (typeof define === "function" && define.amd) {
        define(["require", "exports", "Sub/Model"], factory);
    }
})(function (require, exports) {
    "use strict";
    Object.defineProperty(exports, "__esModule", { value: true });
    var Model = require("Sub/Model");
    var person = new Model.Person();
    person.FirstName = "Andreas";
    person.LastName = "Savva";
    console.log(person.FirstName);
    console.log(person.LastName);
});
