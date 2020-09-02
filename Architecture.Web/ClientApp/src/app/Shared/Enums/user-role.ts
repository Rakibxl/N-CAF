import { MapObject } from './map-object';

export enum EnumUserRole {
    general = "GeneralUser",
    app = "AppUser",
    superAdmin = "SuperAdmin",
    admin = "Admin"
}

export class EnumUserRoleDisplayName {
    public static EnumUserRoleTypeDisplayName: MapObject[] = [
        { id: "GeneralUser", label: "General User" },
        { id: "AppUser", label: "App User" },
        { id: "SuperAdmin", label: "Super Admin" },
        { id: "Admin", label: "Admin" },
    ];

    constructor() {
    }
}