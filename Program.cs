using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
namespace project
{
    public class Program
    {

        static void Main(string[] args)
        {
            Class1 class1 = new Class1();
            User user = null;
            int j = 0;
            while (user == null)
            {
                j++;
                Console.WriteLine("enter name");
                string name = Console.ReadLine();

                Console.WriteLine("enter password");
                string password = Console.ReadLine();

                user = class1.Login(name, password);
                if (j > 1 && user == null || user == null)
                {
                    Console.WriteLine(" פרטיך שגויים");

                }
            }
            Console.WriteLine("conected sucssefully");
            List<Questions1> listQ = class1.ShowQwestion();
            int mark = 0;
            int num = 0;

            foreach (Questions1 q in listQ)
            {
                Console.WriteLine(q.Question);
                if (q.IsAmerican)
                {
                    List<AmericanAnswers> americanAnswers = q.AmericanAnswers.OrderBy(x => Guid.NewGuid()).ToList();
                    for (int i = 0; i < americanAnswers.Count; i++)
                    {
                        Console.WriteLine((i + 1) + "." + americanAnswers[i].Answers);

                    }
                    Console.WriteLine("בחר תשובה");
                    string numString = Console.ReadLine();
                    int.TryParse(numString, out num);
                    while (num > americanAnswers.Count)
                    {
                        Console.WriteLine(" הבחירה אינה קיימת בחר תשובה");
                        numString = Console.ReadLine();
                        int.TryParse(numString, out num);
                    }
                    if (americanAnswers[num - 1].IsTrue)
                        mark += q.Percent;

                }
                if (!q.IsAmerican)
                {


                    Console.WriteLine(" הכנס תשובה נכונה");
                    string numString = Console.ReadLine();

                    int.TryParse(numString, out num);

                    mark += q.Percent;
                }
            }
            Console.WriteLine(mark);
            try
            {
                class1.updteMarkTable(user, mark);
            }
            catch
            {
                Console.WriteLine("לצערנו הפרטים לא נשמרו");
            }

            Console.ReadLine();


        }
    }
}
