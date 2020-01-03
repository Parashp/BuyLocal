"use strict";

var connectionActivityHub = new signalR.HubConnectionBuilder().withUrl("/activityhub").build();



connectionActivityHub.start().then(function () {
    console.log("connected");
}).catch(function (err) {
    return console.error(err.toString());
});



    