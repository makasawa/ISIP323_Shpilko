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
    public void AddStudent(Student student)
    {
        students.Add(student);
    }
    public List<Student> GetAllStudents()
    {
        return students;
    }
    public Student FindStudentById(int id)
    {
        return students.Find(s => s.Id == id);
    }
    public void AddTeacher(Teacher teacher)
    {
        teachers.Add(teacher);
    }
    public List<Teacher> GetAllTeachers()
    {
        return teachers;
    }
    public void AddCourse(Course course)
    {
        courses.Add(course);
    }
    public List<Course> GetAllCourses()
    {
        return courses;
    }
    public Course FindCourseByName(string name)
    {
        return courses.Find(c => c.CourseName == name);
    }
    public void StudentInCourse(int studentId, string courseName)
    {
        var student = FindStudentById(studentId);
        var course = FindCourseByName(courseName);
        student.Courses.Add(course);
        course.Students.Add(student);
    }
    public void TeacherToCourse(string teacherName, string courseName)
    {
        var teacher = teachers.Find(t => t.Name == teacherName);
        var course = FindCourseByName(courseName);

        course.Teacher = teacher;
        teacher.Courses.Add(course);
    }
}
class Program
{
    private static University university = new University();
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("---- меню ----");
            Console.WriteLine("1. добавить дипсикера");
            Console.WriteLine("2. добавить ГВВ");
            Console.WriteLine("3. добавить курс");
            Console.WriteLine("4. показать всех дипсикеров");
            Console.WriteLine("5. показать всех ГВВ");
            Console.WriteLine("6. показать все курсы");
            Console.WriteLine("7. записать дипсикера на курс");
            Console.WriteLine("8. назначить ГВВ на курс");
            Console.WriteLine("9. показать курсы дипсикера");
            Console.WriteLine("10. показать дипсикеров курса");
            Console.WriteLine("0. выход");
            Console.Write("выберите: ");

            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    AddStudent(); break;
                case "2":
                    AddTeacher(); break;
                case "3":
                    AddCourse(); break;
                case "4":
                    ShowAllStudents(); break;
                case "5":
                    ShowAllTeachers(); break;
                case "6":
                    ShowAllCourses(); break;
                case "7":
                    StudentInCourse(); break;
                case "8":
                    TeacherToCourse(); break;
                case "9":
                    ShowStudentCourses(); break;
                case "10":
                    ShowCourseStudents(); break;
                case "0":
                    return;
                default:
                    Console.WriteLine("неверный выбор");
                    break;
            }
        }
    }
    static void AddStudent()
    {
        Console.Write("имя: ");
        var name = Console.ReadLine();

        Console.Write("пол: ");
        var sex = Console.ReadLine();

        Console.Write("возраст: ");
        var age = int.Parse(Console.ReadLine());

        var student = new Student(name, sex, age);
        university.AddStudent(student);
        Console.WriteLine("дипсикер добавлен");
    }

    static void AddTeacher()
    {
        Console.Write("имя: ");
        var name = Console.ReadLine();

        Console.Write("пол: ");
        var sex = Console.ReadLine();

        Console.Write("возраст: ");
        var age = int.Parse(Console.ReadLine());

        Console.Write("предмет: ");
        var subject = Console.ReadLine();

        var teacher = new Teacher(name, sex, age, subject);
        university.AddTeacher(teacher);
        Console.WriteLine("ГВВ добавлен");
    }

    static void AddCourse()
    {
        Console.Write("название курса: ");
        var name = Console.ReadLine();

        var course = new Course(name);
        university.AddCourse(course);
        Console.WriteLine("курс добавлен");
    }

    static void ShowAllStudents()
    {
        var students = university.GetAllStudents();
        Console.WriteLine("\n---- дипсикеры ----");
        foreach (var s in students)
        {
            Console.WriteLine($"Id: {s.Id}, имя: {s.Name}, пол: {s.Sex}, возраст: {s.Age}");
        }
    }

    static void ShowAllTeachers()
    {
        var teachers = university.GetAllTeachers();
        Console.WriteLine("\n---- ГВВШНИКИ ----");
        foreach (var t in teachers)
        {
            Console.WriteLine($"имя: {t.Name}, пол: {t.Sex}, возраст: {t.Age}, предмет: {t.Subject}");
        }
    }
    static void ShowAllCourses()
    {
        var courses = university.GetAllCourses();
        Console.WriteLine("\n---- курсы ----");
        foreach (var c in courses)
        {
            var teacherName = c.Teacher?.Name ?? "не назначен";
            Console.WriteLine($"курсы: {c.CourseName}, преподаватель: {teacherName}, кол-во дипсикеров{c.Students.Count}");
        }
    }
    static void StudentInCourse()
    {
        Console.WriteLine("Id дипсикера: ");
        var studentId = int.Parse(Console.ReadLine());

        Console.WriteLine("название курса: ");
        var courseName = Console.ReadLine();

        university.StudentInCourse(studentId, courseName);
        Console.WriteLine("дипсикер записан на курс");
    }
    static void TeacherToCourse()
    {
        Console.Write("имя ГВВшника: ");
        var teacherName = Console.ReadLine();

        Console.WriteLine("название курса: ");
        var courseName = Console.ReadLine();

        university.TeacherToCourse(teacherName, courseName);
        Console.WriteLine("ГВВшник назначен на курс");
    }
    static void ShowStudentCourses()
    {
        Console.WriteLine("Id студента: ");
        var studentId = int.Parse(Console.ReadLine());


        var student = university.FindStudentById(studentId);
        if (student != null)
        {
            Console.WriteLine($"\nкурсы дипсикера {student.Name}: ");
            foreach (var course in student.Courses)
            {
                Console.WriteLine($"- {course.CourseName}");
            }
        }
    }
    static void ShowCourseStudents()
    {
        Console.WriteLine("название курса: ");
        var courseName = Console.ReadLine();

        var course = university.FindCourseByName(courseName);
        if (course != null)
        {
            Console.WriteLine($"\nдипсикеры курса {course.CourseName}:");
            foreach (var student in course.Students)
            {
                Console.WriteLine($"- {student.Name} (Id: {student.Id})");
            }
        }
    }
}