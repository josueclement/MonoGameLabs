using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace App1;

public class FontManager<T>(ContentManager content)
{
    private Dictionary<T, SpriteFont> _fonts = [];
    
    public void LoadFonts(params (T key, string assetName)[] assets)
    {
        foreach ((T key, string assetName) in assets)
            _fonts.Add(key, content.Load<SpriteFont>(assetName));
    }

    public void DrawString(SpriteBatch spriteBatch, T key, string text, Vector2 position, Color color)
        => spriteBatch.DrawString(_fonts[key], text, position, color);
}