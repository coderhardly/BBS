using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Web
{
    public class SomeMethod
    {
        /// <summary>
        /// 以弹窗形式向客户端发送提示信息
        /// </summary>
        /// <param name="csm">页面的Page.ClientScript属性</param>
        /// <param name="Msg">提示信息</param>
        public static void PrintMsgToClient(ClientScriptManager csm, string Msg)
        {
            if (!csm.IsClientScriptBlockRegistered(csm.GetType(), "Tip"))//检验是否已注册客户端脚本
            {
                //输出提示信息
                csm.RegisterStartupScript(csm.GetType(), "Tip", "<script>alert('" + Msg + "');</script>", false);
            }
        }
        /// <summary>
        /// 获得会员头像的路径
        /// </summary>
        /// <param name="obj">数据库中的头像文件名</param>
        /// <returns></returns>
        public static string GetUserPicPath(object obj)
        {
            string path = "Image/UserPic/";
            return path + Convert.ToString(obj);
        }
        /// <summary>
        /// 根据经验值计算的级并返回相应等级图片的路径
        /// </summary>
        /// <param name="xp">经验值</param>
        /// <returns></returns>
        public static string GetLevelPicPath(object xp)
        {
            //待完善
            string path = "/Image/ThemeDisplay/level.png";
            return path;
        }
        /// <summary>
        /// 判断用户是否登录,若否自动转到登录页面
        /// </summary>
        /// <param name="page">当前页面</param>
        public static void IfLogin(Page page)
        {
            if (page.Session["role"]==null)
            {
                page.Response.Redirect("~/Login.aspx");
            }
        }
        public static void IfAdmin(Page page)
        {
            if (Convert.ToString(page.Session["role"])!="管理员")
            {
                page.Response.Redirect("~/Login.aspx");
            }
        }
        public static void IfModerator(Page page)
        {
            if (page.Session["role"] != "版主")
            {
                page.Response.Redirect("~/Login.aspx");
            }
        }
        public static void IfMA(Page page)
        {
            if (Convert.ToString(page.Session["role"]) != "管理员" && Convert.ToString(page.Session["role"]) != "版主")
            {
                page.Response.Redirect("~/Login.aspx");
            }
        }
        public static string GetIndexPath()
        {
            return "Index.aspx";
        }
    }
}