import { Auditable } from '../Common/auditable';
import { Entity } from '../Common/entity';
import { QueryObject } from '../Common/query-object';

export class User extends Auditable {
    fullName: string;
    // userName: string;
    email: string;
    phoneNumber: string;
    gender: string;
    address: string;
    dateOfBirth?: Date;
    userRoleName: string;
    userRoleId: string;
    // imageUrl: string;

    // only for display
    userRoleDisplayName: string;
    userViewDetailBtn: string;
    
    constructor(init?: Partial<User>) {
        super();
        Object.assign(this, init);
    }

    clear() {
        super.clear();
        this.fullName = '';
        // this.userName = '';
        this.email = '';
        this.phoneNumber = '';
        this.gender = '';
        this.address = '';
        this.dateOfBirth = null;
        this.userRoleName = '';
        this.userRoleId = '';
        // this.imageUrl = '';
    }
}

export class SaveUser extends Entity {
    fullName: string;
    // userName: string;
    email: string;
    phoneNumber: string;
    gender: string;
    address: string;
    dateOfBirth?: Date;
    userRoleId: string;
    // imageUrl: string;
    // imageFile: File;
    
    constructor(init?: Partial<SaveUser>) {
        super();
        Object.assign(this, init);
    }

    clear() {
        super.clear();
        this.fullName = '';
        // this.userName = '';
        this.email = '';
        this.phoneNumber = '';
        this.gender = '';
        this.address = '';
        this.dateOfBirth = null;
        this.userRoleId = '';
        // this.imageUrl = '';
        // this.imageFile = null;
    }
}

export class UserQuery extends QueryObject {
    fullName: string;
    userName: string;
    email: string;
    phoneNumber: string;
    
    constructor(init?: Partial<UserQuery>) {
        super();
        Object.assign(this, init);
    }

    clear() {
        this.fullName = '';
        this.userName = '';
        this.email = '';
        this.phoneNumber = '';
    }
}