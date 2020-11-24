import { TestBed } from '@angular/core/testing';

import { MovementInfoService } from './movement-info.service';

describe('MovementInfoService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: MovementInfoService = TestBed.get(MovementInfoService);
    expect(service).toBeTruthy();
  });
});
