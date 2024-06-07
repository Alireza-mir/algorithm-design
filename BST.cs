using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarytreeNode A = new BinarytreeNode(30);
            BinarytreeNode B = new BinarytreeNode(19);
            BinarytreeNode C = new BinarytreeNode(15);
            BinarytreeNode D = new BinarytreeNode(11);
            BinarytreeNode E = new BinarytreeNode(18,C,B);
            BinarytreeNode F = new BinarytreeNode(25);
            BinarytreeNode G = new BinarytreeNode(32,A,null);
            BinarytreeNode H = new BinarytreeNode(14,D,E);
            BinarytreeNode I = new BinarytreeNode(28,F,G);
            BinarytreeNode J = new BinarytreeNode(21,H,I);


            BinarytreeNode a = new BinarytreeNode(10);
            BinarytreeNode b = new BinarytreeNode(27);
            BinarytreeNode c = new BinarytreeNode(38);
            BinarytreeNode d = new BinarytreeNode(26,a,b);
            BinarytreeNode e = new BinarytreeNode(31,d,c);

            //BinarytreeNode.merg(J, e);
            //BinarytreeNode.ADDNode(J, 7);
            BinarytreeNode.DeleteNode(J, 14);
            BinarytreeNode.printtree(J);
            Console.WriteLine("-----------------------");
            BinarytreeNode.printtree(e);
            Console.WriteLine("the number after 21 is :"+BinarytreeNode.After(J).data);
            Console.WriteLine("the number before 21 is :" + BinarytreeNode.Before(J).data);
            
            BinarytreeNode.inorder(J);
            Console.WriteLine("");
            Console.WriteLine("7th Biggest adad is :" + BinarytreeNode.Kaominadad(J).data);




            MaxHeap node1 = new MaxHeap(10);
            MaxHeap node2 = new MaxHeap(20);
            MaxHeap node3 = new MaxHeap(30);
            MaxHeap node4 = new MaxHeap(40);
            MaxHeap node5 = new MaxHeap(50);

            List<int> nodes = new List<int>();
            nodes.Add(node1.number);
            nodes.Add(node2.number);
            nodes.Add(node3.number);
            nodes.Add(node4.number);
            nodes.Add(node5.number);
            nodes.Add(BinarytreeNode.Kaominadad(J).data);

            int[] l=nodes.ToArray();

            MaxHeap.BuildMaxHeap(l);

            Console.WriteLine("Maxheap nodes are :");
            for (int i = 0; i < MaxHeap.HeapSize+1; i++)
            {
                Console.Write(" " + l[i]);
            
            
            }



                Console.ReadKey();


        }
    }
    class BinarytreeNode
    {
        public int data;
        public BinarytreeNode Left;
        public BinarytreeNode Right;

        

        public BinarytreeNode(int D)
        {
            data = D;
            Left = null;
            Right = null;
        }

        public BinarytreeNode(int D, BinarytreeNode L, BinarytreeNode R)
        {
            data = D;
            Left = L;
            Right = R;
        }

        public static BinarytreeNode ADDNode(BinarytreeNode R, int Dataa)
        {
            if (R == null)
            {
                return new BinarytreeNode(Dataa);
            }
            if (Dataa < R.data)
            {
                R.Left = ADDNode(R.Left, Dataa);
            }
            else if (Dataa > R.data)
            {
                R.Right = ADDNode(R.Right, Dataa);
            }

            return R;
        }


        public static void printtree(BinarytreeNode R, int level = 0)
        {

            if (R == null) return;
            printtree(R.Right, level + 1);
            Console.WriteLine(new string(' ', level * 4) + R.data);
            printtree(R.Left, level + 1);
        }
        public static BinarytreeNode After(BinarytreeNode Node)
        {
            return minnode(Node.Right);

        }
        public static BinarytreeNode Before(BinarytreeNode Node)
        {
            return maxnode(Node.Left);
        }
       
        private static BinarytreeNode minnode(BinarytreeNode R)
        {
            BinarytreeNode min = R;

            while (min.Left != null)
            {
                min = min.Left;
            }
            return min;

        }
        private static BinarytreeNode maxnode(BinarytreeNode R)
        {
            BinarytreeNode max = R;
            while (max.Right != null)
            {
                max = max.Right;
            }
            return max;

        }

        public static BinarytreeNode DeleteNode(BinarytreeNode R, int Data)
        {
            if (R == null)
                return null;
            if (Data < R.data)
            {
                R.Left = DeleteNode(R.Left, Data);
            }
            else if (Data > R.data)
            {
                R.Right = DeleteNode(R.Right, Data);
            }
            else
            {
                //one or no child
                if (R.Left == null)
                {
                    return R.Right;
                }
                else if (R.Right == null)
                {
                    return R.Left;
                }            
                //Two child
                BinarytreeNode temp = After(R);
                R.data = temp.data;
                R.Right = DeleteNode(R.Right, temp.data);

            }
            return R;
                

        }

        public static void merg(BinarytreeNode R1,BinarytreeNode R)
        {
            if (R == null)
                return;
            merg(R1,R.Left);
            ADDNode(R1, R.data);
            merg(R1,R.Right);
        }
        public static BinarytreeNode Kaominadad(BinarytreeNode R)
        {
            List<BinarytreeNode> N = new List<BinarytreeNode>();

            BinarytreeNode.kaominadadHelper(R, N);

            N.Reverse();

            return N[6];
        
        
        }
        public static void  kaominadadHelper(BinarytreeNode R,List<BinarytreeNode> Node)
        {

            if (R == null)
                return ;
            kaominadadHelper(R.Left, Node);
            Node.Add(R);
            kaominadadHelper(R.Right, Node);
            
        }
        public static void inorder(BinarytreeNode R)
        {
            if (R == null)
                return;
            inorder(R.Left);
            Console.Write(R.data+" ");
            inorder(R.Right);
        }



    }
    class MaxHeap
    {
     
        public int number;
        
        public static int HeapSize = 0;

        public MaxHeap(int n)
        {
            number = n;
            HeapSize++;
        
        }
        
        
        
        
        public static void Max_Heapify(int[] A, int i)
        {
            int l, r, Bigchild, Temp;

            l = 2 * i;
            r = 2 * i + 1;
            if (l < HeapSize && A[l] > A[i])
                Bigchild = l;
            else
                Bigchild = i;
            if (r < HeapSize && A[r] > A[Bigchild])
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

            for (int i = HeapSize / 2; i >=0; i--)
            {
                Max_Heapify(A, i);
            }
        }

    
    
    
    
    
    
    }
}
