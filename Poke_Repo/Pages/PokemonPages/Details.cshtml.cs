using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Poke_Repo.Data;
using Poke_Repo.Model;
using Poke_Repo.Services;
using System.Net.Http.Json;

namespace Poke_Repo.Pages.PokemonPages
{
    public class DetailsModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly PokeApiServices _pokeApi;
        public PokemonDto? Pokemon { get; set; }

        public DetailsModel(AppDbContext context, PokeApiServices pokeApi)
        {
            _context = context;
            _pokeApi = pokeApi;
        }
       

       
     
        public async Task OnGetAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return;

            name= name.ToLower();

            var existingPokemon = await _context.Pokemons
                .FirstOrDefaultAsync(p=> p.Name.ToLower() == name.ToLower());

            if (existingPokemon != null)
            {
                Pokemon = new PokemonDto
                {
                    Id = existingPokemon.Id,
                    Name = existingPokemon.Name,
                    Height = existingPokemon.Height,
                    Weight = existingPokemon.Weight,
                };

             return;   
            }

            Pokemon = await _pokeApi.GetPokemonAsync(name);
            if (Pokemon == null) { return; }

            var pokemonModel = new PokemonModel
            {
                PokeApiId = Pokemon.Id,
                Name = Pokemon.Name,
                Height = Pokemon.Height,
                Weight = Pokemon.Weight,
            };

            _context.Pokemons.Add(pokemonModel);
            await _context.SaveChangesAsync();
            // först kolla om pokemon finns i data basen
            // Om den inte finns anropa api



            //kolla om null-> om den är null return

            //spara pokemon i databasen 

        }
    }
}
