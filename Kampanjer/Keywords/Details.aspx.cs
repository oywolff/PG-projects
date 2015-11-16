using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using Microsoft.AspNet.FriendlyUrls.ModelBinding;
using Kampanjer.Models;

namespace Kampanjer.Keywords
{
    public partial class Details : System.Web.UI.Page
    {
		protected Kampanjer.Models.KampanjeContext _db = new Kampanjer.Models.KampanjeContext();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // This is the Select methd to selects a single Keyword item with the id
        // USAGE: <asp:FormView SelectMethod="GetItem">
        public Kampanjer.Models.Keyword GetItem([FriendlyUrlSegmentsAttribute(0)]int? KeywordID)
        {
            if (KeywordID == null)
            {
                return null;
            }

            using (_db)
            {
	            return _db.Keywords.Where(m => m.KeywordID == KeywordID).FirstOrDefault();
            }
        }

        protected void ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Cancel", StringComparison.OrdinalIgnoreCase))
            {
                Response.Redirect("../Default");
            }
        }
    }
}

