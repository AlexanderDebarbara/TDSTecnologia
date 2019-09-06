using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TDSTecnologia.Site.Core.Entities;
using TDSTecnologia.Site.Infrastructure.Data;
using TDSTecnologia.Site.Infrastructure.Repository;

namespace TDSTecnologia.Site.Infrastructure.Services
{
    public class PermissaoService : BasicService
    {
        private readonly PermissaoRepository _permissaoRepository;
        public PermissaoService(AppContexto context, RoleManager<Permissao> roleManger) : base(context)
        {
            _permissaoRepository = new PermissaoRepository(context, roleManger);
        }

        public List<Permissao> ListarTodos()
        {
            return _permissaoRepository.ListarTodos(); ;
        }

        public Task<IdentityResult> Salvar(Permissao permissao)
        {
            Task<IdentityResult> result = _permissaoRepository.Salvar(permissao);
            SaveChangesApp();
            return result;
        }

        public async Task<bool> ExistePermissao(string permissao)
        {
            return await _permissaoRepository.ExistePermissao(permissao);
        }

        public Permissao PesquisarPorId(string id)
        {
            return _permissaoRepository.PesquisarPorId(id);
        }

        public void Excluir(string id)
        {
            _permissaoRepository.Excluir(PesquisarPorId(id));
            SaveChangesApp();
        }

        public void Atualizar(Permissao permissao)
        {
            _permissaoRepository.Atualizar(permissao);
            SaveChangesApp();
        }
    }
}
