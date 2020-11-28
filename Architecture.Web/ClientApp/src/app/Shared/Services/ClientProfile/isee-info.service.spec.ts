import { TestBed } from '@angular/core/testing';

import { ISEEInfoService } from './isee-info.service';

describe('ISEEInfoService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ISEEInfoService = TestBed.get(ISEEInfoService);
    expect(service).toBeTruthy();
  });
});
