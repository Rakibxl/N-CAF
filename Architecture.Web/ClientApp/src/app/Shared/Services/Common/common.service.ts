import { Injectable } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { Guid } from 'guid-typescript';
declare var jQuery: any;

@Injectable({
  providedIn: 'root'
})
export class CommonService {

  public PAGE_SIZE: number = 10;

  constructor(private titleService: Title) { }

  toQueryString(obj) {
    let parts = [];
    for (const property in obj) {
      const value = obj[property];
      if (value != null && value !== undefined) {
        parts.push(encodeURIComponent(property) + '=' + encodeURIComponent(value));
      }
    }

    return parts.join('&');
  }

  toFormData(obj) {
    let formData = new FormData();
    for (const property in obj) {
      const value = obj[property];
      if (value != null && value !== undefined) {
        formData.append(property, value);
      }
    }

    return formData;
  }

  isValidGuid(value): Boolean {
    return value ? (Guid.isGuid(value) && Guid.EMPTY != value ? true : false) : false;
  }

  getUTCDate(date: any): Date {
    const _date = new Date(date);
    return new Date(Date.UTC(_date.getFullYear(), _date.getMonth(), _date.getDate()));
  };

  getTitle() {
    return this.titleService.getTitle();
  }

  setTitle(title: string) {
    this.titleService.setTitle(title);
  }

  public startLoading() {
    jQuery('.spinner-overlay').show();
  }

  public stopLoading() {
    jQuery('.spinner-overlay').hide();
  }

  getDateToSetForm(date: any) {
    if (!date) {
      return '';
    }
    return new Date(date).toISOString().substring(0, 10);
  };
}
