using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestQuest
{
    class Engine
    {
        /// <summary>
        /// момент инерции
        /// </summary>
        private double i;// = 10;
        /// <summary>
        /// крутящий момент
        /// </summary>
        private double m;//;
        /// <summary>
        /// скорость вращения коленвала
        /// </summary>
        private double v;//;
        double[] mm;// = new double[] { 20, 75, 100, 105, 75, 0 };
        double[] vv;// = new double[] { 0, 75, 150, 200, 250, 300 };
        /// <summary>
        /// перегрев
        /// </summary>
        private double tMax;// = 110;
        /// <summary>
        /// коэффициент зависимости скорости нагрева от крутящего момента
        /// </summary>
        private double hm;// =0.01;
        /// <summary>
        /// коэффициент зависимости скорости нагрева от скорости вращения коленвала
        /// </summary>
        private double hv;// =0.0001;
        /// <summary>
        /// коэффициент зависимости скорости охлаждения от температуры двигателя и окружающей среды
        /// </summary>
        private double c;// =0.1;
        
        /// <summary>
        /// температура двигателя
        /// </summary>
        private double tEngine;
        /// <summary>
        /// температура окружающей среды
        /// </summary>
        private double tAmbient;

        /// <summary>
        /// температура двигателя(свойство)
        /// </summary>
        public double TEngine
        {
            get { return tEngine; }
            set { tEngine = value; }
        }
        /// <summary>
        /// температура окружающей среды(свойство)
        /// </summary>
        public double TAmbient
        {
            get { return tAmbient; }
            set { tAmbient = value; }
        }
        /// <summary>
        /// перегрев(свойство)
        /// </summary>
        public double Tmax
        {
            get { return tMax; }
            set { tMax = value; }
        }
        /// <summary>
        /// крутящий момент(свойство)
        /// </summary>
        public double M
        {
            get { return m; }
            set { m = value; }
        }
        /// <summary>
        /// скорость вращения коленвала(свойство)
        /// </summary>
        public double V
        {
            get { return v; }
            set { v = value; }
        }
        /// <summary>
        /// момент инерции(свойство)
        /// </summary>
        public double I
        {
            get { return i; }
            set { i = value; }
        }

        public double[] Mm { get => mm; set => mm = value; }
        public double[] Vv { get => vv; set => vv = value; }
        public double Hm { get => hm; set => hm = value; }
        public double Hv { get => hv; set => hv = value; }
        public double C { get => c; set => c = value; }

        /// <summary>
        /// Конструктор, с указанием температуры окружающей среды
        /// </summary>
        /// <param name="temperatureAmient"></param>
        public Engine(double temperatureAmient)
        {
            tAmbient = temperatureAmient;
            tEngine = temperatureAmient;
        }
        /// <summary>
        /// Конструктор, температура окружающей среды равна 0
        /// </summary>
        public Engine()
        {
            TAmbient = 0;
            tEngine = TAmbient;
        }

        /// <summary>
        /// Скорость нагрева двигателя
        /// </summary>
        public double Vh()
        {
            return M * hm + Math.Pow(v, 2) * hv;
        }
        /// <summary>
        /// Скорость охлаждения двигателя
        /// </summary>
        /// <returns></returns>
        public double Vc()
        {
            return C * (tAmbient - tEngine);
        }
    }
}
