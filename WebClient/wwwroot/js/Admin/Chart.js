$(document).ready(function () {
    $.ajax({
        url: `https://localhost:7095/api/Item`,
        //headers: {
        //    'Authorization': "Bearer " + sessionStorage.getItem("token")
        //},
    }).done((data) => {
        console.log(data);
        var CategoryId = data.data
            .map(x => ({ categoryId: x.categoryId }));
        var { categoryId1, categoryId2, categoryId3 } = CategoryId.reduce((previous, current) => {
            if (current.categoryId === 1) {     // spread operator
                // spread untuk memecah array-nya 
                return { ...previous, categoryId1: previous.categoryId1 + 1 }
            }
            //console.log(previous, "ytt+otak");
            if (current.categoryId === 2) {
                return { ...previous, categoryId2: previous.categoryId2 + 1 }
            }
            if (current.categoryId === 3) {
                return { ...previous, categoryId3: previous.categoryId3 + 1 }
            }
        }, { categoryId1: 0, categoryId2: 0, categoryId3: 0 })

        var options = {
            series: [categoryId1, categoryId2, categoryId3],
            chart: {
                width: 350,
                height: '170%',
                type: 'pie',
            },
            labels: ['1: Electronic', '2: Vehicle', '3: Furniture'],
            responsive: [{
                breakpoint: 450,
                options: {
                    chart: {
                        width: 350
                    },
                    legend: {
                        show: true,
                        position: 'right',
                    }
                }
            }]
        };

        var options2 = {
            series: [{
                data: [categoryId1, categoryId2, categoryId3],
            }],
            chart: {
                height: 250,
                type: 'bar',
                events: {
                    click: function (chart, w, e) {
                        // console.log(chart, w, e)
                    }
                }
            },
            plotOptions: {
                bar: {
                    columnWidth: '45%',
                    distributed: true,
                }
            },
            dataLabels: {
                enabled: false
            },
            legend: {
                show: false
            },
            xaxis: {
                categories: [
                    ['Electronic'],
                    ['Vehicle'],
                    ['Furniture'],
                ],
                labels: {
                    style: {
                        fontSize: '12px'
                    }
                }
            }
        };

        var chartPie = new ApexCharts(document.querySelector("#pieChart"), options);
        chartPie.render();
        var chartBar = new ApexCharts(document.querySelector("#barChart"), options2);
        chartBar.render();
    });
});