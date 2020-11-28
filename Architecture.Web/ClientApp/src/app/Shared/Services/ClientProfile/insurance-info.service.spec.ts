import { TestBed } from '@angular/core/testing';

import { InsuranceInfoService } from './insurance-info.service';

describe('InsuranceInfoService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: InsuranceInfoService = TestBed.get(InsuranceInfoService);
    expect(service).toBeTruthy();
  });
});
