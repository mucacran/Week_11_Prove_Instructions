/*
 Performance Analysis:
 - Enqueue, Dequeue y Peek show constant times(almost all sizes are the same).
   This confirms that its complexity is O(1).
- Contains takes longer on large queues, as expected given its O(n) complexity.
- No anomalies were found; the results are consistent.
- I am satisfied with the results because they reflect the expected theoretical behavior.
*/

namespace w11finalProject;
using System.Diagnostics;

public class QueuePerformance
{
    public static void Run()
    {
        Console.WriteLine("\n== Performance Tests ==");
        int[] sizes = { 10, 100, 1000, 10000, 100000, 1000000 };
        
        foreach (int size in sizes)
        {
            var queue = new AQueue<int>(size);



            for (int i = 0; i < size - 1 ; i++) // size - 1 to leave one empty space for (9999)
            {
                queue.Enqueue(i); // Fill it to the max
            }

            // Performance tests
            // With this declaration and initialization of the object
            // we expect to obtain the performance of each of the operations
            // of the queue
            Stopwatch sw = new();
            long totalEnqueue = 0, totalDequeue = 0, totalPeek = 0, totalContains = 0;
            int trials = 5;

            for (int t = 0; t < trials; t++)
            {
                // Enqueue
                sw.Restart();
                queue.Enqueue(9999); // I hope performance is good O(1)
                sw.Stop();
                totalEnqueue += sw.ElapsedTicks;

                // Dequeue
                sw.Restart();
                queue.Dequeue(); // I hope performance is good O(n)
                sw.Stop();
                totalDequeue += sw.ElapsedTicks;

                // Peek
                sw.Restart();
                queue.Peek();   // i hope performance is good O(1)
                sw.Stop();
                totalPeek += sw.ElapsedTicks;

                // Contains
                // I hope performance is good O(n) because it has to search the entire list and 
                // Only search if it is empty or contains a value (-1)
                sw.Restart();
                queue.Contains(-1); // false
                sw.Stop();
                totalContains += sw.ElapsedTicks;
            }

            Console.WriteLine($"Queue Size: {size}");
            Console.WriteLine($"Avg Enqueue: {totalEnqueue / trials} ticks");
            Console.WriteLine($"Avg Dequeue: {totalDequeue / trials} ticks");
            Console.WriteLine($"Avg Peek: {totalPeek / trials} ticks");
            Console.WriteLine($"Avg Contains: {totalContains / trials} ticks");
            Console.WriteLine();
        }
    }
}
