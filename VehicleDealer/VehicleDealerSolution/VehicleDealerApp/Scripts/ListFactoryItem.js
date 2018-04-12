var uri = 'api/factories';

$(document).ready(function ()
{
    // Send an AJAX request
    $.getJSON(uri)
        .done(function (data)
        {
            // On succcess, 'data' contains a listofproducts.
            $.each(data, function (key, item) {
                // Add a list item for the product.
                $('<li>', { text: formatItem(item) }).appendTo($('#list-factories'));
            });
        });
});

function formatItem(item)
{
    return item.FactoryId + " " + item.FactoryName + " " + item.FactoryLocation;
}