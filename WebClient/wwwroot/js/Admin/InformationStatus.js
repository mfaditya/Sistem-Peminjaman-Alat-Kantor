﻿$(document).ready(function () {
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
            {
                data: null,
                "render": function (data, type, row, meta) {
                    return `<button type= "button" data-bs-toggle="modal" data-bs-target="#needsApproval" onclick="editStatus('${data.id}')" class= "btn btn-primary">Update Status</button>`
                }
            },
        ],
        dom: 'Bfrtip',
        buttons: ['colvis', 'copy', 'excel', 'pdf', 'print']
    });
});

function editStatus(id) {
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
            <p>Status Id: </p><input type="text" class="form-control" id="reqStatus" placeholder="${res.data.statusId}" value="${res.data.statusId}" readonly>
            <button type= "button" class= "btn-primary" id= "editButton" onclick="TakeAnItem('${res.data.id}')">Item Taken</button>
            <button type= "button" class= "btn-primary" id= "editButton" onclick="ReturnItem('${res.data.id}')">Item Return</button>
            `;
        $("#editStatus").html(temp);
    }).fail((err) => {
        console.log(err);
    });
}

function TakeAnItem(id) {
    var Id = id;
    var UserId = $('#reqUserId').val();
    var ItemId = $('#reqItemId').val();
    var StartDate = $('#startDate').val();
    var EndDate = $('#endDate').val();
    var Quantity = $('#reqQuantity').val();
    var Notes = $('#reqNotes').val();
    var StatusId = 5

    var result = { Id, UserId, ItemId, StartDate, EndDate, Quantity, Notes, StatusId };
    $.ajax({
        url: `https://localhost:7095/api/Status/TakeAnItem`,
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

function ReturnItem(id) {
    var Id = id;
    var UserId = $('#reqUserId').val();
    var ItemId = $('#reqItemId').val();
    var StartDate = $('#startDate').val();
    var EndDate = $('#endDate').val();
    var Quantity = $('#reqQuantity').val();
    var Notes = $('#reqNotes').val();
    var StatusId = 2

    var result = { Id, UserId, ItemId, StartDate, EndDate, Quantity, Notes, StatusId };
    $.ajax({
        url: `https://localhost:7095/api/Status/Return`,
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