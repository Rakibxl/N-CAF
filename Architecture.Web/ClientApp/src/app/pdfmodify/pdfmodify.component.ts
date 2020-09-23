import { Component, OnInit } from '@angular/core';
import { PDFModifyService } from './services/pdfmodify.service';

@Component({
  selector: 'app-pdfmodify',
  templateUrl: './pdfmodify.component.html',
  styleUrls: ['./pdfmodify.component.css']
})
export class PDFModifyComponent implements OnInit {

  constructor(private pdfModifyService: PDFModifyService) { }

  ngOnInit() {
  }

  getPDF() {
    this.pdfModifyService.getPDF().subscribe(res => {
      console.log(res)
    });
  }

}
