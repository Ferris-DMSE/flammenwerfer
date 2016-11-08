﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flammenwerfer;

namespace FlammenwerferWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
            if (tbDisplay.Text == "debug") { btnTest.Visible = true; tbDisplay.Text = "Debug"; } //debug mode if you want to test something
            else //Normal Help button functionality
            {
                btnTest.Visible = false;
                tbDisplay.Text = "";
                tbDisplay.Text = "To search for a student simply select your search type, then enter in the required information. The students basic information as well as the course information will be displayed, and the course completion information is displayed on the far right.";
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string queryType;
            if (rbFirstName.Checked)
            {
                queryType = "fname";
            } else if (rbLastName.Checked)
            {
                queryType = "lname";
            }
            else
            {
                queryType = "sid";
            }

            Query_Search query = new Query_Search(true);
            query.Search(tbQuery.Text.ToLower(), queryType);
            if (query.StudentsFoundInQuery != null)
            {
                Output output = new Output(true);
                tbDisplay.Text = output.InfoDisplay(query.StudentsFoundInQuery, true);
                lblCoreComp.Text = "Core Completion: " + output.CourseTypes.CoreCompleted;
                lblElectiveComp.Text = "Elective Completion: " + output.CourseTypes.ElectivesCompleted;
                lblGenEdComp.Text = "GenEd Completion: " + output.CourseTypes.GenEdCompleted;
            }
            else
            {
                tbDisplay.Text = "No results found";
                lblCoreComp.Text = "Core Completion: ";
                lblElectiveComp.Text = "Elective Completion: ";
                lblGenEdComp.Text = "GenEd Completion: ";
            }
        }
    }
}
