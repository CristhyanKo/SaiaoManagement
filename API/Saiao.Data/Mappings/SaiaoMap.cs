﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Saiao.Data.Mappings
{
    public class SaiaoMap : EntityTypeConfiguration<Domain.Model.Saiao>
    {
        public SaiaoMap()
        {
            ToTable(nameof(Saiao));

            HasKey(coluna => coluna.Id);
            Property(coluna => coluna.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(coluna => coluna.UsuarioId).IsRequired();
            Property(coluna => coluna.Motivo).IsRequired();

            HasRequired(coluna => coluna.Usuario);
        }
    }
}
