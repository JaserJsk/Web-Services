var uri = '/api/factories/';

function addItem()
{
    //debugger;

    var obj = {};
    obj.FactoryName = document.getElementById('addFactoryName').value;
    obj.FactoryLocation = document.getElementById('addFactoryLocation').value;

    $.ajax(
        {
            url: uri + '/PostFactory',
            method: 'POST',
            data: obj,
            success: function (data)
            {
                $('#add-factory').text('Factory Added');
            }
        })
        .fail(function (jqXHR, textStatus, err)
        {
            $('#add-factory').text('Error: ' + err);
        });
}