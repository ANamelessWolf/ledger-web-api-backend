using Microsoft.EntityFrameworkCore;
using Nameless.Ledger.Models;
using Nameless.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Ledger.BI.Context
{
    public static class CatalogueContext
    {
        public const string FINANCING_ENTITY_NAME = "entidadcrediticia";

        public static void CreateFinancingEntityContext(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FinancingEntity>(entity =>
            {
                entity.ToTable(FINANCING_ENTITY_NAME);
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FinancingType)
                    .IsRequired()
                    .HasColumnName("idFinancingType");
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("nombre");
                entity.Property(e => e.Description)
                    .HasColumnName("descripcion");
            });
        }
    }
}
