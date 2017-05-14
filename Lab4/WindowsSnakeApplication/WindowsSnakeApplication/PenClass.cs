using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class PenClass
    {
        Pen p;

        public Pen setPenColor(Color c)
        {
            p = new Pen(c);
            return p;
        }
    }
}
