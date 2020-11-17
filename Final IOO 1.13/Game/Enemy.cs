using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Enemy : Object
    {
        Collider enemyCollider;
        
    
        public Enemy(float x, float y, float speed, string path, float scale, int enemyType,int width,int height) : base(x, y, speed, path, scale,width,height)
        {
            enemyCollider = new Collider(width, scale, height);
        }

        public Collider EnemyCollider { get => enemyCollider; set => enemyCollider = value; }

        public bool OutOfScreen()
        {
            if(PosY > 500)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override void Update()
        {
            enemyCollider.UpdatePosition(PosX, PosY);
            
            _posY += _speed * Program.deltaTime;

            base.Update();
        }
    }
}
