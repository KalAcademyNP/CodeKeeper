using Codekeeper.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Xml.Dom;
using Windows.Storage;
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
        public static PatientInformation CurrentPatientInfo;
        public static Dictionary<string, bool> CurrentInterventions;
        public static XmlDocument Report;
        public static XmlElement CodeElement;
        public static XmlElement DefibElement;
        public static XmlElement PatientInfoElement;

        public CodePage()
        {
            if (CurrentInterventions == null)
            {
                CurrentInterventions = new Dictionary<string, bool>();
                CurrentInterventions.Add("Defibrillation", false);
                CurrentInterventions.Add("PatientInfo", false);
            }
            Loaded += CodePage_Loaded;
        }

        public async Task<string> SaveReport()
        {
            //var cf = await ApplicationData.Current.LocalFolder.CreateFolderAsync("Reports");
            var sf = await ApplicationData.Current.LocalFolder.GetFolderAsync("Reports");
            if (sf == null)
            {
                sf = await ApplicationData.Current.LocalFolder.CreateFolderAsync("Reports");
            }
            var fileName = string.Format("CodeReport_{0}_{1}_{2}", CurrentPatientInfo.FirstName, CurrentPatientInfo.LastName, CurrentCode.CPRStartTime.ToString()).Replace('/','_').Replace(':','_');
            var file = await sf.CreateFileAsync(fileName);
            await Report.SaveToFileAsync(file);
            return file.Path;
        }
        void CodePage_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Current = this;
            AppBar timeTracker = new AppBar();
            var homeButton = new Button();
            homeButton.Name = "btnHome";
            homeButton.Click += HomeButton_Click;
            homeButton.Content = "Home";
            var sPanel = new StackPanel();
            sPanel.Children.Add(homeButton);
            timeTracker.Background = new SolidColorBrush(new Color { A = 33, R = 118, G = 15, B = 5 });
            var ttControl = new TimeTrackerControl();
            ttControl.CPRStartTime = CurrentCode.CPRStartTime.ToString(@"MM/dd/yyyy H\:mm");
            sPanel.Children.Add(ttControl);
            timeTracker.Content = sPanel;

            timeTracker.IsOpen = true;
            timeTracker.IsSticky = true;
            this.TopAppBar = timeTracker;

            if (CurrentDefibrillation.Resuscitations == null)
            {
                CurrentDefibrillation.Resuscitations = new List<Resuscitation>();
            }
        }

        private void HomeButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(HomePage));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e != null && e.Parameter != null)
            {
                CurrentCode = e.Parameter as Code;
                if (CurrentCode != null)
                {
                    Report = new XmlDocument();
                    CodeElement = Report.CreateElement("Code");
                    CodeElement.SetAttribute("CPRStartTime", CurrentCode.CPRStartTime.ToString());
                    CodeElement.SetAttribute("CPREndTime", CurrentCode.CPREndTime.ToString());
                    DefibElement = Report.CreateElement("Defibrillation");
                    PatientInfoElement = Report.CreateElement("PatientInformation");
                    CodeElement.AppendChild(DefibElement);
                    CodeElement.AppendChild(PatientInfoElement);
                    Report.AppendChild(CodeElement);
                }
            }

            if (CurrentDefibrillation == null)
            {
                CurrentDefibrillation = new Defibrillation();
            }
            if (CurrentPatientInfo == null)
            {
                CurrentPatientInfo = new PatientInformation();
            }
            base.OnNavigatedTo(e);
        }
    }
}
