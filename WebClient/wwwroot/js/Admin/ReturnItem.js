$(document).ready(function () {
    $("#tableDataReturnItem").DataTable({
        ajax: {
            url: `https://localhost:7095/api/ReturnItem`,
            dataSrc: "data",
        },

        columns: [
            {
                data: "id",
            },
            {
                data: "requestItemId",
            },
            {
                data: "notes",
            },
        ],
        dom: 'Bfrtip',
        buttons: ['colvis']
    });
});

//return Item
function ReturnUserItem() {
    var returnAsset = new Object();
    returnAsset.requestItemId = $('#requestItemId').val();
    returnAsset.notes = $('#notes').val();
    console.log(returnAsset);
    $.ajax({
        type: "POST",
        url: 'https://localhost:7095/api/ReturnItem/NewReturn',
        data: JSON.stringify(returnAsset),
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        headers: {
            'Content-Type': 'application/json'
        },
    }).done((result) => {
        Swal.fire('Success', 'Item Has Been Returned', 'success');
        $('#tableDataReturnItem').DataTable().ajax.reload();

    }).fail((error) => {
        Swal.fire('Error', 'Something Went Wrong', 'error');
    });
}

//function AddReturnItem() {
//    var Item = new Object();
//    Item.RequestItemId = $('#id').val();
//    Item.Notes = $('#notes').val();
//    $.ajax({
//        type: "POST",
//        url: 'https://localhost:7095/api/ReturnItem',
//        data: JSON.stringify(Item),
//        contentType: "application/json; charset=utf-8",
//        datatype: "json"
//    }).done((result) => {
//        Swal.fire('Success', 'Item Has Been Added', 'success');
//        $('#addNewItem').hide;
//        $("#id").val(null);
//        $("#notes").val(null);
//        $('#tableDataReturnItem').DataTable().ajax.reload();

//    }).fail((error) => {
//        Swal.fire('Error', 'Something Went Wrong', 'error');
//    });
//}
