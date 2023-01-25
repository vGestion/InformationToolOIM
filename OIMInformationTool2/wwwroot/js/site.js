// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const sidebar = document.querySelector('.sidebar');
const mainContent = document.querySelector('.main-content');
document.querySelector('button').onclick = function () {
    sidebar.classList.toggle('sidebar_small');
    mainContent.classList.toggle('main-content_large')
}

