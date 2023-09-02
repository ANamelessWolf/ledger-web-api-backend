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
        public const string CREDIT_CARD_NAME = "tarjetacredito";
        public const string VENDOR_NAME = "vendor";
        public const string CATEGORY_NAME = "category";
        public const string SUB_CATEGORY_NAME = "subcategory";

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

        public static void CreateCreditCardContext(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CreditCard>(entity =>
            {
                entity.ToTable(CREDIT_CARD_NAME);
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FinancingEntityId)
                    .HasColumnName("idEntidad");

                entity.Property(e => e.Name)
                    .HasColumnName("name");

                entity.Property(e => e.ShortName)
                    .HasColumnName("shortName");

                entity.Property(e => e.Credit)
                    .HasColumnName("credito");
                
                entity.Property(e => e.UsedCredit)
                    .HasColumnName("creditoUtilizado");

                entity.Property(e => e.ClosingDay)
                    .HasColumnName("diaCorte");

                entity.Property(e => e.DueDay)
                    .HasColumnName("diaLimitePago");

                entity.Property(e => e.EndingCardNumber)
                    .HasColumnName("terminacion");

                entity.Property(e => e.ExpirationDate)
                    .HasColumnName("expiration");

                entity.Property(e => e.CardType)
                    .HasColumnName("cardtype");

                entity.Property(e => e.Color)
                    .HasColumnName("color");
            });
        }

        public static void CreateVendor(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.ToTable(VENDOR_NAME);
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name)
                    .HasColumnName("vendorDescription");
            });
        }

        public static void CreateCategory(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable(CATEGORY_NAME);
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name)
                    .HasColumnName("categoria");
            });
        }

        public static void CreateSubCategory(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SubCategory>(entity =>
            {
                entity.ToTable(SUB_CATEGORY_NAME);
                entity.HasKey(e => e.Id);
                entity.Property(e => e.CategoryId)
                    .IsRequired()
                    .HasColumnName("idCategory");
                entity.Property(e => e.Name)
                    .HasColumnName("subCategoria");
            });
        }

    }
}
