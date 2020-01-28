import { Component, OnInit, TemplateRef } from '@angular/core';
import { Community } from 'src/entities/community';
import { ActivatedRoute, Params } from '@angular/router';
import { FacadeService } from '../services/facade.service';
import { AppComponent } from '../app.component';
import { PostulantsService } from '../services/postulants.service';
import { Postulant } from 'src/entities/postulant';
import { FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-postulants',
  templateUrl: './postulants.component.html',
  styleUrls: ['./postulants.component.css'],
  providers: [ AppComponent]
})
export class PostulantsComponent implements OnInit {

  listOfDisplayData; filteredPostulant: Postulant [] = [];
  emptyPostulant: Postulant;
  constructor(private facade: FacadeService, private fb: FormBuilder, private app: AppComponent) { }

  ngOnInit() {
    this.app.showLoading();
    this.app.removeBgImage();
    this.getPostulants();
  }

  getPostulants(){
    this.facade.postulantService.get<Postulant>().subscribe(res => {
      this.listOfDisplayData = res.sort();
      this.filteredPostulant = res;
      console.log(res);
    }, err => {
      console.log(err);
    });
  }

  showDetaisModal(postulantID: number, modalContent: TemplateRef<{}>): void{
    this.emptyPostulant = this.filteredPostulant.filter(postulant => postulant.id == postulantID)[0];
    this.showModal(modalContent, this.emptyPostulant.name);
  }

  showModal(modalContent: TemplateRef <{}>, fullName: string){
    fullName = fullName + "'s details";
    this.facade.modalService.create({
        nzTitle: fullName,
        nzContent: modalContent,
        nzClosable: true,
        nzWrapClassName: 'vertical-center-modal',
        nzFooter: null
    })
  }

  showDeleteConfirm(postulantID: number): void {
    let postulantDelete: Postulant = this.filteredPostulant.filter(postulant => postulant.id == postulantID)[0];
    this.facade.modalService.confirm({
      nzTitle: 'Are you sure you want to delete ' + postulantDelete.name + '?',
      nzContent: '',
      nzOkText: 'Yes',
      nzOkType: 'danger',
      nzCancelText: 'No',
      nzOnOk: () => this.facade.postulantService.delete<Postulant>(postulantID)
        .subscribe(res => {
          this.getPostulants();
          this.facade.toastrService.success('Postulant was deleted!');
        }, err => {
          if (err.message != undefined) this.facade.toastrService.error(err.message);
          else this.facade.toastrService.error('The service is not available now. Try again later.');
        })
    });
  }

}
