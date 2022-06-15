School.CreateStudent("Batman");
Student studentToAdd = School.GetStudentByName("Batman");

School.AddCourse("Intro to Batman", 500);

Course courseToAdd = School.GetCourseByNumber(500);
School.AddStudentToCourse(studentToAdd, courseToAdd);

class Student
{
    public string Name { get; set; }
    public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    public Student()
    {
    }

    public Student(string name)
    {
        Name = name;
    }
}

class Course
{
    public string Title { get; set; }
    public int Number { get; set; }
    public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public Course()
    {

    }

    public Course(string title, int number)
    {
        Title = title;
        Number = number;
    }
}

static class School
{
    public static string Title { get; set; } = "MITT";
    public static List<Course> Courses { get; set; } = new List<Course>();
    public static List<Student> Students { get; set; } = new List<Student>();
    public static List<Enrollment> Enrollmemts { get; set; } = new List<Enrollment>();

    public static Student CreateStudent(string name)
    {
        Student newStudent = new Student(name);
        Students.Add(newStudent);
        return newStudent;
    }

    public static void AddCourse(string title,  int number)
    {
        Course newCourse = new Course(title, number);
        Courses.Add(newCourse);
    }
    public static void AddStudentToCourse(Student student, Course course)
    {
        Enrollment newEnrollment = new Enrollment(student, course);
        newEnrollment.EnrollmentId = Enrollmemts.Count + 1;

        student.Enrollments.Add(newEnrollment);
        course.Enrollments.Add(newEnrollment);
        Enrollmemts.Add(newEnrollment);
    }


    public static Course GetCourseByNumber(int number)
    {
        foreach (Course course in Courses)
        {
            if (course.Number == number)
            {
                return course;
            }
        }
        
        return null;
    }

    public static Student GetStudentByName(string name)
    {
        foreach(Student student in Students)
        {
            if(string.Equals(student.Name, name))
            {
                return student;
            }
        }

        return null;
    }
}

// Change the system so that instead of adding students to lists of courses and vice-versa, 
// we use an Enrollment class to handle when students are added

class Enrollment
{
    public int EnrollmentId { get; set; }
    public Student Student { get; set; }
    public Course Course { get; set; }
    public int Grade { get; set; }

    public Enrollment(Student student, Course course)
    {
        Student = student;
        Course = course;
    }
}