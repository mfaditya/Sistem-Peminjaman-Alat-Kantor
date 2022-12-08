$(document).ready(function () {
    $("#tableDataItem").DataTable({
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

//card status
$(document).ready(function () {
    $('#tableDataListReq').DataTable({
        ajax: {
            url: `https://localhost:7095/api/RequestItem`,
            type: "GET",
            dataSrc: 'data',
        },

        columns: [
            { data: 'id' },
            { data: 'userId' },
            { data: 'itemId' },
            { data: 'startDate' },
            { data: 'endDate' },
            { data: 'quantity' },
            { data: 'notes' },
            { data: 'statusId' },
        ],
        dom: 'Bfrtip',
        buttons: ['colvis', 'copy', 'excel', 'pdf', 'print']
    });
});

//modal request item
function RequestItem() {
    let data;
    let id = 0;
    let userId = $('#input-akunId').val();
    let item = $(`#input-item`).val();
    let qty = $('#input-quantity').val();
    let startDate = $(`#input-start-date`).val();
    let endDate = $(`#input-end-date`).val();
    let notes = $(`#input-notes`).val();
    let status = 3;


    data = {
        "id": id,
        "userId": userId,
        "itemId": item,
        "quantity": qty,
        "startDate": startDate,
        "endDate": endDate,
        "notes": notes,
        "statusId": status,
    };
    console.log(data);
    Swal.fire({
        title: 'Do you want to save the changes?',
        showDenyButton: true,
        showCancelButton: true,
        confirmButtonText: 'yes, save',
        denyButtonText: `Don't save`,
    }).then((result) => {
        console.log(result)
        if (result.isConfirmed) {
            $.ajax({
                type: "POST",
                url: `https://localhost:7095/api/RequestItem/NewRequest`,
                data: JSON.stringify(data),
                dataType: 'json',
                headers: {
                    'Content-Type': 'application/json'
                },
                success: function () {
                    Swal.fire('Saved!', '', 'success').then(function () {
                        location.reload();
                    })
                },
                error: function (xhr, ajaxOption, theownError) {
                    Swal.fire('error delete');
                }
            });
        }
    });
}