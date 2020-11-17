using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Collider
    {
        float _widthImg;
        float _scaleImg;
        float _heightImg;

        float _posX;
        float _posY;
        public Collider(float widthImg, float scale, float heightImg)
        {
             _widthImg = widthImg;
             _scaleImg = scale;
             _heightImg = heightImg;
        }
        public void UpdatePosition(float posX, float posY)
        {
            _posX = posX;
            _posY = posY;
        }
        private float GetXMin()
        {
            return _posX - (_widthImg * _scaleImg / 2);
        }
        private float GetXMax()
        {
            return _posX + (_widthImg * _scaleImg / 2);
        }
        private float GetYMin()
        {
            return _posY + (_heightImg * _scaleImg / 2);
        }
        private float GetYMax()
        {
            return _posY - (_heightImg * _scaleImg / 2);
        }

        public bool CheckCollision(List<Collider> listaAChequear)
        {

            for(int i =0; i < listaAChequear.Count; i++)
            {
                Collider actual = listaAChequear[i];

                if(CollisionCon(actual.GetXMin(), actual.GetYMin(), actual.GetXMax(), actual.GetYMax()))
                {
                    return true;
                }
            }
            return false;
        }

        public bool CollisionCon(float x2Min,float y2Min, float x2Max, float y2Max)
        {
            bool solapaXIzq = (x2Max >= GetXMin() && x2Max <= GetXMax()) && x2Min <= GetXMin();
            bool solapaXDer = (x2Min >= GetXMin() && x2Min <= GetXMax()) && x2Max >= GetXMax();
            bool solapaXMed = x2Min >= GetXMin() && x2Max <= GetXMax();
            bool solapaX = (solapaXIzq || solapaXMed || solapaXDer);


            bool solapaYMin = (y2Min <= GetYMin() && y2Min >= GetYMax()) && y2Max <= GetYMax();
            bool solapaYMax = (y2Max <= GetYMin() && y2Max >= GetYMax()) && y2Min <= GetYMin();
            bool solapaYMed = y2Min <= GetYMin() && y2Max >= GetYMax();
            bool solapaY = (solapaYMin || solapaYMed || solapaYMax);

            return (solapaX && solapaY);
        }

    }
}
