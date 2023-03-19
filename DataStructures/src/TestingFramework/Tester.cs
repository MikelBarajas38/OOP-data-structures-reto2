using UASLP.Objetos.List.Interfaces;
using UASLP.Objetos.List.ArrayList;
using UASLP.Objetos.List.LinkedList;

namespace TestingFramework
{
    public class Tester
    {
        public static void Main(string[] args)
        {
            IUList<Object> list1 = new ULinkedList<Object>();
            IUList<Object> list2 = new UArrayList<Object>();

            Console.WriteLine("\nTest list1 (LinkedList)");
            TestAddAtFront(list1);
            TestAddAtTail(list1);
            TestRemoveNthElement(list1);
            TestSetAtIndex(list1);
            TestGetAtIndex(list1);
            TestRemoveAllWithValue(list1);

            Console.WriteLine("\nTest list2 (ArrayList)");
            TestAddAtFront(list2);
            TestAddAtTail(list2);
            TestRemoveNthElement(list2);
            TestSetAtIndex(list2);
            TestGetAtIndex(list2);
            TestRemoveAllWithValue(list2);
        }

        private static void TestRemoveAllWithValue(IUList<Object> list)
        {
            Console.WriteLine("\n-> Test remove all with value.");
            list.AddAtTail("A");
            list.AddAtTail(1);
            list.AddAtTail(1);
            list.AddAtTail("A");
            list.AddAtTail(1);
            list.AddAtTail("A");
            printList(list);
            Console.WriteLine("Size: " + list.GetSize() + " Capacity: ");
            list.RemoveAllWithValue("A");
            printList(list);
            Console.WriteLine("Size: " + list.GetSize());
            list.RemoveAllWithValue(1);
            printList(list);
            Console.WriteLine("Size: " + list.GetSize());
        }

        private static void TestGetAtIndex(IUList<Object> list)
        {
            Console.WriteLine("\n-> Test get at index.");
            list.AddAtTail("0");
            list.AddAtTail(1);
            list.AddAtTail('2');
            printList(list);
            Console.WriteLine(list.GetAt(0));
            Console.WriteLine(list.GetAt(1));
            Console.WriteLine(list.GetAt(2));
            Console.WriteLine(list.GetAt(3));
            list.RemoveAll();
        }

        private static void TestSetAtIndex(IUList<Object> list)
        {
            Console.WriteLine("\n-> Test set at index.");
            list.AddAtTail("A");
            list.AddAtTail(2);
            list.AddAtTail(3);
            list.AddAtTail("D");
            printList(list);
            list.SetAt(0, "X");
            list.SetAt(1, 10);
            list.SetAt(3, "Z");
            list.SetAt(4, "ERROR");
            printList(list);
            list.RemoveAll();
        }

        private static void TestRemoveNthElement(IUList<Object> list)
        {
            Console.WriteLine("\n-> Test remove nth-element.");
            list.AddAtTail("A");
            list.AddAtTail(2);
            list.AddAtTail("C");
            list.AddAtTail(4);
            printList(list);
            Console.WriteLine("Size: " + list.GetSize());
            list.Remove(4);
            list.Remove(3);
            list.Remove(1);
            list.Remove(0);
            printList(list);
            Console.WriteLine("Size: " + list.GetSize());
            list.Remove(0);
            printList(list);
            Console.WriteLine("Size: " + list.GetSize());
            list.Remove(0);
        }

        private static void TestAddAtTail(IUList<Object> list)
        {
            Console.WriteLine("\n-> Test add at Tail.");
            list.AddAtTail("A");
            list.AddAtTail('C');
            list.AddAtTail(3);
            printList(list);
            Console.WriteLine("Size: " + list.GetSize());
            list.RemoveAll();
        }

        private static void TestAddAtFront(IUList<Object> list)
        {
            Console.WriteLine("\n-> Test add at Front.");
            list.AddAtFront("A");
            list.AddAtFront(2);
            list.AddAtFront('C');
            printList(list);
            Console.WriteLine("Size: " + list.GetSize());
            list.RemoveAll();
        }

        public static void printList(IUList<Object> list)
        {
            IIterator<Object> it = list.GetIterator();
            Console.Write("List contents: ");
            while (it.HasNext())
            {
                Console.Write(it.Next() + " ");
            }
            Console.Write("\n");
        }
    }
}
