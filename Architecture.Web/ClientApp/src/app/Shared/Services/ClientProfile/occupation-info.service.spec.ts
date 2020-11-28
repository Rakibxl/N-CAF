import { TestBed } from '@angular/core/testing';

import { OccupationInfoService } from './occupation-info.service';

describe('OccupationInfoService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: OccupationInfoService = TestBed.get(OccupationInfoService);
    expect(service).toBeTruthy();
  });
});
