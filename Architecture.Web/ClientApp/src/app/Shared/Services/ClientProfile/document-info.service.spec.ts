import { TestBed } from '@angular/core/testing';

import { DocumentInfoService } from './document-info.service';

describe('DocumentInfoService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: DocumentInfoService = TestBed.get(DocumentInfoService);
    expect(service).toBeTruthy();
  });
});
