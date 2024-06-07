using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximum_priority_queue
{
    class Program
    {
        static void Main(string[] args)
        {
            MaxHeap person1 = new MaxHeap("Alireza", "mir", 20, "F");
            MaxHeap person3 = new MaxHeap("mohammad", "mohammadi", 50, "B");
            MaxHeap person2 = new MaxHeap("zahra", "forghani", 30, "C");
            MaxHeap person4 = new MaxHeap("abolfazl", "mehrani", 25, "D");
            MaxHeap person5 = new MaxHeap("nazanin", "aslani", 25, "F");
            MaxHeap person6 = new MaxHeap("ahmad", "karimi", 30, "A");
            List<int> list = new List<int>();
            list.Add(person1.Priority);
            list.Add(person2.Priority);
            list.Add(person3.Priority);
            list.Add(person4.Priority);
            list.Add(person5.Priority);
            list.Add(person6.Priority);
           
            MaxHeap newPerson1 = new MaxHeap("ali", "mortazavi", 24, "F");
            list.Add(newPerson1.Priority);
            MaxHeap newPerson2 = new MaxHeap("mammad", "aghaee", 15, "F");
            list.Add(newPerson2.Priority);
            
            int[] peaple = new int[30];
            peaple = list.ToArray();
            

            MaxHeap.BuildMaxHeap(peaple);

            
            Console.WriteLine(MaxHeap.DeleteFromQueue(peaple));
            Console.WriteLine(MaxHeap.DeleteFromQueue(peaple));
            Console.WriteLine(MaxHeap.DeleteFromQueue(peaple));
            Console.WriteLine(MaxHeap.DeleteFromQueue(peaple));

            
            Console.Write("priority in array is :");

            for (int i = 0; i < MaxHeap.heapsize; i++)
            {
                Console.Write(" " + peaple[i]);
 
            
            }
            Console.WriteLine(" ");
            


            Console.ReadKey();


        }
    }


    class MaxHeap
    {
        private string Fname;
        private string Lname;
        private int Age;
        private string Skill;
        public int Priority;
        public static int heapsize = 0;
        public MaxHeap(string FN, string LN, int Ag, string Skil)
        {
            Fname = FN;
            Lname = LN;
            Age = Ag;
            Skill = Skil;

            if (Skill == "A")
                Priority = 100 / Age;
            if (Skill == "B")
                Priority = 200 / Age;
            if (Skill == "C")
                Priority = 300 / Age;
            if (Skill == "D")
                Priority = 400 / Age;
            if (Skill == "E")
                Priority = 500 / Age;
            if (Skill == "F")
                Priority = 600 / Age;

            heapsize++;
        }

        public static void Max_Heapify(int[] A, int i)
        {
            int l, r, Bigchild, Temp;

            l = 2 * i ;
            r = 2 * i + 1;
            if (l < heapsize && A[l] > A[i])
                Bigchild = l;
            else
                Bigchild = i;
            if (r < heapsize && A[r] > A[Bigchild])
                Bigchild = r;

            if (Bigchild != i)
            {
                Temp = A[i];
                A[i] = A[Bigchild];
                A[Bigchild] = Temp;
                Max_Heapify(A, Bigchild);
            }
        }

        public static void BuildMaxHeap(int[] A)
        {

            for (int i = heapsize / 2; i >= 0; i--)
            {
                Max_Heapify(A, i);
            }
        }



       
        public static void AddtoQueue(int[] A, int prio)
        {

            heapsize++;
            A[heapsize] = -1000;
            increasePriority(A, heapsize, prio);

        }

        public static void increasePriority(int[] A, int i, int pr)
        {
            int temp = 0;
            if (pr < A[i])
            {
                Console.WriteLine("new priority is smaller than Current priority");
                return;
            }
            A[i] = pr;
            while (i > 1 && A[i / 2] < A[i])
            {
                temp = A[i];
                A[i] = A[i / 2];
                A[i / 2] = temp;

                i = i / 2;
            }


        }
        public static int DeleteFromQueue(int[] A)
        { 
            int max = A[0];
            A[0] = A[heapsize-1];
            heapsize--;
            Max_Heapify(A,0);
            return max;
        }

    }

}
