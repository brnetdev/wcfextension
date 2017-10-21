using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using DB;

namespace Service
{
    public class PersonService : IPersonService
    {
        public void Add(Person person)
        {
            using (var db = new Db())
            {
                db.People.Add(person);
                db.SaveChanges();
            }
        }

        public void Delete(int personId)
        {
            using (var db = new Db())
            {
                var person = db.People.Where(p => p.Id == personId).Single();
                db.People.Remove(person);
                db.SaveChanges();
            }
        }

        public Person Get(int personId)
        {
            using (var db = new Db())
            {
                return db.People.Where(p => p.Id == personId).Single();
            }

        }

        public void Update(Person person)
        {
            using (var db = new Db())
            {
                var dbPerson = db.People.Where(p => p.Id == person.Id).Single();

                dbPerson.LastName = person.LastName;
                dbPerson.Name = person.Name;
                dbPerson.Age = person.Age;

                db.SaveChanges();
            }
        }
    }
}
