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


/***********************************************
    * TestWrapAround
    * 
    * This test checks the wrap-around functionality of the queue.
    * It enqueues elements until the queue is full, then dequeues some elements
    * to free up space, and finally enqueues more elements to see if they are
    * correctly wrapped around. (SUGERIDOS POR EL PROFESOR)t
    ***********************************************/
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

    /*
     * “I do not see any edge testing of your queue.”

✅ Qué significa:
Faltaron pruebas de casos extremos: intentar Dequeue, Peek o Enqueue cuando la queue está vacía o llena.
✅ Qué debes hacer: Agrega estas pruebas en tu archivo AQueueTests.cs:
    */

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