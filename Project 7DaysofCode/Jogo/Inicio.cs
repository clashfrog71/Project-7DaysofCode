using Project_7DaysofCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_7DaysofCode.Jogo;

public class Inicio
{
    public static async Task MenuInicio()
    {
        Console.WriteLine("Bem vindo ao desafio de 7 dias!");

        Console.WriteLine("escolha uma das opções");
        Console.WriteLine("1: Adotar pokemon");
        Console.WriteLine("0: sair");
        var resposta = Console.ReadLine();

        switch (resposta)
        {
            case "1":
                await funcoes.AdotarPokemon();
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


