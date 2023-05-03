// Author:
//  Mahyar Ghasemi Khah


using System;
using System.Text.RegularExpressions;
using static System.Console;
using System.Linq;

namespace studentDB
{
    internal class Program
    {
        // function that displays the table
        // takes 2 args (list to store student objects, text file that contains raw data)
        public static void displayDatabase(List<Student> students, string [] db)
        {
            // loops through db.txt and increment 8 per iteration
            // ( 8 lines of data per student )
            for (int i = 0; i < db.Length; i += 8)
            {
                students.Add(new Student()
                {
                    IdNum = Convert.ToDouble(db[i]),
                    StudentId = Convert.ToInt64(db[i + 1]),
                    FirstName = db[i + 2],
                    LastName = db[i + 3],
                    Major = db[i + 4],
                    PhoneNo = db[i + 5],
                    Gpa = Convert.ToDouble(db[i + 6]),
                    DateOfBirth = db[i + 7]

                });
            }

            wrapper(1);

            // formats output
            for (int i = 0; i < students.Count; i++)
            {

                WriteLine("{0}\t{1}\t{2}\t\t{3}\t\t{4}\t{5}\t{6}\t{7}", students[i].IdNum, students[i].StudentId,
                    students[i].FirstName, students[i].LastName, students[i].Major,
                    students[i].PhoneNo, students[i].Gpa.ToString("0.00"), students[i].DateOfBirth);

            }

            wrapper();

        }

        // Wrapper function with a default parameter value of 0
        public static void wrapper(int wrapperPosition = 0)
        {
            if (wrapperPosition >= 1)
            {
                WriteLine("ID\tStudent Id\tFirst name\t\tLast name\t\tMajor\t" +
                    "Phone number\tGPA\tDate of Birth");
                WriteLine("=====================================================" +
                        "===============================================================================");
            }
            else
            {
                WriteLine("=====================================================" +
                    "===============================================================================\n\n");
            }
        }

