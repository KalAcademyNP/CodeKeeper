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
    public sealed partial class HomePage : CodePage
    {
        public HomePage()
        {
            this.InitializeComponent();
            if (CurrentInterventions["Defibrillation"])
            {
                BtnDefibrillation.Visibility = Visibility.Collapsed;
            }
            else
            {
                BtnDefibrillation.Visibility = Visibility.Visible;
            }
            if (CurrentInterventions["PatientInfo"])
            {
                BtnPatientInformation.Visibility = Visibility.Collapsed;
            }
            else
            {
                BtnPatientInformation.Visibility = Visibility.Visible;
            }
        }

        private void BtnDefibrillation_Click(object sender, RoutedEventArgs e)
        {
           CurrentInterventions["Defibrillation"] = true;
            BtnDefibrillation.Visibility = Visibility.Collapsed;
            this.Frame.Navigate(typeof(DefibrillationPage));
        }

        private void BtnPatientInformation_Click(object sender, RoutedEventArgs e)
        {
            CurrentInterventions["PatientInfo"] = true;
            BtnPatientInformation.Visibility = Visibility.Collapsed;
            this.Frame.Navigate(typeof(PatientPage));
        }

        private void BtnLoggedIntervention_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LoggedInterventionsPage));

        }
    }
}
