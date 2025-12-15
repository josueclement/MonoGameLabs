using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace App1;

public class FontManager(ContentManager content)
{
    private Dictionary<object, SpriteFont> _fonts = [];
    
    public void LoadFonts(params (object key, string assetName)[] assets)
    {
        foreach ((object key, string assetName) in assets)
            _fonts.Add(key, content.Load<SpriteFont>(assetName));
    }

    public void DrawString(SpriteBatch spriteBatch, object key, string text, Vector2 position, Color color)
        => spriteBatch.DrawString(_fonts[key], text, position, color);
}