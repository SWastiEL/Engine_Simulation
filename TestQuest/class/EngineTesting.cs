using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestQuest
{
    class EngineTesting
    {
        int numV=0;
        public const int maxTime = 1800; // 30min

        /// <summary>
        /// Начало тестирования двигателя
        /// </summary>
        /// <param name="engine">тестируемый двигатель</param>
        /// <returns></returns>
        public double Start(Engine engine)
        {
            int time = 0;
            Load(engine);
            double a = engine.M / engine.I;
            int maxIndexM = MaxIndexM(engine);

            while (engine.TEngine < engine.Tmax && time < maxTime)
            {
                time++;
                engine.V += a;      //ускореное вращение коленвала
                if (numV < maxIndexM)
                {
                    if (engine.V >= engine.Vv[numV + 1])
                    {
                        numV ++;
                    }
                }
                double up = engine.V - engine.Vv[numV];                 //ускоренная скорость - стартовая
                double down = engine.Vv[numV + 1] - engine.Vv[numV];    //следующая скорость - стартовая
                double factor = engine.Mm[numV + 1] - engine.Mm[numV];  //следующий момент - стартовый момент
                engine.M = up / down * factor + engine.Mm[numV];

                engine.TEngine += engine.Vc() + engine.Vh();
                a = engine.M / engine.I;

                //DebugLog(time, engine);
            }
            
            return time;
        }

        /// <summary>
        /// Возвращает индекс максимального числа в массиве крутящего момента двигателя
        /// </summary>
        /// <param name="engine">двигатель</param>
        /// <returns></returns>
        private static int MaxIndexM(Engine engine)
        {
            double max = 0;
            int maxIndex = 0;
            for (int i = 0; i < engine.Mm.Length; i++)
            {
                if (max <= engine.Mm[i])
                {
                    max = engine.Mm[i];
                    maxIndex = i;
                }
            }
            return maxIndex;
        }
        
        private void Load(Engine engine)
        {
            engine.M = engine.Mm[numV];
            engine.V = engine.Vv[numV];
        }
        
        /// <summary>
        /// Вывод в консоль текущего состояния данных
        /// </summary>
        /// <param name="time">время с начала теста</param>
        /// <param name="engine">тестируемый двигатель</param>
        private void DebugLog(double time, Engine engine)
        {
            Console.WriteLine($"{time} : t.{engine.TEngine} : M.{engine.M} : V.{engine.V}");
        }
    }
}
