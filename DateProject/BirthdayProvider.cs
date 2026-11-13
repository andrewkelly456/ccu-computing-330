using System;
using System.Collections.Generic;
using System.IO;

namespace DateProject {

    public class BirthdayProvider : IBirthdayProvider {
        private readonly string _fileName;

        public BirthdayProvider() : this("birthdays.txt") {
        }

        public BirthdayProvider(string fileName) {
            _fileName = fileName;
        }

        //Each line looks like: 1990-5-12-Jane Doe  (year-month-day-name)
        public List<Birthday> GetBirthdays() {
            List<Birthday> list = new List<Birthday>();

            try {
                using (StreamReader sr = new StreamReader(_fileName)) {
                    string line;
                    while ((line = sr.ReadLine()) != null) {
                        string[] data = line.Split('-', 4);
                        list.Add(new Birthday() {
                            TheDate = new Date(Int32.Parse(data[0]), Int32.Parse(data[1]), Int32.Parse(data[2])),
                            Name = data[3]
                        });
                    }
                }
            }
            catch (Exception e) {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return list;
        }
    }

    public class Birthday {
        public Date TheDate {get;set;}
        public string Name {get;set;}
    }
}
