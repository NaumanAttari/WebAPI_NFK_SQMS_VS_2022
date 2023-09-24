using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DataAccessLayer.Models.MasterInfo
{
    public  class tblSQMS_Master_LineNo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; set; }

        public string ProdLineNo { get; set; }

        public string Floor { get; set; }


    }
}
