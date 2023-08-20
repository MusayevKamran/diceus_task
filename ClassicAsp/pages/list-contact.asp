<!--#include file="api/list-contract-api.asp"-->

<!DOCTYPE html>
<html>
<head>
    <title>API Data Display</title>
    <link rel="stylesheet" href="../css/site.css"  />
</head>
<body>
    <div class="header" style="margin-bottom: 20px;">
      <div >
        <a  href="https://diceus.azurewebsites.net/">Go to Asp.Net Core</a>
        <a class="active"  href="https://diceus.azurewebsites.net/classic/pages/list-contact.asp">Contact List</a>
      </div>
    </div>
    <div class="table-container">
        <table id="data-table">
          <tr>
            <th>Phone</th>
            <th>Name</th>
            <th>Surname</th>
            <th>Email</th>
          </tr>
      </table>
     </div>
  <script>  
        // Sample array of objects
        var dataArray = <% Response.write jsonResponse %>

        // Get the table element
        var table = document.getElementById('data-table');

        // Loop through the array and populate the table
        dataArray.forEach(item => {
            const row = table.insertRow();
            const cells = ['phone', 'name', 'surname', 'email'];
        
                cells.forEach(cellKey => {
                    const cell = row.insertCell();
                    cell.textContent = item[cellKey];
                });
            });
    </script>

  </script>
</body>
</html>