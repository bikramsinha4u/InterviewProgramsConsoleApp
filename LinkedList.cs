using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Transactions;

namespace InterviewProgramsConsoleApp
{
    public class Node
    {
        public int Data { get; set;}
        public Node? Next { get; set;}

        public Node(int data)
        {
            Data = data;
            Next = null;
        }
    }
    public class LinkedList
    {
        public static void Main(string[] args)
        {
            Node head = new Node(1);
            head.Next = new Node(2);
            head.Next.Next = new Node(3);
            
            
            Console.Write("InserAtBegining ");
            Print(InsertAtBegining(head, 0));
            
            Console.Write("InsertAtEnd ");
            Print(InsertAtEnd(head, 4));
            
            Console.Write("InsertAtPosition ");
            Print(InsertAtPosition(head, 3, 10));

        }

        public static void Print(Node? head)
        {
            while (head != null)
            {
                Console.Write(head.Data + " ");
                head = head.Next;
            }
            Console.WriteLine();
        }

        public static Node InsertAtBegining(Node? head, int data)
        {
            var node = new Node(data);
            node.Next = head;
            head = node;

            return head;
        }

        public static Node InsertAtEnd(Node? head, int data)
        {
            if (head == null) {
                return new Node(data);
        }
            var curr = head;
            while(curr?.Next != null)
            {
                curr = curr.Next;
            }

            curr.Next = new Node(data);
            
            return head;
        }

        public static Node InsertAtPosition(Node? head, int pos, int data)
        {
            if (pos < 1) return head;
                
            if(pos == 1)
                return InsertAtBegining(head, data);
            
            var curr = head;
            for(int i = 1; i < pos - 1 && curr != null; i++)
            {
                curr = curr.Next;
            }

            // if pos is not available
            if(curr == null) return head;

            var node = new Node(data);
            node.Next = curr.Next;
            curr.Next = node;

            return head;
        }
    }
}