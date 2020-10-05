import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { AlertService } from '../../../Shared/Modules/alert/alert.service';
import { GeneratePdfService } from '../../generate-pdf/services/generate-pdf.service';

@Component({
  selector: 'app-generate-pdf',
  templateUrl: './generate-pdf.component.html',
  styleUrls: ['./generate-pdf.component.css']
})
export class GeneratePdfComponent implements OnInit {
  pdfSrc: any;

  constructor(private alertService: AlertService, private sanitizer: DomSanitizer, private generatePdfService: GeneratePdfService) { }

  ngOnInit() {
    this.generatePDF();
  }

  getSanitizedUrl(url) {
    return this.sanitizer.bypassSecurityTrustResourceUrl(url);
  }

  generatePDF() {
    this.generatePdfService.generatePDF().subscribe(res => {
      if (res && res.data) {
        this.pdfSrc = this.getSanitizedUrl(this.generatePdfService.baseUrl + 'Generated PDF/' + res.data);
      }
    });
  }

  onLoad(pdfData) {

  }
}
