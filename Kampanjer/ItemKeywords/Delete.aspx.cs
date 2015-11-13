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

namespace Kampanjer.ItemKeywords
{
    public partial class Delete : System.Web.UI.Page
    {
		protected Kampanjer.Models.ApplicationDbContext _db = new Kampanjer.Models.ApplicationDbContext();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // This is the Delete methd to delete the selected ItemKeyword item
        // USAGE: <asp:FormView DeleteMethod="DeleteItem">
        public void DeleteItem(int ItemKeywordID)
        {
            using (_db)
            {
                var item = _db.ItemKeywords.Find(ItemKeywordID);

                if (item != null)
                {
                    _db.ItemKeywords.Remove(item);
                    _db.SaveChanges();
                }
            }
            Response.Redirect("../Default");
        }

        // This is the Select methd to selects a single ItemKeyword item with the id
        // USAGE: <asp:FormView SelectMethod="GetItem">
        public Kampanjer.Models.ItemKeyword GetItem([FriendlyUrlSegmentsAttribute(0)]int? ItemKeywordID)
        {
            if (ItemKeywordID == null)
            {
                return null;
            }

            using (_db)
            {
	            return _db.ItemKeywords.Where(m => m.ItemKeywordID == ItemKeywordID).Include(m => m.Keyword).FirstOrDefault();
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

