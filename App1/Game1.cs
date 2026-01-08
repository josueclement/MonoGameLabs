using System;
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
    private FontManager<UserFont> _fontManager;
    private Texture2D _pixel;
    private int _width = 800;
    private int _height = 600;
    private TicTacToe _ticTacToe;
    
    private int _frames = 0;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this)
        {
            PreferredBackBufferWidth = _width,
            PreferredBackBufferHeight = _height
        };
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        _fontManager = new FontManager<UserFont>(Content);
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
        
        _pixel = new Texture2D(GraphicsDevice, 1, 1);
        _pixel.SetData([Color.White]);
        _ticTacToe = new TicTacToe(_width, _height, _pixel);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        
        _ticTacToe.Update();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
        
        _ticTacToe.Draw(_spriteBatch);
            
        var frames = $"Frame: {_frames}";
        _fontManager.DrawString(_spriteBatch, UserFont.JetBrainsMonoRegular24, frames, new Vector2(10, 10), Color.White);
            
        _spriteBatch.End();

        _frames++;

        base.Draw(gameTime);
    }
    
    // public static void DrawLine(SpriteBatch spriteBatch, Texture2D pixel, Vector2 start, Vector2 end, Color color, float thickness = 1f)
    // {
    //     float distance = Vector2.Distance(start, end);
    //     float angle = (float)Math.Atan2(end.Y - start.Y, end.X - start.X);
    //
    //     spriteBatch.Draw(
    //         pixel,
    //         start,
    //         null,
    //         color,
    //         angle,
    //         Vector2.Zero,
    //         new Vector2(distance, thickness),
    //         SpriteEffects.None,
    //         0
    //     );
    // }
}