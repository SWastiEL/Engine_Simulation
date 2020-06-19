using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TestQuest
{
    class Informing
    {
        /// <summary>
        /// Ввод температуры окружения
        /// </summary>
        /// <returns></returns>
        public double ReadTAmbient()
        {
            Console.Write("Enter ambient temperature.\n");
            Console.Write("Введите температуру окружения: ");
            double ambient=0;
            string text= Console.ReadLine();
            while (!Double.TryParse(text, out ambient))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Error! Repeat.\n");
                Console.Write("Ошибка! Повторите: ");
                Console.ForegroundColor = ConsoleColor.White;
                text = Console.ReadLine();
            }
            return ambient;
        }
        /// <summary>
        /// Вывод в консоль времени до перегрева
        /// </summary>
        /// <param name="time"></param>
        public void TimeWork(double time)
        {
            if (time<EngineTesting.maxTime)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Engine overheat time: {time} sec.");
                Console.WriteLine($"Время перегрева двигателя: {time} сек.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"At this ambient temperature, the engine does not overheat.");
                Console.WriteLine($"При такой температуре окружающей среды двигатель не перегревается.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        /// <summary>
        /// Возвращает истину, если удалось загрузить исходные данных из файла
        /// </summary>
        /// <param name="engine">двигатель</param>
        /// <returns></returns>
        public bool LoadData(Engine engine)
        {
            try
            {
                StreamReader sr = new StreamReader("data.txt");
                engine.I = (Convert.ToDouble(sr.ReadLine()));
                engine.Mm = StringLineToDoubleLine(sr);
                engine.Vv = StringLineToDoubleLine(sr);
                engine.Tmax = (Convert.ToDouble(sr.ReadLine()));
                engine.Hm = (Convert.ToDouble(sr.ReadLine()));
                engine.Hv = (Convert.ToDouble(sr.ReadLine()));
                engine.C = (Convert.ToDouble(sr.ReadLine()));
                sr.Close();
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("FileNotFoundExeption. Loading source data from code..");
                Console.WriteLine("Файл не найден. Загрузка исходных данных из кода..");
                engine.I = 10;
                engine.Mm = new double[] { 20, 75, 100, 105, 75, 0 };
                engine.Vv = new double[] { 0, 75, 150, 200, 250, 300 };
                engine.Tmax = 110;
                engine.Hm = 0.01;
                engine.Hv = 0.0001;
                engine.C = 0.1;
                return false;
            }
        }

        private static double[] StringLineToDoubleLine(StreamReader sr)
        {
            string[] line = sr.ReadLine().Split(' ');
            double[] lineString = new double[line.Length];
            for (int i = 0; i < line.Length; i++)
            {
                try
                {
                    lineString[i] = Convert.ToDouble(line[i]);
                }
                catch (Exception)
                {
                }
            }
            return lineString;
        }
    }
}
