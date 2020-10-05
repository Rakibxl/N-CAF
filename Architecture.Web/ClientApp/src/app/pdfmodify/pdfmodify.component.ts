import { Component, ComponentRef, ElementRef, OnInit, ViewChild } from '@angular/core';
import { PDFModifyService } from './services/pdfmodify.service';
import { DomSanitizer } from '@angular/platform-browser';
import jsPDF from 'jspdf';
import html2canvas from 'html2canvas';
declare var $: any;

@Component({
  selector: 'app-pdfmodify',
  templateUrl: './pdfmodify.component.html',
  styleUrls: ['./pdfmodify.component.css']
})
export class PDFModifyComponent implements OnInit {
  pdfSrc: any = '';
  @ViewChild('pdfData', { static: false }) content: ElementRef;

  constructor(private pdfModifyService: PDFModifyService, private sanitizer: DomSanitizer) {
    // $('#pdfData').load(function () {
    //   $('#pdfData').contents().find("#toolbarViewerRight").hide();
    // });
  }

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

  onLoad(iframe) {
    console.log(iframe)
  }

  downloadPDF(pdfData, event) {
    var iframe = document.getElementById('pdfData');
    //var iframe = document.querySelector('iframe[id="pdfData"]');

    //var element = iframe.contentWindow.document.querySelector('button');
    //console.log(element)

    // var div1 = document.createElement("div");
    // var frame1 = document.createElement("iframe");
    // frame1.id = "frame1";
    // frame1.onload = function () {
    //   alert("loaded");

    //   var iframe = document.getElementById("pdfData");
    //   var iframeDocument = iframe.contentDocument || iframe.contentWindow.document;

    //   var button = iframeDocument.getElementById("downloadMenu");

    //   if (button == null) {
    //     alert("button is null");
    //   }
    // };
    // frame1.src = "https://localhost:44357/Generated PDF/Bonus Baby_1001.pdf";
    // div1.appendChild(frame1);
    // document.body.appendChild(div1);
  }
}
