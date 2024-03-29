﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snowfall
{
    public class Screen : IRenderable
    {

        private List<IRenderable> RenderableObjects { get; set; } = new();

        public Screen(IEnumerable<IRenderable> renderableObjects)
        {
            RenderableObjects.AddRange(renderableObjects);
        }
        public Screen()
        {

        }

        public void Render()
        {
            foreach (var item in RenderableObjects)
            {
                item.Render();
            }
        }

        public void AddIRenderable(IRenderable renderable)
        {
            RenderableObjects.Add(renderable);
        }
    }
}
