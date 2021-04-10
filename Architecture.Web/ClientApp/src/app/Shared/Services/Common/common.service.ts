import { Injectable } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { Guid } from 'guid-typescript';
import * as _moment from 'moment';
import { AuthService } from '../Users/auth.service';
declare var jQuery: any;

@Injectable({
  providedIn: 'root'
})
export class CommonService {

  public PAGE_SIZE: number = 10;

  constructor(private titleService: Title, private authService: AuthService) { }

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

    getDateToSetForm(dateVal: any) {
    if (!dateVal || dateVal == '0000-00-00' || dateVal == '0000-00-00 00:00:00') {
      return '';
        }
    return _moment(dateVal).isValid() ? _moment(dateVal).format('YYYY-MM-DD') : '';
  }

  getFormatedDateToSave(dateVal) {
    if (!dateVal || dateVal == '0000-00-00' || dateVal == '0000-00-00 00:00:00') {
      return '';
    }
    return _moment(dateVal).isValid() ? _moment(dateVal).format('YYYY-MM-DD') : '';
  }

  getFormatedDateTimeToSave(dateVal) {
    return _moment(dateVal).isValid() ? _moment(dateVal).format('YYYY-MM-DD HH:mm:ss') : '';
  }

  getFormatedDateToShow(dateVal) {
    if (dateVal == '0000-00-00' || dateVal == '0000-00-00 00:00:00') {
      return '';
    }
    return _moment(dateVal).isValid() ? _moment(dateVal).format('DD/MM/YYYY') : '';
  }

  getFormatedDateMonthYearToShow(dateVal) {
    if (dateVal == '0000-00-00' || dateVal == '0000-00-00 00:00:00') {
      return '';
    }
    return _moment(dateVal).isValid() ? _moment(dateVal).format('MMM YYYY') : '';
  }

  getFormatedDateTimeToShow(dateVal) {
    if (dateVal == '0000-00-00' || dateVal == '0000-00-00 00:00:00') {
      return '';
    }
    return _moment(dateVal).isValid() ? _moment(dateVal).format('DD/MM/YYYY HH:mm:ss') : '';
  }

  getCurrentDate() {
    return _moment().toDate();
  }

  getDateToSet(dateString: string) {
    if (!dateString || dateString == '0000-00-00' || dateString == '0000-00-00 00:00:00') {
      return '';
    }
    return _moment(dateString).isValid ? _moment(dateString).toDate() : '';
  }

  getDateDifference(start, end) {
    return _moment.duration(_moment(end).diff(_moment(start)));
  }

  hasPermission(permName: string) {
    let permissions = this.authService.currentUserValue.Permission;
    if (permissions.indexOf(permName) >= 0) {
      return true;
    }
    return false;
  }
}
