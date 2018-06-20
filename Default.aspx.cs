using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Model.Bulletin> t = new List<Model.Bulletin>();
            Model.Bulletin b = new Model.Bulletin()
            {
                BulletinId = "00001",
                BulletinText = "15741的是",
                DivisionId = "0000100001",
                CreatTime = DateTime.Now,
                Title = "shishi"
            };
            for (int i = 0; i < 14; i++)
            {
                t.Add(b);
            }

            gvThemeList.DataSource = t;
            gvThemeList.DataBind();
        }
    }
}