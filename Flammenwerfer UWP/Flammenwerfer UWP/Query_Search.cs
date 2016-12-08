using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Windows.Storage;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
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
            List<string> lFoundStudent = new List<string>();//this array will be used to send the found information to the next class
            lFoundStudent.Add(""); //used to 
            string sArchiveSearch = "";//used to hold FirstNames found in the xml file
            string sArchiveUID = "";
            string sSearchedUID = "";
            bool bStudentFound = false;//will be set to true if student is found
            int iCourseCounter = 0;
            string SearchNode = "";
            XDocument xmlArchive = new XDocument();
            var spath = @"C:/Users/domat/Source/Repos/flammenwerfer/Flammenwerfer UWP/ Flammenwerfer UWP/UserData.xml";
            XNamespace xpath = spath;
            //loads the precreated xml doc,takes the path string found in the XML_Creator class
            var Student = xmlArchive.Descendants(xpath + "Student").ToList();
            var Courses = xmlArchive.Descendants(xpath + "Course").ToList();

            switch (type)//here starts a check for each type of search(ID, First Name and Last Name)
            {
                case "sid":
                    SearchNode = "SID";
                    break;

                case "fname":
                    SearchNode = "FName";
                    break;

                case "lname":
                    SearchNode = "LName";
                    break;

                default: //If no type was properly selected
                    //Console.WriteLine("search paramaters incorrect please see system analyst");
                    //Console.ReadKey();
                    break;
            }

            foreach (var Node in Student)
            {
                sArchiveSearch = Node.Attribute(SearchNode).Value.ToString();
                if (sArchiveSearch == sSearchParamater)//if the searched name equal and achieved name then sFoundStudent is filled with the the information from the archieve
                {
                    bStudentFound = true;
                    sSearchedUID = Node.Attribute("SID").Value.ToString();
                    lFoundStudent.Add(sSearchedUID);
                    lFoundStudent.Add(Node.Attribute("FName").Value.ToString());
                    lFoundStudent.Add(Node.Attribute("LName").Value.ToString());
                    foreach (var xNode in Courses)
                    {
                        sArchiveUID = xNode.Attribute("UID").Value.ToString();
                        if (sArchiveUID == sSearchedUID)
                        {
                            iCourseCounter++;
                            lFoundStudent.Add(xNode.Attribute("CourseID").Value.ToString());
                            lFoundStudent.Add(xNode.Attribute("CourseNumber").Value.ToString());
                            lFoundStudent.Add(xNode.Attribute("CourseName").Value.ToString());
                            lFoundStudent.Add(xNode.Attribute("Credits").Value.ToString());
                            lFoundStudent.Add(xNode.Attribute("Year").Value.ToString());
                            lFoundStudent.Add(xNode.Attribute("Semester").Value.ToString());
                            lFoundStudent.Add(xNode.Attribute("CourseType").Value.ToString());
                            lFoundStudent.Add(xNode.Attribute("CourseGrade").Value.ToString());
                        }
                        lFoundStudent[0] = Convert.ToString(iCourseCounter);
                    }
                }
            }
            if (bStudentFound == true)
            {
                studentsFoundInQuery = lFoundStudent;
            }
        }
    }
}
