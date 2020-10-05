import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DeligationInformationFormComponent } from './deligation-information-form.component';

describe('DeligationInformationFormComponent', () => {
  let component: DeligationInformationFormComponent;
  let fixture: ComponentFixture<DeligationInformationFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DeligationInformationFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DeligationInformationFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
