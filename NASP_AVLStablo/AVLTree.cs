namespace NASP_AVLStablo
{
    // ReSharper disable once InconsistentNaming
    class AVLTree
    {
        public Node Root;

        public void Add(int number)
        {
            Root = Insert(Root, number);
        }

        private Node Insert(Node root,int number)
        {
            #region Adding the number

            if (root == null)
            {
                return new Node(number);
            }
            if (number <= root.Value)
            {
                root.LeftChild = Insert(root.LeftChild, number);
            }
            else
            {
                root.RightChild = Insert(root.RightChild, number);
            }

            #endregion

            #region Balance AVL Tree

            int balance = GetBalance(root.LeftChild, root.RightChild);

            if (balance > 1)
            {
                if (Node.GetHeight(root.LeftChild.LeftChild) > Node.GetHeight(root.LeftChild.RightChild))
                {
                    return RotateRightChild(root);
                }
                else
                {
                    root.LeftChild = RotateLeftChild(root.LeftChild);
                    return RotateRightChild(root);
                }
            }

            if (balance < -1)
            {
                if (Node.GetHeight(root.RightChild.RightChild) > Node.GetHeight(root.RightChild.LeftChild))
                {
                    return RotateLeftChild(root);
                }
                else
                {
                    root.RightChild = RotateRightChild(root.RightChild);
                    return RotateLeftChild(root);
                }
            }

            #endregion

            root.Height = Node.SetHeight(root);
            return root;
        }

        private int GetBalance(Node leftChild, Node rightChild)
        {
            int balance = Node.GetHeight(leftChild) - Node.GetHeight(rightChild);
            return balance;
        }

        private Node RotateLeftChild(Node root)
        {
            Node newRoot = root.RightChild;

            root.RightChild = newRoot.LeftChild;
            newRoot.LeftChild = root;

            root.Height = Node.SetHeight(root);                  
            newRoot.Height = Node.SetHeight(newRoot);    

            return newRoot;
        }

        private static Node RotateRightChild(Node root)
        {
            Node newRoot = root.LeftChild;

            root.LeftChild = newRoot.RightChild;
            newRoot.RightChild = root;

            root.Height = Node.SetHeight(root);        
            newRoot.Height = Node.SetHeight(newRoot);   

            return newRoot;
        }      

        public void Print()
        {
            Root.Print();
        }
    }
}
