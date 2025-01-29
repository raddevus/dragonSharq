## 2025-01-29 Updates
Now you can run and view the HTML you pull down.
I've added a ElectronJS-based Browser which will render the HTML you pull down.

Here's a command line so you can view the HTML first in a text editor:

### Run From Main Project Folder

`dotnet run --project dragonSharq https://cyapass.com -file dsView/index.htm &&  /usr/bin/gnome-text-editor & dsView/index.htm`

This will build & run the project : `dontet run --project dragonSharq`
 * It retrieves the page at URL : `https://cyapass.com`
 * It saves the page in the file at `dsView/index.htm`
 * It starts up the gnome-text-editor (as a background process): `/usr/bin/gnome-text-editor & `
 * it loads the downloaded page in the editor: `dsView/index.htm`

### Rendering Downloaded HTML
You could also use the following command to do all that except open the ElectronJS browser to render the HTML.

`dotnet run --project dragonSharq https://cyapass.com -file dsView/index.htm &&  npm start --prefix dsView`

That last part simply starts the dsView (electronJS browser) which will then load the `index.htm`
