import { Entity } from './entity';

export class Auditable extends Entity {
    created: Date;
    modified: Date;
    createdBy: string;
    modifiedBy: string;

    clear() {
        super.clear();
        this.created = null;
        this.modified = null;
        this.createdBy = '';
        this.modifiedBy = '';
    }
}
