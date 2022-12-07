$(document).ready(function () {
    $("#tableDataReqItem").DataTable({
        ajax: {
            url: `https://localhost:7095/api/Item`,
            dataSrc: "data",
        },

        columns: [
            {
                data: "id",
            },
            {
                data: "name",
            },
            {
                data: "quantity",
            },
        ],
        dom: 'Bfrtip',
        buttons: ['colvis', 'copy', 'excel', 'pdf', 'print']
    });
});

// ADD ITEM
function AddNewItem() {
    var Item = new Object();
    Item.name = $('#name').val();
    Item.quantity = $('#quantity').val();
    Item.categoryId = $('#categoryId').val();
    $.ajax({
        type: "POST",
        url: 'https://localhost:7095/api/Item',
        data: JSON.stringify(Item),
        contentType: "application/json; charset=utf-8",
        datatype: "json"
    }).done((result) => {
        Swal.fire('Success', 'Item Has Been Added', 'success');
        $('#addNewItem').hide;
        $("#name").val(null);
        $("#quantity").val(null);
        $("#categoryId").val(null);
        $('#tableDataReqItem').DataTable().ajax.reload();

    }).fail((error) => {
        Swal.fire('Error', 'Something Went Wrong', 'error');
    });
}

function ReturnAnAsset() {
    var returnAsset = new Object();
    returnAsset.requestItemId = $('#requestItemId').val();
    returnAsset.notes = $('#note').val();
    console.log(returnAsset);
    $.ajax({
        type: "POST",
        url: 'https://localhost:44395/API/ReturnItems/NewRequest',
        data: JSON.stringify(returnAsset),
        contentType: "application/json; charset=utf-8",
        datatype: "json"
    }).done((result) => {
        Swal.fire('Success', 'Item Has Been Returned', 'success');
        $('#tabledatauserrequestreturn').DataTable().ajax.reload();

    }).fail((error) => {
        Swal.fire('Error', 'Something Went Wrong', 'error');
    });
}