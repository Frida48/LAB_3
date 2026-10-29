using System;
namespace DataStructuresLab3
{
// 1. Node (Düyün) sinfi - Bütün strukturlar üçün əsas
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
// 2. STACK (Brauzer Tarixçəsi üçün) - LIFO prinsipi
public class CustomStack<T>
{
private Node<T>? top;
public CustomStack() { top = null; }
// Element əlavə etmə (Səhifəyə girmə)
public void Push(T data)
{
Node<T> newNode = new Node<T>(data);
newNode.Next = top;
top = newNode;
Console.WriteLine($"Ziyarət edildi: {data}");
}
// Element çıxarma (Geri qayıtma)
public T Pop()
{
if (top == null)
{
Console.WriteLine("Tarixçə boşdur! Geri qayıtmaq mümkün deyil.");
return default(T);
}
Node<T> temp = top;
top = top.Next;
Console.WriteLine($"Geri qayıdıldı: {temp.Data}");
return temp.Data;
}
public bool IsEmpty() { return top == null; }
}
// 3. QUEUE (Çap Növbəsi üçün) - FIFO prinsipi
public class CustomQueue<T>
{
private Node<T>? front;
private Node<T>? rear;
public CustomQueue() { front = rear = null; }
// Növbəyə sənəd əlavə etmə
public void Enqueue(T data)
{
Node<T> newNode = new Node<T>(data);
if (rear == null)
{
front = rear = newNode;
return;
}
rear.Next = newNode;
rear = newNode;
Console.WriteLine($"Çap növbəsinə əlavə edildi: {data}");
}
// Növbədən sənədi çap etmək üçün çıxarma
public T Dequeue()
{
if (front == null)
{
Console.WriteLine("Çap növbəsi boşdur!");
return default(T);
}
Node<T> temp = front;
front = front.Next;
if (front == null) rear = null;
Console.WriteLine($"Çap edildi: {temp.Data}");

return temp.Data;
}
}
// 4. LINKED LIST (Musiqi Pleylisti üçün) - Dinamik siyahı
public class CustomLinkedList<T>
{
private Node<T>? head;
public CustomLinkedList() { head = null; }
// Mahnı əlavə etmə (Sona)
public void Add(T data)
{
Node<T> newNode = new Node<T>(data);
if (head == null)
{
head = newNode;
return;
}
Node<T> current = head;
while (current.Next != null)
{
current = current.Next;
}
current.Next = newNode;
Console.WriteLine($"Pleylistə əlavə edildi: {data}");
}
// Pleylisti çap etmə
public void PrintPlaylist()
{
Console.WriteLine("\n--- Cari Pleylist ---");
Node<T> current = head;
if (current == null) Console.WriteLine("Pleylist boşdur.");
while (current != null)
{
Console.WriteLine("-> " + current.Data);
current = current.Next;
}
Console.WriteLine("---------------------\n");
}
}
// Test və Nəticələr üçün Əsas Proqram
class Program
{
static void Main(string[] args)
{
Console.WriteLine("=== 1. STACK TESTİ (Brauzer Tarixçəsi) ===");
CustomStack<string> browserHistory = new CustomStack<string>();
browserHistory.Push("google.com");
browserHistory.Push("youtube.com");
browserHistory.Push("github.com");
browserHistory.Pop(); // github-dan geri qayıdır
browserHistory.Pop(); // youtube-dan geri qayıdır
Console.WriteLine("\n=== 2. QUEUE TESTİ (Çap Növbəsi) ===");
CustomQueue<string> printQueue = new CustomQueue<string>();
printQueue.Enqueue("Sened1.pdf");
printQueue.Enqueue("Sened2.docx");
printQueue.Enqueue("Sekil3.jpg");
printQueue.Dequeue(); // Sened1.pdf çap olunur
printQueue.Dequeue(); // Sened2.docx çap olunur
Console.WriteLine("\n=== 3. LINKED LIST TESTİ (Musiqi Pleylisti) ===");
CustomLinkedList<string> playlist = new CustomLinkedList<string>();
playlist.Add("Mahnı A");
playlist.Add("Mahnı B");
playlist.Add("Mahnı C");
playlist.PrintPlaylist();
Console.ReadLine();
}
}
}
