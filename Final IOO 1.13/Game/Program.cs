using System;
using System.Collections.Generic;

namespace Game
{
    public enum States
    {
        MainMenu,
        Game,
        Win,
        GameOver
    }

    public class Program
    {
        public static States actualState = States.MainMenu;

        //tamaño juego
        public static int wGame = 800; 
        public static int hGame = 500;

        

        //variables deltatime
        public static float deltaTime;
        static DateTime lastFrameTime = DateTime.Now;
        public static DateTime fechaInicio;

        static void Main(string[] args)
        {
            InitializeElements();

            while (true)
            {
                calcDeltatime();

                Update();
                Draw();
            }
        }

        static void Update()
        {
            if (actualState == States.MainMenu)
            {
                MenuManager.Instance.Update();
            }
            else if (actualState == States.Game)
            {
                GameManager.Instance.Update();
            }
            else if (actualState == States.Win)
            {

            }
            else if (actualState == States.GameOver)
            {

            }
        }

        static void Draw()
        {
            Engine.Clear();

            if (actualState == States.MainMenu)
            {
                MenuManager.Instance.DrawManager();
            }
            else if (actualState == States.Game)
            {
                GameManager.Instance.DrawManager();
            }
            else if (actualState == States.Win)
            {
                Engine.Draw("Texturas/Menus/WinMenu.png");
            }
            else if (actualState == States.GameOver)
            {
                Engine.Draw("Texturas/Menus/LoseMenu.png");
            }

            Engine.Show();
        }

        public static float GetTime()
        {
            TimeSpan diferenciaInicio = DateTime.Now.Subtract(fechaInicio);
            return (float)(diferenciaInicio.TotalMilliseconds / 1000f);
        }
    
        static void calcDeltatime()
        {
            TimeSpan deltaSpan = DateTime.Now - lastFrameTime;
            deltaTime = (float)deltaSpan.TotalSeconds;
            lastFrameTime = DateTime.Now;
        }

        static void InitializeElements()
        {
            Engine.Initialize("Game", wGame, hGame);
            fechaInicio = DateTime.Now;
            MenuManager.Instance.InitButtons();
        }
    }
}