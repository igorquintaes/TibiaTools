using SimpleInjector;
using System;
using System.Windows.Forms;
using TibiaTools.Application.Forms;
using TibiaTools.Application.Forms.LootSplitter;
using TibiaTools.Application.Helpers;
using TibiaTools.Application.Helpers.Contracts;
using TibiaTools.Core.Services;
using TibiaTools.Core.Services.Contracts;
using TibiaTools.Database.Repositories;
using TibiaTools.Domain.Contracts.Repositories;

namespace TibiaTools.Application
{
    static class Program
    {
        private static Container _container;

        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            SimpleInjector();

            System.Windows.Forms.Application.Run(_container.GetInstance<Main>());
        }

        private static void SimpleInjector()
        {
            _container = new Container();
            _container.RegisterSingleton<Main>();
            _container.RegisterSingleton<IFormOpener, FormOpener>();
            _container.RegisterSingleton<IPathHelper, PathHelper>();
            _container.RegisterSingleton<IGroupCalculatorService, GroupCalculatorService>();
            _container.RegisterSingleton<IItemRepository, ItemRepository>();
            _container.Verify();
        }
    }
}
