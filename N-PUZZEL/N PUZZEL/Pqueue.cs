using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace N_PUZZEL
{
    class Pqueue 
    {

       private List<TreeNode> MyQueue;
       private String Method;
       private Hashtable map;


        public int GetAt(int id)
       {
           return (int)map[id];

       }
        public void delAt(int i)
        {


        map.Remove(MyQueue[i].id);

        map.Remove(MyQueue[GetTop()].id);


        MyQueue[i] = MyQueue[GetTop()];

        MyQueue.RemoveAt(GetTop());

        if(i<=GetTop())
        map.Add(MyQueue[i].id, i);

        AfterRemove(i);

            
        }




        public Pqueue(String method)
        {

            MyQueue = new List<TreeNode>(1000000);
            Method = method;
            map = new Hashtable();
        }
        private int GetTop()
        {

            return MyQueue.Count - 1;

        }
        public int GetCount()
        {

            return MyQueue.Count;


        }
        public bool contains(int id)
        { 
            return map.ContainsKey(id); 
        
        }

        public void Add(TreeNode elemnt)
        {

            MyQueue.Add(elemnt);

            map.Add(elemnt.id, GetTop());

            AfterAdd(GetTop());
        }

        public TreeNode GetMin()
        {
           TreeNode  Temp = MyQueue[0];

           map.Remove(MyQueue[0].id);
           map.Remove(MyQueue[GetTop()].id);
            
            MyQueue[0] = MyQueue[GetTop()];

            int i = GetTop();

            MyQueue.RemoveAt(i);
            
            if(MyQueue.Count>=1)
            map.Add(MyQueue[0].id, 0);

            AfterRemove(0);

            return Temp;

        }

        public TreeNode Getbyindex(int i)
        { return MyQueue[i]; }


        private void AfterRemove(int perent)
        {

            int left = 2 * perent + 1;
            
            int right = 2 * perent + 2;

            if (left > GetTop()) return;

            if (right <= GetTop() &&( MyQueue[right].CompareTo(MyQueue[left],Method)< 0))
               left = right;

            
            if (MyQueue[perent].GetPriority(Method) <= MyQueue[left].GetPriority(Method)) return;


            else 
            {
                map.Remove(MyQueue[perent].id);
                map.Remove(MyQueue[left].id);

                TreeNode temp = MyQueue[perent];

                MyQueue[perent] = MyQueue[left];

                MyQueue[left] = temp;


                map.Add(MyQueue[perent].id,perent);
                map.Add(MyQueue[left].id, left);

                AfterRemove(left);

            }            

        }
        private void AfterAdd(int Top)
        
        {
            int i = (Top -1) / 2;

            if (Top == 0)
                return;
            else if (MyQueue[Top].CompareTo(MyQueue[i], Method) >= 0)
                return;
            else
            {

                map.Remove(MyQueue[Top].id);
                map.Remove(MyQueue[i].id);

                TreeNode   temp = MyQueue[Top];
                MyQueue[Top] = MyQueue[i];
                MyQueue[i] = temp;

                map.Add(MyQueue[i].id, i);
                map.Add(MyQueue[Top].id, Top);

                AfterAdd(i);

            }

        }

    
    }
}
