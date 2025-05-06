using Project_7DaysofCode.Classes;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Project_7DaysofCode.Classes;
    public class pokemon
    {
        public string name { get; set; }
        public string url { get; set; }
        public int fome { get; set; }
        public int humor { get; set; }
        public int idade { get; set; }
        public int diaDeAdocao { get; set; }
        public pokemon(string name, string url)
        {
            this.name = name;
            this.url = url;
            this.fome = 100;
            this.humor = 100;
            this.idade = 0;
            this.diaDeAdocao = DateTime.Now.Day;
        }
        internal class PokemonInfoTotal
        {
            public int weight { get; set; }
            public int height { get; set; }
            internal int base_experience { get; set; }
        }
        public void ExibirPokemon()
        {
            Console.WriteLine($"Nome: {this.name}");
            Console.WriteLine($"Url: {this.url}");
        }
        public async void ExibirPokemonInfoTotal()
        {
            var client = new RestClient(this.url);
            var request = new RestRequest("", Method.Get);
            var response = await client.ExecuteAsync(request);
            PokemonInfoTotal Json = JsonSerializer.Deserialize<PokemonInfoTotal>(response.Content);
            Console.WriteLine($"Nome: {this.name}");
            Console.WriteLine($"Altura: {Json.height * 10}cm");
            Console.WriteLine($"Peso: {Json.weight}kg");
        }
    }
public class TotalPokemons
{
    public int count { get; set; }
    public List<pokemon> results { get; set; }
    public void Contador()
    {
        Console.WriteLine($"Total de pokemons: {this.count}");
    }

}