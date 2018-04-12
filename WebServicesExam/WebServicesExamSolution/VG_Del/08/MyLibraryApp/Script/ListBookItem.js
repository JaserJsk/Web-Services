var uri = 'api/books';

$(document).ready(function () {
    $.getJSON(uri)
        .done(function (data) {
            $.each(data, function (key, item) {
                $('<li>', { text: formatItem(item) }).appendTo($('#books'));
            });
        });
});

function formatItem(item) {
    return 'Author: ' + item.Author + 'Title: ' + item.Title + ': ISBN: ' + item.ISBN;
}