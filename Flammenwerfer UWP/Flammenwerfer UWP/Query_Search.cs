using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Xml.Dom;
//using System.Xml;
using Windows.Storage;
using System.IO;
using Windows.Storage.Streams;

namespace Flammenwerfer
{
    class Query_Search
    {

        private List<string> studentsFoundInQuery;
        public List<string> StudentsFoundInQuery { get { return studentsFoundInQuery; } }

        public void Search(string sSearchParamater, string type)
        {
            //type is to determine which of the 3 standard XML searchable types for user searching is possible

            List<string> lFoundStudent = new List<string>();//this list will be used to send the found information to the next class
            lFoundStudent.Add(""); //used to be a placeholder for number of courses a student has on record
            string sSearchedUID = ""; //store variable to searching UID variable
            bool bStudentFound = false;//will be set to true if student is found
            int iCourseCounter = 0;
            var rootpoint = Windows.ApplicationModel.Package.Current.InstalledLocation.Path;
            var spath = rootpoint + @"\UserData.xml";
            var xmlString = File.ReadAllText(spath);
            XmlDocument xmlArchive = new XmlDocument();
            xmlArchive.LoadXml(xmlString);//loads the precreated xml doc,takes the path string found in the XML_Creator class
            XmlNodeList XNList = xmlArchive.SelectNodes("/Students/Student");
            XmlNodeList XNListCourses = xmlArchive.SelectNodes("/Students/Student/Courses/Course");
            var typeNode = "/Students/Student/" + type;
            foreach (var Node in XNList)
            {
                if (Node.NodeName == type && Node.InnerText == sSearchParamater)
                {
                    bStudentFound = true;
                    switch(Node.NodeName)
                    {
                        case "SID":
                            lFoundStudent.Add(Node.InnerText);
                            sSearchedUID = Node.InnerText;
                            break;
                        case "FName":
                            lFoundStudent.Add(Node.InnerText);
                            break;
                        case "LName":
                            lFoundStudent.Add(Node.InnerText);
                            break;
                    }
                }
            }
            foreach (var xNode in XNListCourses)
            {
                if (xNode.NodeName == "UID" && xNode.InnerText == sSearchedUID)
                {
                    iCourseCounter++;
                    switch (xNode.NodeName)
                    {
                        case "CourseID":
                            lFoundStudent.Add(xNode.InnerText);
                            break;
                        case "CourseNumber":
                            lFoundStudent.Add(xNode.InnerText);
                            break;
                        case "CourseName":
                            lFoundStudent.Add(xNode.InnerText);
                            break;
                        case "Credits":
                            lFoundStudent.Add(xNode.InnerText);
                            break;
                        case "Year":
                            lFoundStudent.Add(xNode.InnerText);
                            break;
                        case "Semester":
                            lFoundStudent.Add(xNode.InnerText);
                            break;
                        case "CourseType":
                            lFoundStudent.Add(xNode.InnerText);
                            break;
                        case "CourseGrade":
                            lFoundStudent.Add(xNode.InnerText);
                            break;
                    }
                }
                lFoundStudent[0] = iCourseCounter.ToString();
            }
            //loads the precreated xml doc,takes the path string found in the XML_Creator class

            if (bStudentFound == true)
            {
                studentsFoundInQuery = lFoundStudent;
            }
        }

    }
}
