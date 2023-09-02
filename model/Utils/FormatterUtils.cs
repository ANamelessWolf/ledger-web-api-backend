using Nameless.Ledger.ModelTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Ledger.Utils
{
    public static class FormatterUtils
    {
        public static string GetHeader(this FinancingEntityType tp)
        {
            string header;
            switch (tp)
            {
                case FinancingEntityType.CENTRAL_BANKS:
                    header = Headers.CENTRAL_BANKS;
                    break;
                case FinancingEntityType.COMMERCIAL_BANKS:
                    header = Headers.COMMERCIAL_BANKS;
                    break;
                case FinancingEntityType.RETAIL_BANKS:
                    header = Headers.RETAIL_BANKS;
                    break;
                case FinancingEntityType.CREDIT_UNIONS:
                    header = Headers.CREDIT_UNIONS;
                    break;
                case FinancingEntityType.SAVINGS:
                    header = Headers.SAVINGS;
                    break;
                case FinancingEntityType.LOANS:
                    header = Headers.LOANS;
                    break;
                case FinancingEntityType.INVESTMENT_BANKS:
                    header = Headers.INVESTMENT_BANKS;
                    break;
                case FinancingEntityType.BROKERAGE_FIRMS:
                    header = Headers.BROKERAGE_FIRMS;
                    break;
                default:
                    header = Headers.NOT_ESPECIFIED;
                    break;
            }
            return header;
        }

        public static string GetHeader(this CardType tp)
        {
            string header;
            switch (tp)
            {
                case CardType.AMEX:
                    header = Headers.AMEX;
                    break;
                case CardType.MASTER_CARD:
                    header = Headers.MASTER_CARD;
                    break;
                case CardType.VISA:
                    header = Headers.VISA;
                    break;
                case CardType.OTHER:
                    header = Headers.Other;
                    break;
                default:
                    header = Headers.NOT_ESPECIFIED;
                    break;
            }
            return header;
        }



        public static CardType GetCardType(this string header)
        {
            CardType tp;
            tp = CardType.OTHER;
            if (header == Headers.AMEX)
                tp = CardType.AMEX;
            if (header == Headers.MASTER_CARD)
                tp = CardType.MASTER_CARD;
            if (header == Headers.VISA)
                tp = CardType.VISA;
            return tp;
        }
        public static FinancingEntityType GetFinancingEntityType(this string header)
        {
            FinancingEntityType tp;
            tp = FinancingEntityType.NOT_ESPECIFIED;
            if (header == Headers.CENTRAL_BANKS)
                tp = FinancingEntityType.CENTRAL_BANKS;
            if (header == Headers.COMMERCIAL_BANKS)
                tp = FinancingEntityType.COMMERCIAL_BANKS;
            if (header == Headers.RETAIL_BANKS)
                tp = FinancingEntityType.RETAIL_BANKS;
            if (header == Headers.CREDIT_UNIONS)
                tp = FinancingEntityType.CREDIT_UNIONS;
            if (header == Headers.SAVINGS)
                tp = FinancingEntityType.SAVINGS;
            if (header == Headers.LOANS)
                tp = FinancingEntityType.LOANS;
            if (header == Headers.INVESTMENT_BANKS)
                tp = FinancingEntityType.INVESTMENT_BANKS;
            if (header == Headers.BROKERAGE_FIRMS)
                tp = FinancingEntityType.BROKERAGE_FIRMS;
            return tp;
        }

    }
}
