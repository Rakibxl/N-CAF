import { Component, OnInit } from '@angular/core';
import { animationRightToggle } from 'src/app/Shared/Modules/animations/animationRightToggle';

@Component({
  selector: 'app-landing-page',
  templateUrl: './landing-page.component.html',
  styleUrls: ['./landing-page.component.css'],
  animations: [animationRightToggle]
})
export class LandingPageComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
