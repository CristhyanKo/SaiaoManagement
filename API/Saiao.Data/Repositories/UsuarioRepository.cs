using Saiao.Common.Exception;
using Saiao.Common.Resources;
using Saiao.Common.Security;
using Saiao.Data.DataContext;
using Saiao.Domain.Contract.Repositories;
using Saiao.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Saiao.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly SaiaoDataContext _db;
        public UsuarioRepository(SaiaoDataContext context) => _db = context;

        public IRepositoryClassBase Alterar(IRepositoryClassBase classe)
        {
            var usuario = (Usuario)classe;
            ValidaDuplicidade(usuario);

            _db.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();

            return usuario;
        }

        public List<IRepositoryClassBase> Buscar() { return _db.Usuarios.ToList<IRepositoryClassBase>(); }
        public IRepositoryClassBase Buscar(Guid id) { return _db.Usuarios.FirstOrDefault(coluna => coluna.Id == id); }
        public void Dispose() => _db.Dispose();

        public void Excluir(Guid id)
        {
            _db.Usuarios.Remove(_db.Usuarios.Find(id));
            _db.SaveChanges();
        }

        public IRepositoryClassBase Incluir(IRepositoryClassBase classe)
        {
            var usuario = (Usuario)classe;

            ValidaDuplicidade(usuario);

            _db.Usuarios.Add(usuario);
            _db.SaveChanges();

            return usuario;
        }

        public void EfetuaLogin(IRepositoryClassBase classe)
        {
            
        }

        private void ValidaDuplicidade(Usuario usuario)
        {
            var result = (from item in _db.Usuarios
                          where item.PessoaEmailId == usuario.PessoaEmailId && item.Id != usuario.Id
                          select item).FirstOrDefault();

            if (result != null)
                throw new DuplicidadeRegistroException(ErrorMessage.RegistroDuplicado);
        }

        public void AutenticaUsuario(Usuario usuario)
        {
            usuario.Senha = usuario.Senha.Encrypta();

            var usr = (from item in _db.Usuarios.Include(nameof(PessoaEmail))
                       where item.PessoaEmail.Email == (usuario.PessoaEmail.Email) && item.Senha == (usuario.Senha)
                       select item).FirstOrDefault();

            if (usr == null)
                throw new UsuarioInvalidoException(ErrorMessage.UsuarioNaoEncontrado);
        }
    }
}
