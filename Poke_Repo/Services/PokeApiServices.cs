using System.Net.Http.Json;
using Poke_Repo.Model;


namespace Poke_Repo.Services
{
    public class PokeApiServices
    {
        private readonly HttpClient _http;

        public PokeApiServices(HttpClient http) 
        {
            _http = http;
        }

        public async Task<PokemonDto?> GetPokemonAsync(string name)
        {
            return await _http.GetFromJsonAsync<PokemonDto>( 
                $"https://pokeapi.co/api/v2/pokemon/{name.ToLower()}");
        }
    }
}
