using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using WpfCritic.Core;
using WpfCritic.DataLayer;
using WpfCritic.ViewModel;
using WpfCritic.ViewModel.Data;

namespace WpfCritic.View
{
    public partial class MainMenuWindow : Window
    {
        private MainMenuWindowVM _viewModel = new MainMenuWindowVM();
        
        public MainMenuWindow()
        {
            InitializeComponent();

            DataContext = _viewModel;

            Logger.Info("MainMenuWindow.MainMenuWindow", "Екземпляр MainMenuWindow створений.");

            Entertainment[] moviesWithTrailers = Array.FindAll(Entertainment.GetRandomFirstTen(), (ent) => ent.TrailerLink != null && ent.TrailerLink != String.Empty);
            if (moviesWithTrailers.Length != 0)
            {
                Thread thread = new Thread(() =>
                {
                    EntertainmentDetailsWindow eDW = new EntertainmentDetailsWindow(new EntertainmentVM(moviesWithTrailers[0]));
                    eDW.Show();
                });
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
            }      
        }

    }
}
