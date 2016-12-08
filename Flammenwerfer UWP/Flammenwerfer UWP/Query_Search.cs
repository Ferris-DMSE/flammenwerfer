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
            lFoundStudent.Add(""); //used to be a placeholder for number of courses a student has on record
            string sArchiveSearch = "";//used to hold Searched Value found in the xml file
            string sArchiveUID = "";
            string sSearchedUID = "";
            bool bStudentFound = false;//will be set to true if student is found
            int iCourseCounter = 0;
            var spath = "..\\..\\..\\UserData.xml";
            var file = await StorageFile.GetFileFromPathAsync(spath);
            using (var stream = await file.OpenStreamForReadAsync())
            {
                XDocument xmlArchive = XDocument.Load(spath);
                var StudentList = xmlArchive.Element("Students").Elements("SID");
                var StudentListIndex = StudentList.Count();
                var CourseList = xmlArchive.Element("Courses").Elements("CourseID");
                var CourseListIndex = CourseList.Count();



                foreach (var item in StudentList)
                {
                    XName SearchParam = sSearchParamater;
                    sArchiveSearch = xmlArchive.Element("Student").Attribute(type).Value.ToString();
                    if (sArchiveSearch == sSearchParamater)//if the searched name equal and achieved name then sFoundStudent is filled with the the information from the archieve
                    {
                        bStudentFound = true;
                        sSearchedUID = xmlArchive.Element("Student").Attribute("SID").Value.ToString();
                        lFoundStudent.Add(sSearchedUID);
                        lFoundStudent.Add(xmlArchive.Element("Student").Attribute("FName").Value.ToString());
                        lFoundStudent.Add(xmlArchive.Element("Student").Attribute("LName").Value.ToString());
                        foreach (var Item in CourseList)
                        {
                            sArchiveUID = xmlArchive.Element("Course").Attribute("UID").Value.ToString();
                            if (sArchiveUID == sSearchedUID)
                            {
                                iCourseCounter++;
                                lFoundStudent.Add(xmlArchive.Element("Course").Attribute("CourseID").Value.ToString());
                                lFoundStudent.Add(xmlArchive.Element("Course").Attribute("CourseNumber").Value.ToString());
                                lFoundStudent.Add(xmlArchive.Element("Course").Attribute("CourseName").Value.ToString());
                                lFoundStudent.Add(xmlArchive.Element("Course").Attribute("Credits").Value.ToString());
                                lFoundStudent.Add(xmlArchive.Element("Course").Attribute("Year").Value.ToString());
                                lFoundStudent.Add(xmlArchive.Element("Course").Attribute("Semester").Value.ToString());
                                lFoundStudent.Add(xmlArchive.Element("Course").Attribute("CourseType").Value.ToString());
                                lFoundStudent.Add(xmlArchive.Element("Course").Attribute("CourseGrade").Value.ToString());
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
