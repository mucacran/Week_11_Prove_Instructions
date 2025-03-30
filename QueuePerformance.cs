/*
Performance Analysis:

- Enqueue, Dequeue y Peek muestran tiempos constantes (O(1)), incluso con tamaños grandes. Esto indica que la lógica del arreglo circular funciona bien.
- Contains muestra tiempos crecientes con el tamaño, lo cual es esperado porque tiene complejidad O(n).
- No se observaron anomalías: los datos son consistentes con las expectativas teóricas.
- Estoy satisfecho con los resultados porque muestran el comportamiento esperado de cada operación.
*/


namespace w11finalProject;
using System.Diagnostics;

    public class PerformanceTests
    {
        public static void Run()
        {
            Console.WriteLine("\\n== Performance Tests ==");

            int[] sizes = { 10, 100, 1000, 10000 };

            foreach (int size in sizes)
            {
                var queue = new AQueue<int>(size);

                // Pre-fill queue with data leaving one space to avoid overflow
                for (int i = 0; i < size - 1; i++)
                {
                    queue.Enqueue(i);
                }

                long enqueueTime = 0;
                long dequeueTime = 0;
                long peekTime = 0;
                long containsTime = 0;

                Stopwatch sw = new Stopwatch();
                int trials = 100;

                // Enqueue Test
                for (int i = 0; i < trials; i++)
                {
                    queue.Dequeue(); // free up one spot
                    sw.Restart();
                    queue.Enqueue(9999);
                    sw.Stop();
                    enqueueTime += sw.ElapsedTicks;
                }

                // Dequeue Test
                for (int i = 0; i < trials; i++)
                {
                    queue.Enqueue(i); // ensure there's something to dequeue
                    sw.Restart();
                    queue.Dequeue();
                    sw.Stop();
                    dequeueTime += sw.ElapsedTicks;
                }

                // Peek Test
                for (int i = 0; i < trials; i++)
                {
                    sw.Restart();
                    var temp = queue.Peek();
                    sw.Stop();
                    peekTime += sw.ElapsedTicks;
                }

                // Contains Test
                for (int i = 0; i < trials; i++)
                {
                    int searchValue = i % size;
                    sw.Restart();
                    queue.Contains(searchValue);
                    sw.Stop();
                    containsTime += sw.ElapsedTicks;
                }

                Console.WriteLine($"Queue Size: {size}");
                Console.WriteLine($"Avg Enqueue: {enqueueTime / trials} ticks");
                Console.WriteLine($"Avg Dequeue: {dequeueTime / trials} ticks");
                Console.WriteLine($"Avg Peek:    {peekTime / trials} ticks");
                Console.WriteLine($"Avg Contains:{containsTime / trials} ticks\\n");
            }
        }
    }
