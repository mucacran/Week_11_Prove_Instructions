namespace w11finalProject;

public class AQueueTests
{
    public static void Run()
    {
        Console.WriteLine("\n======================\nAQueueTests\n======================");
        TestEnqueue();
        //TestDequeue();
        //TestPeek();
        Console.WriteLine("======================\n");
    }

    private static void TestEnqueue()
    {
        Console.WriteLine("TestEnqueue");
        //crear un numero aleatorio
        int capacity = new Random().Next(1, 100);
        AQueue<int> queue = new AQueue<int>(capacity);
        for (int iii = 0; iii < capacity; iii++)
        {
            //que size es?
            //Console.WriteLine($"{i} Queue size {queue._front}: {queue.Capacity}");
            //queue.Enqueue(i);
            queue.Enqueue(new Random().Next(1, 1000));
        }

        Console.WriteLine(queue.Capacity + ": " + capacity);

        //ingresar el contenido de la cola en un array
        Console.WriteLine("Lista: ====================================");
        var int2 = queue.ToList();
        var i = 0;
        foreach (var item in int2)
        {
            Console.WriteLine($"{i++}: {item}");
        }

         Console.WriteLine("Ver el primer elemento de la cola y el ultimo elemento de la cola: ====================================");
        //ver primer elemento de la cola
        Console.WriteLine(queue.Peek());
        //ver ultimo elemento de la cola
        Console.WriteLine(queue.Last());

        Console.WriteLine("Contenido de la Cola====================================");
        for(int ii = 0; ii < queue.Count; ii++)
        {
            Console.WriteLine($"{ii}: {queue.Dequeue()}");
        }



    }

    private static void TestDequeue()
    {
        Console.WriteLine("TestDequeue");
        AQueue<int> queue = new AQueue<int>(3);
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        int item = queue.Dequeue();
        if (item == 1)
        {
            Console.WriteLine("TestDequeue passed");
        }
        else
        {
            Console.WriteLine("TestDequeue failed");
        }
    }

    private static void TestPeek()
    {
        Console.WriteLine("TestPeek");
        AQueue<int> queue = new AQueue<int>(3);
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        int item = queue.Peek();
        if (item == 1)
        {
            Console.WriteLine("TestPeek passed");
        }
        else
        {
            Console.WriteLine("TestPeek failed");
        }
    }
}