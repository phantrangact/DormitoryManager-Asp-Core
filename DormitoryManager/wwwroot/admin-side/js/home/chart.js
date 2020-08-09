let ChartTrans = function () {
    let _ChartTrans = function () {
        var lineData = {
            labels: ["January", "February", "March", "April", "May", "June", "July"],
            datasets: [
                {
                    label: "VNĐ",
                    backgroundColor: "rgba(26,179,148,0.5)",
                    borderColor: "rgba(26,179,148,0.7)",
                    pointBackgroundColor: "rgba(26,179,148,1)",
                    pointBorderColor: "#fff",
                    data: [28, 48, 40, 19, 86, 27, 90]
                }
            ]
        };

        var lineOptions = {
            responsive: true
        };
        var ctx = document.getElementById("lineChart").getContext("2d");
        new Chart(ctx, { type: 'line', data: lineData, options: lineOptions });
    };
    return {
        init: () => {
            _ChartTrans();
        }
    }
}();
document.addEventListener('DOMContentLoaded', function () {
    ChartTrans.init();
})
