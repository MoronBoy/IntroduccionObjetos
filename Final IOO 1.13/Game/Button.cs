using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Button : IDraw
    {
        private float _posX;
        private float _posY;
        private string _pathImg;

        private int _buttonW = 96;
        private int _buttonH = 32;

        private Button _buttonUp;
        private Button _buttonDown;
        private float _timer = 0f;
        private float _pressTimer = 0.25f;

        public float PosX
        {
            get { return _posX; }
            set { _posX = value; }
        }
        public float PosY
        {
            get { return _posY; }
            set { _posY = value; }
        }
        public string PathImg
        {
            get { return _pathImg; }
            set { _pathImg = value; }
        }
        public int ButtonW
        {
            get { return _buttonW; }
        }
        public int ButtonH
        {
            get { return _buttonH; }
        }

        public Renderer Render { get; set ; }
        public Transform Trans { get ; set ; }

        public Button(int posY, string texture)
        {
            _posX = (Program.wGame - _buttonW) / 2;
            _posY = posY;
            _pathImg = texture;
      
        }

        public void SetearBotones(Button up, Button down)
        {
            _buttonUp = up;
            _buttonDown = down;
        }

        public Button Update()
        {
            _timer += Program.deltaTime;

            if (Engine.GetKey(Keys.UP) && _timer >= _pressTimer)
            {
                _timer = 0f;
                return _buttonUp;
            }
            else if (Engine.GetKey(Keys.DOWN) && _timer >= _pressTimer)
            {
                _timer = 0f;
                return _buttonDown;
            }
            else return this;
        }

        public void Draw()
        {
            Engine.Draw(_pathImg, _posX, _posY);
        }

        
    }
}
