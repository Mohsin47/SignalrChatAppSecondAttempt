let onlineCount = document.querySelector('span.online-count');
debugger;
let updateCountCallback = function (message) {
    if (!message) return;
    console.log('updateCount = ' + message);
    if (onlineCount) onlineCount.innerText = message;
};

function onConnectionError(error) {
    if (error && error.message) console.error(error.message);
}

var ConnectionId = null;
debugger;
let countConnection = new signalR.HubConnectionBuilder().withUrl('/onlinecount').build();
debugger;
countConnection.on('updateCount', updateCountCallback,ConnectionId);
countConnection.onclose(onConnectionError);
countConnection.start()
    .then(function () {
        debugger;
        console.log('OnlineCount Connected');
        var a = $("#connectedId").val();
        $("#connectionId").val(a);
        
    })
    .catch(function (error) {
        console.error(error.message);
    });