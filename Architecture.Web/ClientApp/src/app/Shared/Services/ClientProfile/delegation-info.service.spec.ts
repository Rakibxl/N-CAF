import { TestBed } from '@angular/core/testing';

import { DelegationInfoService } from './delegation-info.service';

describe('DelegationInfoService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: DelegationInfoService = TestBed.get(DelegationInfoService);
    expect(service).toBeTruthy();
  });
});
