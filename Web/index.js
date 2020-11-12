
// (C)RUD
function AddLocation()
{
    let location = {};
    location.name = document.querySelector('#name').value;
    location.address = document.querySelector('#address').value;
    location.city = document.querySelector('#city').value;
    location.state = document.querySelector('#state').value;
    location.zip = document.querySelector('#zip').value;

    let xhr = new XMLHttpRequest();
    xhr.onreadystatechange = function(){
        if(this.readyState == 4 && this.status > 199 && this.status < 300)
        {
            alert("New Location Added!");
            document.querySelector('#name').value = '';
            document.querySelector('#address').value = '';
            document.querySelector('#city').value = '';
            document.querySelector('#state').value = '';
            document.querySelector('#zip').value = '';
            GetAllLocations();
        }
    };
    xhr.open("POST", 'https://localhost:44356/Location/add', true);
    xhr.setRequestHeader('Content-Type', 'application/json');
    xhr.send(JSON.stringify(location));
}

function AddEmployee()
{
    let employee = {};
    employee.fname = document.querySelector('#fname').value;
    employee.lname = document.querySelector('#lname').value;
    employee.email = document.querySelector('#email').value;
    employee.password = document.querySelector('#password').value;
    employee.type = document.querySelector('#type').value;

    let xhr = new XMLHttpRequest();
    xhr.onreadystatechange = function(){
        if(this.readyState == 4 && this.status > 199 && this.status < 300)
        {
            alert("New Employee Added!");
            document.querySelector('#fname').value = '';
            document.querySelector('#lname').value = '';
            document.querySelector('#email').value = '';
            document.querySelector('#password').value = '';
            document.querySelector('#type').value = '';
            GetAllEmployees();
        }
    };
    xhr.open("POST", 'https://localhost:44356/Employee/add', true);
    xhr.setRequestHeader('Content-Type', 'application/json');
    xhr.send(JSON.stringify(employee));
}

function AddProduct()
{
    let product = {};
    product.productId = Math.floor(Math.random() * 100_000);
    product.productName = document.querySelector('#name').value;
    product.productDescription = document.querySelector('#description').value;
    product.listPrice = document.querySelector('#price').value;

    let xhr = new XMLHttpRequest();
    xhr.onreadystatechange = function(){
        if(this.readyState == 4 && this.status > 199 && this.status < 300)
        {
            alert("New Product Added!");
            document.querySelector('#name').value = '';
            document.querySelector('#description').value = '';
            document.querySelector('#price').value = '';
            GetAllProducts();
        }
    };
    xhr.open("POST", 'https://localhost:44360/Product/add', true);
    xhr.setRequestHeader('Content-Type', 'application/json');
    xhr.send(JSON.stringify(product));
}

function AddInventoryItem()
{
    let inventoryItem = {};
    inventoryItem.productId = document.querySelector('#productId').value;
    inventoryItem.locationId = document.querySelector('#locationId').value;
    inventoryItem.quantity = document.querySelector('#quantity').value;

    let xhr = new XMLHttpRequest();
    xhr.onreadystatechange = function(){
        if(this.readyState == 4 && this.status > 199 && this.status < 300)
        {
            alert("New InventoryItem Added!");
            document.querySelector('#productId').value = '';
            document.querySelector('#locationId').value = '';
            document.querySelector('#quantity').value = '';
            GetAllPapers();
        }
    };
    xhr.open("POST", 'https://localhost:44356/InventoryItem/add', true);
    xhr.setRequestHeader('Content-Type', 'application/json');
    xhr.send(JSON.stringify(paper));
}

//C(R)UD
function GetAllLocations()
{
    const proxyurl
    fetch('https://localhost:44356/Location/getall')
    .then(response => response.json)
    .then(result => {
        document.querySelectorAll('#locations tbody tr').forEach(element => element.remove());
        let table = document.querySelector('#locations tbody');
        for(let i = 0; i < result.length(); ++i)
        {
            let row = table.insertRow(table.rows.length);
            let rnCell = row.Insert(0);
            rnCell.innerHTML = result[i].name;

            let aCell = row.Insert(1);
            aCell.innerHTML = result[i].address;

            let hideCell = row.Insert(2);
            hideCell.innerHTML = result[i].city;

        }
    });
}

