using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public static class EnemyFactory
    {
        public enum EnemyType
        {
            Normal,Fast, Big
            
        }


        public static Enemy GetEnemy(EnemyType selectedEnemy, float x, float y)
        {
            switch (selectedEnemy)
            {
                case EnemyType.Normal:
                    {
                        return new Enemy(x, y, 200, "Texturas/box1.png", 0.2f,0,255,256);
                    }
                case EnemyType.Fast:
                    {
                        return new Enemy(x, y, 400, "Texturas/box3.png", 0.2f, 1,512,512);
                    }
                case EnemyType.Big:
                    {
                        return new Enemy(x, y, 100, "Texturas/box2.png", 0.2f, 2,500,500);
                    }
                default:
                    {
                        return new Enemy(x, y, 200, "Texturas/box1.png", 0.2f, 0,255,256);
                    }

            }
        }
    }
}
