using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDAL
{
    /// <summary>
    /// 抽象工厂类
    /// </summary>
    public interface IServiceFactory
    {
        ICollectThemeService createICollectThemeService();
        IConcernService createIConcernService();
        ICriticismService createICriticismService();
        IDivisionService createIDivisionService();
        IMemberService createIMemberService();
        IMessageService createIMessageService();
        IThemeService createIThemeService();
        IUserInfoService createIUserInfoService();
        IAdministratorService createIAdministrator();
        IBulletinService createIBulletin();
        IModeratorService createIModerator();
        INewsService createINews();
        
    }
}
