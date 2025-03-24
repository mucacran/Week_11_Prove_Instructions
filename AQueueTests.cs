namespace w11finalProject;

public class AQueueTests
{
    private static int capacity = new Random().Next(5, 10);
    private static AQueue<int> queue = new AQueue<int>(capacity);
    public static void Run()
    {
        Console.WriteLine("AQueueTests\n======================");
        //RunPerformanceTests();
        TestEnqueue();
        TestDequeue();
        TestPeek();
        TestContains();

    }

    public static void TestEnqueue()
    {
        Console.WriteLine("TestEnqueue");
        Random rand = new Random();

        Console.WriteLine("==================================================");
        Console.WriteLine("|| nº item || item || size || Count || Contains ||");
        Console.WriteLine("==================================================");
        
        for (int i = 0; i < capacity; i++)
        {
            try
            {
                var randItem = rand.Next(1, 9);

                queue.Enqueue(randItem);
                Console.WriteLine($"|| {i}       || {randItem}    || {queue.Capacity}    || {queue.Count}     || {queue.Contains(queue.Peek())}     ||");
            }
            catch (QueueException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        Console.WriteLine("==================================================");

    }

/*    private static void TestEnqueue()
    {
        Console.WriteLine("======================");
        Console.WriteLine("TestEnqueue");
        
        
        for (int iii = 0; iii < capacity; iii++)
        {
            //array size
            Console.WriteLine($"{iii} {queue.Capacity} : {queue.Count}");
            queue.Enqueue(new Random().Next(1, 1000));
        }
    }*/

    private static void TestDequeue()
    {
        Console.WriteLine("TestDequeue");


        Console.WriteLine($"This is the first element in the queue: {queue.Peek()}");
        try
        {
            Console.WriteLine($"This is the first element to be removed from the queue: {queue.Dequeue()}");
        }
        catch (QueueException ex)
        {
            Console.WriteLine(ex.Message);
        }
        Console.WriteLine($"This is the first element to be removed from the queue: {queue.Dequeue()}");

    }

    private static void TestPeek()
    {
        Console.WriteLine("======================");
        Console.WriteLine("TestPeek");

        Console.WriteLine($"current queue size: {queue.Count}");
        Console.WriteLine($"This is the first element in the queue: {queue.Peek()}");
        Console.WriteLine($"current queue size: {queue.Count}");
    }

    private static void TestContains()
    {
        Console.WriteLine("======================");
        Console.WriteLine("TestContains");

        
        var item2 = new Random().Next(10, 20);

        //contents of the queue
        var ii = 0;
        foreach (var i in queue.ToList())
        {
            Console.WriteLine($"{ii++}: {i}");
        }

        //true
        Console.WriteLine($"Does the queue contain {queue.Peek()}? {queue.Contains(queue.Peek())}");
        //false
        Console.WriteLine($"Does the queue contain {item2}? {queue.Contains(item2)}");
    }
}