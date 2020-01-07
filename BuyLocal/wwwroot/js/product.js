"use strict";

var connectionProductHub = new signalR.HubConnectionBuilder().withUrl("/producthub?ProductID=" + productId).build();

connectionProductHub.start().then(function () {
    console.log("connected");
}).catch(function (err) {
    return console.error(err.toString());
});



