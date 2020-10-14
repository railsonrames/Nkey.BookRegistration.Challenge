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
            success: function(response) {
                toastr.success(response.message, 'Success Alert', { timeOut: 3000, "closeButton": true });
            },
            error: function() {
                toastr.error('Alguma treta happened.', 'Error Alert', { timeOut: 3000, "closeButton": true });
            }
        });
    });
});