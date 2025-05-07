using Project_7DaysofCode.Classes;
using Project_7DaysofCode.Funcoes;
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
            bool existe = true;
            Console.WriteLine("Digite o seu nome");
            var nome = Console.ReadLine();
            string caminho = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"..\\..\\..\\{nome}.json");
            JogadorPokemon jogador = JsonSerializer.Deserialize<JogadorPokemon>(File.ReadAllText(Path.GetFullPath(caminho)));
            Console.WriteLine("Jogo carregado com sucesso!");
            while (existe)
            {
                Task.Delay(1001).Wait();
                Console.Clear();
                Console.WriteLine("Cuidar do Pokemon");
                Console.WriteLine("1: Alimentar");
                Console.WriteLine("2: Brincar");
                Console.WriteLine("3: Status do Pokemon");
                Console.WriteLine("0: Voltar");
                var resposta = Console.ReadLine();
                switch (resposta)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Alimentando Pokemon...");
                        jogador.Pokemon.fome -= 10;
                        jogador.Pokemon.humor -= 5;
                        Console.WriteLine("Pokemon alimentado com sucesso!");
                        Jogador jogador1 = new Jogador(jogador.Nome, jogador.Pokemon);
                        Salvarjogo.SalvarJogo(jogador1);

                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Brincando com Pokemon...");
                        jogador.Pokemon.fome += 5;
                        jogador.Pokemon.humor += 10;
                        Console.WriteLine("Pokemon brincado com sucesso!");
                        Jogador jogador2 = new Jogador(jogador.Nome, jogador.Pokemon);
                        Salvarjogo.SalvarJogo(jogador2);

                        break;
                        case "3":
                        Console.Clear();
                        Console.WriteLine($"exibindo informações do pokemon {jogador.Pokemon.name} de {jogador.Nome}");
                        Console.WriteLine($"Fome: {jogador.Pokemon.fome}");
                        Console.WriteLine($"Humor: {jogador.Pokemon.humor}");
                        Console.WriteLine($"Idade: {DateTime.Now.Day - jogador.Pokemon.idade}");
                        Console.WriteLine("Aperte qualquer tecla para voltar");
                        Console.ReadLine();
                        break;
                    case "0":
                        existe = false;
                        await Inicio.MenuInicio();
                        break;
                    default:
                        Console.WriteLine("Opção Invalida");
                        break;
                }

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
