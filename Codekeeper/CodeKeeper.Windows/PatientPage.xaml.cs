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
    public sealed partial class PatientPage : CodePage
    {
        public PatientPage()
        {
            this.InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            CurrentPatientInfo.FirstName = txtFirstName.Text;
            CurrentPatientInfo.LastName = txtLastName.Text;
            CurrentPatientInfo.Gender = comboBoxGender.SelectedValue.ToString();
            CurrentPatientInfo.DOB = dpDOB.Date;
            CurrentPatientInfo.SSN = txtSSN.Text;

            var element = Report.GetElementsByTagName("FirstName").FirstOrDefault();
            if (element == null)
            {
                element = Report.CreateElement("FirstName");
                PatientInfoElement.AppendChild(element);
            }
            element.InnerText = CurrentPatientInfo.FirstName;
            element = Report.GetElementsByTagName("LastName").FirstOrDefault();
            if (element == null)
            {
                element = Report.CreateElement("LastName");
                PatientInfoElement.AppendChild(element);
            }
            element.InnerText = CurrentPatientInfo.LastName;
            element = Report.GetElementsByTagName("Gender").FirstOrDefault();
            if (element == null)
            {
                element = Report.CreateElement("Gender");
                PatientInfoElement.AppendChild(element);
            }
            element.InnerText = CurrentPatientInfo.Gender;
            element = Report.GetElementsByTagName("DOB").FirstOrDefault();
            if (element == null)
            {
                element = Report.CreateElement("DOB");
                PatientInfoElement.AppendChild(element);
            }
            element.InnerText = CurrentPatientInfo.DOB.ToString();
            element = Report.GetElementsByTagName("SSN").FirstOrDefault();
            if (element == null)
            {
                element = Report.CreateElement("SSN");
                PatientInfoElement.AppendChild(element);
            }
            element.InnerText = CurrentPatientInfo.SSN;
        }
    }
}
