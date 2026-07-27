namespace G4G
{
    public class CLLNode
    {
        public int data;
        public CLLNode next;

        public CLLNode(int value) 
        {
            data = value;
            next = null;;
        }
    }
    public class CircularLinkedList
    {
        public static void Main(string[] args)
        {
            var head = new CLLNode(1);
            head.next = new CLLNode(2);
            head.next.next = new CLLNode(3);

            var lastNode = head.next.next;
            lastNode.next = head;

            Console.Write("Circular Linked List: ");
            Print(head);

            Console.Write("DetectLoop: ");
            Console.WriteLine(DetectLoop(head));

            Console.Write("DetectLoopTwoPointer: ");
            Console.WriteLine(DetectLoopTwoPointer(head));
        }

        public static void Print(CLLNode head)
        {
            var temp = head;
            do 
            {
                Console.Write(temp.data + " ");
                 
                if(temp.next == head)
                    Console.Write($": Last node next value: {temp.next.data}");

                temp = temp.next;
            } 
            while (temp != head); 

            Console.WriteLine();
        }

        public static bool DetectLoop(CLLNode head)
        {
            var set = new HashSet<CLLNode>();
            var curr = head;
            while(curr != null)
            {
                if(set.TryGetValue(curr, out _))
                    return true;
                else
                    set.Add(curr);
                
                curr = curr.next;
            }

            return false;
        }

        public static bool DetectLoopTwoPointer(CLLNode head) 
        {
            // fast and slow pointers initially points to the head
             CLLNode slow = head, fast = head;

            // loop that runs while fast and slow pointer are not
            // null and not equal
            while (slow != null && fast != null && fast.next != null) {
                slow = slow.next;
                fast = fast.next.next;

                // if fast and slow pointer points to the same node,
                // then the cycle is detected
                if (slow == fast) {
                    return true;
                }
            }
            return false;
        }       
    }
}