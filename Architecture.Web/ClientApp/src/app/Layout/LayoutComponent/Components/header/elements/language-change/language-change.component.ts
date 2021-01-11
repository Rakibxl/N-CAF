import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-language-change',
  templateUrl: './language-change.component.html',
  styleUrls: ['./language-change.component.css']
})
export class LanguageChangeComponent implements OnInit {

    constructor(private translate: TranslateService) {
        translate.addLangs(['en', 'it']);
        translate.setDefaultLang('en');}

  ngOnInit() {
  }
    switchLang(lang: string) {
        this.translate.use(lang);
    }
}
