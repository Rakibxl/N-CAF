import { Data } from '@angular/router';
import { Auditable } from '../Common/auditable';

export class SectionLink extends Auditable {
    public SectionLinkId: number;    
    public title: string;
    public actionLink: string;   
    public sectionName: string;
    public sectionNameId: number;
    public remarks: any;    
}


