import { TestBed } from '@angular/core/testing';

import { QuestionInfoService } from './question-info.service';

describe('QuestionInfoService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
      const service: QuestionInfoService = TestBed.get(QuestionInfoService);
    expect(service).toBeTruthy();
  });
});
