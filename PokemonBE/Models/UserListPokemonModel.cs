using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonBE.Models
{
    public class UserListPokemonModel
    {
        public int id { get; set; }

        public int? user_id { get; set; }

        public int? pokemon_id { get; set; }

        public string pokemon_origin_name { get; set; }

        public string pokemon_nickname { get; set; }
    }
}
