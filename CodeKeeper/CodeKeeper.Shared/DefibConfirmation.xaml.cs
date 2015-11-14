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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Codekeeper
{
    public sealed partial class DefibConfirmation : UserControl
    {
        public string ResusicationType { get; set; }
        public string TimeRecorded { get; set; }
        public DefibConfirmation()
        {
            this.InitializeComponent();
        }

        public DefibConfirmation(string time) : this()
        {
            lblDefibTime.Text = time;
            TimeRecorded = lblDefibTime.Text;
            ResusicationType = "IV";
        }

        private void cbResuscitationType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbResuscitationType != null)
            {
                ResusicationType = ((ComboBoxItem)cbResuscitationType.SelectedValue).Content.ToString();
            }
        }
    }
}
