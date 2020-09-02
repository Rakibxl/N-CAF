
export class Dashboard {
    serviceRequestCurrentDay: number;
    serviceRequestCurrentWeek: number;
    serviceRequestCurrentMonth: number;
    newAppUserRegisterCurrentMonth: number;
    serviceRequestCharts: any[];
    newAppUserRegisterCharts: any[];
    topAppUsers: any[];

    constructor() {
        this.serviceRequestCurrentDay = 0;
        this.serviceRequestCurrentWeek = 0;
        this.serviceRequestCurrentMonth = 0;
        this.newAppUserRegisterCurrentMonth = 0;
        this.serviceRequestCharts = [];
        this.newAppUserRegisterCharts = [];
        this.topAppUsers = [];
    }
}
