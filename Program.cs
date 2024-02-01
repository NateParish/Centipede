using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Centipede;
using SFML;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace SFML_Test
{
    class Program
    {

        static void OnClose(object sender, EventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;
            window.Close();
        }

        static void WindowResized(object sender, SizeEventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;
            View view = window.GetView();
            view.Size = new Vector2f(e.Width, e.Height);
            window.SetView(view);
        }

        static void KeyPressed(object sender, KeyEventArgs e, Player player, List<Laser> lasers, bool fire)
        {

            RenderWindow window = (RenderWindow)sender;

            if (e.Code == Keyboard.Key.Left)
            {
                player.moveLeft();
            }
            if (e.Code == Keyboard.Key.Right)
            {
                player.moveRight();
            }
            if (e.Code == Keyboard.Key.Up)
            {
                player.moveUp();
            }
            if (e.Code == Keyboard.Key.Down)
            {
                player.moveDown();
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Space))
            {
                fire = true;
            }
            else
            {
                fire = false;
            }

        }

        static void spawnMushrooms(Vector2f mushroomSize, Vector2f gameboardPosition, uint gameboardHeight, uint gameboardWidth, List<Mushroom> mushrooms, Texture spriteSheet)
        {
            int i = 0;
            int k = 0;
            float curX = 0;
            float curY = gameboardPosition.Y;
            float mushroomWidth = 40;
            float mushroomHeight = 40;
            float rowCount = gameboardHeight / mushroomSize.Y;
            Random random = new Random();
            int rnd;

            Console.WriteLine(rowCount);

            while (k < ((gameboardHeight - 250) / mushroomWidth))
            {
                Console.WriteLine(k);

                i = 0;
                while (i < (gameboardWidth / mushroomWidth))
                {
                    rnd = random.Next(1, 5);
                    if (rnd == 1)
                    {
                        Mushroom newMushroom = new Mushroom();
                        curX = i * mushroomWidth + gameboardPosition.X;
                        curY = k * mushroomHeight + gameboardPosition.Y;
                        Vector2f newMushroomPosition = new Vector2f();
                        newMushroomPosition.X = curX;
                        newMushroomPosition.Y = curY;
                        newMushroom.setSize(mushroomSize);
                        newMushroom.setPosition(newMushroomPosition);
                        newMushroom.setSpriteSheet(spriteSheet);
                        newMushroom.setupSprite();
                        mushrooms.Add(newMushroom);
                    }
                    i++;
                }
                k++;
            }
        }

        static void Main()
        {
            Texture spriteSheet = new Texture("C:\\Programming\\Centipede\\Assets\\SpriteSheet.png");
            Player player = new Player();
            Mushroom mushroom = new Mushroom();
            Vector2f playerSize = new Vector2f(8, 8);
            Vector2f playerPosition = new Vector2f(800, 800);
            player.setSize(playerSize);
            player.setPosition(playerPosition);
            player.setSpriteSheet(spriteSheet);
            player.setupSprite();
            bool fire = false;
            uint screenWidth = 1800;
            uint screenHeight = 950;
            uint gameboardWidth = 1600;
            uint gameboardHeight = 750;
            Vector2f gameboardPosition = new Vector2f(100, 100);

            Scoreboard scoreboard = new Scoreboard();
            scoreboard.setupScoreboard();

            BodySegment centipede = new BodySegment();
            Vector2f centPos = new Vector2f(400, 800);
            Vector2f centSize = new Vector2f(16, 8);

            centipede.setPosition(centPos);
            centipede.setSize(centSize);
            centipede.setSpriteSheet(spriteSheet);
            centipede.setupSprite();


           


            Vector2f mushroomPosition = new Vector2f(100, 250);
            Vector2f mushroomSize = new Vector2f(8, 8);
            mushroom.setSize(mushroomSize);
            mushroom.setPosition(mushroomPosition);
            mushroom.setSpriteSheet(spriteSheet);
            mushroom.setupSprite();

            List<Mushroom> mushrooms = new List<Mushroom>();
            List<Mushroom> mushroomsTempList = new List<Mushroom>();
            mushrooms.Add(mushroom);

            List<Laser> lasers = new List<Laser>();
            List<Laser> lasersTempList = new List<Laser>();

            // Create the main window
            RenderWindow app = new RenderWindow(new VideoMode(screenWidth, screenHeight), "Centipede");
            app.SetFramerateLimit(60);
            app.Closed += new EventHandler(OnClose);
            app.Resized += new EventHandler<SizeEventArgs>(WindowResized);
            app.KeyPressed += (sender, e) => KeyPressed(sender, e, player, lasers, fire);


            EnemyCentipede centipede2 = new EnemyCentipede();
            Vector2f cent2Pos = new Vector2f(400, 850);
            centipede2.setPosition(cent2Pos);
            centipede2.setSpriteSheet(spriteSheet);
            centipede2.createBody(8);


            spawnMushrooms(mushroomSize, gameboardPosition, gameboardHeight, gameboardWidth, mushrooms, spriteSheet);


            Color windowColor = new Color(0, 0, 0);


            while (app.IsOpen)
            {

                app.DispatchEvents();
                //Console.WriteLine(fire.ToString());


                app.Clear(windowColor);
                //List<Laser> lasersTempList = new List<Laser>();
                //Console.WriteLine(lasers.Count());


                if (Keyboard.IsKeyPressed(Keyboard.Key.Space))
                {
                    fire = true;
                }
                else
                {
                    fire = false;
                }

                if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
                {
                    player.moveLeft();
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
                {
                    player.moveRight();
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
                {
                    player.moveUp();
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
                {
                    player.moveDown();
                }

                //else
                //{
                //    fire = false;
                //    Console.WriteLine(" - ");
                //}



                foreach (Laser laser in lasers)
                {
                    if (laser.getPosition().Y < -100)
                    {
                        lasersTempList.Add(laser);
                    }
                }

                foreach (Laser laser in lasersTempList)
                {
                    lasers.Remove(laser);
                }

                //lasers.Clear();
                //lasers = lasersTempList;
                lasersTempList.Clear();



                foreach (Laser laser in lasers)
                {
                    laser.update();
                    laser.draw(app);

                    foreach(Mushroom shroom in mushrooms)
                    {
                        if(laser.checkCollisionWithMushroom(shroom))
                        {
                            lasersTempList.Add(laser);
                            shroom.takeDamage();
                        }
                    }

                }

                foreach (Laser laser in lasersTempList)
                {
                    lasers.Remove(laser);
                }

                lasersTempList.Clear();

                foreach(Mushroom shroom in mushrooms)
                {
                    if(shroom.getIsDead())
                    {
                        mushroomsTempList.Add(shroom);
                        player.addPointsToScore(1);
                    }
                }

                foreach(Mushroom shroom in mushroomsTempList)
                {
                    mushrooms.Remove(shroom);
                }

                mushroomsTempList.Clear();


                player.update();

                if(fire)
                {
                    if (player.getIsOKToFire())
                    {
                        lasers.Add(player.fire());
                    }

                }


                scoreboard.update(player);
                centipede.animate();
                centipede2.animate();
                scoreboard.draw(app);
                centipede.draw(app);
                centipede2.draw(app);

                foreach(Mushroom shroom in mushrooms)
                {
                    shroom.update();
                    shroom.draw(app);
                }


                player.draw(app);


                app.Display();
            } 
        } 
    } 
}
