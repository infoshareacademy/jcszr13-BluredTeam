using PP0.Enums;
using PP0.Models;
using System;

namespace PP0.StaticClasses
{
    public static class VisitUtilities
    {
        internal static (bool stayInMainMenu, Visit visit) CreateNewVisit()
        {
            Console.Clear();
            Console.WriteLine("Please provide Visit data:");

            Console.WriteLine("Please provide Doctor Name");
            string doctorsName = Console.ReadLine();

            Console.WriteLine("Please provide Patient Name");
            string patientName = Console.ReadLine();

            Console.WriteLine("Please provide Visit date");
            string visitDateAsString = Console.ReadLine();
            DateTime visitDate;
            DateTime.TryParse(visitDateAsString, out visitDate);

            Console.WriteLine("Please provide Visit type(Stationary = 0, Telephone = 1, Chat = 2)");
            string visitTypeAsString = Console.ReadLine();
            VisitType visitType;
            VisitType.TryParse(visitTypeAsString, out visitType);

            Console.WriteLine("Please provide Visit Description");
            string description = Console.ReadLine();

            Console.WriteLine("Please provide Visit Recomendations");
            string recomendations = Console.ReadLine();

            Console.WriteLine("Please provide Visit Referrals");
            string referrals = Console.ReadLine();

            Console.WriteLine("Please provide Visit Prescriptions");
            string prescriptions = Console.ReadLine();

            var newVisit = new Visit(visitDate, visitType, doctorsName, patientName, description, recomendations, referrals, prescriptions);

            return new (true, newVisit);
        }
    }
}
