using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoring
{
    /// <summary>
    /// A representation of the graph data structure as collection of nodes mapped to their adjList with basic operations
    /// </summary>
    public class Graph
    {
      private  Dictionary<Vertex, List<Vertex>> graph = new Dictionary<Vertex, List<Vertex>>();
       private List<KeyValuePair<Vertex, int>> nodeTodegree = new List<KeyValuePair<Vertex, int>>();
        /// <summary>
        /// Adds a new node to graph
        /// </summary>
        /// <param name="vertex">Node to add</param>
        public void addVertex(string name)
        {
                if (this.ContainsKey(name))
                {
                    throw new ArgumentException();
                    
                }
                else
                {
                    graph.Add(new Vertex(name), new List<Vertex>());
                }
            }
        
        /// <summary>
        /// Removes node from graph and all edges connected to it
        /// </summary>
        /// <param name="vertex">node to remove</param>
        public void removeVertex(string name)
        {
            
                if (this.ContainsKey(name))
                {
                    foreach (var adjnode in this[name])
                    {
                        graph[adjnode].Remove(getVertexWithName(name));
                    }
                    graph.Remove(getVertexWithName(name));
                }
                else
                {
                    throw new ArgumentException();

                }
            
        }
        public bool ContainsKey(string name)
        {
            foreach (var node in graph)
            {
                if (node.Key.Name == name)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Creates a path between two vertices if path doesn't already exist by adding them to their respective adjacency lists
        /// </summary>
        /// <param name="vertex">first node</param>
        /// <param name="vertex2">second node</param>
        public void addEdge(string vertex, string vertex2)
        {
            if (this.ContainsKey(vertex) && this.ContainsKey(vertex2) && vertex != vertex2)
            {
                if (!this[vertex].Contains(getVertexWithName(vertex2)) && !this[vertex2].Contains(getVertexWithName(vertex)))
                {
                    this[vertex].Add(getVertexWithName(vertex2));
                    this[vertex2].Add(getVertexWithName(vertex));
                }
            }
            else
            {
                throw new ArgumentException();  
            }
        }
        public Vertex getVertexWithName(string name)
        {
            foreach(var node in graph)
            {
                if (node.Key.Name == name)
                {
                    return node.Key;
                }
            }
            throw new ArgumentException();
        }
        public void addEdge(string[] array)
        {
            for(int i = 0; i < array.Length; i++)
            {
                for(int j = i+1; j < array.Length; j++)
                {
                    if(j != array.Length)
                    {
                        this.addEdge(array[i], array[j]);
                    }
                }
            }
        }
        /// <summary>
        /// Gets the adjacency list of the specified vertex
        /// </summary>
        /// <param name="vertex">specified vertex</param>
        /// <returns>adjacency list of specified vertex</returns>
        public List<Vertex> this[string name]
        {
            get
            {
                foreach (var node in graph)
                {
                    if (node.Key.Name == name)
                    {
                        return graph[node.Key];
                    }
                }
                throw new ArgumentException("Vertex with name " + name + " doesn't exist in graph");
            }
        }
        /// <summary>
        /// Gets a collection containing the nodes in the graph
        /// </summary>
        public List<Vertex> Nodes
        {
            get
            {
                return graph.Keys.ToList();
            }
        }
        /// <summary>
        /// Checks adjacency of two vertices
        /// </summary>
        /// <param name="vertex">first vertex</param>
        /// <param name="vertex2">second vertex</param>
        /// <returns>true if vertices are djacent or false if otherwise</returns>
        public Boolean isAdjacent(string vertex, string vertex2)
        {
            if (this[vertex].Contains(getVertexWithName(vertex2)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean isAdjacent(Vertex vertex, Vertex vertex2)
        {
            if (graph[vertex].Contains(vertex2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Maps the degree of each node appropriately and sorts based on degree
        /// </summary>
        /// <returns>sorted list of node,degree pair based on degree</returns>
        public void generateDegreeList()
        {
           
            var temp = new Dictionary<Vertex, int>();
            foreach (var node in graph)
            {
                temp.Add(node.Key, node.Value.Count);
            }
            nodeTodegree = temp.OrderByDescending(deg => deg.Value).ToList<KeyValuePair<Vertex,int>>();
    }
        public List<KeyValuePair<Vertex, int>> degreeList
        {
            get
            {
               return nodeTodegree;
            }
        }
        /// <summary>
        /// Prints out graph as adjacency List
        /// </summary>
        /// <returns>String representation of adjacency list</returns>
        public override string ToString()
        {
            string res = "";
            foreach ( var node in graph)
            {
                res += node.Key.Name + ":" + printAdjList(node.Value) + "\n";
            }
            return res;
        }
        private string printAdjList(List<Vertex> list)
        {
            string result = "[";
            foreach (var element in list)
            {
                result += element.Name + " ";
            }
            result += "]";
            return result;
        }
    }
}
