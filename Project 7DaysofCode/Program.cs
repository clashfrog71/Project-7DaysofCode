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
       Json.contador();
        foreach (var item in Json.results)
        {
           item.ExibirPokemon();
        }
    }
}
public class TestObject
{
    public int count { get; set; }
        public List<pokemon> results { get; set; }
        public void contador()
        {
            Console.WriteLine($"Total de pokemons: {this.count}");
        }

}
public class pokemon
{
    public string name { get; set; }
    public string url { get; set; }
    public void ExibirPokemon()
    {
        Console.WriteLine($"Nome: {this.name}");
        Console.WriteLine($"Url: {this.url}");
    }
}

