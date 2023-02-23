using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace BlacAndWight
{
    class WhiteFace : AllFace
    {
        private ConsoleColor color = ConsoleColor.Yellow;

        public WhiteFace(int x, int y, int hp) : base(x, y, (char)1, hp)  {}

        public void Eat(BlackFace face) 
        {
            _hp += face.Hp();
        }

        public void Draw(int i) 
        {
            Console.SetCursorPosition(_x, _y);
            Console.ForegroundColor = color;
            Console.Write((char)1);
        }

        public void Move(ConsoleKey key, int xMin, int xMax, int yMin, int yMax) 
        {
            switch (key) 
            {
                case ConsoleKey.A: 
                    {
                        if (_x > xMin) 
                        {
                            _x--;
                        }

                        break;
                    }
                case ConsoleKey.D:
                    {
                        if (_x < xMax)
                        {
                            _x++;
                        }

                        break;
                    }
                case ConsoleKey.W:
                    {
                        if (_y > yMin) 
                        {
                            _y--;
                        }

                        break;
                    }
                case ConsoleKey.S:
                    {
                        if (_y < yMax)
                        {
                            _y++;
                        }

                        break;
                    }
            }
        }
    }
}