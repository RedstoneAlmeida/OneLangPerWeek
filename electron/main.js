const electron = require('electron');

const app = electron.app;

const BrowserWindow = electron.BrowserWindow;

let mainWindow;

app.on('ready', function() {
    mainWindow = new BrowserWindow({
        width: 350,
        height: 450,
        icon: __dirname + "/public/images/icons/logo.png",
        resizable: false
    });
    mainWindow.setMenu(null);

    

    mainWindow.loadURL('file://' + __dirname + '/index.html');
    mainWindow.on('closed', function() {
        mainWindow = null
    });
});