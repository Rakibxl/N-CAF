import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SectionLinkFormComponent } from './section-link-form.component';

describe('SectionLinkFormComponent', () => {
  let component: SectionLinkFormComponent;
  let fixture: ComponentFixture<SectionLinkFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SectionLinkFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SectionLinkFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
