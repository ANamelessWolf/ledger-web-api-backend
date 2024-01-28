using Microsoft.EntityFrameworkCore;
using Nameless.Ledger.Models;
using Nameless.Ledger.ModelTypes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Ledger.BI.Context
{
    public static class CreditCardOverviewContext
    {
        public const string CREDIT_CARD_OVERVIEW_NAME = "vw_creditcardoverview";
        /*
        public static void CreateCreditCardOverviewContext(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CreditCardOverview>(entity =>
            {
                entity.ToTable(CREDIT_CARD_OVERVIEW_NAME);
                entity.HasKey(e => e.Id);
                entity.Property(e => e.WalletId)
                    .HasColumnName("wallet_id");
                entity.Property(e => e.FinancingEntityId)
                    .HasColumnName("entity_id");
                entity.Property(e => e.Name)
                    .HasColumnName("card_name");
                entity.Property(e => e.FinancingEntity)
                    .HasColumnName("entity");
                entity.Property(e => e.Credit)
                    .HasColumnName("credit");
                entity.Property(e => e.UsedCredit)
                    .HasColumnName("use_credit");
                entity.Property(e => e.CutDate)
                    .HasColumnName("cut_date");
                entity.Property(e => e.DueDate)
                    .HasColumnName("pay_date");
                entity.Property(e => e.DaysToSpend)
                    .HasColumnName("days_to_spend");
                entity.Property(e => e.DaysToPay)
                    .HasColumnName("days_to_pay");
                entity.Property(e => e.ExpirationDate)
                    .HasColumnName("expiration");
                entity.Property(e => e.CardType)
                    .HasColumnName("card_type");
                entity.Property(e => e.EndingCardNumber)
                    .HasColumnName("ending");
                entity.Property(e => e.Color)
                    .HasColumnName("color");
            });
        }*/
    }
}
