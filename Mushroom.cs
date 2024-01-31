using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Centipede
{
    internal class Mushroom
    {

        Vector2f position = new Vector2f();
        Vector2f size = new Vector2f();
        float scale = 5;
        uint damage = 0;
        bool isDead = false;
        Texture texture = new Texture("C:\\Programming\\Centipede\\Assets\\SpriteSheet.png");
        Sprite sprite = new Sprite();

        IntRect TextureTheme1Color1 = new IntRect(68, 72, 8, 8);
        IntRect TextureTheme1Color1Damage1 = new IntRect(77, 72, 8, 8);
        IntRect TextureTheme1Color1Damage2 = new IntRect(86, 72, 8, 8);
        IntRect TextureTheme1Color1Damage3 = new IntRect(95, 72, 8, 8);


        IntRect TextureTheme1Color2 = new IntRect(68, 81, 8, 8);
        IntRect TextureTheme1Color2Damage1 = new IntRect(77, 81, 8, 8);
        IntRect TextureTheme1Color2Damage2 = new IntRect(86, 81, 8, 8);
        IntRect TextureTheme1Color2Damage3 = new IntRect(95, 81, 8, 8);


        public void draw(RenderWindow window)
        {
            //window.Draw(bodyRect);
            window.Draw(sprite);
        }

        public void update()
        {
            if(damage == 0) 
            {
                sprite.TextureRect = TextureTheme1Color1;
            }
            else if(damage == 1)
            {
                sprite.TextureRect = TextureTheme1Color1Damage1;
            }
            else if (damage == 2)
            {
                sprite.TextureRect = TextureTheme1Color1Damage2;
            }
            else if (damage == 3)
            {
                sprite.TextureRect = TextureTheme1Color1Damage3;
            }
        }

        public void takeDamage()
        {
            if(damage ==3) 
            {
                isDead = true;
            }
            else
            {
                damage++;
            }
            
        }

        public void setPosition(Vector2f newPosition)
        {
            position = newPosition;
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

        public void setSize(Vector2f newSize)
        {
            size = newSize;
        }

        public bool getIsDead()
        {
            return isDead;
        }

        public void setupSprite()
        {
            sprite.Texture = texture;
            sprite.TextureRect = TextureTheme1Color2Damage2;
            sprite.Position = position;
            sprite.Scale = new Vector2f(scale, scale);
        }

    }
}
