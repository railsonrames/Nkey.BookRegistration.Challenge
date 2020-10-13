$.fn.serializeObject = function () {
    var o = {};
    var a = this.serializeArray();
    $.each(a, function () {
        if (o[this.name]) {
            if (!o[this.name].push) {
                o[this.name] = [o[this.name]];
            }
            o[this.name].push(this.value || '');
        } else {
            o[this.name] = this.value || '';
        }
    });
    return o;
};

$(function () {
    $('#submit').on('click', function (evt) {
        console.info("{book: " + JSON.stringify($("form").serializeObject()) + "}");
        var testeJson = {
            "Id": "554b5465-3e76-4611-8886-18a8ca87b008",
            "Code": 8,
            "Name": "As Flores do Cerrado",
            "Author": "Arduíno Bonifácio",
            "Isbn": "821-0902-219-20211-3",
            "ReleaseYear": "2019"
        };
        evt.preventDefault();
        $.ajax({
            type: "POST",
            url: "http://localhost:5000/books/save",
            data: "{book: " + JSON.stringify($("form").serializeObject()) + "}",
            contentType: "application/json",
            dataType: "json",
            success: function (data) {
                $("#entryPoint").html("<h2>Novo livro incluído com sucesso.</h2>");
            }
        });
    });
});

//$("#submit").click(function () {
//    var options = {};
//    options.url = "http://localhost:5000/books";
//    options.type = "POST";

//    var obj = {};
//    obj.customerID = $("#newcustomerid").val();
//    obj.companyName = $("#companyname").val();
//    obj.contactName = $("#contactname").val();
//    obj.country = $("#country").val();

//    options.data = JSON.stringify(obj);
//    options.contentType = "application/json";
//    options.dataType = "json";

//    options.beforeSend = function (xhr) {
//        xhr.setRequestHeader("MY-XSRF-TOKEN",
//            $('input:hidden[name="__RequestVerificationToken"]').val());
//    };
//    options.success = function (msg) {
//        $("#msg").html(msg);
//    };
//    options.error = function () {
//        $("#msg").html("Error while making Ajax call!");
//    };
//    $.ajax(options);
//});