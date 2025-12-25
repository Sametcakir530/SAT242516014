/**
 * Chart.js Grafik Yönetim Merkezi
 * Tüm grafik nesnelerini tek bir merkezden yöneterek bellek sızıntısını önler.
 */
const allCharts = {};

/**
 * Mevcut bir grafiği yok eder.
 * @param {string} chartid - Canvas elementinin ID'si
 */
const destroyExistingChart = (chartid) => {
    if (allCharts[chartid]) {
        allCharts[chartid].destroy();
        delete allCharts[chartid];
    }
};

/////////////////////////////// BarChart //////////////////////////////////
window.drawBarChart = (chartid, labels, seriesList, responsive, animation, indexAxis) => {
    const canvas = document.getElementById(chartid);
    if (!canvas) return;
    const ctx = canvas.getContext('2d');

    destroyExistingChart(chartid);

    const datasets = seriesList.map(series => ({
        label: series.label,
        data: series.data,
        backgroundColor: series.backgroundColor,
        borderColor: series.borderColor,
        borderWidth: series.borderWidth || 1
    }));

    allCharts[chartid] = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: labels,
            datasets: datasets
        },
        options: {
            animation: animation ?? true,
            responsive: responsive ?? true,
            maintainAspectRatio: false,
            indexAxis: indexAxis || 'x',
            scales: {
                x: { beginAtZero: true },
                y: { beginAtZero: true }
            },
            plugins: {
                legend: { position: 'bottom' },
                datalabels: {
                    anchor: 'center',
                    align: 'center',
                    formatter: Math.round,
                    font: { weight: 'bold' }
                }
            }
        },
        plugins: [ChartDataLabels],
    });
};

/////////////////////////////// LineChart //////////////////////////////////
window.drawLineChart = (chartid, labels, seriesList, responsive, animation, fill, tension) => {
    const canvas = document.getElementById(chartid);
    if (!canvas) return;
    const ctx = canvas.getContext('2d');

    destroyExistingChart(chartid);

    const datasets = seriesList.map(series => ({
        label: series.label,
        data: series.data,
        backgroundColor: series.backgroundColor,
        borderColor: series.borderColor,
        borderWidth: series.borderWidth || 1,
        fill: series.fill || fill || false,
        tension: series.tension || tension || 0.2,
    }));

    allCharts[chartid] = new Chart(ctx, {
        type: 'line',
        data: {
            labels: labels,
            datasets: datasets
        },
        options: {
            animation: animation ?? true,
            responsive: responsive ?? true,
            maintainAspectRatio: false,
            scales: {
                y: { beginAtZero: true }
            },
            plugins: {
                legend: { position: 'bottom' },
                datalabels: {
                    anchor: 'end',
                    align: 'top',
                    formatter: Math.round,
                    font: { weight: 'bold' }
                }
            }
        },
        plugins: [ChartDataLabels]
    });
};

/////////////////////////////// PieChart //////////////////////////////////
window.drawPieChart = (chartid, labels, seriesList) => {
    const canvas = document.getElementById(chartid);
    if (!canvas) return;
    const ctx = canvas.getContext('2d');

    destroyExistingChart(chartid);

    const datasets = seriesList.map(series => ({
        label: series.label,
        data: series.data,
        backgroundColor: series.backgroundColor, // Pasta grafiğinde genellikle bir dizi (array) gelir
        borderColor: series.borderColor || '#ffffff',
        borderWidth: series.borderWidth || 2
    }));

    allCharts[chartid] = new Chart(ctx, {
        type: 'pie',
        data: {
            labels: labels,
            datasets: datasets
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            plugins: {
                legend: { position: 'bottom' },
                datalabels: {
                    color: '#ffffff',
                    font: { weight: 'bold', size: 12 },
                    formatter: (value, ctx) => {
                        let sum = 0;
                        let dataArr = ctx.chart.data.datasets[0].data;
                        dataArr.map(data => { sum += data; });
                        let percentage = (value * 100 / sum).toFixed(1) + "%";
                        return percentage;
                    }
                }
            }
        },
        plugins: [ChartDataLabels]
    });
};