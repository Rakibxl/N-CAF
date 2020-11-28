import { TestBed } from '@angular/core/testing';

import { HouseRentInfoService } from './houserent-info.service';

describe('HouseRentInfoService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: HouseRentInfoService = TestBed.get(HouseRentInfoService);
    expect(service).toBeTruthy();
  });
});
