﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using Kampanjer.Models;

namespace Kampanjer.Contacts
{
    public partial class Default : System.Web.UI.Page
    {
		protected Kampanjer.Models.ApplicationDbContext _db = new Kampanjer.Models.ApplicationDbContext();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // Model binding method to get List of Contacts entries
        // USAGE: <asp:ListView SelectMethod="GetData">
        public IQueryable<Kampanjer.Models.Contacts> GetData()
        {
            return _db.Contacts;
        }
    }
}

