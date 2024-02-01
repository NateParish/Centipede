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
                segment.setSize(position);
                segment.setSpriteSheet(spriteSheet);
                segment.setupSprite();
                segment.setAnimationOffset(i%8);
                bodySegments.Add(segment);            
            }


        }

    }

}
