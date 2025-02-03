// See https://aka.ms/new-console-template for more information
using System.ComponentModel;
using System.Text;
using dragonSharq;

List<String> allHttpHeaders = new();
Console.WriteLine("Hello, World!");
// #### NOTE: Not using tempfile yet so commenting it out for now.
// string tempFile = System.IO.Path.GetTempFileName();
// Console.WriteLine($"tempFile => {tempFile}");
DragonSharq ds = new DragonSharq();
HttpResponseMessage response = await ds.CreateWebRequest(args);
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
