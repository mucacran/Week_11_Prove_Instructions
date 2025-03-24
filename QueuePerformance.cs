namespace w11finalProject;


Stopwatch sw = new Stopwatch();
sw.Start();
for(int i = 0; i < largeNumber; i++)
{
    queue.Enqueue(i);
}
sw.Stop();
Console.WriteLine($"Enqueue total time: {sw.ElapsedMilliseconds} ms");
