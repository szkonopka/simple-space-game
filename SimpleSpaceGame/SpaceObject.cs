using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleSpaceGame
{
    /// <summary>
    /// Interfejs implementujący metodę rysującą
    /// </summary>
    public class SpaceObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int LastX { get; set; }
        public int LastY { get; set; }
        public int MoveValue { get; set; } = 2;
        public virtual void Draw(PaintEventArgs e) { }
        public virtual void Draw(PaintEventArgs e, Directions dir) { }
    }
}
