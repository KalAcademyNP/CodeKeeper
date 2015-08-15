using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void txtHour_TextChanged(object sender, TextChangedEventArgs e)
        {
            

        }

        private async void btnStart_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog md = new MessageDialog("Confirm the CPR start time?");
            md.Commands.Add(new UICommand("Yes"));
            md.Commands.Add(new UICommand("No"));
            await md.ShowAsync();

        }

 


    }
}
