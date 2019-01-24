using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace MVC_TimeApp.Models
{
    public class TimePerson
    {
        public int Year { get; set; }
        public string Honor { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int BirthYear { get; set; }
        public int DeathYear { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Context { get; set; }

        public static List<TimePerson> GetPersons(int startYear, int endYear)
        {
            List<TimePerson> people = new List<TimePerson>();
            //read in teh file
            //File.ReadAllLines (in an array)
            string[] dataArray = File.ReadAllLines(@"C:\Users\MBG\codefellows\401\Lab11-My-First-MVC-App\MVC_TimeApp\MVC_TimeApp\wwwroot\personOfTheYear.csv");

            for (int i = 1; i < dataArray.Length; i++)
            {
                TimePerson entry = new TimePerson();
                string[] rowData = dataArray[i].Split(',', StringSplitOptions.None);
                
                entry.Year = Convert.ToInt32(rowData[0]);
                entry.Honor = rowData[1];
                entry.Name = rowData[2];
                entry.Country = rowData[3];
                if (rowData[4] == "")
                {
                    entry.BirthYear = 0;
                }
                else
                {
                    entry.BirthYear = Convert.ToInt32(rowData[4]);

                }
                if (rowData[5] == "")
                {
                    entry.DeathYear = 0;
                }
                else
                {
                    entry.DeathYear = Convert.ToInt32(rowData[5]);

                }
                entry.Title = rowData[6];
                entry.Category = rowData[7];
                entry.Context = rowData[8];

                people.Add(entry);
            }

            List<TimePerson> searchQuery = people.Where(p => (p.Year >= startYear) && (p.Year <= endYear)).ToList();

            return searchQuery;

            // iterate through that array and set values appropriately to a new TimePerson Object

            // CSV file is comma delimited

            //create full list of peoples from csv file

            // THEN do LINQ query with lambdas to filter

            //TimePerson tp = new TimePerson();
            //tp.Name = "Mike";
            //tp.Honor = "Being Awesome";
            //tp.Category = "Dog Lover";

            //people.Add(tp);

            //return people;

            //List<TimePerson> listOfPeople = people.Where(p => (p.Year >= startYear) && (p.Year <= endYear)).toList();
        }
    }
}
