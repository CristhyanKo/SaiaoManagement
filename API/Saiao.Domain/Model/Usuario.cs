using Saiao.Domain.Contract.Repositories;
using System;

namespace Saiao.Domain.Model
{
    public class Usuario : IRepositoryClassBase
    {
        public Guid Id { get; set; }
        public Guid PessoaId { get; set; }
        public Guid CargoId { get; set; }
        public string Senha { get; set; }
        public Guid PessoaEmailId { get; set; }

        public virtual Cargo Cargo { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        public virtual PessoaEmail PessoaEmail { get; set; }

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
