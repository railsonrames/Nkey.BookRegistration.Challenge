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
        console.info(JSON.stringify(bookObject));
        $.ajax({
            async: true,
            type: "POST",
            url: "http://localhost:5000/books",
            data: JSON.stringify(bookObject),
            contentType: "application/json; charset=utf-8",
            dataType: "JSON",
            complete: function (response) {
                switch (response.status) {
                case 201:
                    toastr.success(response.responseJSON, response.status + " " + response.statusText, { timeOut: 3000, "closeButton": true });
                    break;
                case 400:
                    toastr.error(response.responseJSON, response.status + " " + response.statusText, { timeOut: 3000, "closeButton": true });
                    break;
                default:
                    toastr.info(response.responseJSON, response.status + " " + response.statusText, { timeOut: 3000, "closeButton": true });
                }
            }
        });
    });
});