document.write("<script src='signalr.min.js'></script>");

var connection;

function joinAuction(join, receive){
    connection = new signalR.HubConnectionBuilder().withUrl("auction").build();
    connection.start().then(join);
    connection.on("BidAccepted", receive);
    connection.on("BidRejected", receive);
}

function leaveAuction(){
    if(connection){
        connection.stop();
        connection = null;
    }
}

function doBidding(price){
    if(connection)
        connection.invoke("AcceptBid", price);
}
