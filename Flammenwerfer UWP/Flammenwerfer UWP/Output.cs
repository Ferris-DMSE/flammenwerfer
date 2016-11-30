using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flammenwerfer
{
    // Dedicated results sub-class that can be arbitrarily instantiated to take in many results as well as add an easy way to use include helper methods to sort/manipulate results with little additional coding
    // Presently the XML Creator presorts the data on data entry and so presently no sorting is needed.
    public class CourseItem
    {
        public String sStudentID;
        public String sFirstName;
        public String sLastName;
        public String sCourseID;
        public String sCourseNbr;
        public String sCourseName;
        public String sCredits;
        public String sSemester;
        public String sCourseYear;
        public String sCourseType;
        public String sCourseGrade;

        //method used to display each instance of CourseItem's course details to the screen
        public void CourseWrite()
        {
            //Uncomment to re-show student information along with each class rather than simply before query results
            //Console.WriteLine("Student ID: " + sStudentID);
            //Console.WriteLine("Student Name: " + sLastName + ", " + sFirstName);
            Console.WriteLine("Course ID: " + sCourseID);
            Console.WriteLine("    Course Number: " + sCourseNbr);
            Console.WriteLine("    Course Name: " + sCourseName);
            Console.WriteLine("    Course Credits: " + sCredits);
            Console.WriteLine("    Semester: " + sSemester);
            Console.WriteLine("    Year: " + sCourseYear);
            Console.WriteLine("    Course Type: " + sCourseType);
            Console.WriteLine("    Course Grade: " + sCourseGrade);
            Console.WriteLine("========================================================================");
        }
    }

    //main output class which displays the query results
    class Output
    {
        //display student info from arbitrary array input
        //incoming list is formatted such that...
            //slot 0 is hard-coded to list the number of incoming query results
            //slot 1 is hard-coded as the queried student ID
            //slots 2 and 3 are hard-coded as the queried student's first and last name respectively
            //slots 4 and onward list queried course data of arbitrary length
        public void InfoDisplay(List<string> sFoundStudent)
        {
            //display number of results passed in from query
            Console.WriteLine("Number of entries found: " + sFoundStudent[0]);

            //display student name and ID before listing courses
            Console.WriteLine("Student ID: " + sFoundStudent[1]);
            Console.WriteLine("Student Name: " + sFoundStudent[3] + ", " + sFoundStudent[2]);
            Console.WriteLine("------------------------------------------------------------------------");

            //iterate through incoming list of course results into a placeholder instance of CourseItem and then call the CourseWrite method to display the info of each returned class
            CourseItem ciTempCourse = new CourseItem();
            for (int i = 4; i < sFoundStudent.Count - 1; i += 8)
            {
                ciTempCourse.sStudentID = sFoundStudent[1];
                ciTempCourse.sFirstName = sFoundStudent[2];
                ciTempCourse.sLastName = sFoundStudent[3];
                ciTempCourse.sCourseID = sFoundStudent[i];
                ciTempCourse.sCourseNbr = sFoundStudent[i + 1];
                ciTempCourse.sCourseName = sFoundStudent[i + 2];
                ciTempCourse.sCredits = sFoundStudent[i + 3];
                ciTempCourse.sCourseYear = sFoundStudent[i + 4];
                ciTempCourse.sSemester = sFoundStudent[i + 5];
                ciTempCourse.sCourseType = sFoundStudent[i + 6];
                ciTempCourse.sCourseGrade = sFoundStudent[i + 7];
                ciTempCourse.CourseWrite();
            }
            //Pause for user
            Console.ReadLine();
        }

        //dump any text output to console and return next command
        //USED BY INPUT - DO NOT DELETE
        public String ReadInfoDisplay(String sInString)
        {
            Console.Write(sInString);
            return Console.ReadLine();
        }

        //dump any text output to console without returning anything
        //USED BY INPUT - DO NOT DELETE
        public void DumbInfoDisplay(String sInString)
        {
            Console.WriteLine(sInString);
            Console.ReadLine();
        }

    }
}