function GetAllEmployees()
{
    const proxyurl
    fetch('https://localhost:44356/Employee/getall')
    .then(response => response.json)
    .then(result => {
        document.querySelectorAll('#employess tbody tr').forEach(element => element.remove());
        let table = document.querySelector('#employees tbody');
        for(let i = 0; i < result.length(); ++i)
        {
            let row = table.insertRow(table.rows.length);
            let rnCell = row.Insert(0);
            rnCell.innerHTML = result[i].name;

            let aCell = row.Insert(1);
            aCell.innerHTML = result[i].address;

            let hideCell = row.Insert(2);
            hideCell.innerHTML = result[i].city;

        }
    });
}

function ValidateLogin()
{
    let user = {};
    let xhr = new XMLHttpRequest();
    var email = document.querySelector('#email').value;
    var password = document.querySelector('#password').value;
    
    xhr.onreadystatechange = function() {
        if(this.readyState == 4 && this.status == 200)
        {
            user = JSON.parse(xhr.responseText);
            if (user.employeePassword == password && user.employeeEmail == email) {
                alert("success")
                //Redirect to new page
            } else {
                alert("failed Login")
            }
        }
    }
    xhr.open("GET", `https://localhost:44360/api/Employee/get/${email}`, true)
    xhr.send();
}

function GetAllProducts()
{
    fetch('https://localhost:44360/api/Product/get')
    .then(response => response.json())
    .then(result => {
        document.querySelectorAll('#products tbody tr').forEach(element => element.remove());
        let table = document.querySelector('#products tbody');
        for(let i = 0; i < result.length; ++i)
        {
            let row = table.insertRow(table.rows.length);
            let nameCell = row.insertCell(0);
            nameCell.innerHTML = result[i].productName;

            let descriptionCell = row.insertCell(1);
            descriptionCell.innerHTML = result[i].productDescription;

            let priceCell = row.insertCell(2);
            priceCell.innerHTML = result[i].listPrice;

        }
    });
}

function GetAllInventoryItems()
{
    const proxyurl
    fetch('https://localhost:44356/InventoryItem/getall')
    .then(response => response.json)
    .then(result => {
        document.querySelectorAll('#InventoryItem tbody tr').forEach(element => element.remove());
        let table = document.querySelector('#InventoryItem tbody');
        for(let i = 0; i < result.length(); ++i)
        {
            let row = table.insertRow(table.rows.length);
            let rnCell = row.Insert(0);
            rnCell.innerHTML = result[i].name;

            let aCell = row.Insert(1);
            aCell.innerHTML = result[i].address;

            let hideCell = row.Insert(2);
            hideCell.innerHTML = result[i].city;

        }
    });
}


//CR(U)D
function UpdateInventoryItem()
{
    let digiName = document.querySelector('#digimonInput').value;
    fetch(`https://digimon-api.vercel.app/api/digimon/name/${digiName}`)
    .then(response => response.json())
    .then(result => {
        document.querySelector('.digimonResult img').setAttribute('src', result[0].img);
        document.querySelectorAll('.digimonResult caption').forEach((element) => element.remove());
        let caption = document.createElement('caption');
        caption.appendChild(document.createTextNode(result[0].name));
        document.querySelector('.digimonResult').appendChild(caption);
        document.querySelector('#digimonInput').value = '';
    });
}

function UpdateEmployee()
{
    let digiName = document.querySelector('#digimonInput').value;
    fetch(`https://digimon-api.vercel.app/api/digimon/name/${digiName}`)
    .then(response => response.json())
    .then(result => {
        document.querySelector('.digimonResult img').setAttribute('src', result[0].img);
        document.querySelectorAll('.digimonResult caption').forEach((element) => element.remove());
        let caption = document.createElement('caption');
        caption.appendChild(document.createTextNode(result[0].name));
        document.querySelector('.digimonResult').appendChild(caption);
        document.querySelector('#digimonInput').value = '';
    });
}

