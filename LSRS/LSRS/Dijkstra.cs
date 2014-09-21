using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace LSRS
{
    class Dijkstra
    {
        private int n = 0;
        private int[,] L;
        public int[] C;
        public int[] D;
        public int u;
        public int startnode;
        public bool[] S; //Shortest path vetex set
        public void Initial(int num, int[,] arr, int v)
        {
            L = new int[num, num];
            C = new int[num];
            D = new int[num];
            S = new bool[num];
            n = num;
            startnode = v;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    L[i, j] = arr[i, j];
                }
            }
            //Initialize distance array
            for (int i = 0; i < n; i++)
            {
                S[i] = false;
                if (L[v, i] != -1)
                    D[i] = L[v, i];
                else
                    D[i] = Int32.MaxValue;
                if (i != v && D[i] != -1)
                    C[i] = v;
                else C[i] = -1;
            }
        }
        public void DijkstraSolving()
        {
            int minValue;
            int j;
            //Add source vertex to S
            S[startnode] = true;
            D[startnode] = 0;
            for (int i = 0; i < n - 1; i++)
            {
                //Choose vetex u out of S, with shortest distance 
                u = startnode;
                minValue = Int32.MaxValue;
                for (j = 0; j < n; j++)
                {
                    if (S[j] == false && D[j] < minValue)
                    {
                        minValue = D[j];
                        u = j;
                    }
                }
                S[u] = true;
                //Modify shortest distance from u to other vetex
                for (int k = 0; k < n; k++)
                {
                    //When a vetex k out of S has shorter path than existing one 
                    if (S[k] == false && L[u, k] != -1 && D[u] + L[u, k] < D[k])
                    {
                        //modify shortest distance and path  
                        D[k] = D[u] + L[u, k];
                        C[k] = u;
                    }
                }
            }
        }
        public string printPath(int o)
        {
            string s = "";
            int m = o;
            while (C[m] != -1)
            { 
                s = (C[m]+1).ToString()+" "+s;
                m = C[m];
            }
            if (o == startnode) {
                s = "NULL";
            }
            return s;
        }
    }
}
