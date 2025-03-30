namespace w11finalProject;

public class QueueException : Exception
{
    public QueueException(string message) : base(message) { }
}

public class AQueue<T>

{
    private T[] _items;
    private int _front;
    private int _rear;
    private int _count;
    private int _capacity;
    public int Capacity => _capacity;


    //constructor
    public AQueue(int capacity)
    {
        _capacity = capacity;
        _items = new T[capacity];
        _front = 0;
        _rear = -1;
        _count = 0;
    }

    /// <summary>
    /// Adds an element to the queue
    /// </summary>
    /// <param name="item">The element to add to the queue</param>
    /// <exception cref="QueueException">Thrown when the queue is full</exception>
    public void Enqueue(T item)
    {
        if (_count == _capacity)
        {
            throw new QueueException("Queue is full");
        }
        _rear = (_rear + 1) % _capacity;
        _items[_rear] = item;
        _count++;
    }

    /// <summary>
    /// method to delete an element
    /// </summary>
    /// <returns>The item that was at the front.</returns>
    /// <exception cref="QueueException">Thrown if the queue is empty.</exception>
    public T Dequeue()
    {
        if (_count == 0)
        {
            throw new QueueException("Queue is empty");
        }
        T item = _items[_front];
        _front = (_front + 1) % _capacity;
        _count--;
        return item;
    }

    /// <summary>
    /// method to get the first element
    /// </summary>
    /// <returns>The returning item will be the first in the queue</returns>
    /// <exception cref="QueueException">Thrown if the queue is empty.</exception>
    public T Peek()
    {
        if (_count == 0)
        {
            throw new QueueException("Queue is empty");
        }
        return _items[_front];
    }

    /// <summary>
    /// Returns the used size of the queue
    /// </summary>
    /// <returns>returns the value of _counte</returns>
    public int Count
    {
        get { return _count; }
    }

    /// <summary>
    /// class contains
    /// </summary>
    /// <returns>returns true or false if an item exists within the queue</returns>
    public bool Contains(T item)
    {
        for (int i = 0; i < _count; i++)
        {
            int index = (_front + i) % _capacity;
            if (EqualityComparer<T>.Default.Equals(_items[index], item))
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// list content
    /// </summary>
    /// <returns>I use this method to see the contents of the list</returns>
    public List<T> ToList()
    {
        List<T> list = new List<T>();
        for (int i = 0; i < _count; i++)
        {
            int index = (_front + i) % _capacity;
            list.Add(_items[index]);
        }
        return list;
    }

    /// <summary>
    /// view the last item in the queue
    /// </summary>
    /// <returns>With this method we return the item from the end of the queue and we can verify which one it is.</returns>
    public T Last()
    {
        if (_count == 0)
        {
            throw new QueueException("Queue is empty");
        }
        return _items[_rear];
    }

}

