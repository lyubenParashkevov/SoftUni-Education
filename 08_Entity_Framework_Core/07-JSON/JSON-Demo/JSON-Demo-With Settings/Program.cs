


using JSON_Demo_With_Settings;
using System.Text;
using System.Text.Json;

Student student = new Student()
{
    Id = 1,
    Name = "Пешо",
    IsDeleted = true,
};

string serializedStudent = student.ToJson(new JsonSerializerOptions());

Console.WriteLine(serializedStudent);
Console.InputEncoding = Encoding.UTF8;

Student student2 = serializedStudent.FromJson<Student>();

if  (student2 != null)
{
    Console.WriteLine($"Name: {student2.Name} Number: {student2.IsDeleted}");
}