"use strict";

var connectionProductHub = new signalR.HubConnectionBuilder().withUrl("/producthub").build();

connectionProductHub.on("showmessagetoproductpage", function (message) {
    //show notification
    $.notify(message, { className: 'info', globalPosition: 'right bottom' });
});


connectionProductHub.start().then(function () {
    console.log("connected");
}).catch(function (err) {
    return console.error(err.toString());
});



