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
            // Close the window when OnClose event is received
            RenderWindow window = (RenderWindow)sender;
            window.Close();
        }

        static void WindowResized(object sender, SizeEventArgs e)
        {
            // Handle window resizing
            RenderWindow window = (RenderWindow)sender;

            // Ensure that the view is updated to maintain the same aspect ratio
            View view = window.GetView();
            view.Size = new Vector2f(e.Width, e.Height);
            window.SetView(view);
        }

        static void KeyPressed(object sender, KeyEventArgs e, Player player, List<Laser> lasers, bool fire)
        {
            // Close the window when OnClose event is received
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
            if(Keyboard.IsKeyPressed(Keyboard.Key.Space))
            {
                fire = true;
            }
            else
            {
                fire = false;
            }

        }

        static void Main()
        {

            Player player = new Player();
            Mushroom mushroom = new Mushroom();
            Vector2f playerSize = new Vector2f(16, 8);
            Vector2f playerPosition = new Vector2f(800, 800);
            player.setSize(playerSize);
            player.setPosition(playerPosition);
            player.setupSprite();
            bool fire = false;


            Vector2f mushroomPosition = new Vector2f(800, 250);
            Vector2f mushroomSize = new Vector2f(8, 8);
            mushroom.setSize(mushroomSize);
            mushroom.setPosition(mushroomPosition);
            mushroom.setupSprite();

            List<Mushroom> mushrooms = new List<Mushroom>();
            List<Mushroom> mushroomsTempList = new List<Mushroom>();
            mushrooms.Add(mushroom);

            List<Laser> lasers = new List<Laser>();
            List<Laser> lasersTempList = new List<Laser>();

            // Create the main window
            RenderWindow app = new RenderWindow(new VideoMode(1600, 950), "Centipede");
            app.SetFramerateLimit(60);
            app.Closed += new EventHandler(OnClose);
            app.Resized += new EventHandler<SizeEventArgs>(WindowResized);
            app.KeyPressed += (sender, e) => KeyPressed(sender, e, player, lasers, fire);

           
            
            

            Color windowColor = new Color(5, 5, 5);

            // Start the game loop
            while (app.IsOpen)
            {
                // Process events
                app.DispatchEvents();
                //Console.WriteLine(fire.ToString());

                // Clear screen
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
                            mushroom.takeDamage();
                            Console.WriteLine("outz");
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

                foreach(Mushroom shroom in mushrooms)
                {
                    shroom.update();
                    shroom.draw(app);
                }


                player.draw(app);
                

                //Console.WriteLine(lasers.Count);
                // Update the window
                app.Display();
            } //End game loop
        } //End Main()
    } //End Program
}
