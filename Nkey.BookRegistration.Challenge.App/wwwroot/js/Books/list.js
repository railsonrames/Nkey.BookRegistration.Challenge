$(document).ready(function () {
        $.ajax({
            type: "GET",
            url: "http://localhost:5000/books",
            success: function (data) {
                $("#entryPoint").html(setDataTable(data));
            }
    });
});

function setDataTable(dataReceived) {
    var html = '<table class="table"><thead><tr><th>Code</th><th>Title</th><th>Author</th><th>ISBN</th><th>Release Year</th><th style="width: 15%"><th></tr></thead><tbody>';
    $.each(dataReceived, function (innerCounter, dataItem) {
        html += `<tr><td>${dataItem.code}</td><td>${dataItem.name}</td><td>${dataItem.author}</td><td>${dataItem.isbn}</td><td>${dataItem.releaseYear}</td><td><a class="btn btn-warning" href="/Books/Edit/${dataItem.id}">Edit</a>&nbsp;<a class="btn btn-danger" href="/Books/Delete/${dataItem.id}">Delete</a></td></tr>`;
    });
    html += '</tbody></table>';
    return html;
};
