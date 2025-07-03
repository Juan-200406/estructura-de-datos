// See https://aka.ms/new-console-template for more information
using System;

// Tus clases Node y LinkedList no necesitan cambios
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

    // 2. Invertir una lista enlazada
    public void ReverseList()
    {
        Node<T> prev = null;
        Node<T> current = Head;
        Node<T> next = null;

        while (current != null)
        {
            next = current.Next; // Guarda el siguiente nodo
            current.Next = prev; // Invierte el puntero del nodo actual
            prev = current;      // Mueve 'prev' al nodo actual
            current = next;      // Mueve 'current' al siguiente nodo
        }
        Head = prev; // 'prev' será la nueva cabeza de la lista invertida
    }
}

// Esta es la parte que necesitas añadir para que el código se ejecute.
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("--- Demostración de LinkedList ---");

        // Creamos una nueva lista de enteros
        LinkedList<int> myLinkedList = new LinkedList<int>();

        // Agregamos algunos elementos
        Console.WriteLine("Agregando elementos: 10, 20, 30, 40");
        myLinkedList.AddLast(10);
        myLinkedList.AddLast(20);
        myLinkedList.AddLast(30);
        myLinkedList.AddLast(40);

        // Imprimimos la lista original
        Console.Write("Lista original: ");
        myLinkedList.PrintList(); // Salida esperada: 10 20 30 40

        // Invertimos la lista
        Console.WriteLine("Invirtiendo la lista...");
        myLinkedList.ReverseList();

        // Imprimimos la lista invertida
        Console.Write("Lista invertida: ");
        myLinkedList.PrintList(); // Salida esperada: 40 30 20 10

        Console.WriteLine("\n--- Probando con una lista vacía ---");
        LinkedList<string> emptyList = new LinkedList<string>();
        Console.Write("Lista vacía: ");
        emptyList.PrintList();
        Console.WriteLine("Invirtiendo lista vacía...");
        emptyList.ReverseList();
        Console.Write("Lista vacía después de invertir: ");
        emptyList.PrintList();
    }
} 