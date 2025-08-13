using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public interface IJairObject {
    string identifier {get; set;}
    Rectangle rectangle{get; set;}
    Texture2D texture{get; set;}
    Color color{get; set;}
}