using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;
using System.Data;

namespace IDAL
{
    public interface IMemberService
    {
        System.Data.DataTable Select();
        System.Data.DataTable Select(string MemberId);
        int Insert(Member member);
        int SelectNum(string memberId);
        int Update(Member member);
        /// <summary>
        /// 修改用户名
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        int UpdateName(string memberId, string name);
        /// <summary>
        /// 修改头像
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="picture"></param>
        /// <returns></returns>
        int UpdatePicture(string memberId, string picture);
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="oldPwd"></param>
        /// <param name="newPwd"></param>
        /// <returns></returns>
        int UpdatePwd(string memberId, string oldPwd, string newPwd);
        int Delete(string memberId);
        /// <summary>
        /// 根据编号查询Member的name,name,xp
        /// </summary>
        /// <param name="MemberId"></param>
        /// <returns>返回DataTable对象</returns>
        DataTable SelectNPX(string MemberId);
        /// <summary>
        /// 根据用户名模糊查询会员信息用于会员查询页面（四表join查询）
        /// </summary>
        /// <param name="key">匹配的键值</param>
        /// <returns></returns>
        DataTable SelectMember(string key);
        /// <summary>
        /// 六表联合查询（调用需谨慎）
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        DataTable SelectSixTable(string memberId);
    }
}
