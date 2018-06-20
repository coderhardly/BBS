using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IDAL;
using Model;
using System.Data;

namespace BLL
{
    public class MemberManagement
    {
        static IMemberService IMS;
        static MemberManagement()
        {
            IServiceFactory isf = new ServiceFactory();
            IMS = isf.createIMemberService();
        }

        /// <summary>
        /// 查询会员是否存在
        /// </summary>
        /// <param name="MemberId">会员编号</param>
        /// <returns></returns>
        public static bool IsExist(string MemberId)
        {
            if (IMS.SelectNum(MemberId) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// 查询Member表中的所有数据
        /// </summary>
        /// <returns>返回DataTable对象</returns>
        public static DataTable ShowAll()
        {
            return IMS.Select();
        }
        /// <summary>
        /// 由账号查询会员信息
        /// </summary>
        /// <param name="MemberId">会员账号</param>
        /// <returns>返回Member对象</returns>
        public static Member ShowMember(string MemberId)
        {
            DataTable dt = IMS.Select(MemberId);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                Member member = new Member()
                {
                    MemberId = Convert.ToString(dt.Rows[0]["member_id"]),
                    Name = Convert.ToString(dt.Rows[0]["name"]),
                    Pwd = Convert.ToString(dt.Rows[0]["pwd"]),
                    Xp = Convert.ToInt32(dt.Rows[0]["xp"]),
                    Picture = Convert.ToString(dt.Rows[0]["picture"]),
                    IsOnline = Convert.ToBoolean(dt.Rows[0]["is_online"]),
                    FreezeDeadtime = Convert.ToDateTime(dt.Rows[0]["freeze_deadline"]),
                    LasttimeOnline = Convert.ToDateTime(dt.Rows[0]["lasttime_online"]),
                    UserInfoId = Convert.ToString(dt.Rows[0]["userInfo_id"]),
                    MemberState = Convert.ToString(dt.Rows[0]["member_state"])
                };
                return member;
            }
        }
        /// <summary>
        /// 根据编号查询所有会员信息
        /// </summary>
        /// <param name="MemberId"></param>
        /// <returns></returns>
        public static DataTable Select(string MemberId)
        {
            return IMS.Select(MemberId);
        }
        /// <summary>
        /// 添加会员
        /// </summary>
        /// <param name="member">会员信息</param>
        /// <returns>"会员已存在" "添加成功" "添加失败"</returns>
        public static string AddMember(Member member)
        {
            if (member.IsError)
            {
                return member.GetErrorMsg();
            }
            if (IsExist(member.MemberId))
            {
                return "会员已存在,不能重复添加";
            }
            if (IMS.Insert(member) == 1)
            {
                return "添加成功";
            }
            else
            {
                return "添加失败";
            }
        }
        /// <summary>
        /// 修改会员信息
        /// </summary>
        /// <param name="member">Member实体类</param>
        /// <returns>"会员不存在" "修改成功" "修改失败"</returns>
        public static string Update(Member member)
        {
            if (member.IsError)
            {
                return member.GetErrorMsg();
            }
            if (!IsExist(member.MemberId))
            {
                return "会员不存在";
            }
            if (IMS.Update(member) == 1)
            {
                return "修改成功";
            }
            else
            {
                return "修改失败";
            }
        }
        /// <summary>
        /// 由会员账号删除会员
        /// </summary>
        /// <param name="MemberId">会员账号</param>
        /// <returns></returns>
        public static string Delete(string MemberId)
        {
            Member member = new Member()
            {
                MemberId = MemberId
            };
            if (member.IsError)
            {
                return member.GetErrorMsg();
            }
            if (!IsExist(MemberId))
            {
                return "该会员不存在";
            }
            if (IMS.Delete(MemberId) == 1)
            {
                return "删除成功";
            }
            else
            {
                return "删除失败";
            }
        }
        public static DataTable SelectNPX(string MemberId)
        {
            return IMS.SelectNPX(MemberId);
        }
        /// <summary>
        /// 根据用户名模糊查询会员信息用于会员查询页面（四表join查询）
        /// </summary>
        /// <returns></returns>
        public static DataTable SelectMember(string key)
        {
            if (key == "")
            {
                return null;
            }
            return IMS.SelectMember(key);
        }

        /// <summary>
        /// 修改用户名
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string UpdateName(string memberId, string name)
        {
            Member member = new Member()
            {
                MemberId = memberId,
                Name = name
            };
            if (member.IsError)
            {
                return member.GetErrorMsg();
            }
            if (IMS.UpdateName(memberId, name) > 0)
            {
                return "修改用户名成功";
            }
            else
            {
                return "修改用户名失败";
            }
        }
        /// <summary>
        /// 修改头像
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="picture"></param>
        /// <returns></returns>
        public static string UpdatePicture(string memberId, string picture)
        {
            Member member = new Member()
            {
                MemberId = memberId,
                Picture=picture
            };
            if (member.IsError)
            {
                return member.GetErrorMsg();
            }
            if (IMS.UpdatePicture(memberId, picture) > 0)
            {
                return "修改用户头像成功";
            }
            else
            {
                return "修改用户头像失败";
            }
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="memberId">用户账号</param>
        /// <param name="oldPwd">旧密码</param>
        /// <param name="newPwd">新密码</param>
        /// <returns></returns>
        public static string UpdatePwd(string memberId, string oldPwd, string newPwd)
        {
            Member member = new Member()
            {
                MemberId = memberId,
                Pwd=newPwd
            };
            if (member.IsError)
            {
                return member.GetErrorMsg();
            }
            if (IMS.UpdatePwd(memberId,oldPwd,newPwd) > 0)
            {
                return "修改密码成功";
            }
            else
            {
                return "修改密码失败";
            }
        }
        /// <summary>
        /// 六表联合查询（调用需谨慎）
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public static DataTable SelectSixTable(string memberId)
        {
            return IMS.SelectSixTable(memberId);
        }
    }
}
