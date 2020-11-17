using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Renderer
    {
        string PathImg;
        Transform transform;

        public Renderer(string path, Transform trans)
        {
            path = PathImg;
            transform = trans;
        }
        public void Draw()
        {
            Engine.Draw(PathImg, transform.PosX, transform.PosY, transform.Scale, transform.Scale);
        }
    }
}
