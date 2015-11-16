using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using Kampanjer.Models;

namespace Kampanjer.ItemKeywords
{
    public partial class Default : System.Web.UI.Page
    {
		protected Kampanjer.Models.KampanjeContext _db = new Kampanjer.Models.KampanjeContext();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // Model binding method to get List of ItemKeyword entries
        // USAGE: <asp:ListView SelectMethod="GetData">
        public IQueryable<Kampanjer.Models.ItemKeyword> GetData()
        {
            return _db.ItemKeywords.Include(m => m.Keyword);
        }
    }
}

