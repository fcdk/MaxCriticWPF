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
            // проверка на то, что лишь одно приложение запущено на одной машине
            bool createdNew;
            _instanceMutex = new Mutex(true, @"Global\ControlPanel", out createdNew);
            if (!createdNew)
            {
                _instanceMutex = null;
                Application.Current.Shutdown();
                return;
            }
            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            Logger.Instance.Dispose();

            if (_instanceMutex != null)
                _instanceMutex.ReleaseMutex();
            base.OnExit(e);
        }
    }
}
