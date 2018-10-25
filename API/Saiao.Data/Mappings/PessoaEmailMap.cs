﻿using Saiao.Domain.Model;
using System.Data.Entity.ModelConfiguration;

namespace Saiao.Data.Mappings
{
    public class PessoaEmailMap : EntityTypeConfiguration<PessoaEmail>
    {
        public PessoaEmailMap()
        {
            ToTable(nameof(PessoaEmail));

            HasKey(coluna => coluna.Id);
            Property(coluna => coluna.Email).IsRequired();
            Property(coluna => coluna.Principal).IsRequired();
            Property(coluna => coluna.PessoaId).IsRequired();

            HasRequired(coluna => coluna.Pessoa);
        }
    }
}
