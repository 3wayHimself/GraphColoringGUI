using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoring
{
    public class Vertex
    {
        private string name;
        private int color;
        public string Name
        {
            get
            {
                return name;
            }
        }
        public Vertex(String name)
        {
            this.name = name;
            this.color = 0;
        }
        public void setColor(int i)
        {
            color = i;
        }
        public int Color
        {
            get
            {
                return color;
            }
        }
    }
}
