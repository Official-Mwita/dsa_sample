namespace DSA.Models
{
    public class Node
    {
        Node next, prev;
        Student data;

        public Node(Student _Student)
        {
            data = _Student;

        }

        public Student Data
        {
            get { return data; }
        }

        public Node Next
        {
            get { return next; }
            set { next = value; }
        }

        public Node Prev
        {
            get { return prev; }
            set { prev = value; }
        }
    }
}
