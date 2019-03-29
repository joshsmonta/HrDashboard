$(document).ready(function() {
    var ctx1 = $("#pieChart1");
    var ctx2 = $("#pieChart2");
    var ctx3 = $("#pieChart3");
    var optChart = {
        legend: {
            display: true,
            position: "left",
            animationEasing: 'easeInOutQuart'
        }
    };
    function GetAllEmpsByBu() {
        var labelArray = [];
        var dataArray = [];
        $.ajax({
            type: "GET",
            url: "/api/position/countallbybu",
            dataType: "json"
        }).done(function (data) {
            for (var i = 0; i < data.length; i++) {
                if (data[i].units == "Sonic One") {
                    labelArray.push(data[i].units);
                    dataArray.push(data[i].count);
                }
                else if (data[i].units == "Sonic Two") {
                    labelArray.push(data[i].units);
                    dataArray.push(data[i].count);
                }
                else if (data[i].units == "Sonic Three") {
                    labelArray.push(data[i].units);
                    dataArray.push(data[i].count);
                }
                else if (data[i].units == "UFS") {
                    labelArray.push(data[i].units);
                    dataArray.push(data[i].count);
                }
                else if (data[i].units == "Selecta") {
                    labelArray.push(data[i].units);
                    dataArray.push(data[i].count);
                }
                else if (data[i].units == "Goodyear") {
                    labelArray.push(data[i].units);
                    dataArray.push(data[i].count);
                }
                else if (data[i].units == "Komeya") {
                    labelArray.push(data[i].units);
                    dataArray.push(data[i].count);
                }
                else if (data[i].units == "Canaan") {
                    labelArray.push(data[i].units);
                    dataArray.push(data[i].count);
                }
                else if (data[i].units == "Shared") {
                    labelArray.push(data[i].units);
                    dataArray.push(data[i].count);
                }
            }
            var data3 = {
                labels: labelArray,
                datasets: [{
                    label: "Business Units",
                    data: dataArray,
                    backgroundColor: [
                        '#ff4000',
                        '#ffbf00',
                        '#ffff00',
                        '#80ff00',
                        '#00ffbf',
                        '#00bfff',
                        '#0040ff',
                        '#bf00ff',
                        '#ff0040'
                    ]
                }]
            }
            new Chart(ctx3, {
                type: "doughnut",
                data: data3,
                options: optChart
            });
        });
    }
    function GetAllPositionStatus() {
        var labelArray = [];
        var dataArray = [];
        $.ajax({
            type: "GET",
            url: "/api/position/allstatus",
            dataType: "json"
        }).done(function (data) {
            for (var i = 0; i < data.length; i++) {
                if (data[i].posStatus == "Active") {
                    labelArray.push(data[i].posStatus);
                    dataArray.push(data[i].count);
                }
                else if (data[i].posStatus == "Vacant") {
                    labelArray.push(data[i].posStatus);
                    dataArray.push(data[i].count);
                }
                else if (data[i].posStatus == "Inactive") {
                    labelArray.push(data[i].posStatus);
                    dataArray.push(data[i].count);
                }
            }
            var data2 = {
                labels: labelArray,
                datasets: [
                    {
                        label: "Positions",
                        data: dataArray,
                        backgroundColor: [
                            '#00c0ef',
                            '#f39c12',
                            '#f56954'
                        ]
                    }
                ]
            };
            new Chart(ctx2, {
                type: 'doughnut',
                data: data2,
                options: optChart
            });
            GetAllEmpsByBu();
        });
    }
    function GetDivisionNumbers() {
        var labelArray = [];
        var divCountArray = [];
        $.ajax({
            type: "GET",
            url: "/api/position/allposperdiv",
            dataType: "json"
        }).done(function (data) {
            for (var i = 0; i < data.length; i++) {
                if (data[i].divIds == 1) {
                    var famsCount = data[i].count;
                    divCountArray.push(famsCount);
                    labelArray.push("FAMS");
                }
                else if (data[i].divIds == 2) {
                    var cadCount = data[i].count;
                    divCountArray.push(cadCount);
                    labelArray.push("CAD");
                }
                else if (data[i].divIds == 3) {
                    var logCount = data[i].count;
                    divCountArray.push(logCount);
                    labelArray.push("Logistics");
                }
                else if (data[i].divIds == 4) {
                    var salesCount = data[i].count;
                    divCountArray.push(salesCount);
                    labelArray.push("Sales Ops");
                }
                else if (data[i].divIds == 5) {
                    var canaanCount = data[i].count;
                    divCountArray.push(canaanCount);
                    labelArray.push("Canaan Farm");
                }
            }
            var data1 = {
                labels: labelArray,
                datasets: [
                    {
                        label: "Divisions",
                        data : divCountArray,
                        backgroundColor: [
                            '#00c0ef',
                            '#f39c12',
                            '#f56954',
                            '#00a65a',
                            '#3c8dbc'
                        ]
                    }
                ]
            };
            new Chart(ctx1, {
                type: 'doughnut',
                data: data1,
                options: optChart
            });
            GetAllPositionStatus();
        });
    }
    GetDivisionNumbers();
});