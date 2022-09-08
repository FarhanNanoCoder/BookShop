var datatable;

$(document).ready(function () {
    var url = window.location.search;

    if (url.includes("inprocess")) {
        loadDataTable("inprocess");
    }
    else if (url.includes("approved")) {
        loadDataTable("approved");
    }
    else if (url.includes("pending")) {
        loadDataTable("pending");
    }
    else if (url.includes("completed")) {
        loadDataTable("completed");
    }
    else {
        loadDataTable("all");
    }

    
})

function loadDataTable(status) {
    console.log("Came in order js")
    datatable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/Order/GetAll?status=" + status
        },
        "columns": [
            { "data": "id", "width": "15%" },
            { "data": "name", "width": "15%" },
            { "data": "phoneNumber", "width": "15%" },
            { "data": "applicationUser.email", "width": "15%" },
            { "data": "orderStatus", "width": "15%" },
            { "data": "orderTotal", "width": "15%" },
            {
                "data": "id",
                 "render": function (data)
                  {
                     return `
                     <div class="w-75 btn-group" role="group">
                        <a class="btn btn-primary mx-2" href="/Admin/Order/Details?orderId=${data}">Details</a>
                      </div>
                     `
                },
                "width":"15%"
            },
        ]
    });
    console.log("order table", datatable)
}