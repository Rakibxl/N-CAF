export interface IAuthUser {
    id: string;
    fullName: string;
    userName: string;
    email: string;
    phoneNumber: string;
    imageUrl: string;
    token?: string;
}

export class Login {
    email: string;
    password: string;
    rememberMe: boolean;
    
    constructor(init?: Partial<Login>) {
        Object.assign(this, init);
    }

    clear() {
        this.email = '';
        this.password = '';
        this.rememberMe = false;
    }
}

export class ResetPassword {
    userId: string;
    newPassword: string;
    token: string;
    
    constructor(init?: Partial<ResetPassword>) {
        Object.assign(this, init);
    }

    clear() {
        this.userId = '';
        this.newPassword = '';
        this.token = '';
    }
}