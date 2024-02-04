using System;

namespace lab99
{
    public class Discipline
    {
        private string name;
        private int contactHours;
        private int selfHours;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int ContactHours
        {
            get { return contactHours; }
            set { contactHours = value; }
        }

        public int SelfHours
        {
            get { return selfHours; }
            set { selfHours = value; }
        }

        public Discipline()
        {
            name = "Default Discipline";
            contactHours = 0;
            selfHours = 0;
        }

        public double PercentageSelfStudy()
        {
            double totalHours = contactHours + selfHours;
            return (selfHours / totalHours) * 100.0;
        }
        public Discipline(string name, int contactHours, int selfHours)
        {
            this.name = name;
            this.contactHours = contactHours;
            this.selfHours = selfHours;
        }

        public Discipline(Discipline otherDiscipline)
        {
            this.name = otherDiscipline.name;
            this.contactHours = otherDiscipline.contactHours;
            this.selfHours = otherDiscipline.selfHours;
        }
        public override bool Equals(object obj)
        {
            bool equals = true;

            if (obj is Discipline)
            {
                Discipline other = (Discipline)obj;

                equals &= (this.Name == other.Name) && (this.Name == other.Name);
                equals &= (this.ContactHours == other.ContactHours) && (this.ContactHours == other.ContactHours);
                equals &= (this.SelfHours == other.SelfHours) && (this.SelfHours == other.SelfHours);
            }

            return equals;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Discipline: {name}, Contact Hours: {contactHours}, Self Hours: {selfHours}");
        }

        public int CalculateCreditUnits()
        {
            int totalHours = contactHours + selfHours;
            int creditUnits = totalHours / 38;
            return creditUnits;
        }
        public static Discipline operator ++(Discipline discipline)
        {
            discipline.ContactHours += 2;
            discipline.SelfHours -= 2;

            if (discipline.SelfHours < 0)
            {
                discipline.SelfHours = 0;
            }

            return discipline;
        }

        public static explicit operator double(Discipline discipline)
        {
            double totalHours = discipline.contactHours + discipline.selfHours;
            return discipline.contactHours / totalHours;
        }

        public static implicit operator int(Discipline discipline)
        {
            return discipline.contactHours / 2;
        }

        public static Discipline operator +(Discipline discipline1, Discipline discipline2)
        {
            Discipline result = new Discipline(discipline1);
            result.Name = $"{discipline1.Name} + {discipline2.Name}";
            result.ContactHours = discipline1.ContactHours + discipline2.ContactHours;
            result.SelfHours = discipline1.SelfHours + discipline2.SelfHours;
            return result;
        }

        public static bool operator ==(Discipline discipline1, Discipline discipline2)
        {
            if (object.ReferenceEquals(discipline1, discipline2))
                return true;

            if (object.ReferenceEquals(discipline1, null) || object.ReferenceEquals(discipline2, null))
                return false;

            return discipline1.Name.Equals(discipline2.Name, StringComparison.Ordinal) &&
                   discipline1.ContactHours == discipline2.ContactHours &&
                   discipline1.SelfHours == discipline2.SelfHours;
        }

        public static bool operator !=(Discipline discipline1, Discipline discipline2)
        {
            return !(discipline1 == discipline2);
        }

        public override int GetHashCode()
        {
            return Tuple.Create(Name, ContactHours, SelfHours).GetHashCode();
        }
    }
}
