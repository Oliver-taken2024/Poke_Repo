using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Poke_Repo.Model;

namespace Poke_Repo.Pages.Pokemon
{
    public class DetailsModel : PageModel
    {
        public PokemonModel Pokemon { get; set; }
     
        public async Task OnGetAsync(string name)
        {
            // först kolla om pokemon finns i data basen
            // Om den inte finns anropa api

            using var httpClient = new HttpClient();
            var url= $"https://pokeapi.co/api/v2/pokemon/{name.ToLower()}";
            Pokemon = await httpClient.GetFromJsonAsync<PokemonModel>(url);

            //kolla om null-> om den är null return

            //spara pokemon i databasen 
        }
    }
}
