import { Data } from '@angular/router';
import { Auditable } from '../Common/auditable';

export class profAddressInfo extends Auditable {
    public  AddressInfoId: number;
    public profileId: number;
    //public virtual ProfBasicInfo ProfBasicInfo { get; set; }

    //public int ? AddressTypeId { get; set; }
    //public virtual AddressType AddressType { get; set; }
    public addressTypeId: number;

    public RoadName: string;

    public RoadNo: string;

    public FloorNo: string;

    public AppartmentNo: string;

    public PostalCode: string;

    public CityName: string;

    public Province: string;

    public State: string;

    public StartDate: Date;

    public EndDate: Date;

    public Status: string; 

        
}


