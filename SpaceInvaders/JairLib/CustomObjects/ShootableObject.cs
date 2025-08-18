using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JairLib.CustomObjects
{
    public abstract class ShootableObject : IJairObject
    {
        public ShootableObject() { }
        public string identifier { get; set; }
        public Rectangle rectangle { get; set; }
        public Texture2D texture { get; set; }
        public Color color { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int speed { get; set; }
    }
}
