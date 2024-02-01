using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using System.Security.Policy;
using System.Runtime.CompilerServices;

namespace Centipede
{

    internal class Laser
    {
        Vector2f position = new Vector2f();
        Vector2f size = new Vector2f(5,40);
        int velocity = 50;
        Color color = new Color(255, 0, 0);
        RectangleShape bodyRect = new RectangleShape();

        public void draw(RenderWindow window)
        {
            //window.Draw(bodyRect);
            window.Draw(bodyRect);
        }

        public void update()
        {
            moveUp();
        }

        public void moveUp()
        {
            position.Y -= velocity;
            bodyRect.Position = position;
        }

        public void setPosition(Vector2f newPosition)
        {
            position = newPosition;
            bodyRect.Position = position;
        }

        public Vector2f getPosition()
        {
            return position;
        }

        public void setSize(Vector2f newSize)
        {
            size = newSize;
            bodyRect.Size = size;
        }

        public Vector2f getSize()
        {
            return position;
        }

       public void setColor(Color newColor)
        {
            color = newColor;
            bodyRect.FillColor = color;
        }

        public bool checkCollisionWithMushroom(Mushroom mushroom)
        {

            bool returnValue = false;
            //Console.WriteLine(mushroom.getPosition() + " " + mushroom.getSize());
            float mushroomSize = mushroom.getSize().X * mushroom.getScale();

            if(position.X >= mushroom.getPosition().X) 
            {
                if (position.X <= mushroom.getPosition().X + mushroomSize)
                {

                    if (position.Y <= mushroom.getPosition().Y + mushroomSize)
                    {

                        if(position.Y >= mushroom.getPosition().Y)
                        {
                            returnValue = true;

                        }

                    }
                        
                }


            }

            return returnValue;
        }


    }


}
