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

    //Adds an element to the queue
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

    //method to delete an element
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

    //method to get the first element
    public T Peek()
    {
        if (_count == 0)
        {
            throw new QueueException("Queue is empty");
        }
        return _items[_front];
    }

    //method to obtain the queue size
    public int Count
    {
        get { return _count; }
    }

    //class contains
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

    // list content
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

    // view the last item in the queue
    public T Last()
    {
        if (_count == 0)
        {
            throw new QueueException("Queue is empty");
        }
        return _items[_rear];
    }

}

