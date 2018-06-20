using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BLL;
using Model;
using System.Data;
using System.IO;

namespace Web
{
    public partial class DivisionSet : System.Web.UI.Page
    {
        string Msg;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            SomeMethod.IfAdmin(this);
            if (!IsPostBack)
            {
                Bind();
            }
        }
        protected void Page_PreRender()
        {
            DataBind();
        }

        Division GetDivision()
        {
            Division division = new Division()
            {
                DivisionId = txtDivisionId.Text.Trim(),
                DivisionName = txtDivisionName.Text.Trim(),
                DivisionPicture=uploadDivisionPicture()
            };
            return division;
        }
        /// <summary>
        /// 删除版块
        /// </summary>
        /// <param name="divisionId">版块编号</param>
        /// <returns>执行结果的提示信息</returns>
        string DeleteDivision(string divisionId)
        {
            Division division = new Division()
            {
                DivisionId = divisionId
            };
            if (division.IsError)
            {
                //参数格式错误
                return "参数格式错误";
            }
            else
            {
                return DivisionManagement.DeleteDivision(division.DivisionId);
            }
        }
        void Bind()//数据绑定
        {
            dt=DivisionManagement.ShowAll();
            lvDivision.DataSource = dt;
            lvDivision.DataBind();
            DataBind();
        }
        protected void btnCreateDivision_Click(object sender, EventArgs e)
        {
            Division division = GetDivision();
            Msg = DivisionManagement.CreateDivision(division);
            SomeMethod.PrintMsgToClient(this.ClientScript, Msg);
            Bind();
        }

        protected void btnEditDivision_Click(object sender, EventArgs e)
        {
            Division division = GetDivision();
            if (division.IsError)
            {
                //参数格式错误
                Msg="参数格式错误";
            }
            else
            {
                Msg = DivisionManagement.UpdateDivision(division);
            }
            Response.Write(Msg);
            Bind();
        }

        protected void btnDeleteDivision_Click(object sender, EventArgs e)
        {
            Msg = DeleteDivision(txtDivisionId.Text.Trim());
            SomeMethod.PrintMsgToClient(this.ClientScript, Msg);
        }

        protected void lvDivision_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            //获取按钮所在项的版块编号
            string divisionId = (lvDivision.Items[(e.Item.DataItemIndex)].FindControl("lblDivisionId") as Label).Text;
            if (e.CommandName == "Check")
            {
                txtDivisionId.Text = divisionId;
                txtDivisionName.Text = (lvDivision.Items[(e.Item.DataItemIndex)].FindControl("lblDivisionName") as Label).Text;
            }
            if (e.CommandName == "Del")
            {
                string Msg = DeleteDivision(divisionId);
                SomeMethod.PrintMsgToClient(this.ClientScript, Msg);
            }
            if (e.CommandName == "FindModerator")
            {
                Response.Redirect("~/BackgroundPages/MemberSet.aspx?DivisionId="+divisionId);
            }
            Bind();
        }

        #region 上传图片并返回文件名
        string uploadDivisionPicture()//上传版块图片
        {
            if (flulDivisionPicture.HasFile)
            {
                if (CheckFileType(flulDivisionPicture.FileName))
                {
                    string filename = DateTime.Now.ToString("yyyyMMddHHmmss") + flulDivisionPicture.FileName;
                    //用FileUpload.FileName属性得到上传文件名，也可以使用HttpPostedFile.FileName得到。  
                    string filePath = "~/Image/DivisionPic/" + filename;
                    //MapPath方法,检索虚拟路径（绝对的或相对的）或应用程序相关的路径映射到的物理路径。  
                    //FileUpload.SavaAs()方法用于把上传文件保存到文件系统中，也可以使用HttpPostedFile.SaveAs()方法。  
                    flulDivisionPicture.SaveAs(Server.MapPath(filePath));
                    return filename;
                }
                return "图片格式错误";
            }
            return "未上传图片";
        }
        bool CheckFileType(string fileName)
        {
            //GetExtension()方法返回指定的路径字符串的扩展名。  
            //Path类位于System.IO命名空间中，用于对包含文件或目录路径信息的 String 实例执行操作。  
            string ext = Path.GetExtension(fileName);
            switch (ext.ToLower())
            {
                case ".gif": return true;
                case ".png": return true;
                case ".jpg": return true;
                case ".jpeg": return true;
                default: return false;
            }
        }   
        #endregion
    }
}