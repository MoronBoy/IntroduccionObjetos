using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class MenuManager : IUpdate, IDrawManager
    {
        private float timerEnter;
        private float maxTimerEnter = 0.3f;
        private bool canEnter = true;

        private List<IDraw> _drawableObjects = new List<IDraw>();

        //variables botones y menu
        private Select select;
        private Button buttonStart;
        private Button buttonLevelSelect;
        private Button buttonExit;
        private Button buttonActual;
        private Background background;

        private static MenuManager instance;

        public static MenuManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MenuManager();
                }

                return instance;
            }

        }

        public List<IDraw> DrawableObjects
        {
            get { return _drawableObjects; }
            set { _drawableObjects = value; }
        }

        public void Update()
        {
            buttonActual = buttonActual.Update();
            select.Update(buttonActual.PosX, buttonActual.PosY);

            EnterDelay();

            if (Engine.GetKey(Keys.RETURN) && canEnter)
            {
                canEnter = false;
                timerEnter = 0f;
                EnterButton();
            }
        }

        public void DrawManager()
        {
            for (int i = 0; i < _drawableObjects.Count; i++)
            {
                DrawableObjects[i].Draw();
            }
            
        }

        public void InitButtons()
        {
            background = new Background("Texturas/Menus/MainMenu.png");
            buttonStart = new Button( 200, "Texturas/Botones/Start_Button (border).png");
            buttonLevelSelect = new Button( 248, "Texturas/Botones/Load_Button (border).png"); //cambiar textura
            buttonExit = new Button( 296, "Texturas/Botones/Exit_Button (border).png");

            buttonStart.SetearBotones(buttonExit, buttonLevelSelect);
            buttonLevelSelect.SetearBotones(buttonStart, buttonExit);
            buttonExit.SetearBotones(buttonLevelSelect, buttonStart);

            buttonActual = buttonStart;
            select = new Select("Texturas/Botones/Button_YesPress.png");

            //agregar fondo, botones y select
            _drawableObjects.Add(background);
            _drawableObjects.Add(buttonStart);
            _drawableObjects.Add(buttonLevelSelect);
            _drawableObjects.Add(buttonExit);
            _drawableObjects.Add(select);
        }

        private void EnterDelay()
        {
            timerEnter += Program.deltaTime;

            if (timerEnter >= maxTimerEnter)
            {
                canEnter = true;
                timerEnter = 0f;
            }
        }

        private void EnterButton()
        {
            if (buttonActual == buttonStart)
            {
                Program.actualState = States.Game;
                GameManager.Instance.Init();
            }
            else if (buttonActual == buttonLevelSelect)
            {
                
            }
            else if (buttonActual == buttonExit)
            {
                Environment.Exit(1);
            }
        }
    }
}
