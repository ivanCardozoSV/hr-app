import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { trimValidator } from 'src/app/directives/trim.validator';
import { Consultant } from 'src/entities/consultant';
import { FacadeService } from 'src/app/services/facade.service';
import { Process } from 'src/entities/process';
import { Globals } from '../../app-globals/globals';
import { SeniorityEnum } from '../../../entities/enums/seniority.enum';
import { StageStatusEnum } from '../../../entities/enums/stage-status.enum';
import { TechnicalStage } from 'src/entities/technical-stage';

@Component({
  selector: 'technical-stage',
  templateUrl: './technical-stage.component.html',
  styleUrls: ['./technical-stage.component.css']
})
export class TechnicalStageComponent implements OnInit {

    @Input()
    private _consultants: Consultant[];
    public get consultants(): Consultant[] {
        return this._consultants;
    }
    public set consultants(value: Consultant[]) {
        this._consultants = value;
    }

  technicalForm: FormGroup = this.fb.group({
    id: [0],
    status: [0, [Validators.required]],
    date: [new Date(), [Validators.required]],
    seniority: [0, [Validators.required]],
    consultantOwnerId: [null, [Validators.required]],
    consultantDelegateId: [null],
    feedback: [null, [trimValidator]],
    client: [null],
    rejectionReason: [null, [Validators.required]]
  });

  statusList: any[];

  seniorityList: any[];

  @Input() technicalStage: TechnicalStage;

  @Output() selectedSeniority = new EventEmitter();

  constructor(private fb: FormBuilder, private facade: FacadeService, private globals: Globals) {
    this.statusList = globals.stageStatusList.filter(x => x.id !== StageStatusEnum.Hired);
    this.seniorityList = globals.seniorityList;
   }

  ngOnInit() {
    this.changeFormStatus(false);
    if (this.technicalStage) { this.fillForm(this.technicalStage); }
  }

  updateSeniority(seniorityId) {
    this.selectedSeniority.emit(seniorityId);
  }

  getFormControl(name: string): AbstractControl {
    return this.technicalForm.controls[name];
  }

  changeFormStatus(enable: boolean) {
    for (const i in this.technicalForm.controls) {
      if (this.technicalForm.controls[i] != this.technicalForm.controls['status']) {
        if (enable) { this.technicalForm.controls[i].enable(); }
        else { this.technicalForm.controls[i].disable(); }
      }
    }
  }

  statusChanged(){
    if (this.technicalForm.controls['status'].value == 1){
       this.changeFormStatus(true);
       this.technicalForm.markAsTouched();
    }
    else{
       this.changeFormStatus(false);
    }
  }

  getFormData(processId: number): TechnicalStage {
    let stage: TechnicalStage = new TechnicalStage();
    let form = this.technicalForm;

    stage.id = this.getControlValue(form.controls.id);
    stage.date = this.getControlValue(form.controls.date);
    stage.feedback = this.getControlValue(form.controls.feedback);
    stage.status = this.getControlValue(form.controls.status);
    stage.consultantOwnerId = this.getControlValue(form.controls.consultantOwnerId);
    stage.consultantDelegateId = this.getControlValue(form.controls.consultantDelegateId);
    stage.processId = processId;
    stage.consultantDelegateId = this.getControlValue(form.controls.consultantDelegateId);
    stage.seniority = this.getControlValue(form.controls.seniority);
    stage.client = this.getControlValue(form.controls.client);
    stage.rejectionReason = this.getControlValue(form.controls.rejectionReason);
    return stage;
  }

  getControlValue(control: any): any {
    return (control === null ? null : control.value);
  }

  fillForm(technicalStage: TechnicalStage){
    const status: number = this.statusList.filter(s => s.id === technicalStage.status)[0].id;
    if (status === StageStatusEnum.InProgress) { this.changeFormStatus(true); }
    this.technicalForm.controls['status'].setValue(status);
    if (technicalStage.id != null) { this.technicalForm.controls['id'].setValue(technicalStage.id); }
    if (technicalStage.date != null) { this.technicalForm.controls['date'].setValue(technicalStage.date); }
    if (technicalStage.consultantOwnerId != null) {
      this.technicalForm.controls['consultantOwnerId'].setValue(technicalStage.consultantOwnerId);
    }
    if (technicalStage.consultantDelegateId != null) {
      this.technicalForm.controls['consultantDelegateId'].setValue(technicalStage.consultantDelegateId);
    }
    if (technicalStage.feedback != null) { this.technicalForm.controls['feedback'].setValue(technicalStage.feedback); }
    if (technicalStage.seniority != null) { this.technicalForm.controls['seniority'].setValue(technicalStage.seniority); }
    if (technicalStage.client != null) { this.technicalForm.controls['client'].setValue(technicalStage.client); }
    if (technicalStage.rejectionReason != null) { this.technicalForm.controls['rejectionReason'].setValue(technicalStage.rejectionReason); }
  }

  showRejectionReason() {
    if (this.technicalForm.controls['status'].value === StageStatusEnum.Rejected) {
      this.technicalForm.controls['rejectionReason'].enable();
      return true;
    }
    this.technicalForm.controls['rejectionReason'].disable();
    return false;
  }

}
