using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public abstract class Object : IUpdate, IDraw
    {
        protected float _posX;
        protected float _posY;
        protected float _speed;

        protected int _life;
        protected int _damage;

        protected int _widthImg;
        protected int _heightImg;
        protected float _scaleImg;
        protected string _pathImg;

        

        public Object(float x, float y, float spd, string path, float scale,int width, int height)
        {
            _posX = x;
            _posY = y;
            _speed = spd;
            _pathImg = path;
            _scaleImg = scale;
            _widthImg = width;
            _heightImg = height;
            
        }

        
        public Renderer Render { get; set; }
        public Transform Trans { get; set; }
        #region Getters
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
        #endregion

        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        public int Life
        {
            get { return _life; }
            set { _life = value; }
        }

        public int Damage
        {
            get { return _damage; }
            set { _damage = value; }
        }

        public int WidthImg
        {
            get { return _widthImg; }
        }

        public int HeightImg
        {
            get { return _heightImg; }
        }

        public float ScaleImg
        {
            get { return _scaleImg; }
            set { _scaleImg = value; }
        }

        public string PathImg
        {
            get { return _pathImg; }
            set { _pathImg = value; }
        }

        



        public virtual void Draw()
        {
            Engine.Draw(PathImg, PosX, PosY, ScaleImg, ScaleImg);
        }

        public virtual void Update()
        {
            
        }

        
    }
}
