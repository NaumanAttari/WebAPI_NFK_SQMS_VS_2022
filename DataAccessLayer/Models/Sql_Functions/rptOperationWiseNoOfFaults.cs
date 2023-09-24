using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models.Sql_Functions
{
    public class rptOperationWiseNoOfFaults
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; set; }
        public string Operation { get; set; }

        public long FaultyPCS { get; set; }

        public long TotalFaultyPCS { get; set; }

        public float FaultPer { get; set; }

    }
}
