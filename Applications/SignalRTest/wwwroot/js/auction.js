"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/auction").build();

function outputError(msg) {
    document.getElementById("errorOutput").innerHTML = msg;
}

function updatePrice(price) {
    document.getElementById("currentPriceOutput").innerHTML = price;
    outputError("");
}

connection.start()
    .then(function(){
        document.getElementById("connectMessage").innerHTML = "Welcome to Auction Hub";
    })
    .catch(function(err){
        outputError(err.toString());
    });

connection.on("StartBidding", updatePrice);

connection.on("BidAccepted", updatePrice);

document.getElementById("bidButton").addEventListener("click", function (event) {
    var price = document.getElementById("bidInput").value;
    connection.invoke("AcceptBid", price).catch(function (err) {
        var ex = err.message.indexOf("HubException");
        return outputError(err.message.substring(ex));
    });
    event.preventDefault();
});