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

        public async void Search(string sSearchParamater, string type)
        {
            List<string> lFoundStudent = new List<string>();//this array will be used to send the found information to the next class
            lFoundStudent.Add(""); //used to 
            string sArchiveSearch = "";//used to hold FirstNames found in the xml file
            string sArchiveUID = "";
            string sSearchedUID = "";
            bool bStudentFound = false;//will be set to true if student is found
            int iCourseCounter = 0;
            string SearchNode = "";
            var spath = "D:/UserData.xml";
            var file = await StorageFile.GetFileFromPathAsync(spath);
            using (var stream = await file.OpenStreamForReadAsync())
            {
                XDocument xmlArchive = XDocument.Load(spath);
                var StudentParamList = xmlArchive.Descendants("Students");
                var studentParamList = StudentParamList.ToArray();
                int studentcount = xmlArchive.Descendants("Student").Count();
                var CourseParamList = xmlArchive.Descendants("Courses");
                var courseParamList = CourseParamList.ToArray();
                int corsecount = xmlArchive.Descendants("Course").Count();

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

                    default:
                        SearchNode = "FName";
                        break;
                }

                for (int x = 0; x < studentcount; x++)
                {
                    sArchiveSearch = studentParamList[x].Attribute(SearchNode).Value.ToString();
                    if (sArchiveSearch == sSearchParamater)//if the searched name equal and achieved name then sFoundStudent is filled with the the information from the archieve
                    {
                        bStudentFound = true;
                        sSearchedUID = studentParamList[x].Attribute("SID").Value.ToString();
                        lFoundStudent.Add(sSearchedUID);
                        lFoundStudent.Add(studentParamList[x].Attribute("FName").Value.ToString());
                        lFoundStudent.Add(studentParamList[x].Attribute("LName").Value.ToString());
                        for (int i = 0; i < corsecount; i++)
                        {
                            sArchiveUID = courseParamList[i].Attribute("UID").Value.ToString();
                            if (sArchiveUID == sSearchedUID)
                            {
                                iCourseCounter++;
                                lFoundStudent.Add(courseParamList[i].Attribute("CourseID").Value.ToString());
                                lFoundStudent.Add(courseParamList[i].Attribute("CourseNumber").Value.ToString());
                                lFoundStudent.Add(courseParamList[i].Attribute("CourseName").Value.ToString());
                                lFoundStudent.Add(courseParamList[i].Attribute("Credits").Value.ToString());
                                lFoundStudent.Add(courseParamList[i].Attribute("Year").Value.ToString());
                                lFoundStudent.Add(courseParamList[i].Attribute("Semester").Value.ToString());
                                lFoundStudent.Add(courseParamList[i].Attribute("CourseType").Value.ToString());
                                lFoundStudent.Add(courseParamList[i].Attribute("CourseGrade").Value.ToString());
                            }
                            lFoundStudent[0] = Convert.ToString(iCourseCounter);
                        }
                    }
                }
            }
            //loads the precreated xml doc,takes the path string found in the XML_Creator class

            if (bStudentFound == true)
            {
                studentsFoundInQuery = lFoundStudent;
            }
        }
    }
}
