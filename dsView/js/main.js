// main.js

const { app, BrowserWindow, Menu } = require('electron/main')
const args = process.argv;
console.log(`${args.length} : ${args}`);

const jsIsOn = args[2];
console.log(`jsIsOn: ${jsIsOn}`);

const createWindow = () => {
  const win = new BrowserWindow({
    width: 800,
    height: 600,
    // webPreferences: {
    //   zoomFactor: 1,
    // },
    webPreferences:{
      javascript: jsIsOn == undefined ? false : true,
      //devTools: true,
      //zoomFactor: 1,
      }
    
  })
  const { navigationHistory } = win.webContents;
  win.loadFile('index.htm');
  console.log(`zoomFactor: ${win.webContents.zoomFactor}`);
  // Create the application menu
  const menu = Menu.buildFromTemplate([
    {
      label: 'Yada',
      submenu: [
        { label: 'Open', click: () => { console.log('Open clicked'); } },
        { label: 'Save', click: () => { console.log('Save clicked'); } },
        { label: 'Back', click: () => {navigationHistory.goBack()}},
        { type: 'separator' },
        { label: 'Exit', click: () => { app.quit(); } },
      ],
    },
    {
      label: 'Edit',
      submenu: [
        { label: 'Undo', role: 'undo' },
        { label: 'Redo', role: 'redo' },
        { label: 'Zoom In', role: 'zoomIn' },
        { label: 'Zoom Out', role: 'zoomOut' },
        { label: 'Reset Zoom', role: 'resetZoom' },
        { type: 'separator' },
        { label: 'Cut', role: 'cut' },
        { label: 'Copy', role: 'copy' },
        { label: 'Paste', role: 'paste' },
      ],
    },
  ]);

  Menu.setApplicationMenu(menu);
  
}

app.whenReady().then(() => {

  createWindow()
  
  app.on('activate', () => {
    if (BrowserWindow.getAllWindows().length === 0) {
      createWindow()
    }
  })
})

app.on('window-all-closed', () => {
  if (process.platform !== 'darwin') {
    app.quit()
  }
})
