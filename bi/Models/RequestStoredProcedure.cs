using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace Nameless.Ledger.BI.Models
{
    public class RequestStoredProcedure
    {
        [Required]
        public string SpName { get; set; }
        public SqlParameter[] Parameters { get; set; }
        [Required]
        public string UserName { get; set; }
    }
}
