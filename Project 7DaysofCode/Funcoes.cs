using RestSharp;
using System.Text.Json;
namespace Project_7DaysofCode;

public static class funcoes
{
    public static async Task AdotarPokemon()
    {
        var response = await fazerConecao();
        TotalPokemons Json = JsonSerializer.Deserialize<TotalPokemons>(response.Content);
        Console.Clear();
        Console.WriteLine("Adote um pokemon!");
        foreach (var item in Json.results)
        {
            Console.WriteLine(item.name);
        }
        var resposta = Console.ReadLine().ToLower();
        var oescolhido = Json.results.FirstOrDefault(p => p.name.ToLower() == resposta);
        Console.WriteLine($"você vai adotar o {oescolhido.name}");
        oescolhido.ExibirPokemonInfoTotal();
        pokemon pokemon = new pokemon(oescolhido.name, oescolhido.url);
        Task.Delay(500).Wait();
        Console.WriteLine("Qual seu nome?");
        var nome = Console.ReadLine();
        Jogador jogador = new Jogador(nome, pokemon);
        funcoes.SalvarJogo(jogador);
        Console.WriteLine("Json salvo com sucesso!");
        Task.Delay(1000).Wait();
    }
    public static void SalvarJogo(Jogador jogador)
    {
        string caminho = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"..\\..\\..\\{jogador.Nome}.json");
        var jogadorSerializado = JsonSerializer.Serialize(jogador);
        File.WriteAllText(caminho, jogadorSerializado);
    }
    public static async Task<RestResponse> fazerConecao()
    {
        var client = new RestClient("https://pokeapi.co/api/v2/pokemon/");
        var request = new RestRequest("", Method.Get);
        var response = await client.ExecuteAsync(request);
        return response;
    }   
}