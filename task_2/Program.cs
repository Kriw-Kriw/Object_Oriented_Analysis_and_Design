/*Обойти граф с помощью списка смежности и матрицы смежности 
используя шаблонный метод*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_and_P_lab_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] graf1 =  {     new int [] {1,2},
                                                        new int [] {0,2,5},
                                                        new int [] {0,1,3,4},
                                                        new int [] {2,5},
                                                        new int [] {2},
                                                        new int [] {1,3} };


            int[][] graf2 = {  new int []{0,1,1,0,0,0 },
                                        new int []{1,0,1,0,0,1 },
                                        new int []{1,0,0,1,1,0 },
                                        new int []{0,0,1,0,0,1 },
                                        new int []{0,0,1,0,0,0 },
                                        new int []{0,1,0,1,0,0 } };




            ListGraf graf = new ListGraf(graf1);
            graf.usealgorithm(4);
            MatrixGraf graf0 = new MatrixGraf(graf2);
            graf0.usealgorithm(4);


            Console.ReadKey();
        }


        abstract class GrafAlgorithm
        {
            public int[][] graf;


            public void usealgorithm(int n)
            {
                BFS(n);
            }

            public virtual void BFS(int n)
            {
                int[] visit = new int[graf.Length];
                Queue<int> queue = new Queue<int>();
                queue.Enqueue(n);
                visit[n] = 1;
                while (queue.Count > 0)
                {
                    int vertex = queue.Dequeue();
                    Console.WriteLine(vertex);
                    int[] AVertices = adjacentVertices(vertex);
                    for (int i = 0; i < AVertices.Length; i++)
                    {
                        if (AVertices[i] == 1 && visit[i] == 0)
                        {
                            queue.Enqueue(i);
                            visit[i] = 1;
                        }
                    }
                }
                Console.WriteLine(' ');
            }

            public abstract int[] adjacentVertices(int vertex);


        }



        class ListGraf : GrafAlgorithm
        {

            public ListGraf(int[][] graf)
            {
                this.graf = graf;
            }

           

            public override int[] adjacentVertices(int vertex)
            {
                int[] AVertices = Enumerable.Repeat(0, graf.Length).ToArray(); 
                for (int i = 0; i < graf[vertex].Length; ++i)
                {
                    AVertices[graf[vertex][i]] = 1;
                }
                return AVertices;
            }

        }


        class MatrixGraf : GrafAlgorithm
        {
            public MatrixGraf(int[][] graf)
            {
                this.graf = graf;
            }


            public override int[] adjacentVertices(int vertex)
            {
                int[] AVertices = Enumerable.Repeat(0, graf.Length).ToArray();
                for (int i = 0; i < graf[vertex].Length; ++i)
                {
                    if(graf[vertex][i] == 1)
                    {
                        AVertices[i] = 1; 
                    }
                    
                }
                return AVertices;
            }

        }


        //поиск в ширину, n - номер вершины
        //override public void BFS(int n)
        //{
        //    Console.WriteLine($"Поиск в ширину от вершины {n} - СПИСОК СМЕЖНОСТИ");

        //    int[] visit = new int[graf.Length];
        //    Queue<int> queue = new Queue<int>();
        //    queue.Enqueue(n);
        //    visit[n] = 1;
        //    while (queue.Count > 0)
        //    {
        //        int vertex = queue.Dequeue();
        //        Console.WriteLine(vertex);
        //        for (int i = 0; i < graf[vertex].Length; i++)
        //        {
        //            if (visit[graf[vertex][i]] == 0)
        //            {
        //                queue.Enqueue(graf[vertex][i]);
        //                visit[graf[vertex][i]] = 1;
        //            }
        //        }
        //    }
        //    Console.WriteLine(' ');
        //}



        //поиск в ширину, n - номер вершины
        //override public void BFS(int n)
        //{
        //    Console.WriteLine($"Поиск в ширину от вершины {n} - МАТРИЦА СМЕЖНОСТИ");
        //    int[] visit = new int[graf.Length];
        //    Queue<int> queue = new Queue<int>();
        //    queue.Enqueue(n);
        //    visit[n] = 1;
        //    while (queue.Count > 0)
        //    {
        //        int vertex = queue.Dequeue();
        //        Console.WriteLine(vertex);
        //        for (int i = 0; i < graf[vertex].Length; i++)
        //        {
        //            if (graf[vertex][i] == 1 && visit[i] == 0)
        //            {
        //                queue.Enqueue(i);
        //                visit[i] = 1;
        //            }
        //        }
        //    }
        //    Console.WriteLine(' ');
        //}

    }
}







