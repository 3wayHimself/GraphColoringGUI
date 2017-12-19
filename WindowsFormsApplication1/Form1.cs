using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GraphColoring;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e) {
            Graph graph = new Graph();
            //graph.addVertex("S");
            //graph.addVertex("P");
            //graph.addVertex("G");
            //graph.addVertex("U");
            //graph.addVertex("L");
            //graph.addVertex("C");
            //graph.addEdge("C", "L");
            //graph.addEdge("C", "S");
            //graph.addEdge("L", "C");
            //graph.addEdge("L", "U");
            //graph.addEdge("L", "P");
            //graph.addEdge("S", "U");
            //graph.addEdge("S", "C");
            //graph.addEdge("S", "P");
            //graph.addEdge("S", "G");
            //graph.addEdge("U", "S");
            //graph.addEdge("U", "L");
            //graph.addEdge("U", "G");
            //graph.addEdge("P", "S");
            //graph.addEdge("P", "L");
            //graph.addEdge("P", "G");
            //graph.addEdge("G", "P");
            //graph.addEdge("G", "S");
            //graph.addEdge("G", "U");
            //color.color();
            //Graph graph = new Graph();
            //ColorGraph color = new ColorGraph(graph);
            string[] student1 = { "maths", "english", "biology", "chemistry" };
            string[] student2 = { "maths", "english", "compsci", "geography" };
            string[] student3 = { "biology", "psychology", "geography", "spanish" };
            string[] student4 = { "biology", "compsci", "history", "french" };
            string[] student5 = { "english", "psychology", "compsci", "history" };
            string[] student6 = { "psychology", "chemistry", "compsci", "french" };
            string[] student7 = { "psychology", "geography", "history", "spanish" };
            graph.addVertex("maths");
            graph.addVertex("english");
            graph.addVertex("biology");
            graph.addVertex("chemistry");
            graph.addVertex("compsci");
            graph.addVertex("geography");
            graph.addVertex("history");
            graph.addVertex("french");
            graph.addVertex("spanish");
            graph.addVertex("psychology");
            graph.addEdge(student1);
            graph.addEdge(student2);
            graph.addEdge(student3);
            graph.addEdge(student4);
            graph.addEdge(student5);
            graph.addEdge(student6);
            graph.addEdge(student7);
            ColorGraph color = new ColorGraph(graph);
            color.color();
           // int totalcolors = color.ChromaticNumber;
            int n = graph.Nodes.Count;
            int width = n *50;
            int height = n*60;
            int xcentre = (width)/2;
            int ycentre = (height) / 2;
            int radius = (int)(Math.Min(height, width) * 0.4);
            Graphics graphic = this.CreateGraphics();
            Font font = new Font(Font, FontStyle.Bold);
            Brush[] colorss = { Brushes.Red, Brushes.Blue, Brushes.Yellow, Brushes.Green, Brushes.HotPink, Brushes.Brown };
            for (int i = 0; i < n; i++)
            {
                float x1point = (float)(xcentre + 20 + radius * Math.Cos(i * 2 * Math.PI / n));
                float y1point = (float)(xcentre + 20 - radius * Math.Sin(i * 2 * Math.PI / n));
                for (int j = i + 1; j < n; j++)
                {
                    float x2point = (float)(xcentre + 20 + radius * Math.Cos(j * 2 * Math.PI / n));
                    float y2point = (float)(xcentre + 20 - radius * Math.Sin(j * 2 * Math.PI / n));
                    if (graph.isAdjacent(graph.Nodes[i], graph.Nodes[j]))
                    {
                        graphic.DrawLine(Pens.Black, x1point, y1point, x2point, y2point);
                    }
                }
            }
            for (int i = 0; i < n; i++)
            {
                int colornumber = graph.Nodes[i].Color;
                //Color color = Color.FromArgb(colornumber*10);
                float x1point = (float)(xcentre + radius * Math.Cos(i * 2 * Math.PI / n)) - 40;
                float y1point = (float)(xcentre - radius * Math.Sin(i * 2 * Math.PI / n));
                graphic.FillEllipse(colorss[colornumber-1], (float)(xcentre + radius * Math.Cos(i * 2 * Math.PI / n)), (float)(xcentre - radius * Math.Sin(i * 2 * Math.PI / n)), 30, 30);
                graphic.DrawString(graph.Nodes[i].Name, font, Brushes.Black, x1point, y1point-10);
            }
            
        }
    }
}
