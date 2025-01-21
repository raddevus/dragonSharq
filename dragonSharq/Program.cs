// See https://aka.ms/new-console-template for more information
using System.ComponentModel;

Console.WriteLine("Hello, World!");
string tempFile = System.IO.Path.GetTempFileName();
Console.WriteLine($"tempFile => {tempFile}");

/*BackgroundWorker webSourceWorker = new BackgroundWorker();
webSourceWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(WebSourceWorkerDoWork);
webSourceWorker.RunWorkerAsync();*/

GetWebSource();

void WebSourceWorkerDoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
{
    try
    {
        Console.WriteLine("I'm in DoWork...");
        GetWebSource();
    }
    finally
    {
        
    }

}

void GetWebSource()
{
    if (args.Length < 1){
        Console.WriteLine("Need a URL.");
        return;
    }
    string strUri = args[0];
    Console.WriteLine($"retrieving {strUri}");
    
    strUri = CheckForUrlPrefix(strUri);
    // urlComboBox.Text = strUri;
    
    /*bool isAdded = visitedUrls.TryAdd(strUri.ToUpper(),strUri);
    if (isAdded)
    {
        urlComboBox.Items.Add(strUri);
    }*/ 
    
    System.Net.HttpWebRequest webreq; 
    
    System.Net.WebResponse webres; 
    try 
    {
        webreq = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(strUri);
        if (args.Length > 1)
        {
            webreq.UserAgent  = args[1];
        }
        else{
            webreq.UserAgent = "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/131.0.0.0 Safari/537.3";
        }
        webres = webreq.GetResponse(); 
    } 
    catch (Exception exc) 
    {
        Console.WriteLine(exc.Message);
        return; 
    } 
    Console.WriteLine("In here...");
    Stream stream = webres.GetResponseStream();
    StreamReader strrdr = new StreamReader(stream); 
    string strLine; 
    int line = 1; 

    while (((strLine = strrdr.ReadLine()) != null))// && (!webSourceWorker.CancellationPending))
    {
        Console.WriteLine( $"{strLine}");
        ++line;
        // only update every 100 lines 
        if ((line %100) == 0)
        {
        //    htmlViewText.Update();
        }
    }
        
    /* foreach (string key in webres.Headers.Keys)
    {
        responseHeadersDropList.Items.Add(string.Format("{0} = {1}",
            key,webres.Headers[key]));
    }
    if (responseHeadersDropList.Items.Count > 0)
    {
        responseHeadersDropList.SelectedIndex = 0;
    }*/ 
}

string CheckForUrlPrefix(string inUrl)
{
    if ((inUrl.IndexOf("http://", StringComparison.OrdinalIgnoreCase) == 0) ||
        (inUrl.IndexOf("https://", StringComparison.OrdinalIgnoreCase) == 0))
    {
        return inUrl;
    }
    else
    {
        return $"http://{inUrl}";
    }
}
