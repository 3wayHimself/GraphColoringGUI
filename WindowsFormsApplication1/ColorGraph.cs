using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoring
{
    class ColorGraph
    {
        Graph graph;
        public ColorGraph(Graph graph)
        {
            this.graph = graph;
        }
        public List<Vertex> getNodesWithColor(int color)
        {
            var temp = new List<Vertex>();
            foreach(var node in graph.degreeList)
            {
                if(node.Key.Color == color)
                {
                    temp.Add(node.Key);
                }
            }
            return temp;
        }
        public void color()
        {
            graph.generateDegreeList();
            int color = 1;
            for (int i = 0; i<graph.degreeList.Count; i++)
            {
                if (graph.degreeList.ElementAt(i).Key.Color != 0)
                {
                    continue;
                }
                graph.degreeList.ElementAt(i).Key.setColor(color);
                for (int j = i + 1; j < graph.degreeList.Count; j++)
                {
                    if (j != graph.degreeList.Count) { 
                    if (graph.isAdjacent(graph.degreeList.ElementAt(i).Key, graph.degreeList.ElementAt(j).Key) || graph.degreeList.ElementAt(j).Key.Color != 0)
                    {
                            continue;
                    }
                        else
                        {
                            if (getNodesWithColor(color).Count == 1)
                            {
                                graph.degreeList.ElementAt(j).Key.setColor(color);
                            }
                            else
                            {
                                bool isAdj = false;
                                foreach (var node in getNodesWithColor(color))
                                {
                                    if (graph.isAdjacent(graph.degreeList.ElementAt(j).Key, node))
                                    {
                                        isAdj = true;
                                        break;
                                    }
                                   
                                }
                                if (isAdj == true)
                                {
                                    continue;
                                }
                                else
                                {
                                    graph.degreeList.ElementAt(j).Key.setColor(color);
                                }
                            }
                        }
                }   
                }
                color++;
            }
        }
        public override string ToString()
        {
            var result = new StringBuilder();
            foreach (var node in graph.degreeList)
            {
                result.Append(node.Key.Name + ": " + node.Key.Color + " \n");
            }
            return result.ToString();
        }
    }
}
