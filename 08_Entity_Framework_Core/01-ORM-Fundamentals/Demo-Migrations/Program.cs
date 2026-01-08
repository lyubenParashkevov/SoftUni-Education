
Console.WriteLine();
public class MyResource : IDisposable
{
    private bool disposed = false; // Флаг за следене на състоянието

    public void UseResource()
    {
        if (disposed)
            throw new ObjectDisposedException("MyResource");

        Console.WriteLine("Using the resource...");
    }

    public void Dispose()
    {
        if (!disposed)
        {
            Console.WriteLine("Releasing resources...");
            disposed = true;
        }
    }

}
