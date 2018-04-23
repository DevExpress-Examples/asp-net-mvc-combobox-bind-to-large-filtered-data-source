using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.Web.ASPxEditors;

namespace ComboBoxLargeDataBase.Model {
    public static class DataHelper {
        public static IQueryable<Person> Persons {
            get {
                if(HttpContext.Current.Session["Persons"] == null) {
                    List<Person> list = new List<Person>();

                    list.Add(new Person(1, "David", "Jordan", "Adler"));
                    list.Add(new Person(2, "Michael", "Christopher", "Alcamo"));
                    list.Add(new Person(3, "Amy", "Gabrielle", "Altmann"));
                    list.Add(new Person(4, "Meredith", "", "Berman"));
                    list.Add(new Person(5, "Margot", "Sydney", "Atlas"));
                    list.Add(new Person(6, "Eric", "Zachary", "Berkowitz"));
                    list.Add(new Person(7, "Kyle", "", "Bernardo"));
                    list.Add(new Person(8, "Liz", "", "Bice"));

                    HttpContext.Current.Session["Persons"] = list.AsQueryable<Person>();
                }
                return (IQueryable<Person>)HttpContext.Current.Session["Persons"];
            }
        }

        public static object GetPersonsRange(ListEditItemsRequestedByFilterConditionEventArgs args) {
            var skip = args.BeginIndex;
            var take = args.EndIndex - args.BeginIndex + 1;
            return (from person in DataHelper.Persons
                    where (person.FirstName + " " + person.MiddleName + " " + person.LastName).ToLower().Contains(args.Filter.ToLower())
                    orderby person.LastName
                    select person
                )
                .Skip(skip)
                .Take(take);
        }
        public static object GetPersonByID(ListEditItemRequestedByValueEventArgs args) {
            if(args.Value != null)
                return GetPersonByID((int)args.Value);
            return null;
        }
        public static object GetPersonByID(int personID) {
            return (from person in DataHelper.Persons
                    where person.PersonID == personID
                    select person).Take(1);
        }
    }

    public class Person {
        public Person() {
            PersonID = 0;
            FirstName = string.Empty;
            MiddleName = string.Empty;
            LastName = string.Empty;
        }

        public Person(int id, String firstName, string middleName, String lastName) {
            this.PersonID = id;
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
        }

        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
    }
}