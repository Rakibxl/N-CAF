import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { QuestionInformationComponent } from './question-information.component';

describe('QuestionInformationComponent', () => {
  let component: QuestionInformationComponent;
  let fixture: ComponentFixture<QuestionInformationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ QuestionInformationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(QuestionInformationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
