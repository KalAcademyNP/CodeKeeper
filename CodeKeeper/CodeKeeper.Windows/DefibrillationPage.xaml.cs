using Codekeeper.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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
    public sealed partial class DefibrillationPage : CodePage
    {
        private DefibConfirmation confirmationPage;
        private XmlElement childElement;
        public DefibrillationPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            DateTime tempTime = CurrentCode.CPRStartTime;
            for (int i = 1; i <= 30; i++)
            {
                tempTime = tempTime.AddMinutes(1);
                AddButton(tempTime);
            }

            Button b = new Button();
            b.Width = 1100;
            b.Height = 100;
            b.Content = "Now";
            b.Background = new SolidColorBrush(new Color { A = 100, R = 245, G = 124, B = 89 });
            b.Click += RecordDefibrillation_Click;
            outerStack.Children.Add(b);
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
            gridView.Items.Add(b);
        }

        private async void RecordDefibrillation_Click(object sender, RoutedEventArgs e)
        {
            var b = sender as Button;
            confirmationPage = new DefibConfirmation(b.Content.ToString());
            var customDialog = new CustomDialog(confirmationPage, "Confirm?");
            customDialog.HeaderBrush = new SolidColorBrush(Colors.Red);
            customDialog.Commands.Add(new UICommand("Yes", RecordResuscitation));
            customDialog.Commands.Add(new UICommand("No"));
            customDialog.DefaultCommandIndex = 0;
            customDialog.CancelCommandIndex = 1;
            var response = await customDialog.ShowAsync();
            if (response.Label == "Yes")
            {
                DefibElement.AppendChild(childElement);
            }
        }

        private void RecordResuscitation(IUICommand command)
        {
            var resuscitation = new Resuscitation
            {
                TimeRecorded = confirmationPage.TimeRecorded,
                TypeOfResuscitation = (ResuscitationType)Enum.Parse(typeof(ResuscitationType), confirmationPage.ResusicationType, true),
                Placed = "RightAC",
                Amount = 18
            };
            CurrentDefibrillation.Resuscitations.Add(resuscitation);
            childElement = Report.CreateElement("Resuscitation");
            childElement.SetAttribute("TimeRecorded", resuscitation.TimeRecorded);
            childElement.SetAttribute("TypeOfResuscitation", resuscitation.TypeOfResuscitation.ToString());
            childElement.SetAttribute("Placed", resuscitation.Placed);
            childElement.SetAttribute("Amount", resuscitation.Amount.ToString());
       }
    }
}
