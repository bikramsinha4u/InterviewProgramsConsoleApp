namespace G4G
{
    public class DLNode
    {
        public DLNode Prev;
        public int Data;
        public DLNode Next;

        public DLNode(int data)
        {
            Prev = null;
            Data = data;
            Next = null;
        }
    }
    public class DoublyLinkedList
    {
       public static void Main(string[] args)
        {
            DLNode head = new DLNode(1);
            
            head.Next = new DLNode(2);
            head.Next.Prev = head;
            
            head.Next.Next = new DLNode(3);
            head.Next.Next.Prev = head.Next;

            Console.Write("Doubly Linked List: ");
            Print(head);
            
            Console.Write("PrintFromEnd: ");
            PrintFromEnd(head);

            Console.Write("InsertAtPos: ");
            Print(InsertAtPos(head, 2, 10));

            Console.Write("DeleteFromPos: ");
            Print(DeleteFromPos(head, 2));

            Console.Write("Reverse: ");
            Print(Reverse(head));
        }

        public static void Print(DLNode head)
        {
            var temp = head;
            while (temp != null)
            {
                Console.Write(temp.Data + " ");
                temp = temp.Next;
            }
            Console.WriteLine();
        }
    
        public static void PrintFromEnd(DLNode head)
        {
            var temp = head;
            while(temp.Next != null)
            {
                temp = temp.Next;
            }

            while(temp != null)
            {
                Console.Write(temp.Data + " ");
                temp = temp.Prev;
            }
            Console.WriteLine();
        }
    
        public static DLNode InsertAtPos(DLNode head, int pos, int key)
        {
            if(head == null || pos < 1)  return head;
            
            var newNode = new DLNode(key);

            if (pos == 1)
            {
                newNode.Next = head;
                head.Prev = newNode;
                return head;
            }
                
            var curr = head;

            for(int i = 1; i < pos - 1 && curr != null; i++)
            {
                curr = curr.Next;
            }  

            // Boundary check: Position is too large for the current list length
            if(curr == null)
            {
                return head;
            }

            // Inserting at the very end of the list
            if(curr.Next == null) 
            { 
                curr.Next = newNode; 
                newNode.Prev = curr; 
            } 
            // Inserting in the middle of the list
            else 
            { 
                newNode.Next = curr.Next; 
                curr.Next.Prev = newNode; // Crucial fix: update the next node's backlink
                curr.Next = newNode; 
                newNode.Prev = curr; 
            } 

            return head;
        }

        public static DLNode DeleteFromPos(DLNode head, int pos)
        {
            if(head == null || pos < 1) return head;

            if (pos == 1)
            {
                head = head.Next;
                if (head != null)
                {
                    head.Prev = null; // Clear the backlink of the new head
                }
                return head;
            }

            var curr = head;
            for(int i = 1; i < pos - 1 && curr != null; i++)
            {
                curr = curr.Next;
            }

            // Validate if the position exceeds the list bounds
            // (curr.Next is the actual node targeted for deletion)
            if (curr == null || curr.Next == null)
            {
                return head; 
            }

            // Capture the node to be deleted
            DLNode nodeToDelete = curr.Next; 
            curr.Next = nodeToDelete.Next; 
            
            if (nodeToDelete.Next != null)
            {
                nodeToDelete.Next.Prev = curr;
            }

            return head;
        }

        public static DLNode Reverse(DLNode head)
        {
            if(head == null || head.Next == null) return head;

            DLNode curr = head;
            DLNode temp = null;

            // Traverse the list and swap pointers
            while (curr != null)
            {
                // Swap Next and Prev pointers
                temp = curr.Prev;
                curr.Prev = curr.Next;
                curr.Next = temp;

                // Move to the next node (which is now in curr.Prev)
                curr = curr.Prev;
            }

            /*
            Node 3: temp becomes Node 2. Next points to Node 2, Prev points to null. 
            curr becomes null.
            
            Loop Ends: curr is null. temp holds Node 2. 
            The method returns temp.Prev (Node 3), which is the new head.
            */
            // Set the new head to the last non-null node processed
            return temp.Prev;
        }
    }
}