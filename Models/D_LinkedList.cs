using System.Xml.Linq;

namespace DSA.Models
{
    public class D_LinkedList
    {
        Node head; //the first node of the list
        Node current; //The pointer to the current node. Used for traversal
        int size; //keeps track of the current list size

        public D_LinkedList()
        {
            head = null;
            current = head;
            size = 0;
        }

        public int Size
        {
            get { return size; }
            set { size = value; }
        }

        public Node Head
        {
            get { return head; }
            set { head = value; }
        }

        public Node Current
        {
            get { return current; }
            set { current = value; }
        }

        public string TestString
        {
            get; set;
        }

        public static void InsertNode(D_LinkedList list, Student data)
        {
            //Create the new node
            Node _Node = new Node(data);

            //Check if head is set. Otherwise set this to head
            if (list.Head == null)
            {
                list.Head = _Node;
            }
            else //Get last node then instert it properly
            {
                Node last = GetLast(list);
                last.Next = _Node;
                _Node.Prev = last;

            }

            //After every addition increment
            list.Size = list.Size + 1;


        }

        /**
            Returns a pointer to the current node in the list in Right traversal
         */
        public static Node TraverseRight(D_LinkedList list)
        {

            if (list.current == null
                && list.size > 0)//Start of traversal
            {
                list.current = list.head;
            }
            else if (list.current.Next != null)//Only when we can traverse the list
            {
                list.current = list.current.Next;
            }


            return list.current;
        }

        /**
            Returns a pointer to the current list in Left traversal
         */
        public static Node TraverseLeft(D_LinkedList list)
        {
            if (list.Current == null
               && list.Size > 0)//Start of traversal
            {
                list.Current = list.Head;
            }
            else if (list.Current != list.Head && list.Size > 1)//Only when we can traverse the list
            {                                                   //Since it is not the head, and the list has previous
                list.Current = list.Current.Prev;
            }


            return list.Current;
        }

        public static Node GetLast(D_LinkedList list)
        {
            Node _Node = list.head;

            while (_Node.Next != null)
            {
                _Node = _Node.Next;

            }

            return _Node;

        }

        public static void InsertFirst(D_LinkedList list, Student data)
        {
            Node temp = list.Head; //Temporary store our head node

            Node _Node = new Node(data); //We create a new node to instert first

            // Now set the next of this list to point to old head
            _Node.Next = temp;

            //Set the old head temp to hold this new node
            temp.Prev = _Node;

            //Set the head of the list point to this newly created node
            list.Head = _Node;

            //After every addition increment
            list.Size = list.Size + 1;

        }

    }
}
