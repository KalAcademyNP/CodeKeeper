using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Codekeeper
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DefibrillationPage : CodePage
    {
        public DefibrillationPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            DateTime tempTime = CurrentCode.CPRStartTime;
            for (int i = 0; i <= 30; i++)
            {
                Button b = new Button();
                b.Width = 100;
                b.Height = 100;
                b.Content = tempTime.TimeOfDay.ToString(@"hh\:mm");
                tempTime = tempTime.AddMinutes(1);
                lstButtons.Items.Add(b);

            }

            base.OnNavigatedTo(e);
        }
    }
}
