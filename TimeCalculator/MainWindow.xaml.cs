using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TimeCalculator
{
    /// <summary>
    /// Authors: Group 1: Abhishek Sawant, Konrad Gaerdes, Rupal Pandya
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click_Convert(object sender, RoutedEventArgs e)
        {
            clocksmile.Visibility = Visibility.Visible;
            clockbroken.Visibility = Visibility.Hidden;
            try
            {
                float UI = float.Parse(UserInput.Text);
                if(UI < 60 && UI > 0){
                    float OP = UI * 1000;
                    Output.Text = $"{OP} Millisecond(s)";
                    OutputBorder.Visibility = Visibility.Visible;
                }
                else if (UI >= 60 && UI < 3600)
                { 
                    float UP = UI % 60;
                    float OP = (UI-UP) / 60;
                    Output.Text = $"{OP} Minute(s) {UP} Second(s)";
                    OutputBorder.Visibility = Visibility.Visible;
                }
                else if (UI >= 3600 && UI < 86400)
                {
                    float UP = UI % 3600;
                    float OP = (UI - UP) / 3600;
                    float IP = UP % 60;
                    float TP = (UP - IP) / 60;
                    Output.Text = $"{OP} Hour(s) {TP} Minute(s) {IP} Second(s)";
                    OutputBorder.Visibility = Visibility.Visible;
                }
                else if (UI >= 86400)
                {
                    float UP = UI % 86400;
                    float OP = (UI - UP) / 86400;
                    float IP = UP % 3600;
                    float TP = (UP - IP) / 3600;
                    float SP = IP % 60;
                    float KP = (IP - SP) / 60;
                    Output.Text = $"{OP} Day(s) {TP} Hour(s) {KP} Minutes(s) {SP} Second(s)";
                    OutputBorder.Visibility = Visibility.Visible;
                }
                else {
                    clocksmile.Visibility = Visibility.Hidden;
                    clockbroken.Visibility = Visibility.Visible;
                    MessageBoxResult xyz = MessageBox.Show("Please enter a valid input","Error");
                    if (xyz == MessageBoxResult.OK)
                    {
                        clocksmile.Visibility = Visibility.Visible;
                        clockbroken.Visibility = Visibility.Hidden;
                        UserInput.Text = null;
                        Output.Text = null;
                        OutputBorder.Visibility = Visibility.Hidden;
                    }
                }
            }
            catch {
                clocksmile.Visibility = Visibility.Hidden;
                clockbroken.Visibility = Visibility.Visible;
                MessageBoxResult xyz = MessageBox.Show("Please enter a valid input", "Error");
                if (xyz == MessageBoxResult.OK) 
                {
                    clocksmile.Visibility = Visibility.Visible;
                    clockbroken.Visibility = Visibility.Hidden;
                    UserInput.Text = null;
                    Output.Text = null;
                    OutputBorder.Visibility = Visibility.Hidden;
                }
            }
        }
        private void Button_Click_Clear(object sender, RoutedEventArgs e)
        {
            UserInput.Text = null;
            Output.Text = null;
            clocksmile.Visibility = Visibility.Visible;
            clockbroken.Visibility = Visibility.Hidden;
            OutputBorder.Visibility = Visibility.Hidden;
        }
    }
}
