import { Data } from '@angular/router';
import { Auditable } from '../Common/auditable';

export class profHouseRentInfo extends Auditable {
    public HouseRentInfoId: number;
    public profileId: number;
    //public virtual ProfBasicInfo ProfBasicInfo { get; set; }

    public contractDate: Date;

    //   public int ? ContractTypeId { get; set; }
    //    public virtual ContractType ContractType { get; set; }

    //    public int ? HouseTypeId { get; set; }
    //    public virtual HouseType HouseType { get; set; }

    public contractType: string;

    public contractTypeId: number;

    public houseType: string;

    public houseTypeId: number;
  
    public startDate: Date;

    public endDate: Date;

    public monthlyRentAmount: number=0;

    public serviceChargeAmount: number=0;

    public registrationInfo: string;

    public registrationDate: Date;

    public registrationOffice: string;

    public registrationCode: string;

    public registrationNo: string;

    public registrationCity: string;

    public isJoined: boolean

    public sharePercent: number=0;

    public foglioNo: string;

    public partiocellaNo: string;

    public subNo: string;

    public sectionNo: string;

    public houseCategoryId: boolean


   //    public int ? HouseCategoryId { get; set; }
   //    public virtual HouseCategory HouseCategory { get; set; }

    public zona: string;

    public microZona: string;

    public consistenza: string;

    public superficieCatastale: string;

    public rendita: string;

    public notaioInfo: string;

    public hasLoan: boolean

    public loanStatusTypeId: number

        //    public int LoanStatusTypeID { get; set; }
    //    public virtual LoanStatusType LoanStatusType { get; set; }
    
    public loanStartDate: Date

    public loanAmount: number = 0;

    public paidAmount: number = 0;

    public loanInterestTypeId: number

    //    public int LoanInterestTypeId { get; set; }

    //    public virtual LoanInterestType LoanInterestType { get; set; }
    
    public loanPeriod: number = 0;

    public isRentByOwner: boolean

    public rentAmount: number = 0;
    
    












}


