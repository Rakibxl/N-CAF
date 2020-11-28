import { Data } from '@angular/router';
import { Auditable } from '../Common/auditable';

export class profWorkerInfo extends Auditable {
    public WorkerInfoId: number;
    public profileId: number;
    //public virtual ProfBasicInfo ProfBasicInfo { get; set; }

    //    public int ? WorkerTypeId { get; set; }
    //    public virtual WorkerType WorkerType { get; set; }

    public workerTypeId: number;

    public name: string;

    public surName: string;

    public taxCode: string;

    public contractNumber: string;

    public monthlySalary: number;
   
    public startDate: Date;

    public endDate: Date;

    public status: string; 
        
}


