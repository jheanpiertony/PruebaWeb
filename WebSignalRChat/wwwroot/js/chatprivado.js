//"use strict";

var connection = new signalR.HubConnectionBuilder()
    .withUrl("/chatHub").build();// Carga a la Clase del HUb

var urlParams = new URLSearchParams(window.location.search);
//const gruop = urlParams.get('group') || "Chat_Home";

//Deshabilita el boton send hasta q se establece la coneccion
document.getElementById("sendButtonPrivado").disabled = true;

connection.on("SendMessage", function (user, message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg = user + " dice: " + msg;
    var li = document.createElement("li");
    li.textContent = encodedMsg;
    li.style.color = "red";
    document.getElementById("messagesList").appendChild(li);
    messageInput = "";
});

connection.start().then(function () {// Hace la coneccion a C# al Hub
    document.getElementById("sendButtonPrivado").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});
document.getElementById("sendButtonPrivado").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    var destinoId = document.getElementById("miDropDownList").value;
    connection.invoke("SendMessagePrivado", user, message, destinoId).catch(function (err) {// cuando envia  el mensaje llama la funcion en c# de  SendMessage en la clase chatHub
        return console.error(err.toString());
    });
    event.preventDefault();
});