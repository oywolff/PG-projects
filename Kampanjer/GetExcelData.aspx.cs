using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;
using System.Data;
using Kampanjer.Models;
using System.Globalization;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


namespace Kampanjer
{
    public partial class GetExcelData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void addNøkkelord(ItemKeyword item)
        {
            if (ModelState.IsValid)
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    db.ItemKeywords.Add(item);
                    db.SaveChanges();
                }
            }
        }
        
        public int GetMaxKeywordID()
        {
            int i;
            var _db = new ApplicationDbContext();
            IQueryable<Keyword> query = _db.Keywords;
            i = query.Max(p => p.KeywordID);
            return i;
        }

        protected void PasteToGridView(object sender, EventArgs e)
        {
            // Create a NumberFormatInfo object and set some of its properties.
            NumberFormatInfo provider = new NumberFormatInfo();
            provider.NumberDecimalSeparator = ",";
            var item = new ItemKeyword(); 
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[2] { 
                new DataColumn("VendorItemNo", typeof(string)),
                new DataColumn("ItemNo", typeof(string))});
            string copiedContent = Request.Form[txtCopied.UniqueID];

            int Keywordnr;
            Keywordnr = GetMaxKeywordID();

            foreach (string row in copiedContent.Split('\n'))
            {
                if (!string.IsNullOrEmpty(row))
                {
                    dt.Rows.Add();
                    int i = 0;
                    foreach (string cell in row.Split('\t'))
                    {
                        dt.Rows[dt.Rows.Count - 1][i] = cell;
                        i++;
                    }
                    item.VendorItemNo = dt.Rows[dt.Rows.Count - 1][0].ToString();
                    item.ItemNo  = dt.Rows[dt.Rows.Count - 1][1].ToString();
                    item.KeywordID = Keywordnr; 
                    addNøkkelord(item);
                }
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
            txtCopied.Text = "";
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Kampanjer.Models.Keyword> NokkelOrdGridview_GetData()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            int Keywordnr;
            Keywordnr = GetMaxKeywordID();
            var query = db.Keywords.Where(e => e.KeywordID == Keywordnr);
            return query;
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void NokkelOrdGridview_UpdateItem(int id)
        {
            Kampanjer.Models.Keyword item = null;
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                // Save changes here, e.g. MyDataLayer.SaveChanges();

            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void NokkelOrdGridview_DeleteItem(int id)
        {

        }
    }
}