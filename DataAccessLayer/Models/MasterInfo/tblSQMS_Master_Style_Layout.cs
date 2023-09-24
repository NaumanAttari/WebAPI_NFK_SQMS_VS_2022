using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models.MasterInfo
{
    public class tblSQMS_Master_Style_Layout
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; set; }

        public string StyleNo { get; set; }

        public string OperationName { get; set; }

        public long OperationSequence { get; set; }

        public decimal PieceRate { get; set; }

        public decimal SAM { get; set; }


    }
}
