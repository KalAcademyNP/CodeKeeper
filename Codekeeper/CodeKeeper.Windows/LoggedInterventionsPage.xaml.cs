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
    public sealed partial class LoggedInterventionsPage : CodePage
    {
        public LoggedInterventionsPage()
        {
            this.InitializeComponent();
            if(CurrentInterventions["Defibrillation"])
            {
                BtnDefibrillation.Visibility = Visibility.Visible;
            }
            else
            {
                BtnDefibrillation.Visibility = Visibility.Collapsed;
            }
            if(CurrentInterventions["PatientInfo"])
            {
                BtnPatientInformation.Visibility = Visibility.Visible;
            }
            else
            {
                BtnPatientInformation.Visibility = Visibility.Collapsed;
            }
        }

        private void BtnDefibrillation_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(DefibrillationPage));
        }

        private void BtnPatientInformation_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PatientPage));
        }
    }
}
