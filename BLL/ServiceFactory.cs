using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DAL;
using IDAL;

namespace BLL
{
    /// <summary>
    ///具体工厂类
    /// </summary>
    class ServiceFactory : IServiceFactory
    {
        public ICollectThemeService createICollectThemeService()
        {
            return new CollectThemeService();
        }
        public IConcernService createIConcernService()
        {
            return new ConcernService();
        }
        public ICriticismService createICriticismService()
        {
            return new CriticismService();
        }
        public IDivisionService createIDivisionService()
        {
            return new DivisionService();
        }
        public IMemberService createIMemberService()
        {
            return new MemberService();
        }
        public IMessageService createIMessageService()
        {
            return new MessageService();
        }
        public IThemeService createIThemeService()
        {
            return new ThemeService();
        }
        public IUserInfoService createIUserInfoService()
        {
            return new UserInfoService();
        }
        public IAdministratorService createIAdministrator()
        {
            return new AdministratorServer();
        }
        public IBulletinService createIBulletin()
        {
            return new BulletinServer();
        }
        public IModeratorService createIModerator()
        {
            return new ModeratorServer();
        }
        public INewsService createINews()
        {
            return new NewsServer();
        }
    }
}
