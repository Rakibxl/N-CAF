import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ChatBoxPopupComponent } from './chat-box-popup.component';

describe('ChatBoxPopupComponent', () => {
  let component: ChatBoxPopupComponent;
  let fixture: ComponentFixture<ChatBoxPopupComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ChatBoxPopupComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ChatBoxPopupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
