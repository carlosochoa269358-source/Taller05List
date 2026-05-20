namespace Taller6_ArchivosPlanos
{
    public class Person
    {
        public int Id
        {
            get;
            set;
        }

        public string FirstName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public string Phone
        {
            get;
            set;
        }

        public string City
        {
            get;
            set;
        }

        public double Balance
        {
            get;
            set;
        }

        // Constructor vacío
        public Person() { }

        // Constructor con parámetros
        public Person(int id, string firstName, string lastName,
                      string phone, string city, double balance)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            City = city;
            Balance = balance;
        }

        // Convierte la persona a línea de texto para guardar en archivo
        public string ToFileLine()
        {
            return $"{Id},{FirstName},{LastName},{Phone},{City},{Balance}";
        }

        // Crea una persona desde una línea de texto del archivo
        public static Person FromFileLine(string line)
        {
            string[] parts = line.Split(',');
            return new Person(
                int.Parse(parts[0]),
                parts[1],
                parts[2],
                parts[3],
                parts[4],
                double.Parse(parts[5])
            );
        }

        // Para mostrar en pantalla (como en el taller)
        public override string ToString()
        {
            return $"\n{Id,-5} {FirstName} {LastName}\n" +
                   $"      Phone: {Phone}\n" +
                   $"      City:  {City}\n" +
                   $"      Balance:       ${Balance:N2}\n";
        }
    }
}