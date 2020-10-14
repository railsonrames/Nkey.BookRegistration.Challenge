$(document).ready(function () {
    var fullUri = window.location.href;
    var bookId = fullUri.substring(fullUri.lastIndexOf("/")+1);
    $.ajax({
        type: "GET",
        url: "http://localhost:5000/books/" + bookId,
        success: function(data) {
            $("#code").val(data.code);
            $("#name").val(data.name);
            $("#author").val(data.author);
            $("#isbn").val(data.isbn);
            $("#releaseYear").val(data.releaseYear);
        }
    });
});