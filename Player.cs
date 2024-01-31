using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using System.Net.Mime;
using System.Runtime.CompilerServices;




namespace Centipede
{

    internal class Player
    {
        Vector2f position = new Vector2f();
        Vector2f size = new Vector2f();
        float scale = 5;
        uint velocity = 10;
        Color color = new Color(0, 255, 0);
        RectangleShape bodyRect = new RectangleShape();
        Texture texture = new Texture("C:\\Programming\\Centipede\\Assets\\SpriteSheet.png");
        Sprite sprite = new Sprite();
        uint fireCooldownCounter = 0;
        uint fireCooldownLength = 10;
        bool isOKToFire = false;
        

        public void update()
        {

            if(fireCooldownCounter >= fireCooldownLength) 
            {
                fireCooldownCounter = fireCooldownLength;
                isOKToFire=true;
            }
            else
            {
                fireCooldownCounter++;
                isOKToFire = false;
            }

        }

        public void draw(RenderWindow window)
        {
            //window.Draw(bodyRect);
            window.Draw(sprite);
        }
        public void setPosition(Vector2f newPosition)
        {
            position = newPosition;
            bodyRect.Position = position;
            sprite.Position = position;
        }

        public Vector2f getPosition() 
        {
            return position;
        }
        public Vector2f getSize()
        {
            return size;
        }

        public float getScale()
        {
            return scale;
        }



        public void moveLeft()
        {
            position.X -= velocity;
            bodyRect.Position = position;
            sprite.Position = position;
        }

        public void moveRight() 
        {
            position.X += velocity;
            bodyRect.Position = position;
            sprite.Position = position;

        }

        public void moveUp() 
        {
            position.Y -= velocity;
            bodyRect.Position = position;
            sprite.Position = position;
        }

        public void moveDown() 
        {
            position.Y += velocity;
            bodyRect.Position = position;
            sprite.Position = position;
        }

        public bool getIsOKToFire()
        {
            return isOKToFire;
        }


        public Laser fire()
        {
            Laser newLaser = new Laser();

            if (fireCooldownCounter >= fireCooldownLength)
            {
                
                Vector2f laserPosition = new Vector2f();
                Vector2f laserSize = new Vector2f();
                laserSize.X = 5;
                laserSize.Y = 80;
                newLaser.setSize(laserSize);
                newLaser.setColor(new Color(255, 0, 0));
                laserPosition.X = getPosition().X + (getScale() * getSize().X / 2) - newLaser.getSize().X / 2 - laserSize.X;
                laserPosition.Y = getPosition().Y;
                newLaser.setPosition(laserPosition);
                fireCooldownCounter = 0;
            }
            return newLaser;
        }


        public void setSize(Vector2f newSize) 
        {
            size = newSize;
            bodyRect.Size = size;
        }
        public void setColor(Color newColor) 
        {
            color = newColor;
        }
        public void setupSprite()
        {
            sprite.Texture = texture;
            sprite.TextureRect = new IntRect(17, 9, 16, 8);
            sprite.Position = position;
            sprite.Scale = new Vector2f(scale, scale);
        }



    }
}
