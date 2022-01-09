using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity.Lifetime;
using Unity;
using System.Reflection;
using ProductType.Database.Implements;
using ProductType.Database.Interfaces;
using System.IO;
using ProductPlugin;

namespace ProductTypesUserInterface
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        public static IPlugin ProductPlugin { get; set; }
        [STAThread]
        static void Main()
        {
            var file = Directory.GetFiles("Plugins")[0];
            foreach (var type in Assembly.LoadFrom(file).GetTypes())
            {
                if (!type.IsInterface && type.GetInterface("IPlugin") != null)
                {
                    ProductPlugin = (IPlugin)Activator.CreateInstance(type);
                }
            }
            var container = BuildUnityContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<MainForm>());
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IMemento, ProductMementoLogic>(new
                HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
