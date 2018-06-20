using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Member : BaseModel
    {
        private string memberId;//会员id
        private string userInfoId;//用户id
        private string memberState;//会员状态

        public string MemberId
        {
            get { return memberId; }
            set
            {
                if (value.Length == 10)
                {
                    memberId = value;
                }
                else
                {
                    IsError = true;
                }
            }
        }
        public string UserInfoId
        {
            get { return userInfoId; }
            set
            {
                if (value.Length == 9)
                {
                    userInfoId = value;
                }
                else
                {
                    IsError = true;
                }
            }
        }
        public string MemberState
        {
            get { return memberState; }
            set
            {
                if (value == "正常" || value == "冻结")
                {
                    memberState = value;
                }
                else
                {
                    IsError = true;
                }
            }
        }
        public string Name { get; set; }//姓名
        public string Pwd { get; set; }//密码
        public int Xp { get; set; }//经验值
        public string Picture { get; set; }//头像
        public bool IsOnline { get; set; }//是否在线
        public DateTime FreezeDeadtime { get; set; }//封禁截止日期
        public DateTime LasttimeOnline { get; set; }//最近登录时间

    }
}
