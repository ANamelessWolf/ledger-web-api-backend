using Nameless.Ledger.BI;

namespace Nameless.Ledger.BI.Services.Interfaces
{
    public interface IContextAccesible
    {
        public NamelessBIContext Context { get; }
    }
}
