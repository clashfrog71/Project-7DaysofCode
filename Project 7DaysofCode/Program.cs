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
        TestObject Json = JsonSerializer.Deserialize<TestObject>(response.Content);
        Console.WriteLine(Json.count);
        foreach (var item in Json.results)
        {
            Console.WriteLine(item.name);
        }
    }
}
class TestObject
{
    public int count { get; set; }
    public List<pokemon> results { get; set; }

}
class pokemon
{
    public string name { get; set; }
    public string url { get; set; }
}

