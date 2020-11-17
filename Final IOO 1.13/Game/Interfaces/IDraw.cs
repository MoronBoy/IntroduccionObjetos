using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public interface IDraw
    {
       
        Renderer Render { get; set; }
        Transform Trans { get; set; }

        void Draw();

        

        
    }
}
