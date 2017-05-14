using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;


namespace WindowsFormsApplication1
{
    class Brush
    {
        private System.Drawing.SolidBrush fillMyColor;

        public System.Drawing.SolidBrush fillWithMyColor(Color c)
        { 
            
            fillMyColor = new System.Drawing.SolidBrush(c);
            return fillMyColor;
        }
    }
}
