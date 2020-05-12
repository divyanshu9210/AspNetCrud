var table = document.getElementById('dataTable');
var form = document.getElementById('employeeForm');
var nameControl = document.getElementById('name');
var emailControl = document.getElementById('email');

fetch('https://localhost:5001/api/Employee')
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
            html += '<td><button class="btn btn-primary">Edit</button></td>';
            html += '<td><button class="btn btn-danger" onclick="Delete(' + element["id"] + ')">Delete</button></td>';
            html += '</tr>';
        });
        html += '</tbody>';
        table.innerHTML = html;
    }
}

function Delete(id){
    var confirm = window.confirm("Do you want to delete this user?");
    if(confirm) {
        fetch('https://localhost:5001/api/Employee/' + id, {
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

BindForm("#employeeForm", function(value){
    console.log(value);
});

// employeeForm.addEventListener("submit", function(e){
//     e.preventDefault();
//     if(nameControl.value.trim() == ''){
//         nameControl.classList.add('is-invalid');
//     }
//     if(emailControl.value.trim() == ''){
//         emailControl.classList.add('is-invalid');
//     }
//     if(nameControl.value.trim() != '' && emailControl.value.trim() != ''){
//         fetch('https://localhost:5001/Employee/', {
//             method: 'POST',
//             headers: {
//                 'Accept': 'application/json',
//                 'Content-Type': 'application/json'
//             },
//             body: JSON.stringify({
//                 name: nameControl.value,
//                 email: emailControl.value
//             }),
            
//         }).then((response) => {
//             if(response.status == '200'){
//                 dataTable.innerHTML += 
//                 `<tr>
//                     <td>` + nameControl.value + `</td>
//                     <td>` + emailControl.value + `</td>
//                 </tr>`;
//                 alert('data inserted successfully!');
//             }
//         })
//     }
// });