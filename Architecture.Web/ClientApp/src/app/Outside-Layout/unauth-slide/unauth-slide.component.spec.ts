import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UnauthSlideComponent } from './unauth-slide.component';

describe('UnauthSlideComponent', () => {
  let component: UnauthSlideComponent;
  let fixture: ComponentFixture<UnauthSlideComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UnauthSlideComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UnauthSlideComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
