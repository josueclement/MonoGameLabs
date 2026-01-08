using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace App1;

public class TicTacToe
{
    private readonly int _width;
    private readonly int _height;
    private readonly Texture2D _pixel;
    private bool _mouseReleased = true;

    public TicTacToe(int width, int height, Texture2D pixel)
    {
        _width = width;
        _height = height;
        _pixel = pixel;
    }
    
    public int[,] Board { get; set; } = new int[3, 3];

    public void Update()
    {
        var mouseState = Mouse.GetState();
        var mousePosition = new Vector2(mouseState.X, mouseState.Y);
        
        if (mouseState.LeftButton == ButtonState.Released)
            _mouseReleased = true;

        if (!_mouseReleased)
            return;
        
        if (mouseState.LeftButton == ButtonState.Pressed)
        {
            _mouseReleased = false;
            var xCell = (int)Math.Floor(mousePosition.X / _width * 3);
            var yCell = (int)Math.Floor(mousePosition.Y / _height * 3);

            if (xCell is >= 0 and < 3 && yCell is >= 0 and < 3)
            {
                if (Board[xCell, yCell] == 0)
                    Board[xCell, yCell] = 1;
                else
                    Board[xCell, yCell] = 0;
                // Console.WriteLine($"{xCell}, {yCell}");
            }
        }
        
        
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        for (int i = 0; i < 2; i++)
        {
            float xCoord = _width / 3 * (i+1);
            DrawLine(spriteBatch, _pixel, new Vector2(xCoord, 0), new Vector2(xCoord, _height), Color.Black, 2f);
        }

        for (int i = 0; i < 2; i++)
        {
            float yCoord = _height / 3 * (i+1);
            DrawLine(spriteBatch, _pixel, new Vector2(0, yCoord), new Vector2(_width, yCoord), Color.Black, 2f);
        } 
        
        for (int i = 0; i < Board.GetLength(0); i++)
        {
            for (int j = 0; j < Board.GetLength(1); j++)
            {
                if (Board[i, j] != 0)
                {
                    spriteBatch.Draw(_pixel, new Vector2(i * _width / 3, j * _height / 3), null, Color.Black, 0f, Vector2.Zero, new Vector2(_width / 3, _height / 3), SpriteEffects.None, 0f);
                }
            }
        } 
    }
    
    public static void DrawLine(SpriteBatch spriteBatch, Texture2D pixel, Vector2 start, Vector2 end, Color color, float thickness = 1f)
    {
        float distance = Vector2.Distance(start, end);
        float angle = (float)Math.Atan2(end.Y - start.Y, end.X - start.X);
    
        spriteBatch.Draw(
            pixel,
            start,
            null,
            color,
            angle,
            Vector2.Zero,
            new Vector2(distance, thickness),
            SpriteEffects.None,
            0
        );
    }
}