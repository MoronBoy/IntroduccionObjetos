using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Player : Object
    {
       
        private float timerC = 0f;
        private float pressTimerC = 0.25f;
        private float timerSpace = 0f;
        private float pressTimerSpace = 0.5f;

        private Collider collider;

        private PlayerInputs input;
        private List<bool> inputList;

        public event Action OnDeath;

        public Collider Collider { get => collider; set => collider = value; }

        public Player(int x, int y, int speed, string path, float scale,int width, int height) : base(x, y, speed, path, scale,width,height)
        {
            Life = 20;
            input = new PlayerInputs();
            collider = new Collider(width,scale,height);
        }

        public override void Update()
        {
            collider.UpdatePosition(_posX, _posY);
            timerC += Program.deltaTime;
            timerSpace += Program.deltaTime;

            UserInputs();
            base.Update();

            CheckLife();
            
        }

        void CheckLife()
        {
            if(Life <= 0)
            {
                OnDeath();
            }
        }

        

        private void UserInputs()
        {
            inputList = input.CheckInputs();
            if (inputList[0])
            {
                _posX -= _speed * Program.deltaTime;
            }
            if (inputList[1])
            {
                _posX += _speed * Program.deltaTime;
            }
            if (inputList[2])
            {
                GameManager.Instance.CurrentLevel ++;
            }
            
        }
    }
}
