using Saiao.Domain.Contract.Repositories;
using System;

namespace Saiao.Domain.Model
{
    public class Usuario : IRepositoryClass
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public Guid CargoId { get; set; }
        public virtual Cargo Cargo { get; set; }

        public void CriaSenha(string senha, string reSenha) {
            ComparaSenhas(senha, reSenha);
            Senha = senha;
        }

        private void ComparaSenhas(string senha, string reSenha)
        {
            if (!(senha.Equals(reSenha)))
                throw new Exception("As senhas informadas não coincidem!");
        }
    }
}
