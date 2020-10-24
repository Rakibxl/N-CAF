import { Data } from '@angular/router';
import { Auditable } from '../Common/auditable';

export class profISEEInfo extends Auditable {
    public  ISEEInfoId: number;
    public profileId: number;
    //public virtual ProfBasicInfo ProfBasicInfo { get; set; }

    //public int? ISEEClassTypeId { get; set; }
    //    public virtual ISEEClassType ISEEClassType { get; set; }
    public ISEEValue: number;

    public Point: number;

    public ISEEFamilyIncome: number;

    public ISPAmount: number;

    public ISEAmount: number;

    public ISRAmount: number;

    public IdentificationNumber: string;

    public SumittedDate: Date;

    public DeliveryDate: Date;

    public ExpiryDate: Date;
        
}


