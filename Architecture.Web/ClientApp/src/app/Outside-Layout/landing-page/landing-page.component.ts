import { Component, OnInit, EventEmitter } from '@angular/core';
import { animationRightToggle } from 'src/app/Shared/Modules/animations/animationRightToggle';

@Component({
  selector: 'app-landing-page',
  templateUrl: './landing-page.component.html',
  animations: [animationRightToggle]
})
export class LandingPageComponent implements OnInit {

  menuState: string = 'out';
  regOpen: string = 'out';

  constructor() { }

  ngOnInit() {
  }

  toggleClick() {
    this.regOpen ='out'
    this.menuState = this.menuState === 'out' ? 'in' : 'out';
  }

  toggleRegClick() {
    this.menuState = 'out';
    this.regOpen = this.regOpen === 'out' ? 'in' : 'out';
  }

  closeFnPanel() {
    this.menuState = 'out';
    this.regOpen = 'out';
  }
  

}
