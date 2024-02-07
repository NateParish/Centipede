using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Centipede
{
    internal class EnemyCentipede
    {

        Vector2f position = new Vector2f();
        List<BodySegment> bodySegments = new List<BodySegment>();
        uint bodySegmentCount = 1;
        Texture spriteSheet;
        float speed = 4;
        bool facingLeft = true;
        


        public void draw(RenderWindow window)
        {
            foreach (var segment in bodySegments) 
            {
                segment.draw(window);
            }
        }
        public void animate()
        {

            foreach (var segment in bodySegments)
            {
                segment.animate();
            }

        }

        public void move()
        {
            foreach(var segment in bodySegments)
            {
                segment.move();
            }    
        }

        public bool checkCollisionWithMushroom(Mushroom mushroom)
        {
            bool collision = false;
            //Console.WriteLine("Starting");
            Console.Write("X ");
            Console.Write(position.X);
            Console.Write("Y ");
            Console.Write(position.Y);
            Console.Write("MX ");
            Console.Write(mushroom.getPosition().X);
            Console.Write("MY ");
            Console.Write(mushroom.getPosition().Y);
            Console.WriteLine();

            if (facingLeft)
            {
                if (position.Y >= mushroom.getPosition().Y)
                {
                    if (position.Y <= mushroom.getPosition().Y + mushroom.getSize().Y)
                    {
                        if (position.X <= mushroom.getPosition().X + mushroom.getSize().X)
                        {
                            if (position.X >= mushroom.getPosition().X)
                            {
                                collision = true;
                                Console.WriteLine("COLLIDE, BOOM!");
                            }
                        }
                    }
                }

            }

            return collision;

        }

            public void setPosition(Vector2f newPosition)
        {
            position = newPosition;
        }

        public void setSpriteSheet(Texture newSpriteSheet)
        {
            spriteSheet = newSpriteSheet;
        }

        public void createBody(uint numberOfSegments)
        {
            for(int i = 0; i < numberOfSegments; i++) 
            {
                BodySegment segment = new BodySegment();
                Vector2f newPosition = new Vector2f();
                newPosition.X = position.X + 40 *i;
                newPosition.Y = position.Y;
                segment.setPosition(newPosition);
                segment.setSize(new Vector2f(40,40));
                segment.setSpeed(speed);
                segment.setSpriteSheet(spriteSheet);
                segment.setupSprite();
                segment.setAnimationOffset(i%8);
                if(i == 0)
                {
                    segment.setIsHead(true);
                }

                bodySegments.Add(segment);            
            }


        }

    }

}
