// Simple weighted graph representation 
// Uses an Adjacency Linked Lists, suitable for sparse graphs

using System;
using System.IO;

public class Graph 
{
    public class Node
    {
        public int vert;
        public int wgt;
        public Node next;//Throwing an error "...inaccessible due to its protectiion level"
    }
    // class for linked list nodes needed, do yourself
    
    // Declare the following
    // V = number of vertices
    // E = number of edges
    // adj[] is the adjacency lists array
    
	// missing declaration here
    int V, E;
    Node[] adj;
    private Node z;
    
    // used for traversing graph
    private int[] visited;
    private int id;
    
    
    // default constructor, some code missing
    public Graph(string graphFile)  
    {
        int u, v;
        int e, wgt;
        Node t;

        //Console.WriteLine("1");

        StreamReader reader = new StreamReader(graphFile);
	   
	    char[] splits = new char[] { ' ', ',', '\t'};     
        string line = reader.ReadLine();
        string[] parts = line.Split(splits, StringSplitOptions.RemoveEmptyEntries);
        
        // find out number of vertices and edges
        V = int.Parse(parts[0]);
        E = int.Parse(parts[1]);


        //Console.WriteLine(V + "   "+ E);

        // create sentinel node
        z = new Node();
        z.next = z;


        
        // Create adjacency lists, initialised to sentinel node z
        // Dynamically allocate array 
        // adj = ????

        //for(v = 1; v  <= V; ++v)
            //finish this

        adj = new Node[V + 1];

        for (v = 1; v <= V; v++)
        {
            adj[v] = z;

        }


        //Console.WriteLine("3");

        // read the edges
		Console.WriteLine("Reading edges from text file");
	    for(e = 1; e <= E; ++e)
	    {
            line = reader.ReadLine();
            parts = line.Split(splits, StringSplitOptions.RemoveEmptyEntries);
            u = int.Parse(parts[0]);
            v = int.Parse(parts[1]); 
            wgt = int.Parse(parts[2]);
               
            Console.WriteLine("Edge {0}--({1})--{2}", toChar(u), wgt, toChar(v));    
            // write code to put edge into adjacency lists     

            //Console.WriteLine("Before");
            //Console.WriteLine(u);
            //Console.WriteLine(v);
            

            t = new Node();
            t.vert = v;
            t.wgt = wgt;
            t.next = adj[u];
            adj[u] = t;
            //Console.WriteLine("After");

            
            
            t = new Node();
            t.vert = u;
            t.wgt = wgt;
            t.next = adj[v];
            adj[v] = t;

			
	    }	       
    }


    //ADD THIS IN   

    public void DF(int s)
    {
        id = 0;
        visited = new int[V + 1];
        // do the rest yourself with help of pseudocode
        for (int v = 1; v < V; v++)
        {
            visited[v] = 0;
        }

        dfVisit(0, s);
    }

    
    private void dfVisit(int prev, int v) // originally V, changed to v
    {
        int u;
        Node n;
        visited[v] = ++id;
        Console.WriteLine("Visited vertex " + toChar(v) + " along edge " + toChar(prev) + "----" + toChar(v));

        for(n = adj[v]; n != n.next; n = n.next)
        {
            u = n.vert;
            if (visited[u] == 0)
            {
                dfVisit(v, u);
            }
        }
    }
    


    // convert vertex into char for pretty printing
    private char toChar(int u)
    {  
        return (char)(u + 64);
    }
    
    // method to display the graph representation
    public void display() {
        int v;
        Node n;
        
        for(v=1; v<=V; ++v){
            Console.Write("\nadj[{0}] ->", toChar(v));
            for(n = adj[v]; n != z; n = n.next) 
                Console.Write(" |{0} | {1}| ->", toChar(n.vert), n.wgt);
            Console.WriteLine(" z");
            //Console.WriteLine(v);
        }
        
    }


    


    public static void Main()
    {
        int s = 1;
        string fname = "wgraph3.txt";
        Console.WriteLine("Main");

        Graph g = new Graph(fname);

        Console.WriteLine("Exectuted");
        g.display();
        Console.WriteLine("1");
        g.DF(s);
    }





}


