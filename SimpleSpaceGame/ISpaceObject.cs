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
    interface ISpaceObject
    {
        void Draw(PaintEventArgs e);
    }
}
