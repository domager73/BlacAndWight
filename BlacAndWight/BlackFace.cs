using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacAndWight
{
    class BlackFace: AllFace
    {


        public BlackFace(int x, int y, int hp) : base(x, y,(char)2, hp) 
        {
            
        }

        public void RandomPosition(Random rnd, int xMin, int xMax, int yMin, int yMax) 
        {
            _x = rnd.Next(xMin, xMax + 1);
            _y = rnd.Next(yMin, yMax + 1);
        }

        
    }
}
