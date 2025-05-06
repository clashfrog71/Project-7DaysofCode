using RestSharp;
namespace Project_7DaysofCode.Funcoes;

public class FazerConexao
{
    public static async Task<RestResponse> fazerConecao()
    {
        var client = new RestClient("https://pokeapi.co/api/v2/pokemon/");
        var request = new RestRequest("", Method.Get);
        var response = await client.ExecuteAsync(request);
        return response;
    }
}
