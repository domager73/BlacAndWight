using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacAndWight
{
    class AllFace
    {
        protected int _x, _y;
        private char _look;
        protected int _hp;

        protected AllFace(int x, int y, char look, int hp) 
        {
            _x = x;
            _y = y;
            _look = look;
            _hp = hp;
        }

        public void Draw() 
        {
            Console.SetCursorPosition(_x, _y);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(_look);
        }

        public bool isCollisionWithAnother(AllFace face) 
        {
            return _x == face._x && _y == face._y;
        }

        public int Hp() => _hp;
        public int X() => _x;
        public int Y() => _y;
    }
}
