import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SectionToSectionLinkComponent } from './section-to-section-link.component';

describe('SectionToSectionLinkComponent', () => {
  let component: SectionToSectionLinkComponent;
  let fixture: ComponentFixture<SectionToSectionLinkComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SectionToSectionLinkComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SectionToSectionLinkComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
