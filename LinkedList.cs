namespace G4G
{
    public class Node
    {
        public int Data;
        public Node Next;

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

            Console.Write("DeleteFromBegining ");
            Print(DeleteFromBegining(head));

            Console.Write("DeleteAtEnd ");
            Print(DeleteAtEnd(head));

            Console.Write("DeleteFromPostion ");
            Print(DeleteFromPostion(head, 3));

            Console.Write("SearchKeyExists ");
            Console.WriteLine(SearchKeyExists(head, 3));

            Console.Write("ReverseList ");
            Print(ReverseList(head));
        }

        public static void Print(Node head)
        {
            var temp = head;
            while (temp != null)
            {
                Console.Write(temp.Data + " ");
                temp = temp.Next;
            }
            Console.WriteLine();
        }

        public static Node InsertAtBegining(Node head, int data)
        {
            var node = new Node(data);

            if (head == null)
                return node;

            node.Next = head;
            head = node;

            return head;
        }

        public static Node? InsertAtEnd(Node? head, int data)
        {
            if (head == null)
                return new Node(data);
            
            var curr = head;
            while(curr.Next != null)
            {
                curr = curr.Next;
            }

            curr.Next = new Node(data);
            
            return head;
        }

        public static Node InsertAtPosition(Node head, int pos, int data)
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
    
        public static Node DeleteFromBegining(Node head)
        {
            if(head == null) return head;

            var temp = head;
            head = head.Next;
            temp = null; // Release the memory

            return head;
        }
    
        public static Node DeleteAtEnd(Node head)
        {
            if(head == null) return head;

            if(head.Next == null)
            {
                head = null;
                return head;
            }

            var secondLast = head;
            while(secondLast.Next.Next != null)
            {
                secondLast = secondLast.Next;
            }

            secondLast.Next = null;

            return head;
        }
    
        public static Node DeleteFromPostion(Node head, int pos)
        {
            if(head == null || pos < 1) return head;

            if(pos == 1)
            {
                head = head.Next;
                return head;
            }

            var curr = head;
            for(int i = 1; i < pos -1; i++)
            {
                curr = curr.Next;
            }

            curr.Next = curr.Next.Next;

            return head;
        }
    
        public static Node DeleteFromPosition2(Node head, int pos)
        {
            if (head == null || pos < 1) return head;

            if (pos == 1)
            {
                return head.Next;
            }

            Node prev = null;
            var curr = head;

            // Your exact loop header
            for (int i = 1; i < pos; i++)
            {
                prev = curr;       // Save current node as previous
                curr = curr.Next;  // Move forward

                // Safety check: position is out of bounds
                if (curr == null) return head; 
            }

            // Safely bypass the current node using the previous node
            prev.Next = curr.Next;

            return head;
        }
    
        public static bool SearchKeyExists(Node head, int key)
        {
            var curr = head;

            while(curr != null)
            {
                if(curr.Data == key) return true;
                curr = curr.Next;
            }

            return false;
        }
    
        public static Node ReverseList(Node head)
        {
            var curr = head;
            Node prev = null;
            Node next = null;
            
            while(curr != null)
            {
                next = curr.Next;
                
                curr.Next = prev;
                prev = curr;
                curr = next;
            }

            return prev;
        }
    }
}