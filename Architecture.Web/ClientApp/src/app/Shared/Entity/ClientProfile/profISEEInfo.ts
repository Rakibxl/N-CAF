import { Data } from '@angular/router';
import { Auditable } from '../Common/auditable';

export class profISEEInfo extends Auditable {
    public  ISEEInfoId: number;
    public profileId: number;
    //public virtual ProfBasicInfo ProfBasicInfo { get; set; }

    //public int? ISEEClassTypeId { get; set; }
    //    public virtual ISEEClassType ISEEClassType { get; set; }

    public iseeClassTypeName: string

    public iseeClassTypeId: number;

    public iseeValue: number;

    public point: number;

    public iseeFamilyIncome: number;

    public ispAmount: number;

    public iseAmount: number;

    public isrAmount: number;

    public identificationNumber: string;

    public submittedDate: Date;

    public deliveryDate: Date;

    public expiryDate: Date;
        
}


