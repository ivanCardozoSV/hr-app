import { Component, OnInit, TemplateRef, Input } from '@angular/core';
import { FacadeService } from 'src/app/services/facade.service';
import { Offer } from 'src/entities/offer';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { trimValidator } from 'src/app/directives/trim.validator';
import { OfferStatusEnum } from 'src/entities/enums/offer-status.enum';
import { Globals } from 'src/app/app-globals/globals';
// import { DatePipe } from '@angular/common';


@Component({
  selector: 'history-offer-popup',
  templateUrl: './history-offer-popup.component.html',
  styleUrls: ['./history-offer-popup.component.css']
})
export class HistoryOfferPopupComponent implements OnInit {
  @Input() 
  private _offerHistory : Offer[];
  public get offerHistory():  Offer[] {
    return this._offerHistory;
  }
  public set offerHistory(value: Offer[]) {
      this._offerHistory = value;
  }

  editForm: FormGroup;
  offerStatusList: any[];

  constructor(private fb: FormBuilder, private facade: FacadeService, private globals: Globals) {    
    this.offerStatusList = globals.offerStatusList;
  }

  ngOnInit() {
  }
  
  showModal(modalContent: TemplateRef <{}>){    
    this.facade.modalService.create({
        nzTitle: "Offer history",
        nzContent: modalContent,
        nzClosable: true,
        nzWrapClassName: 'vertical-center-modal',
        nzFooter: null ,     
        nzWidth : 1000
    })
  }

  doSomething(){        
    console.log(this._offerHistory);
  }

  addOffer(modalContent: TemplateRef<{}>){
    this.resetEditForm();     
    const modal = this.facade.modalService.create({
      nzTitle: 'Add Offer',
      nzContent: modalContent,
      nzClosable: true,
      nzWidth: '90%',
      nzFooter: [
        {
          label: 'Cancel',
          shape: 'default',
          onClick: () => modal.destroy()
        },
        {
          label: 'Save',
          type: 'primary',
          loading: false,
          onClick: () => {
            modal.nzFooter[1].loading = true;
            let isCompleted: boolean = true;
            for (const i in this.editForm.controls) {
              this.editForm.controls[i].markAsDirty();
              this.editForm.controls[i].updateValueAndValidity();
              if (!this.editForm.controls[i].valid) isCompleted = false;
            }
            if (isCompleted) {
              this.offerHistory.push({
                id : 0,
                offerDate: this.editForm.controls['offerDate'].value,
                salary: this.editForm.controls['salaryOffer'].value,
                rejectionReason: this.editForm.controls['rejectionReason'].value,
                status: this.editForm.controls['status'].value,
              });
              this.facade.toastrService.success('Offer was successfully edited !');
              modal.destroy();
            }              
            else modal.nzFooter[1].loading = false;
          }
        }],
    });
  }

  showEditModal(modalContent: TemplateRef<{}>, id: number): void {    
    this.resetEditForm(); 
    this.fillEditForm(this.offerHistory[id]);

    const modal = this.facade.modalService.create({
      nzTitle: 'Edit Offer',
      nzContent: modalContent,
      nzClosable: true,
      nzWidth: '90%',
      nzFooter: [
        {
          label: 'Cancel',
          shape: 'default',
          onClick: () => modal.destroy()
        },
        {
          label: 'Save',
          type: 'primary',
          loading: false,
          onClick: () => {
            modal.nzFooter[1].loading = true;
            let isCompleted: boolean = true;
            for (const i in this.editForm.controls) {
              this.editForm.controls[i].markAsDirty();
              this.editForm.controls[i].updateValueAndValidity();
              if (!this.editForm.controls[i].valid) isCompleted = false;
            }
            if (isCompleted) {
              this.offerHistory[id].offerDate = this.editForm.controls['offerDate'].value;
              this.offerHistory[id].salary = this.editForm.controls['salaryOffer'].value;
              this.offerHistory[id].rejectionReason = this.editForm.controls['rejectionReason'].value;
              this.offerHistory[id].status = this.editForm.controls['status'].value;
              this.facade.toastrService.success('Offer was successfully edited !');
              modal.destroy();
            }              
            else modal.nzFooter[1].loading = false;
          }
        }],
    });
  }

  showDeleteConfirm(id: number): void {    
    this.facade.modalService.confirm({
      nzTitle: 'Are you sure to delete?',
      nzContent: '',
      nzOkText: 'Yes',
      nzOkType: 'danger',
      nzCancelText: 'No',                  
      nzOnOk: () => {          
        this.offerHistory.splice(id,1);
        this.facade.toastrService.success('Offer was deleted !');
      }
    });    
  }

  resetEditForm() { 
    this.editForm = this.fb.group({
      offerDate: [new Date(), [Validators.required]],
      salaryOffer: [null, [Validators.required]],
      rejectionReason: [null, [Validators.required]],
      status: [null, [Validators.required]]
    });
  }

  fillEditForm(offerSelected : Offer) {
    this.editForm.controls['offerDate'].setValue(offerSelected.offerDate);    
    this.editForm.controls['salaryOffer'].setValue(offerSelected.salary);    
    this.editForm.controls['rejectionReason'].setValue(offerSelected.rejectionReason);
    this.editForm.controls['status'].setValue(offerSelected.status);
  }
}
