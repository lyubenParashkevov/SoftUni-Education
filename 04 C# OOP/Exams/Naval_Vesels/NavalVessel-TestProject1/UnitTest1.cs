using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using NavalVessels;

public class Tests_001
{
    // MUST exist within project, otherwise a Compile Time Error will be thrown.
    private static readonly Assembly ProjectAssembly = typeof(StartUp).Assembly;

    [Test]
    public void ValidateHireCaptainCommandMethodInvalidData()
    {
        var controller = CreateObjectInstance(GetType("Controller"));

        var addCaptainArguments = new object[] { "Isoroku_Yamamoto" };
        var addCaptainArgumentsTwo = new object[] { "Isoroku_Yamamoto" };
        var validActualResult = InvokeMethod(controller, "HireCaptain", addCaptainArguments);
        var validActualResultTwo = InvokeMethod(controller, "HireCaptain", addCaptainArgumentsTwo);
        var errorResult = InvokeMethod(controller, "HireCaptain", new object[] { " " });

        var validExpectedResult = "Captain Isoroku_Yamamoto is hired.";
        var validExpectedResultTwo = "Captain Isoroku_Yamamoto is already hired.";
        Assert.AreEqual(validExpectedResult, validActualResult);
        Assert.AreEqual(validExpectedResultTwo, validActualResultTwo);
        Assert.AreEqual(errorResult, "Value cannot be null. (Parameter 'Captain full name cannot be null or empty string.')");

    }

    private static object InvokeMethod(object obj, string methodName, object[] parameters)
    {
        try
        {
            var result = obj.GetType()
                .GetMethod(methodName)
                .Invoke(obj, parameters);

            return result;
        }
        catch (TargetInvocationException e)
        {
            return e.InnerException.Message;
        }
    }

    private static object CreateObjectInstance(Type type, params object[] parameters)
    {
        try
        {
            var desiredConstructor = type.GetConstructors()
                .FirstOrDefault(x => x.GetParameters().Any());

            if (desiredConstructor == null)
            {
                return Activator.CreateInstance(type, parameters);
            }

            var instances = new List<object>();

            foreach (var parameterInfo in desiredConstructor.GetParameters())
            {
                var currentInstance = Activator.CreateInstance(GetType(parameterInfo.Name.Substring(1)));

                instances.Add(currentInstance);
            }

            return Activator.CreateInstance(type, instances.ToArray());
        }
        catch (TargetInvocationException e)
        {
            return e.InnerException.Message;
        }
    }

    private static Type GetType(string name)
    {
        var type = ProjectAssembly
            .GetTypes()
            .FirstOrDefault(t => t.Name.Contains(name));

        return type;
    }
}