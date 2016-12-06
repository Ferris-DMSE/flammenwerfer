using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Xml.Dom;
using Windows.Storage;

namespace Flammenwerfer
{
    class Query_Search
    {

        private List<string> studentsFoundInQuery;
        public List<string> StudentsFoundInQuery { get { return studentsFoundInQuery; } }

        public void Search(string sSearchParamater, string type)
        {
            List<string> lFoundStudent = new List<string>();//this array will be used to send the found information to the next class
            lFoundStudent.Add("");
            string sArchiveSearch = "";//used to hold FirstNames found in the xml file
            string sArchiveUID = "";
            string sSearchedUID = "";
            bool bStudentFound = false;//will be set to true if student is found
            int iCourseCounter = 0;
            string SearchNode = "";
            XmlDocument xmlArchive = new XmlDocument();
            var spath = ""; //NEEDS DATA TO FIX SFJSDLFKJWOTIGWESGKOSDJGO:IWJEGFTL:KSDJGFO:IEJGOIJDSGL:BVHJWEOIGFJEW:KFRJ(@#*$%&@()*%UO@#$IWERJFF@#$*(RU@O$IRFJL:@IDFJ@#*()7u5r)P@&%()@$*&%U(@*&$%)_@(#*$*)_@#(*$)_@#(&%(_*@#$&%T(_@*#U%$+)_@(#*$)@#(&*%_)(@#&*$%_()@#*&$-02897
            xmlArchive.LoadXml(spath); //loads the precreated xml doc,takes the path string found in the XML_Creator class
            XmlNodeList XNList = xmlArchive.SelectNodes("/Students/Student");
            XmlNodeList XNListCourses = xmlArchive.SelectNodes("/Students/Student/Courses/Course");

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

            foreach (IXmlNode Node in XNList)
            {
                var searchparam = "root/Students/Student/" + SearchNode;
                sArchiveSearch = Node.SelectSingleNode(searchparam).InnerText.ToLower();
                if (sArchiveSearch == sSearchParamater)//if the searched name equal and achieved name then sFoundStudent is filled with the the information from the archieve
                {
                    bStudentFound = true;
                    lFoundStudent.Add(Node.SelectSingleNode("root/Students/Student/SID").InnerText);
                    sSearchedUID = Node.SelectSingleNode("root/Students/Student/SID").InnerText;
                    lFoundStudent.Add(Node.SelectSingleNode("root/Students/Student/FName").InnerText);
                    lFoundStudent.Add(Node.SelectSingleNode("root/Students/Student/LName").InnerText);
                    foreach (IXmlNode xNode in XNListCourses)
                    {
                        sArchiveUID = xNode.SelectSingleNode("root/Students/Student/Courses/Course/UID").InnerText;
                        if (sArchiveUID == sSearchedUID)
                        {
                            iCourseCounter++;
                            lFoundStudent.Add(xNode.SelectSingleNode("root/Students/Student/Courses/Course/CourseID").InnerText);
                            lFoundStudent.Add(xNode.SelectSingleNode("root/Students/Student/Courses/Course/CourseNumber").InnerText);
                            lFoundStudent.Add(xNode.SelectSingleNode("root/Students/Student/Courses/Course/CourseName").InnerText);
                            lFoundStudent.Add(xNode.SelectSingleNode("root/Students/Student/Courses/Course/Credits").InnerText);
                            lFoundStudent.Add(xNode.SelectSingleNode("root/Students/Student/Courses/Course/Year").InnerText);
                            lFoundStudent.Add(xNode.SelectSingleNode("root/Students/Student/Courses/Course/Semester").InnerText);
                            lFoundStudent.Add(xNode.SelectSingleNode("root/Students/Student/Courses/Course/CourseType").InnerText);
                            lFoundStudent.Add(xNode.SelectSingleNode("root/Students/Student/Courses/Course/CourseGrade").InnerText);
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
