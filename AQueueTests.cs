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
        TestWrapAround();
        TestDequeueEmpty();
        TestPeekEmpty();
        TestEnqueueFull();
        Console.WriteLine("======================");

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

    private static void TestWrapAround()
    {
        Console.WriteLine("======================");
        Console.WriteLine("TestWrapAround");

        var wrapQueue = new AQueue<int>(3);
        wrapQueue.Enqueue(1);
        wrapQueue.Enqueue(2);
        wrapQueue.Dequeue(); // Libera una posición
        wrapQueue.Dequeue(); // Libera otra

        wrapQueue.Enqueue(3); // Aquí rear debe "envolver"
        wrapQueue.Enqueue(4); // También aquí

        int first = wrapQueue.Dequeue(); // Debe devolver 3
        int second = wrapQueue.Dequeue(); // Debe devolver 4

        Console.WriteLine($"Expected: 3, Got: {first}");
        Console.WriteLine($"Expected: 4, Got: {second}");
    }

    private static void TestDequeueEmpty()
    {
        var q = new AQueue<int>(3);
        try
        {
            q.Dequeue();
            Console.WriteLine("❌ Dequeue from empty queue did not throw.");
        }
        catch (QueueException)
        {
            Console.WriteLine("✅ Dequeue from empty queue threw as expected.");
        }
    }

    private static void TestPeekEmpty()
    {
        var q = new AQueue<int>(3);
        try
        {
            q.Peek();
            Console.WriteLine("❌ Peek from empty queue did not throw.");
        }
        catch (QueueException)
        {
            Console.WriteLine("✅ Peek from empty queue threw as expected.");
        }
    }

    private static void TestEnqueueFull()
    {
        var q = new AQueue<int>(2);
        q.Enqueue(10);
        q.Enqueue(20);
        try
        {
            q.Enqueue(30);
            Console.WriteLine("❌ Enqueue on full queue did not throw.");
        }
        catch (QueueException)
        {
            Console.WriteLine("✅ Enqueue on full queue threw as expected.");
        }
    }


}