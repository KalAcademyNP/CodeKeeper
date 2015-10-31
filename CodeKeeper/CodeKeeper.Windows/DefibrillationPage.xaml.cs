using Codekeeper.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using WinRTXamlToolkit.Controls;

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
                tempTime = tempTime.AddMinutes(1);
                AddButton(tempTime);
            }

            AddButton(DateTime.Now);
            base.OnNavigatedTo(e);
        }

        private void AddButton(DateTime tempTime)
        {
            Button b = new Button();
            b.Width = 100;
            b.Height = 100;
            b.Content = tempTime.TimeOfDay.ToString(@"hh\:mm");
            b.Background = new SolidColorBrush(new Color { A = 100, R = 245, G = 124, B = 89 });
            b.Click += RecordDefibrillation_Click;
            lstButtons.Items.Add(b);
        }

        private void RecordDefibrillation_Click(object sender, RoutedEventArgs e)
        {
            var b = sender as Button;
            var dialog = new InputDialog();
            var result = dialog.ShowAsync("Confirmation", "Confirm {0} {1} Placed in {2} at {3}",
                dialog.InputText, dialog.InputText, dialog.InputText, b.Content.ToString());
            CurrentDefibrillation.Resuscitations.Add(new Resuscitation
                { TimeRecorded = b.Content.ToString(),
                TypeOfResuscitation = ResuscitationType.IO,
                Placed = "RightAC", Amount = 18 });
        }
    }
}
