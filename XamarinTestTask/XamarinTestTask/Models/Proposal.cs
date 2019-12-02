using System;
using System.Collections.Generic;
using XamarinTestTask.Enums;

namespace XamarinTestTask.Models
{
    public class Proposal
    {
        public Proposal()
        {
            var random = new Random();
            Status = (ProposalStatus)random.Next(0, 3);
            Rate = random.Next(10, 40);
            Rating = random.Next(1, 5);
            RatingCount = random.Next(5, 20);
            NoShowsCount = random.Next(0, 5);
            Age = random.Next(25, 50);
            YearsOfExperience = random.Next(5, 15);

            for (int i = 0; i < random.Next(1, 7); i++)
            {
                var date = new DateTime(DateTime.Today.Year, DateTime.Today.Month, random.Next(1, 30));
                JobDates.Add(date);
            }
        }

        public ProposalStatus Status { get; set; }

        public string ProposalType { get; set; } = "Application";
        public string JobTitle { get; set; } = "Certified dental assistant";
        public int Rate { get; set; }
        public string JobAddress { get; set; } = "445 Danforth Ave, Toronto, ON M4K 1P2";
        public string WorkerTitle { get; set; } = "Certified dental assistant";
        public int Rating { get; set; }
        public int RatingCount { get; set; }
        public int NoShowsCount { get; set; }
        public int Age { get; set; }
        public int YearsOfExperience { get; set; }

        public List<DateTime> JobDates { get; set; } = new List<DateTime>();
    }
}
