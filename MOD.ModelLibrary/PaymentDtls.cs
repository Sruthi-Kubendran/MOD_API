using System;
using System.Collections.Generic;
using System.Text;

namespace MOD.ModelLibrary
{

    public class PaymentDtls
    {
        public int id { get; set; }
        public string userId { get; set; }
        public string trainerId { get; set; }
        public int skillId { get; set; }
        public double fees { get; set; }
        public double trainerFees { get; set; }
        public double commision { get; set; }
        public string skillName { get; set; }
        public bool paymentStatus { get; set; }
        public int trainingDetailsId { get; set; }
    }
}
