using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class GameManager
    {
        private Player _player1;

        private List<Level> levels = new List<Level>();
        private int _currentLevel = 0;
        
        public event Action OnWin;
        float Time = 10;//Tiempo de juego

        private static GameManager instance;

        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameManager();
                }

                return instance;
            }

        }



        public int CurrentLevel
        {
            get { return _currentLevel; }
            set { _currentLevel = value; }
        }

        public Player Player1 { get => _player1; set => _player1 = value; }

        public void Update()
        {
            levels[CurrentLevel].Update();
            _player1.Update();
            Timer();
            if (Timer()) OnWin();
        }

        public void DrawManager()
        {
            levels[CurrentLevel].DrawManager();
            _player1.Draw();
        }

        public void Init()
        {
            var level1 = new Level(50, 50,1f);
            //var level2 = new Level(50, 50,2f);
            levels.Add(level1);
            //levels.Add(level2);
            OnWin += WinScreen;

            _player1 = new Player(50, 425, 200, "Texturas/player.png", 0.04f,1200,1200);
            _player1.OnDeath += LoseScreen;
            
        }

        void LoseScreen()
        {
            Program.actualState = States.GameOver;
        }
        
        void WinScreen()
        {
            Program.actualState = States.Win; 
        }

        private bool Timer()
        {
            Engine.Debug("Tic toc" + Time);
            Time -= Program.deltaTime;
            if (Time <= 0)
            {
                return true;
            }
            return false;

        }

    }
}
