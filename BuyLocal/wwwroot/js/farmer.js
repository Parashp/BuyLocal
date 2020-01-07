"use strict";

var connectionFarmerHub = new signalR.HubConnectionBuilder().withUrl("/farmerhub").build();

connectionFarmerHub.start().then(function () {
    console.log("connected");
}).catch(function (err) {
    return console.error(err.toString());
});



