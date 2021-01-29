using System;
namespace ConsoleApp6
{
    class person
    {
        public string name { get; set; }
        public string lastname { get; set; }
        public bool want_to_climb_in_bus { get; set; } = false;
        public bool arrival { get; set; } = false;
        public bool i_do_not_care_about_fine { get; set; } = false;
        public int fine { get; set; }
        public profession PersonProffesion { get; set; }
       

    }
       public enum profession { Firefighter, Teacher, Doctor, Nurse, Postal_Worker, Armed_Force, student }
    class bus
    {
        public float price_of_ticket { get; private set; } = 0.5f;
        public string advertisment1 = "there is no seats in here";
        public string advertisment2 = "there is seats in here, come in";
        public profession profession;
        public person person;
        public  int humans_count { get; private set; }
        public void get_profession( profession profession)
        {
            this.profession = profession;
            if (profession ==profession.Doctor || profession == profession.Armed_Force || profession == profession.Firefighter)
            {
                price_of_ticket = 0.2f;
            }
        }
        public void about_person(person person)
        {
            this.person = person;
            if (person.want_to_climb_in_bus == true && humans_count >= 20)
            {
                Console.WriteLine(advertisment1);
                if (person.i_do_not_care_about_fine == true)
                {
                    person.fine = 3000;
                    humans_count++;
                }
            }
            if (person.want_to_climb_in_bus == true && humans_count < 20)
            {
                Console.WriteLine(advertisment2);
                humans_count++;

            }


        }
        public void arrival(person person)
        {
            this.person = person;
            if (person.arrival == true)
            {
                humans_count--;
                person.arrival = false;
                person.want_to_climb_in_bus = false;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            person first = new person();
            first.want_to_climb_in_bus = true;
            first.name = "harry";
            first.lastname = "batman";

            first.i_do_not_care_about_fine = true;
            bus bus = new bus();
            bus.about_person(first);
            bus.get_profession(profession.Armed_Force);
            Console.WriteLine(bus.humans_count);
            Console.WriteLine(bus.price_of_ticket);
            Console.WriteLine("{0} {1}your fine is {2} connect us", first.name, first.lastname, first.fine);
        }
    }
}
