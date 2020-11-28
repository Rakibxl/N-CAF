import { TestBed } from '@angular/core/testing';

import { LegalInfoService } from './legal-info.service';

describe('LegalInfoService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: LegalInfoService = TestBed.get(LegalInfoService);
    expect(service).toBeTruthy();
  });
});
