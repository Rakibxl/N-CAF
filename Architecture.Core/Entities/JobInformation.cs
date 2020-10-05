using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Architecture.Core.Entities
{
    public class JobInformation
    {
        [Key]
        public int JobId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsCommon { get; set; }
        public int JobDeliveryTypeId { get; set; }
        public Decimal OperatorTimeFram { get; set; }
        public bool IsHighlighted { get; set; }
        public string VideoLink { get; set; }
        public string DocumentLink { get; set; }

        #region Job Access Permission 
        public int ChildAgeMin { get; set; }
        public int ChildAgeMax { get; set; }
        public int ISEEMin { get; set; }
        public int ISEEMax { get; set; }
        public int DefinedISEEClaaId { get; set; }
        public bool IsPegnent { get; set; }
        public int OccupationTypeId { get; set; }
        public int NumberOfChild { get; set; }
        public int DaysToExpairJobContract { get; set; }
        public int DaysToBeExpairedRacidencePermit { get; set; }
        public bool IsElegibleForUnlimitedResidencePermit { get; set; }
        public int DaysToBeExpairedNationalId { get; set; }
        public int DaysToBeExpairedPassport { get; set; }

        #endregion
    }
}
