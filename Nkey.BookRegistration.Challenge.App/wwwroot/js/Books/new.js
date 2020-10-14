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
            type: "POST",
            url: "http://localhost:5000/books",
            data: JSON.stringify(bookObject),
            contentType: "application/json",
            dataType: "json",
            success: formPostCompleted,
        });
    });
});

function formPostCompleted() {
    $("#entryPoint").html("<h2>Novo livro incluído com sucesso.</h2>");
}