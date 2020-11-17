using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Background : IDraw
    {
        private float _posX;
        private float _posY;
        private string _pathImg;

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
        public Renderer Render { get; set; }
        public Transform Trans { get; set; }

        public Background(string path)
        {
            _pathImg = path;
        }

        public void Draw()
        {
            Engine.Draw(_pathImg, _posX, _posY);
        }
    }
}
