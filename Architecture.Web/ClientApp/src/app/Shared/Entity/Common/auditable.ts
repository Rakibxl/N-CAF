import { Entity } from './entity';

export class Auditable extends Entity {
    created: Date;
    lastModified: Date;
    createdBy: string;
    lastModifiedBy: string;

    clear() {
        super.clear();
        this.created = null;
        this.lastModified = null;
        this.createdBy = '';
        this.lastModifiedBy = '';
    }
}
