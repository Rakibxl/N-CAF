import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MovementInformationFormComponent } from './movement-information-form.component';

describe('MovementInformationFormComponent', () => {
  let component: MovementInformationFormComponent;
  let fixture: ComponentFixture<MovementInformationFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MovementInformationFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MovementInformationFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
