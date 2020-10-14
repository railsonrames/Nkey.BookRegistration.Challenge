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
            type: "PUT",
            url: "http://localhost:5000/books",
            data: JSON.stringify(bookObject),
            contentType: "application/json; charset=utf-8",
            dataType: "JSON",
            complete: function (response) {
                switch (response.status) {
                case 204:
                        toastr.success("Livro atualizado com sucesso.", response.status + " " + response.statusText, { timeOut: 3000, "closeButton": true });
                        //window.location.href = "http://localhost:9000/Books";
                        break;
                case 404:
                    toastr.error(response.responseJSON, response.status + " " + response.statusText, { timeOut: 3000, "closeButton": true });
                    break;
                default:
                    toastr.info(response.responseJSON, response.status + " " + response.statusText, { timeOut: 3000, "closeButton": true });
                }
            }
        });
    });
});