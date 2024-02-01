using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Centipede
{
    internal class BodySegment
    {

        Vector2f position = new Vector2f();
        Vector2f size = new Vector2f();
        float scale = 5;
        uint damage = 0;
        bool isDead = false;
        Texture texture;
        Sprite sprite = new Sprite();
        uint animationTimer = 0;
        uint animationDelay = 2;
        uint currentSpriteIndex = 0;

        IntRect Head1Color1 = new IntRect(4, 18, 7, 8);
        IntRect Head2Color1 = new IntRect(21, 18, 7, 8);
        IntRect Head3Color1 = new IntRect(38, 18, 7, 8);
        IntRect Head4Color1 = new IntRect(55, 18, 7, 8);
        IntRect Head5Color1 = new IntRect(72, 18, 7, 8);
        IntRect Head6Color1 = new IntRect(89, 18, 7, 8);
        IntRect Head7Color1 = new IntRect(106, 18, 7, 8);
        IntRect Head8Color1 = new IntRect(123, 18, 7, 8);


        public void draw(RenderWindow window)
        {
            //window.Draw(bodyRect);
            window.Draw(sprite);
        }

        public void animate()
        {
            bool switchToNextImage = false;

            if(animationTimer >=animationDelay)
            {
                switchToNextImage = true;
                animationTimer = 0;
            }

            if(switchToNextImage)
            {


                if(currentSpriteIndex == 0)
                {
                    sprite.TextureRect = Head2Color1;
                }
                if (currentSpriteIndex == 1)
                {
                    sprite.TextureRect = Head3Color1;
                }
                if (currentSpriteIndex == 2)
                {
                    sprite.TextureRect = Head4Color1;
                }
                if (currentSpriteIndex == 3)
                {
                    sprite.TextureRect = Head5Color1;
                }
                if (currentSpriteIndex == 4)
                {
                    sprite.TextureRect = Head6Color1;
                }
                if (currentSpriteIndex == 5)
                {
                    sprite.TextureRect = Head7Color1;
                }
                if (currentSpriteIndex == 6)
                {
                    sprite.TextureRect = Head8Color1;
                }
                if (currentSpriteIndex == 7)
                {
                    sprite.TextureRect = Head1Color1;
                }

                if(currentSpriteIndex < 7)
                {
                    currentSpriteIndex++;
                }
                else
                {
                    currentSpriteIndex = 0;
                }


                
            }

            animationTimer++;

        }

        public void update()
        {

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
            sprite.TextureRect = Head7Color1;
            sprite.Position = position;
            sprite.Scale = new Vector2f(scale, scale);
        }

        public void setSpriteSheet(Texture newSpriteSheet)
        {
            texture = newSpriteSheet;
        }

    }

}
