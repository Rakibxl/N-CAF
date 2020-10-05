import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DocumentInformationFormComponent } from './document-information-form.component';

describe('DocumentInformationFormComponent', () => {
  let component: DocumentInformationFormComponent;
  let fixture: ComponentFixture<DocumentInformationFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DocumentInformationFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DocumentInformationFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
