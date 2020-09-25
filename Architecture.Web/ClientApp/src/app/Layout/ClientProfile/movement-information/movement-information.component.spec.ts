import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MovementInformationComponent } from './movement-information.component';

describe('MovementInformationComponent', () => {
  let component: MovementInformationComponent;
  let fixture: ComponentFixture<MovementInformationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MovementInformationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MovementInformationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
