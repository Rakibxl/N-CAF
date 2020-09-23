import { TestBed } from '@angular/core/testing';

import { PDFModifyService } from './pdfmodify.service';

describe('PDFModifyService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: PDFModifyService = TestBed.get(PDFModifyService);
    expect(service).toBeTruthy();
  });
});
