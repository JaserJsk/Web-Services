function find() {
    var isbn = $('#bookisbn').val();

    $.getJSON(uri + '/' + isbn)
        .done(function (data) {
            $.each(data, function(key, item) {
                $('#book').empty();
                $('#book').append(item.Author + " " + item.ISBN);
            });
        })
        .fail(function (jqXHR, textStatus, err) {
            $('#book').text('Error: ' + err);
        });
}