import { Entity } from './entity';
import { RecordStatus } from "./record-status";

export class Auditable extends Entity {
    created: Date = new Date();
    modified: Date = new Date();
    createdBy: string = '';
    modifiedBy: string = '';
    recordStatusId: number = 1;
    recordStatus: RecordStatus;

    //clear() {
    //    super.clear();
    //    this.created = null;
    //    this.modified = null;
    //    this.createdBy = '';
    //    this.modifiedBy = '';
    //}
}
