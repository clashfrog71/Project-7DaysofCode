using RestSharp;
using System.Text.Json;

namespace Project_7DaysofCode
{
    public class pokemon
    {
        public pokemon(string name, string url)
        {
            this.name = name;
            this.url = url;
        }

        public string name { get; set; }
        public string url { get; set; }
        public void ExibirPokemon()
        {
            Console.WriteLine($"Nome: {this.name}");
            Console.WriteLine($"Url: {this.url}");
        }

        public void ExibirPokemonInfoTotal()
        {
            var client = new RestClient($"{this.url}");
            var request = new RestRequest("", Method.Get);
            var response = client.Execute(request);
            PokemonInfoTotal Json = JsonSerializer.Deserialize<PokemonInfoTotal>(response.Content);

            Console.WriteLine($"Nome: {this.name}");
            Console.WriteLine($"Altura: {Json.height * 10}cm");
            Console.WriteLine($"Peso: {Json.weight}kg");
        }

        internal class PokemonInfoTotal
        {
            public int weight { get; set; }
            public int height { get; set; }
            internal int base_experience { get; set; }

        }
    }

    public class Jogador
    {
        public Jogador(string nome, pokemon pokemon)
        {
            this.Nome = nome;
            this.Pokemon = pokemon;
        }
        public string Nome { get; set; }
        public pokemon Pokemon { get; set; }
        public void ExibirJogador()
        {
            Console.WriteLine($"Nome: {this.Nome}");
            Console.WriteLine($"Pokemon: {this.Pokemon.name}");
        }
    }
}
