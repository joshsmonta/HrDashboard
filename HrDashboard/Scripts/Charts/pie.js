$(document).ready(function() {
    var ctx1 = $("#pieChart1");
    var ctx2 = $("#pieChart2");
    var ctx3 = $("#pieChart3");

    var data1 = {
        labels: ["FAMS", "CAD", "Logistics", "Sales Ops", "Canaan Farm"],
        datasets: [
            {
                label: "Divisions",
                data : [10, 50, 25, 70, 40],
                backgroundColor: [
                    '#00c0ef',
                    '#f39c12',
                    '#f56954',
                    '#00a65a',
                    '#3c8dbc'
                ],
                borderColor: [
                    '#00c0ef',
                    '#f39c12',
                    '#f56954',
                    '#00a65a',
                    '#3c8dbc'
                ],
                borderWidth: [1, 1, 1, 1, 1]
            }
        ]
    };

    var data2 = {
        labels: ["Occupied", "Vacant", "Inactive"],
        datasets: [
            {
                label: "Positions",
                data: [10, 50, 25],
                backgroundColor: [
                    '#00c0ef',
                    '#f39c12',
                    '#f56954'
                ],
                borderColor: [
                    '#00c0ef',
                    '#f39c12',
                    '#f56954'
                ],
                borderWidth: [1, 1, 1]
            }
        ]
    };

    var data3 = {
        labels: ["Sonic One", "Sonic Two", "Sonic Three", "UFS", "Selecta", "Goodyear", "Komeya", "Canaan", "Shared"],
        datasets: [
            {
                label: "Business Units",
                data: [50, 20, 60, 80, 25, 62, 45, 62, 40],
                backgroundColor: [
                    '#00c0ef',
                    '#f39c12',
                    '#f56954',
                    '#00a65a',
                    '#3c8dbc',
                    '#81D8D0',
                    '#8A2BE2',
                    '#FF6666',
                    '#FFC0CB'
                ],
                borderColor: [
                    '#00c0ef',
                    '#f39c12',
                    '#f56954',
                    '#00a65a',
                    '#3c8dbc',
                    '#81D8D0',
                    '#8A2BE2',
                    '#FF6666',
                    '#FFC0CB'
                ],
                borderWidth: [1, 1, 1, 1, 1, 1, 1, 1, 1]
            }
        ]
    };

    var optChart = {
        legend: {
            display: true,
            position: "bottom"
        }
    };

    var chart1 = new Chart(ctx1, {
        type: "doughnut",
        data: data1,
        options: optChart
    });

    var chart2 = new Chart(ctx2, {
        type: "doughnut",
        data: data2,
        options: optChart
    });

    var chart3 = new Chart(ctx3, {
        type: "doughnut",
        data: data3,
        options: optChart
    });
});