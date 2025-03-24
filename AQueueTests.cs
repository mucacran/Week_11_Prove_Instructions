namespace w11finalProject;

public class AQueueTests
{
    private static int capacity = new Random().Next(1, 10);
    public static void Run()
    {
        Console.WriteLine("\n======================\nAQueueTests\n======================");
        TestEnqueue();
        TestDequeue();
        TestPeek();
        TestContains();
        Console.WriteLine("======================\n");
    }

    public static void RunPerformanceTests()
    {
        Console.WriteLine("\n======================\nAQueueTests\n======================");
        AQueue<int> queue = new AQueue<int>(capacity);
        for (int iii = 0; iii < capacity; iii++)
        {
            //array size
            Console.WriteLine($"{iii} {queue.Capacity} : {queue.Count}");
            queue.Enqueue(new Random().Next(1, 1000));
        }
        Console.WriteLine("======================\n");
    }

    private static void TestEnqueue()
    {
        Console.WriteLine("TestEnqueue");
        
        AQueue<int> queue = new AQueue<int>(capacity);
        for (int iii = 0; iii < capacity; iii++)
        {
            //array size
            Console.WriteLine($"{iii} {queue.Capacity} : {queue.Count}");
            queue.Enqueue(new Random().Next(1, 1000));
        }
    }

    private static void TestDequeue()
    {
        Console.WriteLine("TestDequeue");
        AQueue<int> queue = new AQueue<int>(capacity);
        for (int iii = 0; iii < capacity; iii++)
        {
            //array size
            Console.WriteLine($"{iii} {queue.Capacity} : {queue.Count}");
            queue.Enqueue(new Random().Next(1, 1000));
        }

        Console.WriteLine($"This is the first element in the queue: {queue.Peek()}");
        Console.WriteLine($"This is the first element to be removed from the queue: {queue.Dequeue()}");

    }

    private static void TestPeek()
    {
        Console.WriteLine("TestPeek");
        AQueue<int> queue = new AQueue<int>(capacity);
        for (int iii = 0; iii < capacity; iii++)
        {
            //array size
            Console.WriteLine($"{iii} {queue.Capacity} : {queue.Count}");
            queue.Enqueue(new Random().Next(1, 1000));
        }
        Console.WriteLine($"current queue size: {queue.Count}");
        Console.WriteLine($"This is the first element in the queue: {queue.Peek()}");
        Console.WriteLine($"current queue size: {queue.Count}");
    }

    private static void TestContains()
    {
        Console.WriteLine("TestContains");
        AQueue<int> queue = new AQueue<int>(capacity);
        for (int iii = 0; iii < capacity; iii++)
        {
            //array size
            Console.WriteLine($"{iii} {queue.Capacity} : {queue.Count}");
            queue.Enqueue(new Random().Next(1, 10));
        }
        
        var item = new Random().Next(1, capacity);
        var item2 = new Random().Next(10, 20);

        //contents of the queue
        foreach (var i in queue.ToList())
        {
            Console.WriteLine(i);
        }

        //true
        Console.WriteLine($"Does the queue contain {queue.Peek()}? {queue.Contains(queue.Peek())}");
        //false
        Console.WriteLine($"Does the queue contain {item2}? {queue.Contains(item2)}");
    }
}