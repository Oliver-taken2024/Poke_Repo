using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Poke_Repo.Model;

namespace Poke_Repo.Pages.PokemonPages
{
    public class IndexModel : PageModel
    {
        public List<string> Pokemons { get; set; }
        public void OnGet() 
        {
            Pokemons = Enum.GetNames(typeof(Pokemons)).ToList();
        }
    }
    
}
