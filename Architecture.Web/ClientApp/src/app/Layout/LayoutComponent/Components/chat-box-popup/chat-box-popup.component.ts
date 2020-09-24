import { Component, OnInit } from '@angular/core';
import {  scaleAnimation } from 'src/app/Shared/Modules/animations/animationRightToggle';

@Component({
  selector: 'app-chat-box-popup',
  templateUrl: './chat-box-popup.component.html',
  animations: [scaleAnimation]
})
export class ChatBoxPopupComponent implements OnInit {

  constructor() { }

  animationOpen: string = 'out';


  toggleClick() {
    this.animationOpen = this.animationOpen === 'out' ? 'in' : 'out';
  }
  closeChatbox=()=>{this.animationOpen = 'out';}


  ngOnInit() {
  }

}
