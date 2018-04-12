var uri = '/api/factories/';

function findItem()
{
    //debugger;

    var id = $('#findById').val();

    $.getJSON(uri + '/' + id)
        .done(function (data)
        {
            $.each(data, function (key, item)
            {
                $('#find-factory').empty();
                $('#find-factory').append(item.FactoryId + " " + item.FactoryName);
            });
        })
        .fail(function (jqXHR, textStatus, err) {
            $('#find-factory').text('Error: ' + err);
        });
}