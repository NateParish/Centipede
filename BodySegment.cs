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
        int animationTimer = 0;
        int animationDelay = 2;
        int currentSpriteIndex = 0;
        bool isHead = false;
        int animationOffset = 0;
        string movingRightOrLeft = "left";
        string movingUpOrDown = "down";
        float speed = 4;
        bool turnLeftFlag = false;

        IntRect Head1Color1 = new IntRect(4, 18, 7, 8);
        IntRect Head2Color1 = new IntRect(21, 18, 7, 8);
        IntRect Head3Color1 = new IntRect(38, 18, 7, 8);
        IntRect Head4Color1 = new IntRect(55, 18, 7, 8);
        IntRect Head5Color1 = new IntRect(72, 18, 7, 8);
        IntRect Head6Color1 = new IntRect(89, 18, 7, 8);
        IntRect Head7Color1 = new IntRect(106, 18, 7, 8);
        IntRect Head8Color1 = new IntRect(123, 18, 7, 8);

        IntRect Body1Color1 = new IntRect(4, 36, 7, 8);
        IntRect Body2Color1 = new IntRect(21, 36, 7, 8);
        IntRect Body3Color1 = new IntRect(38, 36, 7, 8);
        IntRect Body4Color1 = new IntRect(55, 36, 7, 8);
        IntRect Body5Color1 = new IntRect(72, 36, 7, 8);
        IntRect Body6Color1 = new IntRect(89, 36, 7, 8);
        IntRect Body7Color1 = new IntRect(106, 36, 7, 8);
        IntRect Body8Color1 = new IntRect(123, 36, 7, 8);


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

            int spriteIndex;

            if (currentSpriteIndex + animationOffset < 7)
            {
                spriteIndex = currentSpriteIndex + animationOffset;
            }
            else 
            {
                spriteIndex = (currentSpriteIndex + animationOffset) % 7;
            }

            




            if(switchToNextImage)            
            
            {
                if(spriteIndex == 0)
                {
                    if(isHead)
                    {
                        sprite.TextureRect = Head2Color1;
                    }
                    else
                    {
                        sprite.TextureRect = Body2Color1;
                    }
                    
                }
                if (spriteIndex == 1)
                {
                    if (isHead)
                    {
                        sprite.TextureRect = Head3Color1;
                    }
                    else
                    {
                        sprite.TextureRect = Body3Color1;
                    }
                }
                if (spriteIndex == 2)
                {
                    if (isHead)
                    {
                        sprite.TextureRect = Head4Color1;
                    }
                    else
                    {
                        sprite.TextureRect = Body4Color1;
                    }
                }
                if (spriteIndex == 3)
                {
                    if (isHead)
                    {
                        sprite.TextureRect = Head5Color1;
                    }
                    else
                    {
                        sprite.TextureRect = Body5Color1;
                    }
                }
                if (spriteIndex == 4)
                {
                    if (isHead)
                    {
                        sprite.TextureRect = Head6Color1;
                    }
                    else
                    {
                        sprite.TextureRect = Body6Color1;
                    }
                }
                if (spriteIndex == 5)
                {
                    if (isHead)
                    {
                        sprite.TextureRect = Head7Color1;
                    }
                    else
                    {
                        sprite.TextureRect = Body7Color1;
                    }
                }
                if (spriteIndex == 6)
                {
                    if (isHead)
                    {
                        sprite.TextureRect = Head8Color1;
                    }
                    else
                    {
                        sprite.TextureRect = Body8Color1;
                    }
                }
                if (spriteIndex == 7)
                {
                    if (isHead)
                    {
                        sprite.TextureRect = Head1Color1;
                    }
                    else
                    {
                        sprite.TextureRect = Body1Color1;
                    }
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

        public void move()
        {
            float leftBoundary = 100;
            float rightBoundary = 1100;

            if (isHead)
            {
                //Console.WriteLine($"Speed: {speed}  position x: {position.X} position.Y: {position.Y} sizeY: {size.Y}");
            }
            //Console.WriteLine($"Speed: {speed}  position x: {position.X} position.Y: {position.Y}");

            if (movingRightOrLeft == "right")
            {
                position.X = position.X + speed;
                sprite.Position = position;
                if (position.X > rightBoundary)
                {
                    reverseDirection();
                }
            }
            else
            {
                position.X = position.X - speed;
                sprite.Position = position;
                if (position.X < leftBoundary)
                {
                    reverseDirection();
                }
            }


        }

        public void reverseDirection()
        {


            if(movingRightOrLeft == "right")
            {
                movingRightOrLeft = "left";
            }
            else
            {
                movingRightOrLeft = "right";
            }


            position.Y = position.Y + size.Y;
           
        }

        public void setAnimationOffset(int newOffset)
        {
            animationOffset = newOffset;
        }

        public void setIsHead(bool isSegmentHead)
        {
            isHead = isSegmentHead;
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
