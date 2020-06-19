using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestQuest
{

    //Необходимо разработать консольное приложение, которое 
    //    рассчитывает и выводит время, 
    //    которое пройдет от старта двигателя внутреннего сгорания до момента его перегрева, 
    //    в зависимости от заданной температуры окружающей среды.
    //Приложение должно принимать с консоли пользовательский ввод температуры окружающей среды в градусах Цельсия, 
    //    и выводить на консоль время до перегрева в секундах.
    //Рассчитывать время точно, аналитическим путем не нужно, интересует получение этого времени методом симуляции 
    //    (разумеется, таким образом время будет вычислено с определенной погрешностью).

    class MainClass
    {
        static void Main(string[] args)
        {
            Informing informing = new Informing();
            EngineTesting engineTesting = new EngineTesting();
            Engine engine = new Engine(informing.ReadTAmbient());

            informing.LoadData(engine);
            informing.TimeWork(engineTesting.Start(engine));

            Console.ReadKey();
        }
    }
}
