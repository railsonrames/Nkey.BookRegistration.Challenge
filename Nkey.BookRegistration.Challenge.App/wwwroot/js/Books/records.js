$(document).ready(function () {
    $('#getDataButton').on('click', function () {
        $.ajax({
            type: "GET",
            url: "http://localhost:5000/books",
            sucess: function (data) {
                var result = $.parseJSON(data);
                alert(result);
                var obj = JSON.parse(data);
                for (var i = 0; i < obj.length; i++) {
                    console.log(obj[i]);
                }
                //$("#entryPoint").html(setDataTable(data));
            }
        });
    });
});

function setDataTable(dataReceived) {
    var html = '<table class="table"><thead><tr><th>Code</th><th>Title</th><th>Author</th><th>ISBN</th><th>Release Year</th></tr></thead><tbody>';
    $.each(dataReceived, function (innerCounter, dataItem) {
        html += `<tr><td>${dataItem.code}</td><td>${dataItem.name}</td><td>${dataItem.author}</td><td>${dataItem.isbn}</td><td>${dataItem.releaseYear}</td></tr>`;
    });
    html += '</tbody></table>';
    return html;
};
