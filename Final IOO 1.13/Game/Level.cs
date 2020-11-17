using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Level : IUpdate, IDrawManager
    {

        private List<IDraw> _drawableObjects;
        private List<Enemy> _enemies = new List<Enemy>();

        

        private LevelBackground lvlbackground;

        float lastSpawn;
        float spawnRate;

        Random rnd;

        

        public List<IDraw> DrawableObjects
        {
            get { return _drawableObjects; }
            set { _drawableObjects = value; }
        }

        public List<Enemy> Enemies
        {
            get { return _enemies; }
            set { _enemies = value; }
        }

        public Level(int checkX, int checkY,float spawnR)
        {
            lvlbackground = new LevelBackground("Texturas/backgroundLvl.png");
            rnd = new Random();
            int currentlvl = GameManager.Instance.CurrentLevel;
            spawnRate = spawnR;
            
        }

        private void UpdateCollisions()
        {
            List<Collider> colliderEnemies = new List<Collider>();

            for (int i = 0; i < Enemies.Count; i++)//Lista enemigos del nivel
            {
                
                colliderEnemies.Add(Enemies[i].EnemyCollider);

            }

            if (GameManager.Instance.Player1.Collider.CheckCollision(colliderEnemies))
            {
                GameManager.Instance.Player1.Life--; 
                Engine.Debug("Bajar vida");
            }

        }

        public void Update()
        {
            //Enemy update
            if(Program.GetTime() >= lastSpawn + spawnRate)
            {
                int posX = rnd.Next(25, 750);
                _enemies.Add(EnemyFactory.GetEnemy(EnemyFactory.EnemyType.Normal, posX, -50));
                _enemies.Add(EnemyFactory.GetEnemy(EnemyFactory.EnemyType.Big, posX, -50));
                _enemies.Add(EnemyFactory.GetEnemy(EnemyFactory.EnemyType.Fast, posX, -50));
                lastSpawn = Program.GetTime();
            }
            
            for (int count = 0; count < _enemies.Count; count++)
            {
                //Engine.Debug("La puta madre");
                _enemies[count].Update();
                if (_enemies[count].OutOfScreen())
                {
                    _enemies.Remove(_enemies[count]);
                    count--;
                }
            }


            UpdateCollisions();
        }

        public void DrawManager()
        {
            
            lvlbackground.Draw();
            for (int count = 0; count < _enemies.Count; count++)
            {

                _enemies[count].Draw();
                ResetEnemyCount(count);
            }    
        }

        private void ResetEnemyCount(int count)
        {
            if (count >= _enemies.Count)
            {
                count = 0;
            }
        }

    }
}
