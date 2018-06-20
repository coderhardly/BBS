using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class EditImformation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void subUpload_ServerClick(object sender, EventArgs e)
        {
            if (pic_upload.HasFile)
            {
                pic_upload.PostedFile.SaveAs(Server.MapPath("~/Image/UserPic/") + pic_upload.FileName);
            }
        }
    }
}