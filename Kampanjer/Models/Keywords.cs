using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Kampanjer.Models
{
    public class Keyword
    {
        [ScaffoldColumn(false)]
        public int KeywordID { get; set; }

        [Required, StringLength(30), Display(Name = "Nøkkelord")]
        public string KeywordName { get; set; }

        public virtual ICollection<ItemKeyword> ItemKeyword { get; set; }
    }
}