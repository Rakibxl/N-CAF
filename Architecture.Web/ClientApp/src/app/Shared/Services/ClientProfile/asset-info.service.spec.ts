import { TestBed } from '@angular/core/testing';

import { AssetInfoService } from './asset-info.service';

describe('AssetInfoService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: AssetInfoService = TestBed.get(AssetInfoService);
    expect(service).toBeTruthy();
  });
});
