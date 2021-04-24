import { Data } from '@angular/router';
import { Auditable } from '../Common/auditable';

export class profAssetInfo extends Auditable {
    public AssetInfoId: number;
    public profileId: number;
    //public virtual ProfBasicInfo ProfBasicInfo { get; set; }
    
    public  assetTypeId : number
    //public virtual AssetType AssetType { get; set; }
    public assetTypeName: string

    public numberOfAsset: number

    public equivalentMoneyMax: number

    public equivalentMoneyMin: number

    public moneyAverage: number

    public ownerTypeName: string

    public ownerTypeId: number
    //public virtual OwnerType OwnerType { get; set; }

    public ownershipPercentage: number

    public ownerFromDate: Date

    public rentAmount: number
    public taxAmount: number
    public useAblePercentage: number

    public anyRestrictionByGovt: string; 

    public cityName: string;
    
    public note: string; 
        
}


