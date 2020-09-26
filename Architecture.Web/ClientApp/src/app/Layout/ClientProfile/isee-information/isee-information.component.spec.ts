import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { IseeInformationComponent } from './isee-information.component';

describe('IseeInformationComponent', () => {
  let component: IseeInformationComponent;
  let fixture: ComponentFixture<IseeInformationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ IseeInformationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(IseeInformationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
