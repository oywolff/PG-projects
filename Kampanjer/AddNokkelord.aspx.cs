using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Kampanjer.Models;

namespace Kampanjer
{
    public partial class AddNokkelord : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void addNøkkelord_InsertItem()
        {
            var item = new Kampanjer.Models.Keyword();
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                using (ApplicationDbContext db = new ApplicationDbContext ())
                {
                    db.Keywords.Add(item);
                    db.SaveChanges();
                    addNøkkelord.Visible = false;
                }


            }
        }

        protected void addNøkkelord_ItemInserted(object sender, FormViewInsertedEventArgs e)
        {
            Response.Redirect("~/GetExcelData");
            addNøkkelord.Visible = false;
        }

        protected void cancelButton_Click(object sender, EventArgs e)
        {
            addNøkkelord.Visible = false;
            Response.Redirect("~/");
        }

    }
}