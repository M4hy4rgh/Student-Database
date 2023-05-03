namespace studentDB
{
    public class Student
    {
        private double idNum;

        public double IdNum
        {
            get { return idNum; }
            set { idNum = value; }
        }
        private long studentId;

        public long StudentId
        {
            get { return studentId; }
            set { studentId = value; }
        }

        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        private string major;

        public string Major
        {
            get { return major; }
            set { major = value; }
        }

        private string phoneNo;

        public string PhoneNo
        {
            get { return phoneNo; }
            set { phoneNo = value; }
        }

        private double gpa;

        public double Gpa
        {
            get { return gpa; }
            set { gpa = value; }
        }

        private string dateOfBirth;

        public string DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }

    }
}