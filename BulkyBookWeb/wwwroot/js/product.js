var datatable;

$(document).ready(function () {
    loadDataTable();
})

function loadDataTable() {
    console.log("Came in product js")
    datatable = $('#tblData').DataTable({
        "ajax": {
            "url":"/Admin/Product/GetAll"
        },
        "columns": [
            { "data": "title", "width": "15%" },
            { "data": "isbn", "width": "15%" },
            { "data": "price", "width": "15%" },
            { "data": "author", "width": "15%" },
            { "data": "category.name", "width": "15%" },
            { "data": "coverType.name", "width": "15%" },
            {
                "data": "id",
                 "render": function (data)
                  {
                     return `
                     <div class="w-75 btn-group" role="group">
                        <a class="btn btn-primary mx-2" href="/Admin/Product/Upsert?id=${data}">Edit</a>
                        <a onClick=Delete('/Admin/Product/Delete/${data}') class="btn btn-danger mx-2">Delete</a>
                      </div>
                     `
                },
                "width":"15%"
            },
        ]
    });
    console.log("product table", datatable)
}

function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        datatable.ajax.reload();
                        toastr.success(data.message);
                    } else {
                        toastr.error(data.error);
                    }
                }
            })
        }
    })
}