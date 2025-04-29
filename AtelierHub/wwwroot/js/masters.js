$(document).ready(function () {
    $("#loadMastersBtn").click(function () {
        $.ajax({
            url: "/api/MastersApi", 
            method: "GET",
            success: function (data) {
                let result = "<h3>Masters from API:</h3><ul>";
                data.forEach(function (master) {
                    result += `<li>${master.name} - ${master.specialty}</li>`;
                });
                result += "</ul>";
                $("#mastersApiResult").html(result);
            },
            error: function (xhr, status, error) {
                $("#mastersApiResult").html("<p>Error loading masters: " + error + "</p>");
            }
        });
    });
});