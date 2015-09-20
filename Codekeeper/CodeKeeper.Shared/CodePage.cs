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
        public Code CurrentCode { get; set; }

        public CodePage()
        {
            Loaded += CodePage_Loaded;
        }

        void CodePage_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Current = this;
            AppBar timeTracker = new AppBar();
            timeTracker.Background = new SolidColorBrush(new Color { A = 255, R = 0, G = 178, B = 240 });
            var ttControl = new TimeTrackerControl();
            ttControl.CPRStartTime = CurrentCode.CPRStartTime.ToString();
            timeTracker.Content = ttControl;

            timeTracker.IsOpen = true;
            timeTracker.IsSticky = true;
            this.TopAppBar = timeTracker;
            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e != null)
            {
                CurrentCode = e.Parameter as Code;
            }

            base.OnNavigatedTo(e);
        }
    }
}
