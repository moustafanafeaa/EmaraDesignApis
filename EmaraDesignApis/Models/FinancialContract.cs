using EmaraDesignWebApi.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmaraDesignApis.Models
{
    public class FinancialContract
    {
        public int Id { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Payed { get; set; }


        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Remaining { get; set; } 

        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public decimal RemainingAmount(decimal A,decimal P)
        {
            return A - P;
        }

    }
}
