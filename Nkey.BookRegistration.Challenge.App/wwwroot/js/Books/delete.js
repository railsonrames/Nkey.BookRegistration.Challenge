$(function () {
    $('#submit').on('click', function (evt) {
        evt.preventDefault();
        var userConfirmation = confirm("Realmente deseja excluir o livro?");
        if (userConfirmation === true) {
            var fullUri = window.location.href;
            var bookId = fullUri.substring(fullUri.lastIndexOf("/") + 1);
            $.ajax({
                type: "DELETE",
                url: "http://localhost:5000/books/" + bookId,
                complete: function(response) {
                    switch (response.status) {
                    case 204:
                        toastr.success("Livro excluído com sucesso.",
                            response.status + " " + response.statusText,
                            { timeOut: 3000, "closeButton": true });
                        //window.location.href = "http://localhost:9000/Books";
                        break;
                    case 404:
                        toastr.error(response.responseJSON,
                            response.status + " " + response.statusText,
                            { timeOut: 3000, "closeButton": true });
                        break;
                    default:
                        toastr.info(response.responseJSON,
                            response.status + " " + response.statusText,
                            { timeOut: 3000, "closeButton": true });
                    }
                }
            });
        } else {
            return false;
        }
    });
});