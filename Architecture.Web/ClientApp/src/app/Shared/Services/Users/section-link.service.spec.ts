import { TestBed } from '@angular/core/testing';

import { SectionLinkService } from './section-link.service';

describe('SectionLinkService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
      const service: SectionLinkService = TestBed.get(SectionLinkService);
    expect(service).toBeTruthy();
  });
});
