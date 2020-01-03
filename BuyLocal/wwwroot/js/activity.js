"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/activityhub").build();



connection.start().then(function () {
    console.log("connected");
}).catch(function (err) {
    return console.error(err.toString());
});



    