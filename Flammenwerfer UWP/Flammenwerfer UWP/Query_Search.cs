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
            string sSearchedStudent = "";
            int index = 0;
            int caseOffset = 0;
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
            while (index < XNList.Count)
            {
                switch (type)
                {
                    case "FName":
                        sSearchedStudent = XNList[index].InnerText;
                        caseOffset = 1;
                        break;
                    case "LName":
                        sSearchedStudent = XNList[index].InnerText;
                        caseOffset = 2;
                        break;
                    case "SID":
                        sSearchedStudent = XNList[index].InnerText;
                        caseOffset = 0;
                        break;
                }
                if (sSearchedStudent == sSearchParamater)
                    break;
                index++;
            }
            lFoundStudent.Add(XNList[(index - caseOffset)].InnerText);
            sSearchedUID = XNList[(index - caseOffset)].InnerText;
            lFoundStudent.Add(XNList[(index - caseOffset + 1)].InnerText);
            lFoundStudent.Add(XNList[(index - caseOffset + 2)].InnerText);
            index = 0;
            caseOffset = 0;
            while (index < XNListCourses.Count)
            {
                if (XNListCourses[index].NodeName == "UID")
                {
                    if (XNListCourses[index].InnerText == sSearchedUID)
                    {
                        iCourseCounter++;
                        var coursedataindex = index + 1;
                        lFoundStudent.Add(XNListCourses[(coursedataindex)].InnerText);
                        coursedataindex++;
                        lFoundStudent.Add(XNListCourses[(coursedataindex)].InnerText);
                        coursedataindex++;
                        lFoundStudent.Add(XNListCourses[(coursedataindex)].InnerText);
                        coursedataindex++;
                        lFoundStudent.Add(XNListCourses[(coursedataindex)].InnerText);
                        coursedataindex++;
                        lFoundStudent.Add(XNListCourses[(coursedataindex)].InnerText);
                        coursedataindex++;
                        lFoundStudent.Add(XNListCourses[(coursedataindex)].InnerText);
                        coursedataindex++;
                        lFoundStudent.Add(XNListCourses[(coursedataindex)].InnerText);
                        coursedataindex++;
                        lFoundStudent.Add(XNListCourses[(coursedataindex)].InnerText);
                        coursedataindex++;

                    }
                }
                index++;
            }
            lFoundStudent[0] = iCourseCounter.ToString();
            //loads the precreated xml doc,takes the path string found in the XML_Creator class
            if (bStudentFound == true)
            {
                studentsFoundInQuery = lFoundStudent;
            }
        }

    }
}
