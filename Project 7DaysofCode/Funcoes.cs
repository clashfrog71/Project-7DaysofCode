using RestSharp;
using System.Text.Json;


namespace Project_7DaysofCode
{
    public static class funcoes
    {
        public static async Task AdotarPokemon()
        {
            var client = new RestClient("https://pokeapi.co/api/v2/pokemon/");
            var request = new RestRequest("", Method.Get);
            var response = await client.ExecuteAsync(request);
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
            Console.WriteLine("Qual seu nome?");
            var nome = Console.ReadLine();
            Jogador jogador = new Jogador(nome, pokemon);
            funcoes.SalvarJogo(jogador);

        }
        public static void SalvarJogo(Jogador jogador)
        {
            string caminho = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"..\\..\\..\\{jogador.Nome}.json");
            var jogadorSerializado = JsonSerializer.Serialize(jogador);
            File.WriteAllText(caminho, jogadorSerializado);
        }
        
    }public static class Menu
    {
        public static void ExibirMenu()
        {
            Console.WriteLine("Bem vindo ao desafio de 7 dias!");
            
            Console.WriteLine("escolha uma das opções");
            Console.WriteLine("1: Adotar pokemon");
            Console.WriteLine("0: sair");
        }
    }
}
