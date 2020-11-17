using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Select : IDraw
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
        public Renderer Render { get; set; }
        public Transform Trans { get; set; }

        public string PathImg
        {
            get { return _pathImg; }
            set { _pathImg = value; }
        }

        public Select(string path)
        {
            _pathImg = path;
        }

        public void Update(float x, float y)
        {
            PosX = x;
            PosY = y;
        }

        public void Draw()
        {
            Engine.Draw(PathImg, PosX, PosY);
        }
    }
}
