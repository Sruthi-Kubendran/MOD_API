using System;
using System.Collections.Generic;
using System.Text;

namespace MOD.ModelLibrary
{
    public class TrainingDtls
    {
        public int id { get; set; }
        public string status { get; set; }
        public int progress { get; set; }
        public double commisionAmount { get; set; }
        public int rating { get; set; }
        public double avaRating { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string timeSlot { get; set; }
        public double amountReceived { get; set; }
        public string userId { get; set; }
        public string userFirstName { get; set; }
        public string userLastName { get; set; }

        public string mentorId { get; set; }
        public string mentorFirstName { get; set; }
        public string mentorLastName { get; set; }

        public int skillId { get; set; }
        public string skillname { get; set; }
        public bool accept { get; set; }
        public bool rejectNotify { get; set; }
        public bool trainingPaymentStatus { get; set; }

    }
}
