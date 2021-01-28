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
        public enum profession { Firefighters, Teachers, Doctors, Nurses, Postal_Workers, Armed_Forces, student }

    }
    class bus
    {
        public float price_of_ticket { get; private set; } = 0.5f;
        public string advertisment1 = "there is no seats in here";
        public string advertisment2 = "there is seats in here, come in";
        public person.profession profession;
        public person person;
        public static int humans_count { get; private set; }
        public void get_profession(person.profession profession)
        {
            this.profession = profession;
            if (profession == person.profession.Doctors || profession == person.profession.Armed_Forces || profession == person.profession.Firefighters)
            {
                price_of_ticket = 0.2f;
            }
        }
        public void get_person(person person)
        {
            this.person = person;
        }
        public void about_person()
        {
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
            bus.get_person(first);
            bus.about_person();
            bus.get_profession(person.profession.Armed_Forces);
            Console.WriteLine(bus.humans_count);
            Console.WriteLine(bus.price_of_ticket);
            Console.WriteLine("{0} {1}your fine is {2} connect us", first.name, first.lastname, first.fine);
        }
    }
}
