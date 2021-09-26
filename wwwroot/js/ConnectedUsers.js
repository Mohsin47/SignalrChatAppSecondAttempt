$("#show-all-connections").on("click", function () {
    debugger;

    var connection = new signalR.HubConnectionBuilder().withUrl("/connectionHub").build();


    connection.GetAllActiveConnections().done(function (connections) {
        $.map(connections, function (item) {
            $("#user-list").append("<li>Connection ID : " + item + "</li>");
        });
    });
    //chatHub.server.getAllActiveConnections().done(function (connections) {
    //    $.map(connections, function (item) {
    //        $("#user-list").append("<li>Connection ID : " + item + "</li>");
    //    });
    //});
});