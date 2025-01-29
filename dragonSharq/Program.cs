// See https://aka.ms/new-console-template for more information
using System.ComponentModel;
using System.Text;

List<String> allHttpHeaders = new();
Console.WriteLine("Hello, World!");
// #### NOTE: Not using tempfile yet so commenting it out for now.
// string tempFile = System.IO.Path.GetTempFileName();
// Console.WriteLine($"tempFile => {tempFile}");

HttpResponseMessage response = await CreateWebRequest();
Console.WriteLine($"{response.Content.Headers.Count()} : {response.Content.ReadAsStream().Length}");

byte [] buffer = new byte[response.Content.ReadAsStream().Length];

var bytesRead = response.Content.ReadAsStream().Read(buffer,0,buffer.Length);

var retrievedHTML = $"{Encoding.UTF8.GetString(buffer)}";

if (args.Length > 1){
    switch (args[1]){
        case "-file":{
            if (args[2] == null){
                Console.WriteLine("If you're saving to file, please provide the file name.");
                return;
            }
            File.WriteAllText(args[2],retrievedHTML);
            break;
        }
        case "-headers":{
            foreach (var h in response.Headers){
               Console.WriteLine($"{h.Key} = {h.Value.First()}");
            }
            return;
        }
    }
}
else{
    Console.WriteLine( retrievedHTML);
}



foreach (var h in response.Headers){
    Console.WriteLine($"{h.Key} = {h.Value.First()}");
}

async Task<HttpResponseMessage> CreateWebRequest()
 {
    if (args.Length < 1){
        Console.WriteLine("Need a URL.");
        return new HttpResponseMessage();
    }
    string strUri = args[0];
    Console.WriteLine($"retrieving {strUri}");
    
    strUri = CheckForUrlPrefix(strUri); 
      var httpClient = new HttpClient();
      var userAgentElectron = @"Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) dsview/1.0.0 Chrome/132.0.6834.83 Electron/34.0.1 Safari/537.36";
      var userAgentEdge = @"Mozilla/5.0 (Windows NT 10.0; Win64; x64) ppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36 Edg/120.0.0.0";
      httpClient.DefaultRequestHeaders.Add("User-Agent", userAgentElectron);
      var httpContent = new StringContent("", Encoding.UTF8, "text/xml");
      // httpContent.Headers.Add("SOAPAction", action);
      var httpResponse = await httpClient.GetAsync(strUri);
        
      return httpResponse;
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
