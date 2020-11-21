import { TestBed } from '@angular/core/testing';

import { EducationInfoService } from './education-info.service';

describe('EducationInfoService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: EducationInfoService = TestBed.get(EducationInfoService);
    expect(service).toBeTruthy();
  });
});
