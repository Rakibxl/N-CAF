import { Data } from '@angular/router';
import { Auditable } from '../Common/auditable';

export class profAddressInfo extends Auditable {
    public  AddressInfoId: number;
    public profileId: number;
    //public virtual ProfBasicInfo ProfBasicInfo { get; set; }

    //public int ? AddressTypeId { get; set; }
    //public virtual AddressType AddressType { get; set; }
    public addressType: string;

    public addressTypeId: number;

    public roadName: string;

    public roadNo: string;

    public buildingNo: string;

    public floorNo: string;

    public appartmentNo: string;

    public postalCode: string;

    public cityName: string;

    public province: string;

    public state: string;

    public startDate: Date;

    public endDate: Date;

    public active: string; 
        
}


