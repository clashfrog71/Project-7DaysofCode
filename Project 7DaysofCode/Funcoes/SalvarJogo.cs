using Project_7DaysofCode.Classes;
using Project_7DaysofCode.Menus;
using System.Text.Json;

namespace Project_7DaysofCode.Funcoes;

internal class Salvarjogo
{
    public static void SalvarJogo(Jogador jogador)
    {
        try
        {
            string caminho = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"..\\..\\..\\{jogador.Nome}.json");
            var jogadorSerializado = JsonSerializer.Serialize(jogador);
            File.WriteAllText(caminho, jogadorSerializado);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro ao salvar o jogo: {ex.Message}");
            Console.Clear();
            Inicio.MenuInicio().Wait();
        }
    }
}
