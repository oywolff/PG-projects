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
    public partial class Edit : System.Web.UI.Page
    {
		protected Kampanjer.Models.KampanjeContext _db = new Kampanjer.Models.KampanjeContext();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // This is the Update methd to update the selected Keyword item
        // USAGE: <asp:FormView UpdateMethod="UpdateItem">
        public void UpdateItem(int  KeywordID)
        {
            using (_db)
            {
                var item = _db.Keywords.Find(KeywordID);

                if (item == null)
                {
                    // The item wasn't found
                    ModelState.AddModelError("", String.Format("Item with id {0} was not found", KeywordID));
                    return;
                }

                TryUpdateModel(item);

                if (ModelState.IsValid)
                {
                    // Save changes here
                    _db.SaveChanges();
                    Response.Redirect("../Default");
                }
            }
        }

        // This is the Select method to selects a single Keyword item with the id
        // USAGE: <asp:FormView SelectMethod="GetItem">
        public Kampanjer.Models.Keyword GetItem([FriendlyUrlSegmentsAttribute(0)]int? KeywordID)
        {
            if (KeywordID == null)
            {
                return null;
            }

            using (_db)
            {
                return _db.Keywords.Find(KeywordID);
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
