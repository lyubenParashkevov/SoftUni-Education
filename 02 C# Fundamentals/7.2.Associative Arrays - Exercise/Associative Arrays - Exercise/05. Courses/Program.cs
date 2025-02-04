namespace _05._Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courseDataBase = new Dictionary<string, List<string>>();
            while (true)
            {

                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }
                string[] courseAndStudent = input.Split(" : ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string courseName = courseAndStudent[0];
                string studentName = courseAndStudent[1];

                if (!courseDataBase.ContainsKey(courseName))
                {
                    courseDataBase.Add(courseName, new List<string>());
                }
                courseDataBase[courseName].Add(studentName);
            }

            foreach (var course in courseDataBase)
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");

                for (int i = 0; i < course.Value.Count; i++)
                {
                    Console.WriteLine($"-- {course.Value[i]}");
                }
            }
        }
    }
}