using Project_7DaysofCode.Classes;
using Project_7DaysofCode.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Project_7DaysofCode.Funcoes
{
    public class funcoes

    {
        public static async Task AdotarPokemon()
        {
            try
            {
                var response = await FazerConexao.fazerConecao();
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
                Salvarjogo.SalvarJogo(jogador);
                Console.WriteLine("Json salvo com sucesso!");
                Task.Delay(1000).Wait();
                await Inicio.MenuInicio();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro: {ex.Message}");
                Task.Delay(2000).Wait();
                Console.Clear();
                await Inicio.MenuInicio();
            }
        }
    }
}
