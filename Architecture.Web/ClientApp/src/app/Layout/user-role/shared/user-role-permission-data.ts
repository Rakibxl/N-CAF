import { RolePermissions } from 'src/app/Shared/Constants/user-role-permission';


export interface ISaveRolePermission {
    id: number;
    title: string;
    parentId: number;
    isSelected: boolean;
    name: string;
    _children: ISaveRolePermission[];
}

export class RolePermissionsData {
    parentId = 1;
    childId = 100;
    items: ISaveRolePermission[] = [
        // Branch...
        {
            id: this.parentId, title: 'Branches', parentId: undefined,
            isSelected: false, name: undefined, _children: [
                {
                    id: this.childId++, title: 'List View', parentId: this.parentId,
                    isSelected: false, name: RolePermissions.Branches.ListView, _children: undefined
                },
                // {
                //     id: this.childId++, title: 'Details View', parentId: this.parentId,
                //     isSelected: false, name: RolePermissions.Branches.DetailsView, _children: undefined
                // },
                {
                    id: this.childId++, title: 'Create', parentId: this.parentId,
                    isSelected: false, name: RolePermissions.Branches.Create, _children: undefined
                },
                {
                    id: this.childId++, title: 'Edit', parentId: this.parentId,
                    isSelected: false, name: RolePermissions.Branches.Edit, _children: undefined
                },
                {
                    id: this.childId++, title: 'Delete', parentId: this.parentId,
                    isSelected: false, name: RolePermissions.Branches.Delete, _children: undefined
                }
            ]
        },
        // User...
        {
            id: ++this.parentId, title: 'Users', parentId: undefined,
            isSelected: false, name: undefined, _children: [
                {
                    id: this.childId++, title: 'List View', parentId: this.parentId,
                    isSelected: false, name: RolePermissions.Users.ListView, _children: undefined
                },
                // {
                //     id: this.childId++, title: 'Details View', parentId: this.parentId,
                //     isSelected: false, name: RolePermissions.Users.DetailsView, _children: undefined
                // },
                {
                    id: this.childId++, title: 'Create', parentId: this.parentId,
                    isSelected: false, name: RolePermissions.Users.Create, _children: undefined
                },
                {
                    id: this.childId++, title: 'Edit', parentId: this.parentId,
                    isSelected: false, name: RolePermissions.Users.Edit, _children: undefined
                },
                {
                    id: this.childId++, title: 'Delete', parentId: this.parentId,
                    isSelected: false, name: RolePermissions.Users.Delete, _children: undefined
                }
            ]
        },
        // User Role...
        {
            id: (++this.parentId), title: 'User Roles', parentId: undefined,
            isSelected: false, name: undefined, _children: [
                {
                    id: this.childId++, title: 'List View', parentId: this.parentId,
                    isSelected: false, name: RolePermissions.UserRoles.ListView, _children: undefined
                },
                // {
                //     id: this.childId++, title: 'Details View', parentId: this.parentId,
                //     isSelected: false, name: RolePermissions.UserRoles.DetailsView, _children: undefined
                // },
                {
                    id: this.childId++, title: 'Create', parentId: this.parentId,
                    isSelected: false, name: RolePermissions.UserRoles.Create, _children: undefined
                },
                {
                    id: this.childId++, title: 'Edit', parentId: this.parentId,
                    isSelected: false, name: RolePermissions.UserRoles.Edit, _children: undefined
                },
                {
                    id: this.childId++, title: 'Delete', parentId: this.parentId,
                    isSelected: false, name: RolePermissions.UserRoles.Delete, _children: undefined
                }
            ]
        },
        // User Role Mapping...
        {
            id: (++this.parentId), title: 'User Role Mapping', parentId: undefined,
            isSelected: false, name: undefined, _children: [
                {
                    id: this.childId++, title: 'List View', parentId: this.parentId,
                    isSelected: false, name: RolePermissions.UserRoleMapping.ListView, _children: undefined
                },
                // {
                //     id: this.childId++, title: 'Details View', parentId: this.parentId,
                //     isSelected: false, name: RolePermissions.UserRoleMapping.DetailsView, _children: undefined
                // },
                {
                    id: this.childId++, title: 'Create', parentId: this.parentId,
                    isSelected: false, name: RolePermissions.UserRoleMapping.Create, _children: undefined
                },
                {
                    id: this.childId++, title: 'Edit', parentId: this.parentId,
                    isSelected: false, name: RolePermissions.UserRoleMapping.Edit, _children: undefined
                },
                {
                    id: this.childId++, title: 'Delete', parentId: this.parentId,
                    isSelected: false, name: RolePermissions.UserRoleMapping.Delete, _children: undefined
                }
            ]
        }
    ];
}



