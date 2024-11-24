using System;

class Node<T>
{
    public T Value { get; set; }
    public Node<T> Next { get; set; }

    public Node(T value)
    {
        Value = value;
        Next = null;
    }
}

class MyLinkedList<T>
{
    private Node<T> _head;
    private int _count;

    public MyLinkedList()
    {
        _head = null;
        _count = 0;
    }

    public void Add(T item)
    {
        Node<T> newNode = new Node<T>(item);
        if (_head == null)
        {
            _head = newNode;
        }
        else
        {
            Node<T> current = _head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }
        _count++;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= _count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
        }

        if (index == 0)
        {
            _head = _head.Next;
        }
        else
        {
            Node<T> current = _head;
            for (int i = 0; i < index - 1; i++)
            {
                current = current.Next;
            }
            current.Next = current.Next.Next;
        }
        _count--;
    }

    public T Get(int index)
    {
        if (index < 0 || index >= _count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
        }

        Node<T> current = _head;
        for (int i = 0; i < index; i++)
        {
            current = current.Next;
        }
        return current.Value;
    }

    public int Count => _count;

    public void PrintAll()
    {
        Node<T> current = _head;
        while (current != null)
        {
            Console.WriteLine(current.Value);
            current = current.Next;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        TestMyLinkedList();
    }

    static void TestMyLinkedList()
    {
        Console.WriteLine("Testing MyLinkedList");
        MyLinkedList<int> myList = new MyLinkedList<int>();

        // Test Add
        myList.Add(1);
        myList.Add(2);
        myList.Add(3);
        Console.WriteLine("After adding elements:");
        myList.PrintAll(); // Expected output: 1, 2, 3

        // Test RemoveAt
        myList.RemoveAt(1); // Removes element at index 1
        Console.WriteLine("After removing element at index 1:");
        myList.PrintAll(); // Expected output: 1, 3

        // Test Get
        Console.WriteLine("Element at index 1: " + myList.Get(1)); // Expected output: 3

        // Test Count
        Console.WriteLine("Count: " + myList.Count); // Expected output: 2

        // Test handling out of range
        try
        {
            myList.Get(5); // Should throw ArgumentOutOfRangeException
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.WriteLine(e.Message); // Expected output: Index is out of range.
        }
    }
}
