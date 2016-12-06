using Flammenwerfer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Flammenwerfer_UWP
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

        string QueryType = "";

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            string queryType = QueryType;
            performQuery(queryType);
        }

        private void performQuery(string queryType)
        {
            Query_Search query = new Query_Search();
            query.Search(textBox.Text.ToLower(), queryType);
            if (query.StudentsFoundInQuery != null)
            {
                Output outputter = new Output(true);
                output.Text = outputter.InfoDisplay(query.StudentsFoundInQuery);
                CoreValue.Text = outputter.CourseTypes.CoreCompleted;
                ElectiveValue.Text = outputter.CourseTypes.ElectivesCompleted;
                GenEdValue.Text = outputter.CourseTypes.GenEdCompleted;
                OverallValue.Text = outputter.CourseTypes.OverallCourseCompleted;
            }
            else
            {
                output.Text = "No results found";
                CoreValue.Text = " ";
                ElectiveValue.Text = " ";
                GenEdValue.Text = " ";
                OverallValue.Text = " ";
            }
        }

        private void HelpBtn_Click(object sender, RoutedEventArgs e)
        {
            output.Text = "";
            output.Text = "To search for a student simply select your search type, then enter in the required information. The students basic information as well as the course information will be displayed, and the course completion information is displayed on the far right.";
        }


        private void lnameRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            textBlock.Text = "Enter students last name";
        }

        private void sidRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            textBlock.Text = "Enter students I.D. #";

        }

        private void fnameRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            textBlock.Text = "Enter students first name";

        }
    }
}
