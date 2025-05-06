using Project_7DaysofCode.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Project_7DaysofCode.Menus;

public class CuidarPokemon
{

    public static async Task MenuCuidarPokemon()
    {
        try
        {
            Console.WriteLine("Digite o seu nome");
            var nome = Console.ReadLine();
            string caminho = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"..\\..\\..\\{nome}.json");
            JogadorPokemon jogador = JsonSerializer.Deserialize<JogadorPokemon>(File.ReadAllText(Path.GetFullPath(caminho)));
            Console.WriteLine("Jogo carregado com sucesso!");
            Task.Delay(1001).Wait();
            Console.Clear();
            Console.WriteLine("Cuidar do Pokemon");
            Console.WriteLine("1: Alimentar");
            Console.WriteLine("2: Brincar");
            Console.WriteLine("3: Treinar");
            Console.WriteLine("0: Voltar");
            var resposta = Console.ReadLine();
            switch (resposta)
            {
                case "1":
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "0":
                    await Inicio.MenuInicio();
                    break;
                default:
                    Console.WriteLine("Opção Invalida");
                    break;
            }

        }
        catch
        {
            Console.WriteLine("nome não encontrado!");
            Task.Delay(2000).Wait();
            Console.Clear();
            Inicio.MenuInicio().Wait();
        }
        
    }
}
