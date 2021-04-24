import { Auditable } from '../Common/auditable';
import { OfferInfo } from '../Users/OfferInfo';

export class NotificationInfo extends Auditable {
    public notificationInfoId: number;
    public messageContent: string;
    public parentMessageId: string;
    public isGlobal: boolean = false;
    public messageFor: string;
    public isSeen: boolean=false;
    public seenTime: Date;
    public offerInfoId: number;
    public type: string;
    public offerInfo: OfferInfo;
    public createdByName: string;
    public messageForName: string;
}

