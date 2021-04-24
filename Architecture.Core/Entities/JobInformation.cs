using Architecture.Core.Entities.Core;
using Architecture.Core.Entities.LU;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Architecture.Core.Entities
{
    public class JobInfo:Auditable
    {
        [Key]
        public int JobInfoId { get; set; }
        //public int JobId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsCommon { get; set; }
        public int JobDeliveryTypeId { get; set; }
        public virtual JobDeliveryType JobDeliveryType { get; set; }
        public Decimal OperatorTimeFrame { get; set; }
        public bool IsHighlighted { get; set; }
        public string VideoLink { get; set; }
        public string DocumentLink { get; set; }

        #region Job Access Permission 
        public int? ChildAgeMin { get; set; }
        public int? ChildAgeMax { get; set; }
        public int? ISEEMin { get; set; }
        public int? ISEEMax { get; set; }
        public int? ISEEClassTypeId { get; set; }
        public virtual ISEEClassType ISEEClassType { get; set; }
        public bool IsPregnant { get; set; }
        public int? OccupationTypeId { get; set; }
        public virtual OccupationType OccupationType { get; set; }
        public int? NumberOfChild { get; set; }
        public int? DaysToExpairJobContract { get; set; }
        public int? DaysToBeExpairedResidencePermit { get; set; }
        public bool IsEligibleForUnlimitedResidencePermit { get; set; }
        public int? DaysToBeExpairedNationalId { get; set; }
        public int? DaysToBeExpairedPassport { get; set; }      
        public bool IsEligibleForCityzenShipApply { get; set; }
        public bool HasUnlimitedResidencePermit { get; set; }

        #endregion

        public virtual ICollection<JobSectionLink> JobSectionLink { get; set; }
        #region accounts
        public decimal ClientRequiredAmount { get; set; }
        public decimal OperatorRequiredAmount { get; set; }
        public decimal BranchRequiredAmount { get; set; }
        #endregion accounts
    }
}


