const { remote, ipcRenderer } = require('electron');

const form = document.querySelector("#form");

form.addEventListener("submit", (event) => {
    let title = document.getElementById("title").value;
    let dir = document.getElementById("dir").value;
    let folder_name = document.getElementById("folder_name").value;

    var fs = require('fs');

    let folder = dir+"/"+folder_name;

    fs.mkdir(folder);
    
    fs.mkdir(folder+"/application");

    fs.mkdir(folder+"/application/controller");

    fs.readFile("../files/Controller_php.txt", (err, data) => {
        if(err){
            return;
        }

        fs.writeFile(folder+"/controller/Controller.php", data, (err) => {
            console.log("Arquivo gerado!");
        });
    });

    fs.mkdir(folder+"/application/model");
    
    new Notification('MVCTemplate', {
        body: 'Todas as pastas foram geradas sem nenhuma exceção.'
    });
});