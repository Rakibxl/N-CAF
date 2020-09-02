import { Auditable } from '../Common/auditable';
import { Entity } from '../Common/entity';
import { QueryObject } from '../Common/query-object';

export class Example extends Auditable {
    sequence: string;
    description: string;
    name: string;
    imageUrl: string;

    // for display
    isActiveText: string;
    
    constructor(init?: Partial<Example>) {
        super();
        Object.assign(this, init);
    }

    clear() {
        super.clear();
        this.sequence = '';
        this.description = '';
        this.name = '';
        this.imageUrl = '';
        this.isActiveText = '';
    }
}

export class SaveExample extends Entity {
    sequence: string;
    name: string;
    description: string;
    imageFile: File;
    
    constructor(init?: Partial<SaveExample>) {
        super();
        Object.assign(this, init);
    }

    clear() {
        super.clear();
        this.sequence = '';
        this.name = '';
        this.description = '';
        this.imageFile = null;
    }
}

export class ExampleQuery extends QueryObject {
    name: string;
    
    constructor(init?: Partial<ExampleQuery>) {
        super();
        Object.assign(this, init);
    }

    clear() {
        this.name = '';
    }
}