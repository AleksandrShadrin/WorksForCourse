using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snowfall
{
    public interface IRenderable
    {
        void AddIRenderable(IRenderable renderable);
        void Render();
    }
}
