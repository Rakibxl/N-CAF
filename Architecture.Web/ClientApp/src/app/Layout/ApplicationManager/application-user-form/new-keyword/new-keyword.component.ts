import { Component, OnInit, Inject, OnDestroy, Input, AfterViewInit, ChangeDetectorRef } from '@angular/core';
import { each, some, find } from 'lodash';
import { Subscription, pipe } from 'rxjs';
import { SaveUserRole, UserRole } from 'src/app/Shared/Entity/Users/role';
import { RoleService } from 'src/app/Shared/Services/Users/role.service';
import { AlertService } from 'src/app/Shared/Modules/alert/alert.service';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { finalize } from 'rxjs/operators';
import { CommonService } from 'src/app/Shared/Services/Common/common.service';


@Component({
  selector: 'app-new-keyword',
  templateUrl: './new-keyword.component.html',
  styleUrls: ['./new-keyword.component.css']
})
export class NewKeywordComponent implements OnInit, AfterViewInit {
  operatorKeyword: any;
  @Input() operatorKeywords: any[];

  constructor(
    private alertService: AlertService,
    public activeModal: NgbActiveModal,
    private cdr: ChangeDetectorRef,
    private commonService: CommonService,
    private roleService: RoleService) {
  }

  ngOnInit() {
    this.operatorKeyword = {};
  }

  ngAfterViewInit() {
    this.cdr.detectChanges();
  }

  onSubmit() {
    let item = this.operatorKeywords.filter(ex => ex.operatorKeywordName == this.operatorKeyword.operatorKeywordName);
    if (item.length) {
      alert('Already Exists!');
      return;
    }
    this.activeModal.close(this.operatorKeyword);
    return;
    this.commonService.startLoading();
    this.alertService.fnLoading(true);
    const createSubscription = this.roleService.create(this.operatorKeyword)
      .pipe(finalize(() => { this.alertService.fnLoading(false); this.commonService.stopLoading(); }))
      .subscribe(res => {
        if (!res) {
          return;
        }
        this.activeModal.close(`Role successfully has been added.`);
        this.alertService.titleTosterSuccess(`Role successfully has been added.`);
      }, error => {
      });
  }
}
