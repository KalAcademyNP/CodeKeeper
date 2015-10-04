using Codekeeper.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Codekeeper
{
    public class CodePage:Page
    {
        public static CodePage Current;
        public static Code CurrentCode;
        public static Defibrillation CurrentDefibrillation;

        public CodePage()
        {
            Loaded += CodePage_Loaded;
        }

        void CodePage_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Current = this;
            AppBar timeTracker = new AppBar();
            timeTracker.Background = new SolidColorBrush(new Color { A = 33, R = 118, G = 15, B = 5 });
            var ttControl = new TimeTrackerControl();
            ttControl.CPRStartTime = CurrentCode.CPRStartTime.ToString(@"MM/dd/yyyy H\:mm");
            timeTracker.Content = ttControl;

            timeTracker.IsOpen = true;
            timeTracker.IsSticky = true;
            this.TopAppBar = timeTracker;
            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e != null && e.Parameter != null)
            {
                CurrentCode = e.Parameter as Code;
            }

            if (CurrentDefibrillation == null)
            {
                CurrentDefibrillation = new Defibrillation();
            }
            base.OnNavigatedTo(e);
        }
    }
}
