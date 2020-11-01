import { Data } from '@angular/router';
import { Auditable } from '../Common/auditable';

export class profAssetInfo extends Auditable {
    public AssetInfoId: number;
    public profileId: number;
    //public virtual ProfBasicInfo ProfBasicInfo { get; set; }
    
    public  AssetTypeId : number
    //public virtual AssetType AssetType { get; set; }

    public NumberOfAsset: number

    public EquivalentMoneyMax: number

    public EquivalentMoneyMin: number

    public MoneyAverage: number

    public OwnerTypeId: number
    //public virtual OwnerType OwnerType { get; set; }

    public OwnershipPercentage: number

    public OwnerFromDate: Date

    public RentAmount: number
    public TaxAmount: number
    public UseAblePercentage: number

    public AnyRestrictionByGovt: string; 

    public CityName: string;
    
    public Note: string; 
        
}


