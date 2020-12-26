import { TestBed } from '@angular/core/testing';

import { JobInfoService } from './job-info.service';

describe('JobInfoService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
      const service: JobInfoService = TestBed.get(JobInfoService);
    expect(service).toBeTruthy();
  });
});
