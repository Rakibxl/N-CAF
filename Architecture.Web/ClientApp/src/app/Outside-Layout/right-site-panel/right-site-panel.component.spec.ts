import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RightSitePanelComponent } from './right-site-panel.component';

describe('RightSitePanelComponent', () => {
  let component: RightSitePanelComponent;
  let fixture: ComponentFixture<RightSitePanelComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RightSitePanelComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RightSitePanelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
