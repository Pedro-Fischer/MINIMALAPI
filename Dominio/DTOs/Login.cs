using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MINIMALAPI.DTOs
{
    public class loginDTO
    {
        public string Email { get; set; } = default!;
        public string Senha { get; set; } = default!;
    }
}