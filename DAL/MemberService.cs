using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;
using IDAL;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class MemberService : IMemberService
    {
        /// <summary>
        /// 查询所有记录
        /// </summary>
        /// <returns>返回DataTable对象</returns>
        public DataTable Select()
        {
            string sql = "select * from Member";
            return SqlHelper.GetTable(sql, null);
        }
        /// <summary>
        /// 根据编号查询Member
        /// </summary>
        /// <param name="MemberId"></param>
        /// <returns>返回DataTable对象</returns>
        public DataTable Select(string MemberId)
        {
            string sql = "select * from Member where member_id=@member_id";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@member_id",MemberId)
            };
            return SqlHelper.GetTable(sql, parameters);
        }
        /// <summary>
        /// 向Member表中插入数据
        /// </summary>
        /// <param name="member">Member</param>
        /// <returns>受影响的行数</returns>
        public int Insert(Member member)
        {
            string sql = "insert into Member(member_id,name,pwd,xp,picture,is_online,freeze_deadline,lasttime_online,userInfo_id,member_state) values(@member_id,@name,@pwd,@xp,@picture,@is_online,@freeze_deadline,@lasttime_online,@userInfo_id,@member_state)";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@member_id",member.MemberId),
                new SqlParameter("@name",member.Name),
                new SqlParameter("@pwd",member.Pwd),
                new SqlParameter("@xp",member.Xp),
                new SqlParameter("@picture",member.Picture),
                new SqlParameter("@is_online",member.IsOnline),
                new SqlParameter("@freeze_deadline",member.FreezeDeadtime),
                new SqlParameter("@lasttime_online",member.LasttimeOnline),
                new SqlParameter("@userInfo_id",member.UserInfoId),
                new SqlParameter("@member_state",member.MemberState)
            };
            return SqlHelper.ExecuteNonQuery(sql, parameters);
        }
        /// <summary>
        /// 根据memberId查询记录数量
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public int SelectNum(string memberId)
        {
            string sql = "select count(*) from Member where member_id=@memberId";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@memberId",memberId)
            };
            return (int)SqlHelper.ExecuteScaler(sql, parameters);
        }
        /// <summary>
        /// 修改会员Member信息
        /// </summary>
        /// <param name="member">会员Member</param>
        /// <returns>受影响的行数</returns>
        public int Update(Member member)
        {
            string sql = "update Member set name=@name,pwd=@pwd,xp=@xp,picture=@picture,freeze_deadline=@freeze_deadline,member_state=@member_state where member_id=@member_id";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@member_id",member.MemberId),
                new SqlParameter("@name",member.Name),
                new SqlParameter("@pwd",member.Pwd),
                new SqlParameter("@xp",member.Xp),
                new SqlParameter("@picture",member.Picture),
                new SqlParameter("@freeze_deadline",member.FreezeDeadtime),
                new SqlParameter("@member_state",member.MemberState)
            };
            return SqlHelper.ExecuteNonQuery(sql, parameters);
        }
        /// <summary>
        /// 修改用户名
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public int UpdateName(string memberId, string name)
        {
            string sql = "update Member set name=@name where member_id=@member_id ";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@name",name),
                new SqlParameter("@member_id",memberId)
            };
            return SqlHelper.ExecuteNonQuery(sql, parameters);
        }
        /// <summary>
        /// 修改头像
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="picture"></param>
        /// <returns></returns>
        public int UpdatePicture(string memberId, string picture)
        {
            string sql = "update Member set picture=@picture where member_id=@member_id ";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@picture",picture),
                new SqlParameter("@member_id",memberId)
            };
            return SqlHelper.ExecuteNonQuery(sql, parameters);
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="oldPwd"></param>
        /// <param name="newPwd"></param>
        /// <returns></returns>
        public int UpdatePwd(string memberId, string oldPwd,string newPwd)
        {
            string sql = "update Member set pwd=@newPwd where member_id=@member_id and pwd=@oldPwd";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@newPwd",newPwd),
                new SqlParameter("@member_id",memberId),
                new SqlParameter("@oldPwd",oldPwd)
            };
            return SqlHelper.ExecuteNonQuery(sql, parameters);
        }
        /// <summary>
        /// 根据会员memberId删除会员账号
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public int Delete(string memberId)
        {
            string sql = "delete from Member where member_id=@memberId";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@memberId",memberId)
            };
            return (int)SqlHelper.ExecuteNonQuery(sql, parameters);
        }
        /// <summary>
        /// 根据编号查询Member的name,picture,xp
        /// </summary>
        /// <param name="MemberId"></param>
        /// <returns>返回DataTable对象</returns>
        public DataTable SelectNPX(string MemberId)
        {
            string sql = "select name,picture,xp from Member where member_id=@member_id";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@member_id",MemberId)
            };
            return SqlHelper.GetTable(sql, parameters);
        }
        /// <summary>
        /// 根据用户名模糊查询会员信息用于会员查询页面（四表join查询）
        /// </summary>
        /// <param name="key">匹配的键值</param>
        /// <returns></returns>
        public DataTable SelectMember(string key)
        {
            string sql = "select A.member_id,A.name name,picture,xp,sex,clickNum,criticismNum,themeNum from (select Member.member_id,Member.name name,picture,xp,sex from Member,UserInfo where Member.userInfo_id=UserInfo.userInfo_id and member.name like '%'+@key+'%') as A left join (select creator,count(*) themeNum,sum(clicks) clickNum from Theme group by creator) as B on A.member_id=B.creator left join (select member_id,count(*) criticismNum from Criticism group by member_id) as C on A.member_id=C.member_id";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@key",key)
            };
            return SqlHelper.GetTable(sql, parameters);
        }
        /// <summary>
        /// 六表联合查询（调用需谨慎）
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public DataTable SelectSixTable(string memberId)
        {
            string sql = "select A.member_id member_id,picture,name,criticism_num,theme_num,concern_num,fans,motto from (select picture,Member.name name,member_id,motto from Member,UserInfo where Member.userInfo_id=UserInfo.userInfo_id and member_id=@member_id) as A left join (select member_id,count(*) criticism_num from Criticism group by member_id having member_id=@member_id) as B on A.member_id=B.member_id left join (select creator,count(*) theme_num from Theme group by creator having creator=@member_id) as C on A.member_id=C.creator left join (select concern_member,count(*) concern_num from Concern group by concern_member having concern_member=@member_id) as D on A.member_id=D.concern_member left join (select concern_to,count(*) fans from Concern group by concern_to having  concern_to=@member_id) as E on A.member_id=E.concern_to";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@member_id",memberId)
            };
            return SqlHelper.GetTable(sql, parameters);
        }
    }
}
