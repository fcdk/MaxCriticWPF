using WpfCritic.View;

namespace WpfCritic.ViewModel
{
    public class MenuWindowVM : ViewModelBase
    {
        internal void GamesShowButtonClick()
        {
            AllGamesWindow allGames = new AllGamesWindow();
            allGames.Show();
        }
    }
}
