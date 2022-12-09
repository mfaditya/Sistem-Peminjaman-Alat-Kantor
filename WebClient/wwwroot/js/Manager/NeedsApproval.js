//function format(d) {
//    // `d` is the original data object for the row
//    return '<table cellpadding="5" cellspacing="0" border="0" style="padding-left:50px;">' +
//        '<tr>' +
//        '<td>Request Id:</td>' +
//        '<td>' + d.id + '</td>' +
//        '</tr>' +
//        '<tr>' +
//        '<td>Employee' + "'s" + ' Id:</td>' +
//        '<td>' + d.accountId + '</td>' +
//        '</tr>' +
//        '<tr>' +
//        '<td>Quantity of Requested Item:</td>' +
//        '<td>' + d.quantity + ' items</td>' +
//        '</tr>' +
//        '<tr>' +
//        '<td>Notes for the Request:</td>' +
//        '<td>' + d.notes + '</td>' +
//        '</tr>' +
//        '</table>';
//}

$(document).ready(function () {
    $('#tableDataList').DataTable({
        ajax: {
            url: `https://localhost:7095/api/RequestItem/UserRequest`,
            datatype: "json",
            dataSrc: "",
        },

        columns: [
            //{
            //    'className': 'details-control',
            //    'orderable': false,
            //    'data': null,
            //    'defaultContent': ''
            //},
            { data: 'id' },
            { data: 'userId' },
            { data: 'item' },
            { data: 'startDate' },
            { data: 'endDate' },
            { data: 'quantity' },
            { data: 'notes' },
            { data: 'status' },
            {
                data: null,
                "render": function (data, type, row, meta) {
                    return `<button type= "button" data-bs-toggle="modal" data-bs-target="#needsApproval" onclick="NeedsApproval('${data.id}')" class= "btn btn-primary">Approval Check</button>`
                }
            },
        ],
        dom: 'Bfrtip',
        buttons: ['colvis']
    });

    //$('#tableDataListReq tbody').on('click', 'td.details-control', function () {
    //    var tr = $(this).closest('tr');
    //    var row = statusWaiting.row(tr);

    //    if (row.child.isShown()) {
    //        row.child.hide();
    //        tr.removeClass('shown');
    //    }
    //    else {
    //        row.child(format(row.data())).show();
    //        tr.addClass('shown');
    //    }
    //});

    //statusWaiting.on('order.dt search.dt', function () {
    //    statusWaiting.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
    //        cell.innerHTML = i + 1;
    //    });
    //}).draw();
});

function NeedsApproval(id) {
    $.ajax({
        url: `https://localhost:7095/api/RequestItem/${id}`,
        type: "GET"
    }).done((res) => {
        let temp = "";
        temp += `
            <input type="hidden" class="form-control" id="hideId" readonly placeholder="" value="0">
            <p>Id: </p><input type="text" class="form-control" id="reqId" placeholder="${res.data.id}" value="${res.data.id}" readonly>
            <p>User Id: </p><input type="text" class="form-control" id="reqUserId" placeholder="${res.data.userId}" value="${res.data.userId}" readonly>
            <p>Item Id: </p><input type="text" class="form-control" id="reqItemId" placeholder="${res.data.itemId}" value="${res.data.itemId}" readonly>
            <p>Start Date: </p><input type="text" class="form-control" id="startDate" placeholder="${res.data.startDate}" value="${res.data.startDate}" readonly>
            <p>End Date: </p><input type="text" class="form-control" id="endDate" placeholder="${res.data.endDate}" value="${res.data.endDate}" readonly>
            <p>Quantity: </p><input type="text" class="form-control" id="reqQuantity" placeholder="${res.data.quantity}" value="${res.data.quantity}" readonly>
            <p>Notes: </p><input type="text" class="form-control" id="reqNotes" placeholder="${res.data.notes}" value="${res.data.notes}" readonly>
            <p>Status Id: </p><input type="text" class="form-control" id="reqStatus" placeholder="${res.data.statusId}" value="${res.data.statusId}">
            <button type= "button" class= "btn-success" id= "editButton" onclick="Approve('${res.data.id}')">Approve</button>
            <button type= "button" class= "btn-danger" id= "editButton" onclick="Reject('${res.data.id}')">Reject</button>
            `;
        $("#editApproval").html(temp);
    }).fail((err) => {
        console.log(err);
    });
}

