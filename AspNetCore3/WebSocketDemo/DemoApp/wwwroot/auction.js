var connection;

function joinAuction(join, receive){
    connection = new WebSocket(`ws://${location.host}/auction`);
    connection.onopen = function(event){
        join();
    };
    connection.onmessage = function(event){
        receive(event.data);
    };
}

function leaveAuction(){
    if(connection){
        connection.close(1000, "Closed by client");
        connection = null;
    }
}

function doBidding(price){
    if(connection)
        connection.send(price);
}
