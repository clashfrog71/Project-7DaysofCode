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
        Console.WriteLine("Bem vindo ao desafio de 7 dias!");
        Console.WriteLine("1: Adotar pokemon");
        var resposta = Console.ReadLine();
        if (int.TryParse(resposta, out int numero))
        {
            switch (numero)
            {
                case 1:
                    await funcoes.AdotarPokemon();
                    break;
            }
        }
        else
        {
            Console.WriteLine("Número Inválido");
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
public static class funcoes
{
    public static async Task AdotarPokemon()
    {
        var client = new RestClient("https://pokeapi.co/api/v2/pokemon/");
        var request = new RestRequest("", Method.Get);
        var response = await client.ExecuteAsync(request);
        TestObject Json = JsonSerializer.Deserialize<TestObject>(response.Content);
        Console.Clear();
        Console.WriteLine("Adote um pokemon!");
        foreach (var item in Json.results)
        {
            Console.WriteLine(item.name); 
        }
        var resposta = Console.ReadLine().ToLower();
        var oescolhido = Json.results.FirstOrDefault(p => p.name.ToLower() == resposta);
        Console.WriteLine($"você vai adotar o {oescolhido.name}");
    }
}