        static void Main(string[] args)
        {
            double gpa, gpaSearch;
            string firstName,lastName,major,majorSearch,phoneNum,dateOfBirth;
            int idNum;
            long studentId;

            string studentDatabase = "studentDatabase.txt";
            bool mainProgram = true;

            string majorPattern = @"[a-zA-Z][0-9][0-9][0-9]";
            Regex rgMajor = new Regex(majorPattern);
            string dateOfBirthPattern = @"(?i)((Jan(|uary)|Feb(|ruary)|Mar(|ch)|Apr(|il)|May|Jun(|e)|Jul(|y)|Aug(|ust)|Sept(|ember)|Oct(|ober)|(Nov|Dec)(|ember))([\s])(0?[1-9]|[1-2][0-9]|[3][0-1])(\s)([1-9][0-9][0-9][0-9]\b))";
            Regex rgDateOfBirth = new Regex(dateOfBirthPattern);

            while (mainProgram)
            {
                try
                {
                    WriteLine("GBC Student Database");
                    WriteLine("[1] View database\n[2] Add Student\n[3] Update Student\n[4] Delete Student\n[5] Exit");
                    double userInput = Convert.ToDouble(ReadLine());

                    var students = new List<Student>();
                    var db = File.ReadAllLines(studentDatabase);
                    List<string> updatedStudentData = new List<string>();
                    switch (userInput)
                    {
                        case 1:
                            
                            Clear();
                            displayDatabase(students, db);

                            WriteLine("[1] Sort\n[2] Search\n[3] Exit\n");
                            userInput = Convert.ToInt32(ReadLine());
                            if (userInput == 1)
                            {
                                WriteLine("[1] First name\n[2] Last name\n[3] GPA\n[4] Exit\n");
                                userInput = Convert.ToInt32(ReadLine());
                                if (userInput == 1)
                                {
                                    Clear();
                                    wrapper(1);


                                    // loops through the students' list and sorts them by their property FirstName
                                    List<Student> sortedFirstNames = students.OrderBy(firstName => firstName.FirstName).ToList();
                                    for (int i = 0; i < sortedFirstNames.Count; i++)
                                    {
                                        WriteLine("{0}\t{1}\t{2}\t\t{3}\t\t{4}\t{5}\t{6}\t{7}",
                                                    sortedFirstNames[i].IdNum, sortedFirstNames[i].StudentId,
                                                    sortedFirstNames[i].FirstName, sortedFirstNames[i].LastName, sortedFirstNames[i].Major,
                                                    sortedFirstNames[i].PhoneNo, sortedFirstNames[i].Gpa.ToString("0.00"), sortedFirstNames[i].DateOfBirth);
                                    }

                                    wrapper();
                                }
                                else if (userInput == 2)
                                {
                                    Clear();
                                    wrapper(1);

                                    // loops through the students' list and sorts them by their property LastName
                                    List<Student> sortedLastNames = students.OrderBy(lastName => lastName.LastName).ToList();
                                    for (int i = 0; i < sortedLastNames.Count; i++)
                                    {
                                        WriteLine("{0}\t{1}\t{2}\t\t{3}\t\t{4}\t{5}\t{6}\t{7}",
                                                    sortedLastNames[i].IdNum, sortedLastNames[i].StudentId,
                                                    sortedLastNames[i].FirstName, sortedLastNames[i].LastName, sortedLastNames[i].Major,
                                                    sortedLastNames[i].PhoneNo, sortedLastNames[i].Gpa.ToString("0.00"), sortedLastNames[i].DateOfBirth);
                                    }

                                    wrapper();
                                }
                                else if (userInput == 3)
                                {
                                    Clear();
                                    wrapper(1);

                                    // loops through the students' list and sorts them by their property Gpa
                                    List<Student> sortedGpa = students.OrderBy(gpa => gpa.Gpa).ToList();
                                    for (int i = 0; i < sortedGpa.Count; i++)
                                    {
                                        WriteLine("{0}\t{1}\t{2}\t\t{3}\t\t{4}\t{5}\t{6}\t{7}",
                                                    sortedGpa[i].IdNum, sortedGpa[i].StudentId,
                                                    sortedGpa[i].FirstName, sortedGpa[i].LastName, sortedGpa[i].Major,
                                                    sortedGpa[i].PhoneNo, sortedGpa[i].Gpa.ToString("0.00"), sortedGpa[i].DateOfBirth);
                                    }
                                    wrapper();
                                }
                                else if (userInput == 4)
                                {
                                    break;
                                }
                                else
                                {
                                    WriteLine("Invalid key, please try again!");
                                }

                            }
                            else if (userInput == 2)
                            {

                                WriteLine("[1] Student ID\n[2] Major\n[3] GPA");
                                userInput = Convert.ToInt32(ReadLine());
                                if (userInput == 1)
                                {
                                    WriteLine("Enter the student number that you want to search!\n");
                                    userInput = Convert.ToDouble(ReadLine());
                                    Clear();
                                    wrapper(1);
                                    for (int i = 0; i < students.Count; i++)
                                    {
                                        if (userInput == students[i].StudentId)
                                        {
                                            WriteLine("{0}\t{1}\t{2}\t\t{3}\t\t{4}\t{5}\t{6}\t{7}",
                                            students[i].IdNum, students[i].StudentId,
                                            students[i].FirstName, students[i].LastName, students[i].Major,
                                            students[i].PhoneNo, students[i].Gpa.ToString("0.00"), students[i].DateOfBirth);
                                            break;
                                        }
                                        else if(i == students.Count-1)
                                        {
                                            WriteLine("\t\t\t\t\t\t\tNo Student's found!");
                                            
                                        }
                                    }

                                    wrapper(0);
                                }
                                else if (userInput == 2)
                                {
                                    WriteLine("Enter the major that you want to search!\n");
                                    majorSearch = ReadLine();
                                    Clear();
                                    wrapper(1);
                                    int studentsFound = 0;
                                    for (int i = 0; i < students.Count; i++)
                                    {
                                        if (majorSearch == students[i].Major)
                                        {
                                            WriteLine("{0}\t{1}\t{2}\t\t{3}\t\t{4}\t{5}\t{6}\t{7}",
                                            students[i].IdNum, students[i].StudentId,
                                            students[i].FirstName, students[i].LastName, students[i].Major,
                                            students[i].PhoneNo, students[i].Gpa.ToString("0.00"), students[i].DateOfBirth);
                                            studentsFound++;
                                        }
                                        else if (i == students.Count - 1 && studentsFound == 0)
                                        {
                                            WriteLine("\t\t\t\t\t\t\tNo Student's found!");
                                            break;
                                        }
                                    }
                                    wrapper();

                                }
                                else if (userInput == 3)
                                {
                                    WriteLine("Enter the GPA you want to search");
                                    gpaSearch = Convert.ToDouble(ReadLine());
                                    WriteLine("\n\n[1] Higher\n[2] Lower\n");
                                    userInput = Convert.ToDouble(ReadLine());
                                    if(userInput == 1)
                                    {
                                        Clear();
                                        wrapper(1);
                                        int studentGpaFound = 0;
                                        for (int i = 0; i < students.Count; i++)
                                        {
                                            if (gpaSearch <= students[i].Gpa)
                                            {
                                                WriteLine("{0}\t{1}\t{2}\t\t{3}\t\t{4}\t{5}\t{6}\t{7}",
                                                students[i].IdNum, students[i].StudentId,
                                                students[i].FirstName, students[i].LastName, students[i].Major,
                                                students[i].PhoneNo, students[i].Gpa.ToString("0.00"), students[i].DateOfBirth);
                                                studentGpaFound++;
                                            }
                                            else if (i == students.Count - 1 && studentGpaFound == 0)
                                            {
                                                WriteLine("\t\t\t\t\t\t\tNo Student's found!");
                                            }


                                        }
                                        wrapper();
                                    }
                                    else if (userInput == 2)
                                    {
                                        Clear();
                                        wrapper(1);
                                        for (int i = 0; i < students.Count; i++)
                                        {
                                            if (gpaSearch >= students[i].Gpa)
                                            {
                                                WriteLine("{0}\t{1}\t{2}\t\t{3}\t\t{4}\t{5}\t{6}\t{7}",
                                                students[i].IdNum, students[i].StudentId,
                                                students[i].FirstName, students[i].LastName, students[i].Major,
                                                students[i].PhoneNo, students[i].Gpa.ToString("0.00"), students[i].DateOfBirth);
                                            }
                                            else if (i == students.Count - 1)
                                            {
                                                WriteLine("\t\t\t\t\t\t\tNo Student's found!");
                                                break;
                                            }
                                        }
                                        wrapper();
                                    }
                                    else
                                    {
                                        WriteLine("Invalid key, please try again!\n");
                                    }


                                }
                            }
                            else if (userInput == 3)
                            {
                                break;
                            }
                            else
                            {
                                Clear();
                                WriteLine("Invalid key, please try again!");
                            }

                            break;

                        case 2: 
                            displayDatabase(students, db); // initiates students list
                            Clear();

                            while (true)
                            {
                                try
                                {

                                    WriteLine("Enter Student ID [ 9 digits long ]\n");
                                    studentId = Convert.ToInt64(ReadLine());
                                    if (Convert.ToString(studentId).Length == 9)
                                    {
                                        // checks if studentId is already existing in the database
                                        if (students.Any(student => student.StudentId == studentId))
                                        {
                                            Clear();
                                            WriteLine("Student ID already exist, try a another one!");
                                        }
                                        else
                                        {
                                            break;
                                        }
    
                                    }
                                    else
                                    {
                                        Clear();
                                        WriteLine("Please enter a valid student id [ 9 digits long ]");

                                    }

                                }
                                catch (Exception e)
                                {

                                    if (e is OverflowException || e is FormatException)
                                    {
                                        Clear();
                                        WriteLine("Please enter a valid student id [ 9 digits long ]");

                                    }

                                }

                            }


                            WriteLine("Enter Student's first name\n");
                            firstName = ReadLine();
                            WriteLine("Enter Student's last name\n");
                            lastName = ReadLine();


                           
                            while (true)
                            {
                                try
                                {
                                    WriteLine("Enter Student's major [ 1 character and 3 digits ] :\n");
                                    major = ReadLine();
                                    if (rgMajor.IsMatch(major))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        WriteLine("Please enter a valid major [ 1 character and 3 digits ]");
                                    }

                                }
                                catch (OverflowException)
                                {

                                    Clear();
                                    WriteLine("Please enter a valid major [ 1 character and 3 digits ]");


                                }

                            }


                            while (true)
                            {
                                WriteLine("Enter Student's phone number:\n");
                                phoneNum = ReadLine();
                                if (phoneNum.Length == 10)
                                {
                                    break;
                                }
                                else
                                {
                                    WriteLine("Please enter a  valid phone number [ 10 digits ]");
                                }
                            }

                            WriteLine("Enter Student's GPA:\n");
                            gpa = Convert.ToDouble(ReadLine());
                            while (true)
                            {
                                try
                                {
                                    WriteLine("Enter Student's date of birth [mmm dd yyyy] :\n");
                                    dateOfBirth = ReadLine();
                                    if (rgDateOfBirth.IsMatch(dateOfBirth))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Clear();
                                        WriteLine("Please enter a valid date of birth [mmm dd yyyy]");
                                    }
                                }
                                catch (FormatException)
                                {
                                    Clear();
                                    WriteLine("Please enter a valid date of birth [mmm dd yyyy]");
                                }

                            }



                            // adds white space to first and last name to make their length uniform
                            // for table formmatting
                            if (firstName.Length != 12)
                            {
                                int numOfSpaces = 12 - firstName.Length;
                                firstName += String.Concat(Enumerable.Repeat(" ", numOfSpaces));
                            }
                            if (lastName.Length != 12)
                            {
                                int numOfSpaces = 12 - lastName.Length;
                                lastName += String.Concat(Enumerable.Repeat(" ", numOfSpaces));
                            }


                            db = File.ReadAllLines(studentDatabase);
                            try
                            {
                                idNum = Convert.ToInt32(db[db.Length - 8]) + 1;
                            }
                            catch (IndexOutOfRangeException)
                            {
                                idNum = 10000;
                            }


                            // stores user input data of the student to a array called studentData
                            string[] studentData = {idNum.ToString(),studentId.ToString(), firstName, lastName, major,
                        phoneNum,gpa.ToString(),dateOfBirth};


                            // Checks if the database exist or not, and writes the studentData into the database
                            if (File.Exists(studentDatabase))
                            {

                                File.AppendAllLines(studentDatabase, studentData);
                            }
                            else
                            {
                                File.WriteAllLines(studentDatabase, studentData);
                            }
                            break;
                        case 3:
                            Clear();

                            displayDatabase(students, db);

                            WriteLine("Enter the student number of the student you want to have changes!\n");
                            userInput = Convert.ToDouble(ReadLine());

                            // Checks wheter the userInput matches a student id on the database
                            for (int i = 0; i < students.Count; i++)
                            {
                                if (userInput == students[i].StudentId)
                                {
                                    WriteLine("Edit mode\nSelect what you want to edit");
                                    WriteLine("[1] Student Number\n[2] First name\n[3] Last name\n" +
                                        "[4] Major\n[5] Phone number\n[6] GPA\n[7] Date of Birth");
                                    userInput = Convert.ToDouble(ReadLine());
                                    switch (userInput)
                                    {
                                        case 1:
                                            WriteLine("Enter new value of Student Number:\n");
                                            studentId = Convert.ToInt32(ReadLine());
                                            if (Convert.ToString(studentId).Length == 9)
                                            {
                                                // checks if studentId is already existing in the database
                                                if (students.Any(student => student.StudentId == studentId))
                                                {
                                                    Clear();
                                                    WriteLine("Student ID already exist, try a another one!");
                                                    break;
                                                }
                                                else
                                                {
                                                    students[i].StudentId = studentId;
                                                    break;
                                                }

                                            }
                                            else
                                            {
                                                Clear();
                                                WriteLine("Please enter a valid student id [ 9 digits long ]");
                                                break;

                                            }
                                            break;

                                        case 2:
                                            WriteLine("Enter new value of First name:\n");
                                            firstName = ReadLine();
                                            if (firstName.Length != 12)
                                            {
                                                int numOfSpaces = 12 - firstName.Length;
                                                firstName += String.Concat(Enumerable.Repeat(" ", numOfSpaces));
                                                students[i].FirstName = firstName;
                                            }
                                            break;
                                        case 3:
                                            WriteLine("Enter new value of Last name:\n");
                                            lastName = ReadLine();
                                            if (lastName.Length != 12)
                                            {
                                                int numOfSpaces = 12 - lastName.Length;
                                                lastName += String.Concat(Enumerable.Repeat(" ", numOfSpaces));
                                                students[i].LastName = lastName;
                                            }
                                            break;
                                        case 4:
                                            while (true)
                                            {
                                                try
                                                {
                                                    WriteLine("Enter new value of Major [1 character and 3 digits]:\n");
                                                    major = ReadLine();
                                                    if (rgMajor.IsMatch(major))
                                                    {
                                                        students[i].Major = major;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        WriteLine("Please enter a valid major [ 1 character and 3 digits ]");
                                                    }

                                                }
                                                catch (OverflowException)
                                                {

                                                    Clear();
                                                    WriteLine("Please enter a valid major [ 1 character and 3 digits ]");


                                                }

                                            }
                                            break;
                                        case 5:
                                            while (true)
                                            {
                                                WriteLine("Enter new value of Phone Number:\n");
                                                phoneNum = ReadLine();
                                                if (phoneNum.Length == 10)
                                                {
                                                    students[i].PhoneNo = phoneNum;
                                                    break;
                                                }
                                                else
                                                {
                                                    WriteLine("Please enter a  valid phone number [ 10 digits ]");
                                                }
                                            }
                                            break;
                                        case 6:
                                            WriteLine("Enter new value of GPA:\n");
                                            gpa = Convert.ToDouble(ReadLine());
                                            students[i].Gpa = gpa;
                                            break;
                                        case 7:
                                            while (true)
                                            {
                                                try
                                                {
                                                    WriteLine("Enter Student's date of birth [mmm dd yyyy] :\n");
                                                    dateOfBirth = ReadLine();
                                                    if (rgDateOfBirth.IsMatch(dateOfBirth))
                                                    {
                                                        students[i].DateOfBirth = dateOfBirth;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        Clear();
                                                        WriteLine("Please enter a valid date of birth [mmm dd yyyy]");
                                                    }
                                                }
                                                catch (FormatException)
                                                {
                                                    Clear();
                                                    WriteLine("Please enter a valid date of birth [mmm dd yyyy]");
                                                }

                                            }
                                            break;
                                        default:
                                            WriteLine("Invalid key, please try again\n");
                                            break;
                                    }
                                    WriteLine("Student updated successfully!");
                                    break;
                                }
                                else if (i == students.Count - 1)
                                {
                                    WriteLine("\nStudent does not exist!");
                                }
                            }


                            // adds white space to first and last name to make their length uniform
                            // for table formmatting
                            
                            

                            for (int i = 0; i < students.Count; i++)
                            {
                                updatedStudentData.Add(students[i].IdNum.ToString());
                                updatedStudentData.Add(students[i].StudentId.ToString());
                                updatedStudentData.Add(students[i].FirstName);
                                updatedStudentData.Add(students[i].LastName);
                                updatedStudentData.Add(students[i].Major);
                                updatedStudentData.Add(students[i].PhoneNo);
                                updatedStudentData.Add(students[i].Gpa.ToString());
                                updatedStudentData.Add(students[i].DateOfBirth);
                            }

                            File.WriteAllLines(studentDatabase, updatedStudentData);
                            break;
                        case 4:
                            Clear();
                            displayDatabase(students, db);

                            WriteLine("Enter the student number of the student you want to delete!\n");
                            userInput = Convert.ToDouble(ReadLine());
                            for (int i = 0; i < students.Count; i++)
                            {
                                if (userInput == students[i].StudentId)
                                {
                                    for (int j = 0; j < students.Count; j++)
                                    {

                                        if (students[j].StudentId != userInput)
                                        {
                                            updatedStudentData.Add(students[j].IdNum.ToString());
                                            updatedStudentData.Add(students[j].StudentId.ToString());
                                            updatedStudentData.Add(students[j].FirstName);
                                            updatedStudentData.Add(students[j].LastName);
                                            updatedStudentData.Add(students[j].Major);
                                            updatedStudentData.Add(students[j].PhoneNo);
                                            updatedStudentData.Add(students[j].Gpa.ToString());
                                            updatedStudentData.Add(students[j].DateOfBirth);
                                        }
                                    }
                                    File.WriteAllLines(studentDatabase, updatedStudentData);
                                    WriteLine("\nStudent Deleted!");
                                    break;
                                }
                                if(i == students.Count-1)
                                {
                                    WriteLine("Student not found");
                                    
                                }
                            }
                            

                            break;
                        case 5:
                            mainProgram = false;
                            break;
                        default:
                            WriteLine("Invalid key, please try again!");
                            break;



                    }
                }
                catch (FormatException)
                {
                    Clear();
                    WriteLine("Please enter a valid key");
                }         
            }
        }
    }
}