import { Data } from '@angular/router';
import { Auditable } from '../Common/auditable';

export class profHouseRentInfo extends Auditable {
    public HouseRentInfoId: number;
    public profileId: number;
    //public virtual ProfBasicInfo ProfBasicInfo { get; set; }

    public ContractDate: Date;

    //   public int ? ContractTypeId { get; set; }
    //    public virtual ContractType ContractType { get; set; }

    //    public int ? HouseTypeId { get; set; }
    //    public virtual HouseType HouseType { get; set; } 
  
    public StartDate: Date;

    public EndDate: Date;

    public MonthlyRentAmount: number;

    public ServiceChargeAmount: number;

    public RegistrationInfo: string;

    public RegistrationDate: Date;

    public RegistrationOffice: string;

    public RegistrationCode: string;

    public RegistrationNo: string;

    public RegistrationCity: string;

    public IsJoined: boolean

    public SharePercent: number;

    public FoglioNo: string;

    public PartiocellaNo: string;

    public SubNo: string;

    public SectionNo: string;

   //    public int ? HouseCategoryId { get; set; }
   //    public virtual HouseCategory HouseCategory { get; set; }

    public Zona: string;

    public MicroZona: string;

    public Consistenza: string;

    public SuperficieCatastale: string;

    public Rendita: string;

    public NotaioInfo: string;

    public HasLoan: boolean
    
        //    public int LoanStatusTypeID { get; set; }
    //    public virtual LoanStatusType LoanStatusType { get; set; }
    
    public LoanStartDate: Date

    public LoanAmount: number

    public PaidAmount: number

    //    public int LoanInterestTypeId { get; set; }

    //    public virtual LoanInterestType LoanInterestType { get; set; }
    
    public LoanPeriod: number

    public IsRentByOwner: boolean

    public RentAmount: boolean
    
    












}


