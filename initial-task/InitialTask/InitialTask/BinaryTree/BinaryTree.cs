namespace InitialTask.BinaryTree
{
    public class BinaryTree
    {
        public int? Data;
        public BinaryTree Left;
        public BinaryTree Right;
        public BinaryTree Parent;

        public void Insert(int data)
        {
            if (Data == null || Data == data)
            {
                Data = data;
                return;
            }

            if (Data > data)
            {
                if (Left == null) Left = new BinaryTree();
                Insert(data, Left, this);
            }
            else
            {
                if (Right == null) Right = new BinaryTree();
                Insert(data, Right, this);
            }
        }
        private void Insert(int data, BinaryTree node, BinaryTree Parent)
        {
            if (node.Data == null || node.Data == data)
            {
                node.Data = data;
                node.Parent = Parent;
                return;
            }
            
            if (node.Data > data)
            {
                if (node.Left == null) node.Left = new BinaryTree();
                Insert(data, node.Left, node);
            }
            else
            {
                if (node.Right == null) node.Right = new BinaryTree();
                Insert(data, node.Right, node);
            }
        }

        public BinaryTree Search(int data)
        {
            if (Data == data) return this;
            if (Data > data)
                return Search(data, Left);
            return Search(data, Right);
        } 
        private BinaryTree Search(int data, BinaryTree node)
        {
            if (node == null) return null;
            if (node.Data == data) return node;
            if (node.Data > data)
                return Search(data, node.Left);
            return Search(data, node.Right);
        }

        public bool Remove(int data)
        {
            BinaryTree tree = Search(data);
            if (tree == null)
            {
                return false;
            } 
            BinaryTree current;
  
            // Если удаляем корень
            if (tree == this)
            {
                current = tree.Right ?? tree.Left;

                while (current.Left != null) 
                {
                    current = current.Left;
                }
                int temp = current.Data.Value;
                this.Remove(temp);
                tree.Data = temp;

                return true;
            }

            // Удаление листьев
            if (tree.Left == null && tree.Right == null && tree.Parent != null)
            {
                if(tree == tree.Parent.Left)
                    tree.Parent.Left = null;
                else
                    tree.Parent.Right = null;
                return true;
            }

            // Удаление узла, имеющего левое поддерево, но не имеющее правого поддерева
            if (tree.Left != null && tree.Right == null)
            {
                tree.Left.Parent = tree.Parent;
                if(tree == tree.Parent.Left)
                    tree.Parent.Left = tree.Left;
                else if(tree == tree.Parent.Right)
                    tree.Parent.Right = tree.Left;
                return true;
            }

            // Удаление узла, имеющего правое поддерево, но не имеющее левого поддерева
            if (tree.Left == null && tree.Right != null)
            {
                tree.Right.Parent = tree.Parent;
                if (tree == tree.Parent.Left)
                    tree.Parent.Left = tree.Right;
                else if (tree == tree.Parent.Right)
                    tree.Parent.Right = tree.Right;
                return true;
            }

            if (tree.Right != null && tree.Left != null)
            {
                current = tree.Right;
                while (current.Left != null)
                {
                    current = current.Left;
                }

                // Если самый левый элемент является первым потомком
                if (current.Parent == tree)
                {
                    current.Left = tree.Left;
                    tree.Left.Parent = current;
                    current.Parent = tree.Parent;
                    if (tree == tree.Parent.Left)
                    {
                        tree.Parent.Left = current;
                    }
                    else if (tree == tree.Parent.Right)
                    {
                        tree.Parent.Right = current;
                    }

                    return true;
                }
                // Если самый левый элемент НЕ является первым потомком
                else
                {
                    if (current.Right != null)
                    {
                        current.Right.Parent = current.Parent;
                    }

                    current.Parent.Left = current.Right;
                    current.Right = tree.Right;
                    current.Left = tree.Left;
                    tree.Left.Parent = current;
                    tree.Right.Parent = current;
                    current.Parent = tree.Parent;
                    if (tree == tree.Parent.Left)
                    {
                        tree.Parent.Left = current;
                    }
                    else if (tree == tree.Parent.Right)
                    {
                        tree.Parent.Right = current;
                    }

                    return true;
                }
            }

            return false;
        }
    }
}