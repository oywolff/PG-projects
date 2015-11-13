using System.ComponentModel.DataAnnotations;

namespace Kampanjer.Models
{
    public class ItemKeyword
    {
        [ScaffoldColumn(false)]
        public int ItemKeywordID { get; set; }

        [Required, StringLength(20), Display(Name = "Varenummer")]
        public string VendorItemNo { get; set; }
        public string ItemNo { get; set; }
        public int? KeywordID { get; set; }

        public virtual Keyword Keyword { get; set; }
    }
}