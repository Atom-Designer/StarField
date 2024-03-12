using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Starfield
{
    class Star
    {
        public Texture2D tex;
        public Rectangle rect;
        public int vX;
        public int vY;
        public Color color;
        public Star(Texture2D te, Rectangle re)
        {
            tex = te;
            rect = re;
        }
        public void Update()
        {
            rect.X += vY;
            rect.Y += vX;   
        }
        
        public Boolean outside()
        {
           if (rect.X < 0 || rect.X > 800 || rect.Y < 0 || rect.Y > 480)
           return true;
           return false;
        }
    }
}
