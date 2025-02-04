
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
namespace AuthorProblem
{


    [Author("Victor")]
    public class StartUp
    {
        [Author("George")]
        static void Main(string[] args)
        {

            
        }

    }
}
//[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
//public class AuthorAttribute : Attribute
//{
//    public AuthorAttribute(string name)
//    {
//        Name = name;
//    }
//    public string Name { get; set; }
//}