using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models.MasterInfo
{
    public class tblSQMS_Master_Faults
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; set; }

        public string Faults { get; set; }

        public bool Inline { get; set; }

        public bool EndLine { get; set; }

        public string FaultType { get; set; }

}
}
