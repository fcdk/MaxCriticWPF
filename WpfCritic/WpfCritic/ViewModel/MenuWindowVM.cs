﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
