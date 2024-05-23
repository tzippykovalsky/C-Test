using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Class1
    {
        public User Login(string name, string password)
        {

            User user = new User();
            try
            {

                using (EstyfridmanMathTestEntities db = new EstyfridmanMathTestEntities())
                {
                    user = db.User.FirstOrDefault(x => x.Name == name && x.Password == password);

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }


            return user;

        }



        public List<Questions1> ShowQwestion()
        {
            List<Questions1> allquestions;
            List<Questions1> questions5 = new List<Questions1>();
            List<Questions1> questions6 = new List<Questions1>();
            List<Questions1> questions10 = new List<Questions1>();
            try
            {

                using (EstyfridmanMathTestEntities db = new EstyfridmanMathTestEntities())
                {
                    questions5 = db.Questions1.Include("AmericanAnswers").Where(x => x.Percent == 5).OrderBy(x => Guid.NewGuid()).Take(3).ToList();
                    questions6 = db.Questions1.Where(x => x.Percent == 6).OrderBy(x => Guid.NewGuid()).Take(4).ToList();
                    questions10 = db.Questions1.Where(x => x.Percent == 10).OrderBy(x => Guid.NewGuid()).Take(5).ToList();

                }
                questions5.AddRange(questions10);
                questions5.AddRange(questions6);
                allquestions = questions5;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return allquestions;

        }
        public void updteMarkTable(User user, int mark)
        {
            Marks marks = new Marks();
            marks.Mark = mark;
            marks.UserId = user.Id;
            marks.DateTest = DateTime.Now;
            try
            {

                using (EstyfridmanMathTestEntities db = new EstyfridmanMathTestEntities())
                {
                    db.Marks.Add(marks);
                    db.SaveChanges();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }


    }
}