function UpdateLocation()
{
    let digiName = document.querySelector('#digimonInput').value;
    fetch(`https://digimon-api.vercel.app/api/digimon/name/${digiName}`)
    .then(response => response.json())
    .then(result => {
        document.querySelector('.digimonResult img').setAttribute('src', result[0].img);
        document.querySelectorAll('.digimonResult caption').forEach((element) => element.remove());
        let caption = document.createElement('caption');
        caption.appendChild(document.createTextNode(result[0].name));
        document.querySelector('.digimonResult').appendChild(caption);
        document.querySelector('#digimonInput').value = '';
    });
}


function UpdateProduct(id)
{
    let product = {};
    product.productId = id;
    product.productName = document.querySelector('#name').value;
    product.productDescription = document.querySelector('#description').value;
    product.listPrice = document.querySelector('#price').value;

    let xhr = new XMLHttpRequest();
    xhr.onreadystatechange = function(){
        if(this.readyState == 4 && this.status > 199 && this.status < 300)
        {
            alert("Product Updated!");
            document.querySelector('#name').value = '';
            document.querySelector('#description').value = '';
            document.querySelector('#price').value = '';
            GetAllProducts();
        }
    };
    xhr.open("PUT", 'https://localhost:44356/Product/Update', true);
    xhr.setRequestHeader('Content-Type', 'application/json');
    xhr.send(JSON.stringify(product));
}

//CRU(D)
function DeleteEmployee()
{
    let digiName = document.querySelector('#digimonInput').value;
    fetch(`https://digimon-api.vercel.app/api/digimon/name/${digiName}`)
    .then(response => response.json())
    .then(result => {
        document.querySelector('.digimonResult img').setAttribute('src', result[0].img);
        document.querySelectorAll('.digimonResult caption').forEach((element) => element.remove());
        let caption = document.createElement('caption');
        caption.appendChild(document.createTextNode(result[0].name));
        document.querySelector('.digimonResult').appendChild(caption);
        document.querySelector('#digimonInput').value = '';
    });
}

function DeleteLocation()
{
    let digiName = document.querySelector('#digimonInput').value;
    fetch(`https://digimon-api.vercel.app/api/digimon/name/${digiName}`)
    .then(response => response.json())
    .then(result => {
        document.querySelector('.digimonResult img').setAttribute('src', result[0].img);
        document.querySelectorAll('.digimonResult caption').forEach((element) => element.remove());
        let caption = document.createElement('caption');
        caption.appendChild(document.createTextNode(result[0].name));
        document.querySelector('.digimonResult').appendChild(caption);
        document.querySelector('#digimonInput').value = '';
    });
}

function DeleteProduct(id)
{
    let product = {};
    product.productId = id
    product.productName = document.querySelector('#name').value;
    product.productDescriptiondescription = document.querySelector('#description').value;
    product.listPrice = document.querySelector('#price').value;

    let xhr = new XMLHttpRequest();
    xhr.onreadystatechange = function(){
        if(this.readyState == 4 && this.status > 199 && this.status < 300)
        {
            alert("Product Updated!");
            document.querySelector('#name').value = '';
            document.querySelector('#description').value = '';
            document.querySelector('#price').value = '';
            GetAllProducts();
        }
    };
    xhr.open("DELETE", 'https://localhost:44356/Product/Delete', true);
    xhr.setRequestHeader('Content-Type', 'application/json');
    xhr.send(JSON.stringify(product));
}

function DeleteInventoryItem()
{
    let digiName = document.querySelector('#digimonInput').value;
    fetch(`https://digimon-api.vercel.app/api/digimon/name/${digiName}`)
    .then(response => response.json())
    .then(result => {
        document.querySelector('.digimonResult img').setAttribute('src', result[0].img);
        document.querySelectorAll('.digimonResult caption').forEach((element) => element.remove());
        let caption = document.createElement('caption');
        caption.appendChild(document.createTextNode(result[0].name));
        document.querySelector('.digimonResult').appendChild(caption);
        document.querySelector('#digimonInput').value = '';
    });
}

