using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public interface IDrawManager
    {
        List<IDraw> DrawableObjects { get; set; }
        void DrawManager();
    }
}
