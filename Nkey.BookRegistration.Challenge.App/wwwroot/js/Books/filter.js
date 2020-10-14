$(function () {
    $('#submit').on('click', function (evt) {
        evt.preventDefault();
        var bookObject = {
            code: parseInt($("#code").val()),
            name: $("#name").val(),
            author: $("#author").val(),
            isbn: $("#isbn").val(),
            releaseYear: parseInt($("#releaseYear").val())
        };
        $.ajax({
            async: true,
            type: "POST",
            url: "http://localhost:5000/books/filter",
            data: JSON.stringify(bookObject),
            contentType: "application/json; charset=utf-8",
            dataType: "JSON",
            complete: function (response) {
                switch (response.status) {
                case 200:
                    $("#entryPoint").html(setDataTable(response.responseJSON));
                    toastr.success("Registro filtrados com sucesso.", response.status + " " + response.statusText, { timeOut: 3000, "closeButton": true });
                    break;
                default:
                    toastr.info(response.responseJSON, response.status + " " + response.statusText, { timeOut: 3000, "closeButton": true });
                }
            }
        });
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