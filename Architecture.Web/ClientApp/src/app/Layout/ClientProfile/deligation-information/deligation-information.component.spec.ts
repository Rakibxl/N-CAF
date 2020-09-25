import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DeligationInformationComponent } from './deligation-information.component';

describe('DeligationInformationComponent', () => {
  let component: DeligationInformationComponent;
  let fixture: ComponentFixture<DeligationInformationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DeligationInformationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DeligationInformationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
