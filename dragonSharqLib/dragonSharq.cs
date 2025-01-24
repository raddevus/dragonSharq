using System.Text;

namespace dragonSharq;

public class dragonSharq{
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