using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flammenwerfer;
using LogThis;

namespace FlammenwerferWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Log.UseSensibleDefaults();
            Log.LogHeader(Log.LogName + ": Starting...", elogheaderlevel.Level_1);
            Log.LogThis("TODO: Redact Student Info other than Name and ID", eloglevel.info);
        }

        private void rbFirstName_CheckedChanged(object sender, EventArgs e)
        {
            lblInstruct.Visible = true;
            lblInstruct.Text = "Enter students first name";
        }

        private void rbLastName_CheckedChanged(object sender, EventArgs e)
        {
            lblInstruct.Visible = true;
            lblInstruct.Text = "Enter students last name";
        }

        private void rbID_CheckedChanged(object sender, EventArgs e)
        {
            lblInstruct.Visible = true;
            lblInstruct.Text = "Enter students I.D. #";
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            /* if (tbDisplay.Text == "debug") { btnTest.Visible = true; tbDisplay.Text = "Debug"; } //debug mode if you want to test something
             else //Normal Help button functionality
             {
                 btnTest.Visible = false;
                 tbDisplay.Text = "";
                 tbDisplay.Text = "To search for a student simply select your search type, then enter in the required information. The students basic information as well as the course information will be displayed, and the course completion information is displayed on the far right.";
             }*/

            btnTest.Visible = false;
            tbDisplay.Text = "";
            tbDisplay.Text = "To search for a student simply select your search type, then enter in the required information. The students basic information as well as the course information will be displayed, and the course completion information is displayed on the far right.";
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string queryType = getQueryTypeFromInput();
            performQuery(queryType);
        }
        #region Private Helper Methods
        private void performQuery(string queryType)
        {
            Query_Search query = new Query_Search(true);
            query.Search(tbQuery.Text.ToLower(), queryType);
            Log.LogThis("User Searched: " + tbQuery.Text, eloglevel.info);
            if (query.StudentsFoundInQuery != null)
            {
                Output output = new Output(true);
                tbDisplay.Text = output.InfoDisplay(query.StudentsFoundInQuery, true);


                foreach (string sStudentInfo in query.StudentsFoundInQuery)
                {
                    Log.LogThis("User Accessed Student Info: " + sStudentInfo, eloglevel.info);
                }
                lblCoreComp.Text = "Core Completion: " + output.CourseTypes.CoreCompleted;
                lblElectiveComp.Text = "Elective Completion: " + output.CourseTypes.ElectivesCompleted;
                lblGenEdComp.Text = "GenEd Completion: " + output.CourseTypes.GenEdCompleted;
                lblDegreeCompletion.Text = "Overall Class Completion: " + output.CourseTypes.OverallCourseCompleted;
            }
            else
            {
                tbDisplay.Text = "No results found";
                lblCoreComp.Text = "Core Class Completion: ";
                lblElectiveComp.Text = "Elective Class Completion: ";
                lblGenEdComp.Text = "GenEd Class Completion: ";
                lblDegreeCompletion.Text = "Overall Class Completion: ";
            }
        }

        private string getQueryTypeFromInput()
        {
            string queryType;
            if (rbFirstName.Checked)
            {
                queryType = "fname";
            }
            else if (rbLastName.Checked)
            {
                queryType = "lname";
            }
            else
            {
                queryType = "sid";
            }

            return queryType;
        }

        #endregion
    }
}
