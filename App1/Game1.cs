using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace App1;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    
    private SpriteFont _font;

    
    // FPS tracking variables
    private double _frames = 0;
    private double _updates = 0;
    private double _elapsed = 0;
    private double _last = 0;
    private double _now = 0;
    private double _fps = 0;


    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        _font = Content.Load<SpriteFont>("JetBrainsMono-Regular");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // Calculate FPS
        _now = gameTime.TotalGameTime.TotalSeconds;
        _elapsed = _now - _last;
            
        if (_elapsed > 1)
        {
            _fps = _frames / _elapsed;
            _elapsed = 0;
            _frames = 0;
            _last = _now;
        }
            
        _updates++;

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
            
        // Draw FPS counter in top-left corner
        string fpsText = $"FPS: {_frames:0.00}";
        _spriteBatch.DrawString(_font, fpsText, new Vector2(10, 10), Color.White);
            
        _spriteBatch.End();

        _frames++;

        base.Draw(gameTime);
    }
}