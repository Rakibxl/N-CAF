import { TestBed } from '@angular/core/testing';

import { IncomeInfoService } from './income-info.service';

describe('IncomeInfoService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: IncomeInfoService = TestBed.get(IncomeInfoService);
    expect(service).toBeTruthy();
  });
});
