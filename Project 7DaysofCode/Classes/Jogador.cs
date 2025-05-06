using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_7DaysofCode.Classes;

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