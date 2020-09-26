import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { PDFModifyService } from './services/pdfmodify.service';
import { DomSanitizer } from '@angular/platform-browser';
import jsPDF from 'jspdf';

@Component({
  selector: 'app-pdfmodify',
  templateUrl: './pdfmodify.component.html',
  styleUrls: ['./pdfmodify.component.css']
})
export class PDFModifyComponent implements OnInit {
  pdfSrc: any = '';
  @ViewChild('pdfData', { static: false }) content: ElementRef;

  constructor(private pdfModifyService: PDFModifyService, private sanitizer: DomSanitizer) { }

  ngOnInit() {

  }

  getSanitizedUrl(url) {
    return this.sanitizer.bypassSecurityTrustResourceUrl(url);
  }

  getPDF() {
    this.pdfSrc = '';
    this.pdfModifyService.getPDF().subscribe(res => {
      if (res && res.data) {
        this.pdfSrc = res.data;
        //this.pdfSrc = this.getSanitizedUrl(res.data);
        // console.log(this.pdfSrc)
      }
    });
  }

  downloadPDF(pdfData, event) {
    // var doc = new jsPDF();
    // doc.text(20, 20, 'Hello world!');
    // doc.text(20, 30, 'This is client-side Javascript, pumping out a PDF.');
    // doc.addPage();
    // doc.text(20, 20, 'Do you like that?');
    // doc.save('Test.pdf');


    // const doc = new jsPDF();
    // const specialElementHandlers = {
    //   '#editor': function (element, renderer) {
    //     return true;
    //   }
    // };
    // const content = this.content.nativeElement;
    // doc.fromHTML(content.innerHTML, 15, 15, {
    //   width: 190,
    //   'elementHandlers': specialElementHandlers
    // });
    // doc.save('fileName.pdf');




    // const doc = new jsPDF('l')
    // const ta = document.getElementById('pdfData');
    // doc.fromHTML(ta, 0, 0);
    // doc.save('demo.pdf');

    // window.open(data)
    // console.log(event)

    // this.pdfModifyService.download(data);
  }
}
