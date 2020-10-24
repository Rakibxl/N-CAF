import { Data } from '@angular/router';
import { Auditable } from '../Common/auditable';

export class profWorkerInfo extends Auditable {
    public WorkerInfoId: number;
    public profileId: number;
    //public virtual ProfBasicInfo ProfBasicInfo { get; set; }

    //    public int ? WorkerTypeId { get; set; }
    //    public virtual WorkerType WorkerType { get; set; }

    public Name: string;

    public SurName: string;

    public TaxCode: string;

    public ContractNumber: string;

    public MonthlySalary: number;
   
    public StartDate: Date;

    public EndDate: Date;

    public Status: string; 
        
}


