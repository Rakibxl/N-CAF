import { Data } from '@angular/router';
import { Auditable } from '../Common/auditable';

export class profIncomeInfo extends Auditable {
    public  IncomeInfoId: number;
    public profileId: number;
    //public virtual ProfBasicInfo ProfBasicInfo { get; set; }

        //public int? IncomeTypeId { get; set; }
        //public virtual IncomeType IncomeType { get; set; }

    public YearlyIncome: number;

    public MontlyIncome: number;

    public Year: Date;

    public Month: Date;

    public Document: String;

    public Status: String;
        
}


