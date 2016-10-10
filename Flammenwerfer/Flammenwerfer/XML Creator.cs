﻿using System;
using System.Xml;

namespace Flammenwerfer
{

    class XML_Creator
    {
        #region variable declaration

        Output cDisplayer = new Output();
        XMLPATH xPathFileLocation = new XMLPATH();
        string sPath = "";
        int iCourseCounter = 0;

        #endregion
            /*Logic for creating user from prompts requested*/
        #region Start User Creation

        public void instantiator()
        { //entry point of User Creation logic for XML
            Console.Clear();
            sPath = xPathFileLocation.Path;
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(sPath);
            CreateUser(xDoc);
        }

        public void CreateUser(XmlDocument xDoc)
        { //user creation logic
            XmlNode xStudent = xDoc.CreateElement("Student");
            // Start Node Filler Writer
            iCourseCounter = Int32.Parse(cDisplayer.ReadInfoDisplay("Number of courses student is taking:"));
            StudentIDNode(xDoc, xStudent);
            StudentFNNode(xDoc, xStudent);
            StudentLNNode(xDoc, xStudent);
            XmlNode xCourses = xDoc.CreateElement("Courses");
            XmlNode xCourse = xDoc.CreateElement("Course");
            for (int iCurrentCourse = 0; iCurrentCourse < iCourseCounter; iCurrentCourse++)
            {
                CourseIDNode(xDoc, xStudent);
                CourseNameNode(xDoc, xStudent);
                SemesterNode(xDoc, xStudent);
                CourseTypeNode(xDoc, xStudent);
                CourseGradeNode(xDoc, xStudent);
            }
            //End Node Filler Writer
            xDoc.DocumentElement.AppendChild(xCourses);
            xDoc.DocumentElement.AppendChild(xCourse);
            xDoc.DocumentElement.AppendChild(xStudent);
            xDoc.Save(sPath);
            Exit();
        }

        #endregion
         /*logic for leaving program when user finishes user creation*/
        #region Exit Prompt

        public void Exit()
        {// when user is created, exit program
            cDisplayer.DumbInfoDisplay("Please press any key to close program");
            Console.ReadKey();
            Environment.Exit(0);
        }

        #endregion
            /*XML node filling logic*/
        #region Node Writer FIller
        //prompts and writes information about student and classes taken to XML file
        private void StudentIDNode(XmlDocument xDoc, XmlNode xStudent)
        {
            XmlNode xSID = xDoc.CreateElement("SID"); //<SID>
            xSID.InnerText = cDisplayer.ReadInfoDisplay("Student ID number: "); //Input SID data
            xStudent.AppendChild(xSID); //</SID>
        }

        private void StudentFNNode(XmlDocument xDoc, XmlNode xStudent)
        {
            XmlNode xFName = xDoc.CreateElement("FName"); //<FName>
            xFName.InnerText = cDisplayer.ReadInfoDisplay("Student first name: "); //Input FName data
            xStudent.AppendChild(xFName); //</FName>
        }

        private void StudentLNNode(XmlDocument xDoc, XmlNode xStudent)
        {
            XmlNode xLName = xDoc.CreateElement("LName"); //<LName>
            xLName.InnerText = cDisplayer.ReadInfoDisplay("Student last name: "); //Input LName data
            xStudent.AppendChild(xLName); //</LName>
        }

        private void CourseIDNode(XmlDocument xDoc, XmlNode xStudent)
        {
            XmlNode xCourseID = xDoc.CreateElement("CourseID"); //<CourseID>
            xCourseID.InnerText = cDisplayer.ReadInfoDisplay("ID of course: "); //Input CourseID data
            xStudent.AppendChild(xCourseID); //</CourseID>
        }

        private void CourseNameNode(XmlDocument xDoc, XmlNode xStudent)
        {
            XmlNode xCourseName = xDoc.CreateElement("CourseName"); //<CourseName>
            xCourseName.InnerText = cDisplayer.ReadInfoDisplay("Name of course: "); //Input CourseName data
            xStudent.AppendChild(xCourseName); //</CourseName>
        }

        private void SemesterNode(XmlDocument xDoc, XmlNode xStudent)
        {
            XmlNode xSem = xDoc.CreateElement("Semester"); //<Semester>
            xSem.InnerText = cDisplayer.ReadInfoDisplay("Semester: "); //Input Semester data
            xStudent.AppendChild(xSem); //</Semester>
        }

        private void CourseTypeNode(XmlDocument xDoc, XmlNode xStudent)
        {
            XmlNode xCourseType = xDoc.CreateElement("CourseType"); //<CourseType>
            xCourseType.InnerText = cDisplayer.ReadInfoDisplay("type of course: "); //Input CourseType data
            xStudent.AppendChild(xCourseType); //</CourseType>
        }

        private void CourseGradeNode(XmlDocument xDoc, XmlNode xStudent)
        {
            XmlNode xCourseGrade = xDoc.CreateElement("CourseGrade"); //<CourseGrade>
            xCourseGrade.InnerText = cDisplayer.ReadInfoDisplay("Grade of course: "); //Input CourseGrade data
            xStudent.AppendChild(xCourseGrade); //</CourseGrade>
        }

        #endregion
    }
}
