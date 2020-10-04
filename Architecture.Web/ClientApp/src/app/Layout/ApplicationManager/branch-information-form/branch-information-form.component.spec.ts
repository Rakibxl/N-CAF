import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BranchInformationFormComponent } from './branch-information-form.component';

describe('BranchInformationFormComponent', () => {
  let component: BranchInformationFormComponent;
  let fixture: ComponentFixture<BranchInformationFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BranchInformationFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BranchInformationFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
