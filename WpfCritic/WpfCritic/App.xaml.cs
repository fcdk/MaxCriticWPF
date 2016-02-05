using System.Threading;
using System.Windows;
using WpfCritic.Core;

namespace WpfCritic
{
    public partial class App : Application
    {
        private Mutex _instanceMutex = null;

        protected override void OnStartup(StartupEventArgs e)
        {
            Logger.Info("App.OnStartup", "Програма стартувала.");

            // проверка на то, что лишь одно приложение запущено на одной машине
            bool createdNew;
            _instanceMutex = new Mutex(true, @"Global\ControlPanel", out createdNew);
            if (!createdNew)
            {
                _instanceMutex = null;
                Application.Current.Shutdown();
                return;
            }

            Logger.Info("App.OnStartup", "Перевірено, чи запущений лише один екземпляр програми на даній машині.");

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            Logger.Info("App.OnExit", "Програма завершує роботу.");
            Logger.Instance.Dispose();

            if (_instanceMutex != null)
                _instanceMutex.ReleaseMutex();
            base.OnExit(e);
        }
    }
}
