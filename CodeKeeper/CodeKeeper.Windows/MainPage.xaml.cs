﻿using Codekeeper.Models;
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
            uint hour; //uint means unsigned interger
            if (!uint.TryParse(txtHour.Text, out hour) || (hour < 0 || hour > 23))
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

        private void txtMinute_TextChanged(object sender, TextChangedEventArgs e)
        {
            uint minute;
            if (!uint.TryParse(txtMinute.Text, out minute) || (minute < 0 || minute >59))
            {
                if (txtMinute.Text.Length > 1)
                {
                    txtMinute.Text = txtMinute.Text.Substring(0, txtMinute.Text.Length - 1);
                }
                else
                {
                    txtMinute.Text = string.Empty;
                }
            }

        }

        private async void btnStart_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog md = new MessageDialog(string.Format("Confirm the CPR start time? {0}:{1}", txtHour.Text, txtMinute.Text)); 
            md.Commands.Add(new UICommand("Yes", YesBtnClick));
            md.Commands.Add(new UICommand("No"));
            await md.ShowAsync();
        }

 
        private void YesBtnClick(IUICommand command)
        {
            Code c = new Code();
            c.CPRStartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, int.Parse(txtHour.Text), int.Parse(txtMinute.Text), 0);

            this.Frame.Navigate(typeof(HomePage), c);
        }


    }
}
