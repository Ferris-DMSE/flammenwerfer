using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace Flammenwerfer
{
    public class Query_Search
    {
        #region Properties and fields
        private bool usingGUI = false;
        private List<string> studentsFoundInQuery;
        public List<string> StudentsFoundInQuery { get { return studentsFoundInQuery; } }
        #endregion
        /// <summary>
        /// Constructor for using GUI
        /// </summary>
        /// <param name="usingGUI"></param>
        public Query_Search(bool usingGUI)
        {
            this.usingGUI = usingGUI;
        }
        /// <summary>
        /// Constructor for legacy code.
        /// </summary>
        public Query_Search() { }

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
            XMLPATH path = new XMLPATH();
            string spath = path.Path;
            xmlArchive.Load(spath);//loads the precreated xml doc,takes the path string found in the XML_Creator class
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
                    Console.WriteLine("search paramaters incorrect please see system analyst");
                    Console.ReadKey();
                    break;
            }

            foreach (XmlNode Node in XNList)
            {

                sArchiveSearch = Node[SearchNode].InnerText.ToLower();
                if (sArchiveSearch == sSearchParamater)//if the searched name equal and achieved name then sFoundStudent is filled with the the information from the archieve
                {
                    bStudentFound = true;
                    lFoundStudent.Add(Node["SID"].InnerText);
                    sSearchedUID = Node["SID"].InnerText;
                    lFoundStudent.Add(Node["FName"].InnerText);
                    lFoundStudent.Add(Node["LName"].InnerText);
                    foreach (XmlNode xNode in XNListCourses)
                    {
                        sArchiveUID = xNode["UID"].InnerText;
                        if (sArchiveUID == sSearchedUID)
                        {
                            iCourseCounter++;
                            lFoundStudent.Add(xNode["CourseID"].InnerText);
                            lFoundStudent.Add(xNode["CourseNumber"].InnerText);
                            lFoundStudent.Add(xNode["CourseName"].InnerText);
                            lFoundStudent.Add(xNode["Credits"].InnerText);
                            lFoundStudent.Add(xNode["Year"].InnerText);
                            lFoundStudent.Add(xNode["Semester"].InnerText);
                            lFoundStudent.Add(xNode["CourseType"].InnerText);
                            lFoundStudent.Add(xNode["CourseGrade"].InnerText);
                        }
                        lFoundStudent[0] = Convert.ToString(iCourseCounter);
                    }
                }
            }
            if (bStudentFound == true)
            {
                Output Displayer = new Output();
                if (usingGUI)
                {
                    studentsFoundInQuery = lFoundStudent;
                }

                else
                {
                    Displayer.InfoDisplay(lFoundStudent);
                    CommandInput input = new CommandInput();
                    input.InputReader();
                }


                
            }
            else
            {
                if (usingGUI)
                    return;
                else
                {
                    Output Display = new Output();
                    Display.DumbInfoDisplay("search failed");
                    Console.ReadKey();
                    CommandInput input = new CommandInput();
                    input.InputReader();
                }
                
            }
        }
    }
}
