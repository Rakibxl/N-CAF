import { Data } from '@angular/router';
import { Auditable } from '../Common/auditable';

export class profDocumentInfo extends Auditable {
    public DocumentInfoId: number;
    public profileId: number;
    //public virtual ProfBasicInfo ProfBasicInfo { get; set; }

    //public int ? DocumentTypeId { get; set; }
    //public virtual DocumentType DocumentType { get; set; }

    public DocumentTypeName: string;
    public documentTypeId: number;
    public documentName: string;
    public documentNumber: string;
    public purposeOfDocument: string;
    public issuedBy: string

    public issuedDate: Date;

    public expiryDate: Date;

    public urls: [];

}


