using Project_7DaysofCode;
using RestSharp;
using System.Text.Json;
using System.Xml.Linq;

public class program
{
    async static Task Main()
    {
        Menu.ExibirMenu();
        var resposta = Console.ReadLine();
        if (int.TryParse(resposta, out int numero))
        {
            switch (numero)
            {
                case 1:
                    await funcoes.AdotarPokemon();
                    break;
                case 0:
                    Console.Clear();
                    Console.WriteLine("tchau");
                    break;
                default:
                    Console.WriteLine("Opção Invalida");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Número Inválido");
        }
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