function Approve(id) {
    var Id = id;
    var UserId = $('#reqUserId').val();
    var ItemId = $('#reqItemId').val();
    var StartDate = $('#startDate').val();
    var EndDate = $('#endDate').val();
    var Quantity = $('#reqQuantity').val();
    var Notes = $('#reqNotes').val();
    var StatusId = 4

    var result = { Id, UserId, ItemId, StartDate, EndDate, Quantity, Notes, StatusId };
    $.ajax({
        url: `https://localhost:7095/api/Status/Approve`,
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

function Reject(id) {
    var Id = id;
    var UserId = $('#reqUserId').val();
    var ItemId = $('#reqItemId').val();
    var StartDate = $('#startDate').val();
    var EndDate = $('#endDate').val();
    var Quantity = $('#reqQuantity').val();
    var Notes = $('#reqNotes').val();
    var StatusId = 1

    var result = { Id, UserId, ItemId, StartDate, EndDate, Quantity, Notes, StatusId };
    $.ajax({
        url: `https://localhost:7095/api/Status/Reject`,
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

//$("#tableDataListReq").on('click', '#btnNeedsApproval', function () {
//    var data = $("#tableDataListReq").DataTable().row($(this).parents('tr')).data();
//    console.log(data);
//    $('#userId_emp').val(data.userId);
//    $('#name_emp').val(data.name);
//    $('#req_id').val(data.id);
//    $('#item_name').val(data.item);
//    $('#req_date').val(moment(data.startDate).format('DD-MM-YYYY') + " to " + moment(data.endDate).format('DD-MM-YYYY'));
//    $('#req_quantity').val(data.quantity);
//    $('#req_notes').val(data.notes);
//    $('#startDateE').val(data.startDate.slice(0, 10));
//    $('#endDateE').val(data.endDate.slice(0, 10));
//    $("#needsApproval").modal("show");
//    $("#needsApproval").on('click', '#btnNeedsApprovalClose', function () {
//        $("#needsApproval").modal("hide");
//    })
//    $("#needsApproval").on('click', '#btnApproveReq', function () {
//        $("#needsApproval").modal("hide");
//        Swal.fire({
//            title: 'You will approve the request?',
//            text: "You won't be able to revert this!",
//            icon: 'warning',
//            showCancelButton: true,
//            confirmButtonColor: '#27e65a',
//            cancelButtonColor: '#d33',
//            confirmButtonText: 'Yes, Approve it!'
//        }).then((result) => {
//            if (result.isConfirmed) {
//                var obj = new Object();
//                obj.Id = data.id;
//                obj.AccountId = data.accountId;
//                obj.ItemId = data.itemId;
//                obj.StartDate = data.startDate.slice(0, 10);
//                obj.EndDate = data.endDate.slice(0, 10);
//                obj.Quantity = data.quantity;
//                obj.Notes = data.notes;
//                $.ajax({
//                    type: "PUT",
//                    url: "https://localhost:7095/api/Status/Approve",
//                    data: JSON.stringify(obj),
//                    contentType: "application/json; charset=utf-8",
//                    datatype: "json"
//                }).done((success) => {
//                    Swal.fire(
//                        'Approved!',
//                        'The Request has been Approved.',
//                        'success'
//                    );
//                    $("#tableDataListReq").DataTable().ajax.reload();

//                }).fail((notsuccess) => {
//                    Swal.fire(
//                        'Error!',
//                        'Data failed to approve !',
//                        'error'
//                    );
//                });
//            }
//        });
//    })
//    $("#needsApproval").on('click', '#btnRejectReq', function () {
//        $("#needsApproval").modal("hide");
//        Swal.fire({
//            title: 'You will reject the request?',
//            text: "You won't be able to revert this!",
//            icon: 'warning',
//            showCancelButton: true,
//            confirmButtonColor: '#3085d6',
//            cancelButtonColor: '#d33',
//            confirmButtonText: 'Yes, Reject it!'
//        }).then((result) => {
//            if (result.isConfirmed) {
//                var obj = new Object();
//                obj.Id = data.id;
//                obj.AccountId = data.accountId;
//                obj.ItemId = data.itemId;
//                obj.StartDate = data.startDate.slice(0, 10);
//                obj.EndDate = data.endDate.slice(0, 10);
//                obj.Quantity = data.quantity;
//                obj.Notes = data.notes;
//                $.ajax({
//                    type: "PUT",
//                    url: "https://localhost:7095/api/Status/Reject",
//                    data: JSON.stringify(obj),
//                    contentType: "application/json; charset=utf-8",
//                    datatype: "json"
//                }).done((success) => {
//                    Swal.fire(
//                        'Rejected!',
//                        'The Request has been Rejected.',
//                        'success'
//                    );
//                    $("#tableDataListReq").DataTable().ajax.reload();

//                }).fail((notsuccess) => {
//                    Swal.fire(
//                        'Error!',
//                        'Data failed to reject !',
//                        'error'
//                    );
//                });
//            }
//        });
//    })

//})