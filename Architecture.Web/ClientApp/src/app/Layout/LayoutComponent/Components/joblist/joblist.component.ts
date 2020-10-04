import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
@Component({
  selector: 'app-joblist',
  templateUrl: './joblist.component.html',
})
export class JoblistComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit() {
  }

  onClickGeneratePDF() {
    const url = this.router.serializeUrl(
      this.router.createUrlTree(['./generate-pdf'])
    );
    window.open(url, '_blank');
  }
}
