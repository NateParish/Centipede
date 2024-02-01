using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;

namespace Centipede
{
    internal class Scoreboard
    {

        RectangleShape backgroundRect = new RectangleShape();
        Text scoreLabel = new Text();
        Font ariel = new Font("C:/Windows/Fonts/arial.ttf");
        int playerScore = 0;


        public void setupScoreboard()
        {
            backgroundRect.Size = new Vector2f(1800, 80);
            backgroundRect.FillColor = new Color(20,20,20);
            backgroundRect.Position = new Vector2f(0,0);
            scoreLabel.CharacterSize = 24;
            scoreLabel.Font = ariel;
            scoreLabel.Position = new Vector2f(10,10);
            scoreLabel.DisplayedString = "Yo Vinny";

        }

        public void update(Player player)
        {
            playerScore = player.getPlayerScore();
            scoreLabel.DisplayedString = $"SCORE:  {playerScore}"; 
        }

        public void draw(RenderWindow window)
        {
            window.Draw(backgroundRect);
            window.Draw(scoreLabel);
        }
    }


}
