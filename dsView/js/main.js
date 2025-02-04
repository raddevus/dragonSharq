// main.js

const { app, BrowserWindow } = require('electron/main')
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
  win.loadFile('index.htm');
  console.log(`zoomFactor: ${win.webContents.zoomFactor}`);
  
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
