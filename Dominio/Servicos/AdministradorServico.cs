using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MINIMALAPI.Dominio.DTOs;
using MINIMALAPI.Dominio.Entidades;
using MINIMALAPI.Dominio.Interfaces;
using MINIMALAPI.Infraestrutura.Db;

namespace MINIMALAPI.Dominio.Servicos
{
    public class AdministradorServico : IAdministradorServico
    {
        private readonly DbContexto _contexto;
        public AdministradorServico(DbContexto contexto)
        {
            _contexto = contexto;
        }
        public Administrador? Login(LoginDTO loginDTO)
        {
            var adm = _contexto.Administradores.Where(a => a.Email == loginDTO.Email && a.Senha == loginDTO.Senha).FirstOrDefault();
            return adm;
        }

        public Administrador? Incluir(Administrador administrador)
        {
            _contexto.Administradores.Add(administrador);
            _contexto.SaveChanges();

            return administrador;
        }

        public List<Administrador> Todos(int? pagina)
        {
            var query = _contexto.Administradores.AsQueryable();
            int ItensPorPagina = 10;
            if (pagina != null)
            {
                query = query.Skip(((int)pagina - 1) * ItensPorPagina).Take(ItensPorPagina);
            }
            return query.ToList();
        }
        
        public Administrador? BuscarPorId(int id)
        {
            return _contexto.Administradores.Where(a => a.Id == id).FirstOrDefault();
        }
    }
}