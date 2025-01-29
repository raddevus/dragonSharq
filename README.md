## 2025-01-29 Updates
Now you can run and view the HTML you pull down.
I've added a ElectronJS-based Browser which will render the HTML you pull down.

### NPM Install
The first thing you have to do is switch to the `dsView` directory under the main project directory and run :
* `npm install`

That will install everything (electronJs & associated dependencies) that you need so the dsView ElectronJS app will run properly.  After that, follow the instructions below.

Here's a command line so you can view the HTML first in a text editor:

### Run From Main Project Folder

#### Linux -- uses gnome text editor
`dotnet run --project dragonSharq https://cyapass.com -file dsView/index.htm &&  /usr/bin/gnome-text-editor & dsView/index.htm`

#### Windows - uses notepad
 dotnet run --project dragonSharq https://newlibre.com -file dsView/index.htm && notepad dsView/index.htm

This will build & run the project : `dontet run --project dragonSharq`
 * It retrieves the page at URL : `https://cyapass.com`
 * It saves the page in the file at `dsView/index.htm`
 * It starts up the gnome-text-editor (as a background process): `/usr/bin/gnome-text-editor & `
 * it loads the downloaded page in the editor: `dsView/index.htm`

### Rendering Downloaded HTML
You could also use the following command to do all that except open the ElectronJS browser to render the HTML.

#### This works on ANY OS (linux, macOS, Win)!!
`dotnet run --project dragonSharq https://cyapass.com -file dsView/index.htm &&  npm start --prefix dsView`

That last part simply starts the dsView (electronJS browser) which will then load the `index.htm`
