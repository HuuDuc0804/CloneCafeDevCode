// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

window.addEventListener('DOMContentLoaded', e => {
    let dataTables = document.getElementsByClassName('datatable-js');
    if (dataTables != null &&
        dataTables != undefined) {
        for (var dataTable of dataTables) {
            new simpleDatatables.DataTable(dataTable);
        }
    }
})
