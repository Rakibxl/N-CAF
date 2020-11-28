import { Data } from '@angular/router';
import { Auditable } from '../Common/auditable';

export class profIncomeInfo extends Auditable {
    public  IncomeInfoId: number;
    public profileId: number;
    //public virtual ProfBasicInfo ProfBasicInfo { get; set; }

        //public int? IncomeTypeId { get; set; }
        //public virtual IncomeType IncomeType { get; set; }

    public incomeTypeId: number;

    public yearlyIncome: number;

    public monthlyIncome: number;

    public year: Date;

    public month: Date;

    public document: String;

    public status: String;
        
}


