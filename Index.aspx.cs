using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Text;
using System.Data;
using BLL;

namespace Web
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
            }
        }
        void Bind()
        {
            DataTable dt= MemberManagement.SelectNPX(Convert.ToString(Session["memberId"]));
            if (dt.Rows.Count>0)
            {
                pic.Attributes.Add("style", "background-image:url(" + SomeMethod.GetUserPicPath(dt.Rows[0]["picture"]) + ");");
            }
            int col = 3;//定义一行中显示的版块数
            StringBuilder sb = new StringBuilder();
            #region 动态生成版块列表
            dt = DivisionManagement.ShowAll();
            sb.Append("<table>");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (i % col == 0)
                {
                    sb.Append("<tr>");
                }
                //<td>
                //        <a href="ThemeList.aspx?divisionName=游戏">
                //            <img src="Image/Login/bg.jpg" />
                //        </a>
                //</td>
                sb.Append("<td><a href=\"ThemeList.aspx?divisionName=");
                sb.Append(dt.Rows[i]["division_name"]);//板块
                sb.Append("\"><img src=\"");
                sb.Append("Image/DivisionPic/"+dt.Rows[i]["division_picture"]);//图片
                sb.Append("\" title=\"");
                sb.Append(dt.Rows[i]["division_name"]);
                sb.Append("\" /></a></td>");
                if ((i + 1) % col == 0)
                {
                    sb.Append("</tr>");
                }
            }
            sb.Append("</table>");
            #endregion
            List.InnerHtml = Convert.ToString(sb);
        }
    }
}