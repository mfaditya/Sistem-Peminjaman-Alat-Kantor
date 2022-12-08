$(document).ready(function () {
    $("#tableDataItem").DataTable({
        ajax: {
            url: `https://localhost:7095/api/Item`,
            dataSrc: "data",
        },

        columns: [
            {data: "id",},
            {data: "name",},
            {data: "quantity",},
            {data: "categoryId",},
            {
                data: null,
                "render": function (data, type, row, meta) {
                    return `<button type= "button" data-bs-toggle="modal" data-bs-target="#editDataItem" onclick="editItem('${data.id}')" class= "btn btn-primary">Edit</button>
                    <button type= "button" onclick="deleteItem('${data.id}')" class= "btn btn-danger">Hapus</button>`;
                }
            }
        ],
        dom: 'Bfrtip',
        buttons: ['colvis']
    });
});

//Edit Item
function editItem(id) {
    $.ajax({
        url: `https://localhost:7095/api/Item/${id}`,
        type: "GET"
    }).done((res) => {
        let temp = "";
        temp += `
            <input type="hidden" class="form-control" id="hideId" readonly placeholder="" value="0">
            <p>Id: </p><input type="text" class="form-control" id="reqId" placeholder="${res.data.id}" value="${res.data.id}">
            <p>Name Item: </p><input type="text" class="form-control" id="reqname" placeholder="${res.data.name}" value="${res.data.name}">
            <p>Quantity: </p><input type="text" class="form-control" id="reqquantity" placeholder="${res.data.quantity}" value="${res.data.quantity}">
            <p>Category Id: </p><input type="text" class="form-control" id="reqCategory" placeholder="${res.data.categoryId}" value="${res.data.categoryId}">
            <button type= "button" class= "btn-primary" id= "editButton" onclick="saveEditItem('${res.data.id}')">Save Changes</button>
            `;
        $("#editItem").html(temp);
    }).fail((err) => {
        console.log(err);
    });
}

function saveEditItem(id) {
    var Id = id;
    var Name = $('#reqname').val();
    var Quantity = $('#reqquantity').val();
    var CategoryId = $('#reqCategory').val();

    var result = { Id, Name, Quantity, CategoryId };
    $.ajax({
        url: `https://localhost:7095/api/Item`,
        type: "PUT",
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify(result),
        success: function () {
            Swal.fire(
                'Good job!',
                'You clicked the button!',
                'success'
            ); setTimeout(function () {
                location.reload();
            }, 2000);
        },
        error: function () {

        }
    });
}

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
        Swal.fire('Success', 'Item Has Been Added', 'success').then(function () {
            location.reload();
        });
        $('#addNewItem').hide;
        $("#name").val(null);
        $("#quantity").val(null);
        $("#categoryId").val(null);
        $('#tableDataReqItem').DataTable().ajax.reload();

    }).fail((error) => {
        Swal.fire('Error', 'Something Went Wrong', 'error');
    });
}

//function ReturnAnAsset() {
//    var returnAsset = new Object();
//    returnAsset.requestItemId = $('#requestItemId').val();
//    returnAsset.notes = $('#notes').val();
//    console.log(returnAsset);
//    $.ajax({
//        type: "POST",
//        url: 'https://localhost:44395/API/ReturnItems/NewRequest',
//        data: JSON.stringify(returnAsset),
//        contentType: "application/json; charset=utf-8",
//        datatype: "json"
//    }).done((result) => {
//        Swal.fire('Success', 'Item Has Been Returned', 'success');
//        $('#tabledatauserrequestreturn').DataTable().ajax.reload();

//    }).fail((error) => {
//        Swal.fire('Error', 'Something Went Wrong', 'error');
//    });
//}