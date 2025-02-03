using System.Text;

namespace dragonSharq;

public class DragonSharq{
    public async Task<HttpResponseMessage> CreateWebRequest(string [] args)
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
      var userAgentEdge = @"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36 Edg/120.0.0.0";
      httpClient.DefaultRequestHeaders.Add("User-Agent", userAgentElectron);
      var httpContent = new StringContent("", Encoding.UTF8, "text/xml");
      // httpContent.Headers.Add("SOAPAction", action);
      var httpResponse = await httpClient.GetAsync(strUri);
        
      return httpResponse;
    }

    private string CheckForUrlPrefix(string inUrl)
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
}