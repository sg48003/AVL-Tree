using System;

namespace NASP_AVLStablo
{
    public class Node
    {
        public int Value;
        public int Height;
        public Node LeftChild;
        public Node RightChild;

        public Node(int number)
        {
            Value = number;
            LeftChild = null;
            RightChild = null;
            Height = 1;
        }

        public static int GetHeight(Node root)
        {
            return root?.Height ?? 0;
        }

        public static int SetHeight(Node root)
        {
            int leftChild = root.LeftChild?.Height ?? 0;
            int rightChild = root.RightChild?.Height ?? 0;
            return 1 + Math.Max(leftChild, rightChild);
        }
    }
}
