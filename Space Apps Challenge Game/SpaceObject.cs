using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Space_Apps_Challenge_Game
{
    class SpaceObject
    {
        public SpaceObject(float x, float y, float radius, Bitmap texture, int id)
        {
            X = x;
            Y = y;
            r = radius;
            Texture = texture;
            ID = id;
        }
        public float X = 0;
        public float Y = 0;
        public Bitmap Texture;
        public float r = 0;
        public float vx = 0;
        public float vy = 0;
        public int ID = 0;
    }
}
