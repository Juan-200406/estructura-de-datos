using System;

public class Node<T>
{
    public T Data { get; set; }
    public Node<T> Next { get; set; }

    public Node(T data)
    {
        Data = data;
        Next = null;
    }
}

public class LinkedList<T>
{
    public Node<T> Head { get; set; }

    public LinkedList()
    {
        Head = null;
    }

    // Método para agregar un nodo al final (útil para varios ejercicios)
    public void AddLast(T data)
    {
        Node<T> newNode = new Node<T>(data);
        if (Head == null)
        {
            Head = newNode;
            return;
        }

        Node<T> current = Head;
        while (current.Next != null)
        {
            current = current.Next;
        }
        current.Next = newNode;
    }

    // Método para agregar un nodo al inicio (útil para varios ejercicios)
    public void AddFirst(T data)
    {
        Node<T> newNode = new Node<T>(data);
        newNode.Next = Head;
        Head = newNode;
    }

    // Método para imprimir la lista
    public void PrintList()
    {
        if (Head == null)
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }

        Node<T> current = Head;
        while (current != null)
        {
            Console.Write(current.Data + " ");
            current = current.Next;
        }
        Console.WriteLine();
    }

    // 1. Función que calcule el número de elementos de una lista
    public int CountElements()
    {
        int count = 0;
        Node<T> current = Head;
        while (current != null)
        {
            count++;
            current = current.Next;
        }
        return count;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Crear una nueva lista enlazada de enteros
        LinkedList<int> myLinkedList = new LinkedList<int>();

        Console.WriteLine("--- Agregando elementos ---");
        myLinkedList.AddLast(10);
        myLinkedList.AddLast(20);
        myLinkedList.AddFirst(5);
        myLinkedList.AddLast(30);

        Console.Write("Lista actual: ");
        myLinkedList.PrintList(); // Debería imprimir: 5 10 20 30

        Console.WriteLine($"Número de elementos en la lista: {myLinkedList.CountElements()}"); // Debería imprimir: 4

        Console.WriteLine("\n--- Probando una lista vacía ---");
        LinkedList<string> emptyList = new LinkedList<string>();
        emptyList.PrintList();
        Console.WriteLine($"Número de elementos en la lista vacía: {emptyList.CountElements()}");
    }
}