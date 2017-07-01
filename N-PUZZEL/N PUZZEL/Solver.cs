using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;

namespace N_PUZZEL
{
    class Solver
    {
        private Pqueue MyQueue;
        private TreeNode FreeNod;
        private List<TreeNode> MyPath;
        private int MminNumOFMov { set; get; }
        private bool solvability { set; get; }
        private Hashtable closeList;
        private string Method;
        private TreeNode Root;
        private TreeNode LastNod;
        public int countr;

        public Solver(TreeNode root, String method)
        {
            Method = method;
            Root = root;
            MyQueue = new Pqueue(Method);
            MyPath = new List<TreeNode>();
            closeList = new Hashtable();
            countr = 0;
        }
        public bool solvabile()
        {

            solvability = Solvability.CheckSolvability(Root);
            return solvability;
        
        }

        public List<TreeNode> GetMyPath()
        { return MyPath; }

        public void Solve()
        {

            int ix = 0;
            
            MyQueue.Add(Root);

            

            CreateChilde x = new CreateChilde();

            

            while (MyQueue.GetCount() > 0)
            {

                ix++;

                FreeNod = MyQueue.GetMin();
               
                closeList.Add(FreeNod.id, FreeNod);

                if (FreeNod.Heuristicvalue(Method) == 0)
                {

                    LastNod = FreeNod;
                    break;
                }

                x.SetNod(FreeNod);
                List<TreeNode> T = x.Create();
                int count = T.Count;
                for (int i = 0; i < count; i++)
                {


                    if (!(MyQueue.contains(T[i].id) || closeList.ContainsKey(T[i].id)))
                    {


                        MyQueue.Add(T[i]);
                       

                    }
                    else
                    {


                        if (MyQueue.contains(T[i].id))
                        {

                           
                            int g = MyQueue.GetAt(T[i].id);

                            

                            if (MyQueue.Getbyindex(g).GetPriority(Method) > T[i].GetPriority(Method))
                            {
                                MyQueue.delAt(g);
                                MyQueue.Add(T[i]);

                            }


                        }


                        if (closeList.ContainsKey(T[i].id))
                        {


                            TreeNode b = (TreeNode)closeList[T[i].id];


                            if (b.GetPriority(Method) > T[i].GetPriority(Method))
                            {

                                closeList.Remove(T[i].id);
                                closeList.Add(T[i].id, T[i]);


                            }

                        }

                    }

                }

                if (ix % 1000000 == 0)
                    GC.Collect();

                    
            }
         
            GetPath();
            countr = ix;
        }

        private void GetPath()
        {
            while (true)
            {

                MyPath.Add(LastNod);

                if (LastNod.IsRoot())
                    break;

                LastNod = (TreeNode)closeList[LastNod.GetMyperent()];

            }

           
        }







    }
}
