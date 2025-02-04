using System;
using Formula1;
using System.Linq;
using NUnit.Framework;
using System.Reflection;
using System.Collections.Generic;

public class Tests_014
{
    private static readonly Assembly ProjectAssembly = typeof(StartUp).Assembly;

    [Test]
    public void AddCarToPilotThrowExceptionWhenCarIsNull()
    {
        var controller = CreateObjectInstance(GetType("Controller"));

        var carArguments = new object[] { "Williams", "FW14", 970, 1.7 };
        var pilotArgument = new object[] { "Fernando_Alonso" };
        var addCarToPilotArguments = new object[] { "Fernando_Alonso", "FW14" };
        var pilotArgumentTwo = new object[] { "Lewis_Hamilton" };
        var addCarToPilotArgumentsTwo = new object[] { "Lewis_Hamilton", "FW14" };

        InvokeMethod(controller, "CreateCar", carArguments);
        InvokeMethod(controller, "CreatePilot", pilotArgument);
        InvokeMethod(controller, "CreatePilot", pilotArgumentTwo);
        InvokeMethod(controller, "AddCarToPilot", addCarToPilotArguments);
        var result = InvokeMethod(controller, "AddCarToPilot", addCarToPilotArgumentsTwo);

        var validExpectedResult = "Car FW14 does not exist.";

        Assert.AreEqual(result, validExpectedResult);
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