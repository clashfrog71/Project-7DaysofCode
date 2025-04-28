using System.Text.Json;

using (HttpClient client = new HttpClient())
{


  

        try
        {
            string resposta = await client.GetStringAsync("https://pokeapi.co/api/v2/ability/65/");
        
            var musicas = JsonSerializer.Deserialize<List<pokemon>>(resposta)!;

        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Erro na requisição: {e.Message}");
        }
    
}public class pokemon
{
    public string name { get; set; }
}

