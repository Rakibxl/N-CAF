
export class Entity {
    id: any;
    isDeleted: boolean;
    isActive: boolean;

    clear() {
        // this.id = '';
        this.isActive = false;
        this.isDeleted = false;
    }
}
