using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MINIMALAPI.Dominio.Enuns;

namespace MINIMALAPI.Dominio.ModelViews
{
    public record AdministradorModelView
    {
        public int Id { get; init; } = default!;

        public string Email { get; init; } = default!;

        public string Perfil { get; init; } = default!;
    }
}   