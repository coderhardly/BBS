using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using BLL;
using Model;
using System.IO;

namespace Web
{
    public partial class PersonUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SomeMethod.IfLogin(this.Page);
            if (!IsPostBack)
            {
                SomeMethod.IfLogin(this.Page);
                Bind();
            }
        }
        void Bind()
        {
            DataTable dt = UserInfoManagement.SelectInfo(Convert.ToString(Session["memberId"]));
            if (dt.Rows.Count == 1)
            {
                adress.Value = Convert.ToString(dt.Rows[0]["Addr"]);
                age.Value = Convert.ToString(dt.Rows[0]["Age"]);
                email.Value = Convert.ToString(dt.Rows[0]["Email"]);
                job.Value = Convert.ToString(dt.Rows[0]["Job"]);
                motto.Value = Convert.ToString(dt.Rows[0]["Motto"]);
                realname.Value = Convert.ToString(dt.Rows[0]["Name"]);
                phone.Value = Convert.ToString(dt.Rows[0]["Tel"]);
                radlSex.SelectedValue = Convert.ToString(dt.Rows[0]["Sex"]);
            }
            username.Value = Convert.ToString(Session["UserName"]);//绑定用户名

            dt=MemberManagement.SelectNPX(Convert.ToString(Session["memberId"]));//绑定头像
            if (dt.Rows.Count == 1)
            {
                pic.Attributes.Add("style", "background-image:url(" + SomeMethod.GetUserPicPath(dt.Rows[0]["picture"]) + ");");
            }
        }
        protected void subEdit_ServerClick(object sender, ImageClickEventArgs e)
        {
            //【1】修改个人信息
            UserInfo userInfo = new UserInfo()
            {
                Addr = adress.Value.Trim(),
                Age = Convert.ToInt32(age.Value.Trim()),
                Email = email.Value.Trim(),
                Job = job.Value.Trim(),
                Motto = motto.Value.Trim(),
                Name = realname.Value.Trim(),
                Tel = phone.Value.Trim(),
                Sex = radlSex.SelectedValue,
                UserInfoId = MemberManagement.ShowMember(Convert.ToString(Session["memberId"])).UserInfoId
            };
            SomeMethod.PrintMsgToClient(this.ClientScript, UserInfoManagement.UpdateUserInfo(userInfo));
            //【2】修改用户名
            string Msg=MemberManagement.UpdateName(Convert.ToString(Session["memberId"]),username.Value.Trim());
            if (Msg == "修改用户名成功")
            {
                Session["UserName"] = username.Value.Trim();
            }
            SomeMethod.PrintMsgToClient(this.ClientScript, Msg);
            Bind();
        }

        protected void ChangePwd_ServerClick(object sender, ImageClickEventArgs e)
        {
            string Msg=MemberManagement.UpdatePwd(Convert.ToString(Session["memberId"]), oldPwd.Value.Trim(), newpwd.Value.Trim());
            SomeMethod.PrintMsgToClient(this.ClientScript, Msg);
        }

        protected void subUpload_ServerClick(object sender, EventArgs e)
        {
            if (pic_upload.HasFile)
            {
                if (CheckFileType(pic_upload.FileName))
                {
                    string filename = DateTime.Now.ToString("yyyyMMddHHmmss") + pic_upload.FileName;
                    //用FileUpload.FileName属性得到上传文件名，也可以使用HttpPostedFile.FileName得到。  
                    string filePath = "~/Image/UserPic/" + filename;
                    //MapPath方法,检索虚拟路径（绝对的或相对的）或应用程序相关的路径映射到的物理路径。  
                    //FileUpload.SavaAs()方法用于把上传文件保存到文件系统中，也可以使用HttpPostedFile.SaveAs()方法。  
                    pic_upload.SaveAs(Server.MapPath(filePath));
                    MemberManagement.UpdatePicture(Convert.ToString(Session["memberId"]), filename);
                }
            }  
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
    }
}