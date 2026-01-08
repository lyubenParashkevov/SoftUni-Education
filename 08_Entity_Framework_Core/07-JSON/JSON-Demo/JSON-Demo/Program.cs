

using JSON_Demo;
using System.Text;
using System.Text.Json;

public class StartUp
{
    public static void Main(string[] args)
    {

        Student student = new Student()
        {
            Id = 1,
            Name = "Пешо",
            IsFirstGrade = true,
        };



        string studentInfo = JsonSerializer.Serialize(student);


        Console.WriteLine(studentInfo);

        Student? st = JsonSerializer.Deserialize<Student>(studentInfo);

        Console.WriteLine($"{st.Name} : {st.Id}");

       

    }
}

