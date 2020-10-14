"use strict";

console.log('starting server');
var connection = new signalR
.HubConnectionBuilder()
.withUrl("/chatHub")
.build();

connection.on('updateReceived',function(msg){
    console.log(msg);
});
connection.start().then(function(){
    alert('connection started.');
});

function placeOrder() {
   connection.invoke("PlaceOrder")
   .catch(function(err){
       console.error(err);
   })
}