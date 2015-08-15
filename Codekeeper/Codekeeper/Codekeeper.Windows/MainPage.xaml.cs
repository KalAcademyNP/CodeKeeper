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
            //Added validaiton for number
            //Sindhu - you add validation for 0-23 and also do similar checks for minutes
            uint hour;
            if (!uint.TryParse(txtHour.Text, out hour))
            {
                if (txtHour.Text.Length > 1)
                {
                    txtHour.Text = txtHour.Text.Substring(0, txtHour.Text.Length - 1);
                }
                else
                {
                    txtHour.Text = string.Empty;
                }
            }

        }

        private async void btnStart_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog md = new MessageDialog("Confirm the CPR start time?");
            md.Commands.Add(new UICommand("Yes", YesBtnClick));
            md.Commands.Add(new UICommand("No"));
            await md.ShowAsync();
        }

 
        private void YesBtnClick(IUICommand command)
        {
            //Sindhu - create a new instance of "Code" here and set its CPR start time to the time that was entered in the hour and minute box

        }

    }
}
