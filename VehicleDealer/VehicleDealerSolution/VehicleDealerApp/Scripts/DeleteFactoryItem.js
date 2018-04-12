var uri = '/api/factories/';

function deleteItem()
{
    //debugger;

    var id = $('#deleteById').val();

    $.ajax(
        {
            url: uri + id,
            method: 'DELETE',
            success: function (data)
            {
                $('#delete-factory').text('Factory Deleted');
            }
        })
        .fail(function (jqXHR, textStatus, err)
        {
            $('#delete-factory').text('Error: ' + err);
        });
}