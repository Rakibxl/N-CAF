import { Data } from '@angular/router';
import { Auditable } from '../Common/auditable';

export class profDocumentInfo extends Auditable {
    public DocumentInfoId: number;
    public profileId: number;
    //public virtual ProfBasicInfo ProfBasicInfo { get; set; }

    //public int ? DocumentTypeId { get; set; }
    //public virtual DocumentType DocumentType { get; set; }

    public PurposeofDocument: string;

    public IssuedBy: string

    public IssueDate: Date;

    public ExpiryDate: Date;

}


