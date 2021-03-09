//"use strict";

var connection = new signalR.HubConnectionBuilder()
    .withUrl("/chatHub").build();// Carga a la Clase del HUb

//Deshabilita el boton send hasta q se establece la coneccion
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg = user + " dice: " + msg;
    var li = document.createElement("li");
    li.textContent = encodedMsg;
    document.getElementById("messagesList").appendChild(li);
    messageInput = "";
});

connection.start().then(function () {// Hace la coneccion a C# al Hub
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {// cuando envia  el mensaje llama la funcion en c# de  SendMessage en la clase chatHub
        return console.error(err.toString());
    });
    event.preventDefault();
});