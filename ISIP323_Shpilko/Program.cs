class Person
{

    public string Name { get; set; }
    public string Sex { get; set; }
    public int Age { get; set; }

    public Person(string name, string sex, int age)
    {

        Name = name;
        Sex = sex;
        Age = age;
    }
}
class Student : Person
{
    private static int nextId = 1;
    public int Id { get; set; }
    public List<Course> Courses { get; set; }

    public Student(string name, string sex, int age)
        : base(name, sex, age)
    {
        Id = nextId++;
        Courses = new List<Course>();
    }
}
class Teacher : Person
{
    public string Subject { get; set; }
    public List<Course> Courses { get; set; }
    public Teacher(string name, string sex, int age, string subject)
        : base(name, sex, age)
    {
        Subject = subject;
        Courses = new List<Course>();
    }
}
class Course
{
    public string CourseName { get; set; }
    public Teacher Teacher { get; set; }
    public List<Student> Students { get; set; }
    public Course(string courseName)
    {
        CourseName = courseName;
        Students = new List<Student>();
    }
}
class University
{
    private List<Student> students;
    private List<Course> courses;
    private List<Teacher> teachers;
    public University()
    {
        students = new List<Student>();
        teachers = new List<Teacher>();
        courses = new List<Course>();
    }
    
}
