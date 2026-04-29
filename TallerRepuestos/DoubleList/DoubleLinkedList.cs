using Shared;

namespace DoubleList;

public class DoubleLinkedList<T> : ILinkedList<T> where T : IComparable<T>
{
    private Node<T>? _head;
    private Node<T>? _tail;

    public DoubleLinkedList()
    {
        _head = null;
        _tail = null;
    }

    public void Add(T data)
    {
        var newNode = new Node<T>(data);

        if (_head == null)
        {
            _head = newNode;
            _tail = newNode;
            return;
        }

        var current = _head;
        while (current != null && current.Data!.CompareTo(data) < 0)
        {
            current = current.Next;
        }

        if (current == _head)
        {
            newNode.Next = _head;
            _head.Previous = newNode;
            _head = newNode;
        }
        else if (current == null)
        {
            newNode.Previous = _tail;
            _tail!.Next = newNode;
            _tail = newNode;
        }
        else
        {
            newNode.Next = current;
            newNode.Previous = current.Previous;
            current.Previous!.Next = newNode;
            current.Previous = newNode;
        }
    }

    public void ShowForward()
    {
        var current = _head;
        while (current != null)
        {
            Console.Write($"{current.Data}");
            if (current.Next != null) Console.Write(" -> ");
            current = current.Next;
        }
        Console.WriteLine();
    }

    public void ShowReverse()
    {
        var current = _tail;
        while (current != null)
        {
            Console.Write($"{current.Data}");
            if (current.Previous != null) Console.Write(" -> ");
            current = current.Previous;
        }
        Console.WriteLine();
    }

    public void Sort()
    {
        if (_head == null || _head == _tail) return;

        Node<T>? current = _head;
        while (current != null)
        {
            Node<T>? inner = current.Next;
            while (inner != null)
            {
                if (current.Data!.CompareTo(inner.Data) < 0)
                {
                    var temp = current.Data;
                    current.Data = inner.Data;
                    inner.Data = temp;
                }
                inner = inner.Next;
            }
            current = current.Next;
        }
    }

    public List<T> GetModes()
    {
        var modes = new List<T>();
        if (_head == null) return modes;

        var current = _head;
        var maxCount = 0;

        while (current != null)
        {
            var count = CountOccurrences(current.Data!);
            if (count > maxCount) maxCount = count;
            current = current.Next;
        }

        current = _head;
        while (current != null)
        {
            var count = CountOccurrences(current.Data!);
            if (count == maxCount && !modes.Contains(current.Data!))
            {
                modes.Add(current.Data!);
            }
            current = current.Next;
        }

        return modes;
    }

    private int CountOccurrences(T data)
    {
        var count = 0;
        var current = _head;
        while (current != null)
        {
            if (current.Data!.Equals(data)) count++;
            current = current.Next;
        }
        return count;
    }

    public void ShowChart()
    {
        var printed = new List<T>();
        var current = _head;

        while (current != null)
        {
            if (!printed.Contains(current.Data!))
            {
                var count = CountOccurrences(current.Data!);
                Console.Write($"{current.Data,-20} ");
                for (int i = 0; i < count; i++) Console.Write("*");
                Console.WriteLine();
                printed.Add(current.Data!);
            }
            current = current.Next;
        }
    }

    public bool Exists(T data)
    {
        var current = _head;
        while (current != null)
        {
            if (current.Data!.Equals(data)) return true;
            current = current.Next;
        }
        return false;
    }

    public void RemoveFirst(T data)
    {
        var current = _head;
        while (current != null)
        {
            if (current.Data!.Equals(data))
            {
                RemoveNode(current);
                return;
            }
            current = current.Next;
        }
    }

    public void RemoveAll(T data)
    {
        var current = _head;
        while (current != null)
        {
            var next = current.Next;
            if (current.Data!.Equals(data))
            {
                RemoveNode(current);
            }
            current = next;
        }
    }

    private void RemoveNode(Node<T> node)
    {
        if (node == _head && node == _tail)
        {
            _head = null;
            _tail = null;
        }
        else if (node == _head)
        {
            _head = _head.Next;
            _head!.Previous = null;
        }
        else if (node == _tail)
        {
            _tail = _tail.Previous;
            _tail!.Next = null;
        }
        else
        {
            node.Previous!.Next = node.Next;
            node.Next!.Previous = node.Previous;
        }
    }

    public override string ToString()
    {
        var current = _head;
        var result = string.Empty;
        while (current != null)
        {
            result += $"{current.Data}";
            if (current.Next != null) result += " -> ";
            current = current.Next;
        }
        return result;
    }
}