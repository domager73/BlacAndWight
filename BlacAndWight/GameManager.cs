using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacAndWight
{
    class GameManager
    {
        private WhiteFace whiteFace;
        private BlackFace[] blackFaces;
        private int countEat;

        private Random rnd;

        private int xMin, xMax, yMin, yMax;

        public GameManager(int countBlacFaces)
        {
            countEat = 0;
            xMin = 2;
            xMax = Console.WindowWidth - 2;
            yMin = 2;
            yMax = Console.WindowHeight - 2;

            rnd = new Random();

            whiteFace = new WhiteFace(rnd.Next(xMin, xMax), rnd.Next(yMin, yMax), 10);
            blackFaces = new BlackFace[countBlacFaces];

            InitBlackFaces();

            RandomBlackFacesPosition();
        }

        public void Play()
        {
            while (whiteFace.Hp() > 0)
            {
                Console.Clear();

                Console.SetCursorPosition(0, 0);
                Console.WriteLine($"X: {whiteFace.X()} Y: {whiteFace.Y()} Hp: {whiteFace.Hp()} Count Eaten: {countEat}");

                for (int i = 0; i < blackFaces.Length; i++) 
                {
                    blackFaces[i].Draw();
                }
                whiteFace.Draw(1);

                whiteFace.Move(Console.ReadKey().Key, xMin, xMax, yMin, yMax);
                bool isColission = false;


                for (int i = 0; i < blackFaces.Length; i++) 
                {
                    if (whiteFace.isCollisionWithAnother(blackFaces[i])) 
                    {
                        whiteFace.Eat(blackFaces[i]);
                        countEat++;
                        isColission = true;
                        break;
                    }
                }

                if (isColission) 
                {
                    RandomBlackFacesPosition();
                }
            }

            Console.Clear();

            Console.SetCursorPosition(0, 0);
            Console.WriteLine("You died");
            Console.WriteLine($"Final Hp: {whiteFace.Hp()} Count Eaten: {countEat}");

        }

        private void InitBlackFaces()
        {
            for (int i = 0; i < blackFaces.Length / 2; i++)
            {
                blackFaces[i] = new BlackFace(xMin, yMin, rnd.Next(-5, 0 + 1));
            }

            for (int i = blackFaces.Length / 2; i < blackFaces.Length; i++)
            {
                blackFaces[i] = new BlackFace(xMin, yMin, rnd.Next(1, 5));
            }
        }

        private void RandomBlackFacesPosition()
        {
            bool isColission;

            for (int i = 0; i < blackFaces.Length; i++)
            {

                do
                {
                    isColission = false;
                    blackFaces[i].RandomPosition(rnd, xMin, xMax, yMin, yMax);

                    for (int j = 0; j < blackFaces.Length; j++)
                    {
                        if (i == j) { continue; }

                        if (blackFaces[i].isCollisionWithAnother(blackFaces[j])
                            || blackFaces[i].isCollisionWithAnother(whiteFace))
                        {
                            isColission = true;
                            break;
                        }
                    }

                } while (isColission);
            }
        }
    }
}
