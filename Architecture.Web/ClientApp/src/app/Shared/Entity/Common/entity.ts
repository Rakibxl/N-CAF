
export class Entity {
    id: any;
    isDeleted: boolean = false;
    isActive: boolean = false;

    clear() {
        // this.id = '';
        this.isActive = false;
        this.isDeleted = false;
    }
}
