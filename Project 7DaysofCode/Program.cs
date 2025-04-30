using RestSharp;
using System.Text.Json;
using System.Xml.Linq;

public class program
{
    async static Task Main()
    {
        var client = new RestClient("https://pokeapi.co/api/v2/pokemon/");
        var request = new RestRequest("", Method.Get);
        var response = await client.ExecuteAsync(request);
        var b = JsonSerializer.Deserialize<TestObject>(response.Content);
        Console.WriteLine(b.count);
    }
}
class TestObject
{
    public int count { get; set; }

}

