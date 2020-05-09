var table = document.getElementById('dataTable');

fetch('https://localhost:5001/Employee')
.then((data) => data.json())
.then((data) => {
    FillData(data);
});

function FillData(data){
    var html = '';
    if(data.length > 0){
        html += 
        `<thead>
        <tr>
        <th>Name</th>
        <th>Email</th>
        <th colspan="2">Action</th>
        </tr>
        </thead>`;
        html += '<tbody>';
        data.forEach(element => {
            html += '<tr id="row-' + element["id"] + '">';
            html += '<td>' + element["name"] + '</td>';
            html += '<td>' + element["email"] + '</td>';
            html += '<td><button>Edit</button></td>';
            html += '<td><button onclick="Delete(' + element["id"] + ')">Delete</button></td>';
            html += '</tr>';
        });
        html += '</tbody>';
        table.innerHTML = html;
    }
}

function Delete(id){
    var confirm = window.confirm("Do you want to delete this user?");
    if(confirm) {
        fetch('https://localhost:5001/Employee/' + id, {
            method: 'DELETE'
        })
        .then((response) => {
            if(response.status == 200) {
                var row = document.getElementById('row-' + id);
                row.remove();
            }
        });
    }
}