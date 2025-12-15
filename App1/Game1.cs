using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace App1;

public enum UserFont
{
    JetBrainsMonoRegular12,
    JetBrainsMonoRegular14,
    JetBrainsMonoRegular16,
    JetBrainsMonoRegular18,
    JetBrainsMonoRegular20,
    JetBrainsMonoRegular24
}

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private FontManager _fontManager;
    
    private int _frames = 0;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        _fontManager = new FontManager(Content);
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        
        _fontManager.LoadFonts(
            (UserFont.JetBrainsMonoRegular12, "JetBrainsMono-Regular-12"),
            (UserFont.JetBrainsMonoRegular14, "JetBrainsMono-Regular-14"),
            (UserFont.JetBrainsMonoRegular16, "JetBrainsMono-Regular-16"),
            (UserFont.JetBrainsMonoRegular18, "JetBrainsMono-Regular-18"),
            (UserFont.JetBrainsMonoRegular20, "JetBrainsMono-Regular-20"),
            (UserFont.JetBrainsMonoRegular24, "JetBrainsMono-Regular-24"));
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
            
        var frames = $"Frame: {_frames}";
        _fontManager.DrawString(_spriteBatch, UserFont.JetBrainsMonoRegular24, frames, new Vector2(10, 10), Color.White);
            
        _spriteBatch.End();

        _frames++;

        base.Draw(gameTime);
    }
}