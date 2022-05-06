let brands = [];
let connection = null;
let brandIdToUpdate = -1;
getData();
setupSignalR();


function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:3445/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("BrandCreated", (user, message) => {
        getData();
    });

    connection.on("BrandDeleted", (user, message) => {
        getData();
    });

    connection.on("BrandUpdated", (user, message) => {
        getData();
    });

    connection.onclose(async () => {
        await start();
    });
    start();


}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

async function getData() {
    await fetch('http://localhost:3445/brand')
        .then(x => x.json())
        .then(y => {
            brands = y;
            display();
        });
}
function display() {
    document.getElementById('resultarea').innerHTML = '';
    brands.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            `<tr>
                <td>${t.id}</td>
                <td>${t.brand_Name}</td>
                <td>
                    <button type="button" onclick="remove(${t.id})">Delete</button>
                    <button type="button" onclick="showUpdate(${t.id})">Update</button>
                </td>
            </tr>`
    });
}

function showUpdate(id) {
    document.getElementById('brandnametoupdate').value = brands.find(t => t['id'] == id).brand_Name
    document.getElementById('updateformdiv').style.display = "flex";
    brandIdToUpdate = id;
}

function update() {
    document.getElementById('updateformdiv').style.display = "none";
    let name = document.getElementById('brandnametoupdate').value;
    fetch('http://localhost:3445/brand', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { brand_Name: name, id : brandIdToUpdate })
    })
        .then(response => response)
        .then(data => { console.log('Success:', data); getData(); })
        .catch((error) => { console.error('Error:', error); });
}

function remove(id) {
    fetch('http://localhost:3445/brand/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null})
        .then(response => response)
        .then(data => { console.log('Success:', data); getData(); })
        .catch((error) => { console.error('Error:', error); });
}
function create() {
    let name = document.getElementById('brandname').value;
    fetch('http://localhost:3445/brand', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { brand_Name: name })})
        .then(response => response)
        .then(data => { console.log('Success:', data); getData();})
        .catch((error) => { console.error('Error:', error); });
}