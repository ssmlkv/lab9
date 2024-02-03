using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lab9
{
    internal class Discipline
    {
        public string name;
        public int contactHours;
        public int selfHours;
        private static int count = 0;
        double Сredits = 0.0;

        public string Name { get; internal set; }
        public int Credits { get; internal set; }

        public Discipline(string name,int contatHours,int selfHours)
        {
            this.name += name;
            this.contactHours += contatHours;
            this.selfHours += selfHours;
            count++;
        }
        public Discipline(string v)
        {
            name = "Нет имени";
            contactHours = 0;
            selfHours = 0;
            count++;
        }
        public Discipline(Discipline otherDiscipline)
        {
            name=otherDiscipline.name;
            contactHours = otherDiscipline.contactHours;
            selfHours = otherDiscipline.selfHours;   
            count++;
        }

        public Discipline(string v, int v1) : this(v)
        {
        }

        public int calculateCredits()
        {
            int totalHours = contactHours + selfHours;
            return totalHours / 38;
        }
        public void show()
        {
            Console.WriteLine($"Название дисциплины: {name}, Часы аудиторной работы: {contactHours}, Часы самостоятельной работы: {selfHours}");
        }
        public static int GetObjectCount()
        {
            return count;
        }
        public static double operator !(Discipline discipline)
        {
            if (discipline.contactHours + discipline.selfHours == 0)
            {
                return 0;
            }

            double percentage = (double)discipline.selfHours / (discipline.contactHours + discipline.selfHours) * 100;
            return Math.Round(percentage, 2);
        }
        public static Discipline operator ++(Discipline discipline)
        {
            discipline.contactHours += 2;
            discipline.selfHours = Math.Max(0, discipline.selfHours - 2);

            return discipline;
        }
        public static explicit operator double(Discipline discipline)
        {
            if (discipline.contactHours == 0)
            {
                return 0.0;
            }

            return (double)discipline.contactHours / (discipline.contactHours + discipline.selfHours);
        }
        public static implicit operator int(Discipline discipline)
        {
            return discipline.contactHours / 2;
        }
        public static bool operator >=(Discipline d1, Discipline d2)
        {
            return (d1.contactHours + d1.selfHours) >= (d2.contactHours + d2.selfHours);
        }
        public static bool operator <=(Discipline d1, Discipline d2)
        {
            return (d1.contactHours + d1.selfHours) <= (d2.contactHours + d2.selfHours);
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Discipline otherDiscipline = (Discipline)obj;
            return name == otherDiscipline.name && contactHours == otherDiscipline.contactHours && selfHours == otherDiscipline.selfHours;
        }
    }
}