$(document).ready(function () {
    //set stuff up
    $(".toggleDiv").hide();

    /////////make collapsing bullets/////////////////////////
    $(function () {
        $("a.toggle").click(function (e) {

            $(this).next().toggle();
            e.preventDefault();
        });
    });
    ///////////////temp construction messages - remove after implmentation////////////
    ///////////////remove when feature is completed ///////////////////////////////////
    $("#txtSearch2").keypress(function () {
        $('#myModal').modal('show');
    });
    $("#bd").click(function () {
        $('#myModal').modal('show');
    });
    $("#awtl").click(function () {
        $('#myModel').modal('show');
    });
    $("#cpp").click(function () {
        $('#myModal').modal('show');
    });
    $("#du").click(function () {
        $('#myModal').modal('show');
    });
    $("#eui").click(function () {
        $('#myModal').modal('show');
    });
    $("#vun").click(function () {
        $('#myModal').modal('show');
    });
    ///////////////// temp messages//////////////////////////////////////////////////

    // get with parameter
    $("#txtSearch").keypress(function () {
        $.ajax({
            url: "/TimeLogs/GetAssociateLogEntries",
            data: { prefix: $('#txtSearch').val() },
            type: "GET",
            dataType: "json",
            success: function (data) {
                loadData(data);
            },
            error: function () {
                alert("failed! Please try again.");
            }
        });
    });
    function loadData(data) {
        // build and formated table
        console.log(data);
        var tab = $('<table class="table"></table>');
        var thead = $('<thead></thead>');
        thead.append('<th>Associate Name</th>');
        thead.append('<th>Work Date   </th>');
        thead.append('<th>Hours</th>');
        tab.append(thead);
        //filter
        if ($("input[name=TF1]:checked").val() == "All") {
            //show all entries
            $.each(data, function (i, val) {
                // Append records into database data here
                var trow = $('<tr></tr>');
                trow.append('<td>' + val.AssociateName + '</td>');
                trow.append('<td>' + convertDate(val.WorkDate) + '</td>');
                trow.append('<td>' + val.NumberHours + '</td>');
                tab.append(trow);
            });
            $("tr:odd", tab).css('background-color', '#FFFAFA');
            $("#UpdatePanel1").html(tab);
        } else {
            //show only current pay period
            var periodTotal = 0;

            $.each(data, function (i, val) {
                // Append records into database data here if in date range
                // do not write them to screen if they are out of range
                var trow = $('<tr></tr>');
                if (isDateInPeriod(val.WorkDate)) {

                    trow.append('<td>' + val.AssociateName + '</td>');
                    trow.append('<td>' + convertDate(val.WorkDate) + '</td>');
                    trow.append('<td>' + val.NumberHours + '</td>');
                   
                    periodTotal += parseInt(val.NumberHours);

                    tab.append(trow);
                }
            });
            $("tr:odd", tab).css('background-color', '#FFFAFA');
            $("#UpdatePanel1").html(tab);
            $("#Totals").text("Current displayed total hours: " + periodTotal);
        }
    };
});
function convertDate(_date) {
    //a messy way to get a pretty date back.
    var re = /-?\d+/;
    var m = re.exec(_date);
    var d = new Date(parseInt(m[0]));
    return (d.getMonth() + 1) + "/" + d.getDate() + "/" + d.getFullYear();
}
function isDateInPeriod(_inputDate) {

    //convert input date to usable form
    var re = /-?\d+/;
    var m = re.exec(_inputDate);
    var inputDay = new Date(parseInt(m[0]));

    var today = new Date();
    var delta = today.getDay() + 1;

    var startDay = new Date();
    var endDay = new Date();
    //find the start day
    startDay.setDate(today.getDate() - delta);
    //find the end day
    endDay.setDate(startDay.getDate() + 7);

    //test and return boolean
    if (inputDay >= startDay && inputDay <= endDay) { return true; }
    else { return false; }
}