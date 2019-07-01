using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheory
{
    
    class GFG
    {

        static int V = 10;
        static double max_closeness = -9999;
        static double max_eccentricity = -9999;
        int minDistance(int[] dist,
                        bool[] sptSet)
        {
            // Initialize min value 
            int min = int.MaxValue, min_index = -1;

            for (int v = 0; v < V; v++)
                if (sptSet[v] == false && dist[v] <= min)
                {
                    min = dist[v];
                    min_index = v;
                }

            return min_index;
        }

        void printSolution(int[] dist, int n)
        {
            double sum = 0;
            double normalize = 0;
            double inverse = 0;
            double max_ecc = 0;
            double inverse_ecc = 0;
            Console.Write("Vertex     Distance "
                          + "from Source\n");
            for (int i = 0; i < V; i++)
            {
                Console.Write(i + " \t\t " + dist[i] + "\n");
                sum += dist[i];
            }

            //Closeness Centrality
            normalize = sum / 9;
            inverse = 1 / normalize;
            Console.WriteLine("Sum: " + sum);
            Console.WriteLine("Normalize: " + normalize);
            Console.WriteLine("Inverse normalize: " + inverse);
            if (max_closeness < inverse)
            {
                max_closeness = inverse;
            }


            //Eccentricity Centrality
            max_ecc = dist.Max();
            inverse_ecc = 1 / max_ecc;
            Console.WriteLine("Max: " + max_ecc);
            Console.WriteLine("Inverse Max: " + inverse_ecc);
            if (max_eccentricity < inverse_ecc)
            {
                max_eccentricity = inverse_ecc;
            }
            Console.WriteLine();

            sum = 0;
        }

        void dijkstra(int[,] adjMatrix, int src)
        {
            int[] dist = new int[V];


            bool[] sptSet = new bool[V];

            for (int i = 0; i < V; i++)
            {
                dist[i] = int.MaxValue;
                sptSet[i] = false;
            }

            dist[src] = 0;

            for (int count = 0; count < V - 1; count++)
            {
                int u = minDistance(dist, sptSet);
                sptSet[u] = true;

                for (int v = 0; v < V; v++)
                    if (!sptSet[v] && adjMatrix[u, v] != 0 &&
                         dist[u] != int.MaxValue && dist[u] + adjMatrix[u, v] < dist[v])
                        dist[v] = dist[u] + adjMatrix[u, v];
            }
            printSolution(dist, V);
        }

        //

        static void Main(string[] args)
        {
            //Adjacency Matrix
            string character = " ";
            string character2 = " ";
            
            int[,] adjMatrix= new int[,] { { 0,1,1,1,1,1,1,1,1,1 }, 
                                           { 1,0,1,1,1,0,1,0,0,1 }, 
                                           { 1,1,0,1,1,0,1,0,0,0 }, 
                                           { 1,1,1,0,1,1,1,1,1,0 }, 
                                           { 1,1,1,1,0,1,0,0,0,0}, 
                                           { 1,0,0,1,1,0,0,0,1,0 }, 
                                           { 1,1,1,1,0,0,0,0,0,0 }, 
                                           { 1,0,0,1,0,0,0,0,1,0 }, 
                                           { 1,0,0,1,0,1,0,1,0,0 }, 
                                           { 1,1,0,0,0,0,0,0,0,0 } };

            int sum = 0;
            int max_degree = 0;
            int maxIndex = 0;
            string degree_char = " ";
            string closeness_char = " ";
            string eccentricity_char = " ";
            int[] degree_centrality = new int[adjMatrix.GetLength(0)];

            for (int i=0; i<adjMatrix.GetLength(0); i++)
            {
                //Define Characters in Row
                if(i==0)
                {
                    character = "Harry Potter";
                    Console.WriteLine(character + " is connected to: ");
                }
                else if (i == 1)
                {
                    character = "Ron Weasley";
                    Console.WriteLine(character + " is connected to: ");
                }
                else if (i == 2)
                {
                    character = "Hermonie Granger";
                    Console.WriteLine(character + " is connected to: ");
                }
                else if (i == 3)
                {
                    character = "Voldemort";
                    Console.WriteLine(character + " is connected to: ");
                }
                else if (i == 4)
                {
                    character = "Dumbledore";
                    Console.WriteLine(character + " is connected to: ");
                }
                else if (i == 5)
                {
                    character = "Snape";
                    Console.WriteLine(character + " is connected to: ");
                }
                else if (i == 6)
                {
                    character = "Malfoy";
                    Console.WriteLine(character + " is connected to: ");
                }
                else if (i == 7)
                {
                    character = "James Potter";
                    Console.WriteLine(character + " is connected to: ");
                }
                else if (i == 8)
                {
                    character = "Lily Potter";
                    Console.WriteLine(character + " is connected to: ");
                }
                else if (i == 9)
                {
                    character = "Ginny Weasley";
                    Console.WriteLine(character + " is connected to: ");
                }
                
                for (int j = 0; j < adjMatrix.GetLength(1); j++)
                {
                    //Console.Write(adjMatrix[i, j]);
                    //Define Characters in Column
                    if (j == 0)
                    {
                        character2 = "Harry Potter";                        
                    }
                    else if (j == 1)
                    {
                        character2 = "Ron Weasley";                        
                    }
                    else if (j == 2)
                    {
                        character2 = "Hermonie Granger";                        
                    }
                    else if (j == 3)
                    {
                        character2 = "Voldemort";                        
                    }
                    else if (j == 4)
                    {
                        character2 = "Dumbledore";                        
                    }
                    else if (j == 5)
                    {
                        character2 = "Snape";                        
                    }
                    else if (j == 6)
                    {
                        character2 = "Malfoy";                        
                    }
                    else if (j == 7)
                    {
                        character2 = "James Potter";                       
                    }
                    else if (j == 8)
                    {
                        character2 = "Lily Potter";                        
                    }
                    else if (j == 9)
                    {
                        character2 = "Ginny Weasley";                        
                    }
                    ///////////////
                    if (character=="Harry Potter" && adjMatrix[i,j]==1)
                    {                        
                        Console.Write(character2 + ", ");
                    }                    
                    if (character == "Ron Weasley" && adjMatrix[i, j] == 1)
                    {
                        Console.Write(character2 + ", ");
                    }
                    if (character == "Hermonie Granger" && adjMatrix[i, j] == 1)
                    {
                        Console.Write(character2 + ", ");
                    }
                    if (character == "Voldemort" && adjMatrix[i, j] == 1)
                    {
                        Console.Write(character2 + ", ");
                    }
                    if (character == "Dumbledore" && adjMatrix[i, j] == 1)
                    {
                        Console.Write(character2 + ", ");
                    }
                    if (character == "Snape" && adjMatrix[i, j] == 1)
                    {
                        Console.Write(character2 + ", ");
                    }
                    if (character == "Malfoy" && adjMatrix[i, j] == 1)
                    {
                        Console.Write(character2 + ", ");
                    }
                    if (character == "James Potter" && adjMatrix[i, j] == 1)
                    {
                        Console.Write(character2 + ", ");
                    }
                    if (character == "Lily Potter" && adjMatrix[i, j] == 1)
                    {
                        Console.Write(character2 + ", ");
                    }
                    if (character == "Ginny Weasley" && adjMatrix[i, j] == 1)
                    {
                        Console.Write(character2 + ", ");
                    }

                    //Degree Centrality Hesapla
                    sum += adjMatrix[i, j];
                    degree_centrality[i] = sum;
                }

                sum = 0;
                Console.WriteLine();
                Console.WriteLine();
                max_degree = degree_centrality.Max();
                maxIndex = degree_centrality.ToList().IndexOf(max_degree); 
                if(maxIndex==i)
                {
                    degree_char = character;
                }
                if (maxIndex == i)
                {
                    closeness_char = character;
                }
                if (maxIndex == i)
                {
                    eccentricity_char = character;
                }

            }

            //Console.WriteLine("Most important character according to degree centrality: " + degree_char + ", Degree= " + max_degree);


            GFG t = new GFG();
            t.dijkstra(adjMatrix, 0);
            t.dijkstra(adjMatrix, 1);
            t.dijkstra(adjMatrix, 2);
            t.dijkstra(adjMatrix, 3);
            t.dijkstra(adjMatrix, 4);
            t.dijkstra(adjMatrix, 5);
            t.dijkstra(adjMatrix, 6);
            t.dijkstra(adjMatrix, 7);
            t.dijkstra(adjMatrix, 8);
            t.dijkstra(adjMatrix, 9);

            Console.WriteLine("Most important character according to degree centrality: " + degree_char + ", Degree= " + max_degree);
            Console.WriteLine("Most important character according to closeness centrality: Harry Potter" + ", Closeness= " + max_closeness);
            Console.WriteLine("Most important character according to eccentricity centrality: Harry Potter" + ", Eccentricity= " + max_eccentricity);



            Console.ReadLine();
        }
    }
}
