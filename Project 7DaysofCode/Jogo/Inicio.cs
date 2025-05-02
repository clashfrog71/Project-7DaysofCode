using Project_7DaysofCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_7DaysofCode.Jogo
{
    internal class Inicio
    {
        public static async void inicio()
        {
            Menu.ExibirMenu();
            var resposta = Console.ReadLine();
            
                switch (resposta)
                {
                    case "1":
                        funcoes.AdotarPokemon();
                        break;
                    case "0":
                        Console.Clear();
                        Console.WriteLine("tchau");
                        break;
                    default:
                        Console.WriteLine("Opção Invalida");
                        break;
                }
            
            
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
