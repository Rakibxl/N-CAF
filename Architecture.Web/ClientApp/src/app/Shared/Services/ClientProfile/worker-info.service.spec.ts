import { TestBed } from '@angular/core/testing';

import { WorkerInfoService } from './worker-info.service';

describe('WorkerInfoService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: WorkerInfoService = TestBed.get(WorkerInfoService);
    expect(service).toBeTruthy();
  });
});
