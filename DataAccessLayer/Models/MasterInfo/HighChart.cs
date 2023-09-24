using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models.MasterInfo
{
    public class HighChart
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long id { get; set; }
        public string label { get; set; }

        public long  y { get; set; }

    }
}
