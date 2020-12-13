import { Data } from '@angular/router';
import { Auditable } from '../Common/auditable';

export class QuestionInfo extends Auditable {
    public QuestionInfoId: number;

    public profileId: number;
    
    public questionDescription: string;

    public pageToUrl: string;
   
    public sectionName: string;

    public sectionNameId: number;

    public status: any;
    
}


