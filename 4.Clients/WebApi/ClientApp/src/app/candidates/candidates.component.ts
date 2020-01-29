import { Component, OnInit, ViewChild, TemplateRef } from '@angular/core';
import { Candidate } from 'src/entities/candidate';
import { FacadeService } from 'src/app/services/facade.service';
import { trimValidator } from '../directives/trim.validator';
import { FormGroup, FormBuilder, Validators, FormControl, AbstractControl } from '@angular/forms';
import { CandidateSkill } from 'src/entities/candidateSkill';
import { Skill } from 'src/entities/skill';
import { CandidateDetailsComponent } from './details/candidate-details.component';
import { AppComponent } from '../app.component';
import { Consultant } from 'src/entities/consultant';
import { NzStatisticNumberComponent } from 'ng-zorro-antd/statistic/nz-statistic-number.component';
import { User } from 'src/entities/user';
import { Globals } from '../app-globals/globals';
import { Office } from '../../entities/office';
import { Community } from 'src/entities/community';
import { CandidateProfile } from 'src/entities/Candidate-Profile';
import { replaceAccent } from 'src/app/helpers/string-helpers'



@Component({
  selector: 'app-candidates',
  templateUrl: './candidates.component.html',
  styleUrls: ['./candidates.component.css'],
  providers: [CandidateDetailsComponent, AppComponent]
})



export class CandidatesComponent implements OnInit {

  @ViewChild('dropdown') nameDropdown;
  @ViewChild('dropdownStatus') statusDropdown;

  filteredCandidates: Candidate[] = [];
  isLoadingResults = false;
  searchValue = '';
  listOfSearchCandidates = [];
  listOfDisplayData = [...this.filteredCandidates];

  sortName = 'name';
  sortValue = 'ascend';

  recruiters: Consultant[] = [];
  profiles: CandidateProfile[] = [];
  communities: Community[] = [];
  _offices: Office[] = [];

  //Modals
  skills: Skill[] = [];
  private completeSkillList: Skill[] = [];
  validateForm: FormGroup;
  isAddVisible: boolean = false;
  isAddOkLoading: boolean = false;
  emptyCandidate: Candidate;
  controlArray: Array<{ id: number, controlInstance: string[] }> = [];
  controlEditArray: Array<{ id: number, controlInstance: string[] }> = [];
  isEdit: boolean = false;
  editingCandidateId: number = 0;

  isDniLoading: boolean = false;
  isDniValid: boolean = false;

  currentConsultant: User;

  searchValueStatus = '';
  statusList: any[];
  englishLevelList: any[];

  constructor(private facade: FacadeService, private fb: FormBuilder, private detailsModal: CandidateDetailsComponent,
    private app: AppComponent, private globals: Globals) {
      this.currentConsultant = JSON.parse(localStorage.getItem('currentUser'));
      this.statusList = globals.candidateStatusList;
      this.englishLevelList = globals.englishLevelList;
     }

  ngOnInit() {
    this.app.showLoading();
    this.app.removeBgImage();
    this.getCandidates();
    this.getRecruiters();
    this.getProfiles();
    this.getCommunities();
    this.getOffices();
    this.getSkills();
    this.resetForm();
    this.app.hideLoading();

  }

  getCandidates() {
    this.facade.candidateService.get<Candidate>()
      .subscribe(res => {
        this.filteredCandidates = res;
        this.listOfDisplayData = res.sort((a, b) => (this.sortValue === 'ascend') ? (a[this.sortName] > b[this.sortName] ? 1 : -1) : (b[this.sortName] > a[this.sortName] ? 1 : -1));;
      }, err => {
        console.log(err);
      });
  }

  getRecruiters() {
    this.facade.consultantService.get<Consultant>()
      .subscribe(res => {
        this.recruiters = res;
      }, err => {
        console.log(err);
      });
  }

  getProfiles() {
    this.facade.candidateProfileService.get<CandidateProfile>()
    .subscribe(res => {
      this.profiles = res;
    }, err => {
      console.log(err);
    });
  }

  getCommunities() {
    this.facade.communityService.get<Community>()
    .subscribe(res => {
      this.communities = res;
    }, err => {
      console.log(err);
    });
  }


  getSkills() {
    this.facade.skillService.get<Skill>()
      .subscribe(res => {
        this.skills = res;
      }, err => {
        console.log(err);
      });
  }

  getOffices() {
    this.facade.OfficeService.get<Office>()
      .subscribe(res => {
        this._offices = res;
      }, err => {
        console.log(err);
      });
  }

  resetForm() {
    this.validateForm = this.fb.group({
      name: [null, [Validators.required, trimValidator]],
      lastName: [null, [Validators.required, trimValidator]],
      dni: [null, Validators.required],
      email: [null, [Validators.email]],
      phoneNumberPrefix: ['+54'],
      phoneNumber: [null],
      linkedin: [null, [Validators.required, trimValidator]],
      additionalInformation: [null, [trimValidator]],
      recruiter: [null, [Validators.required]],
      englishLevel: 'none',
      status: null,
      contactDay: null,
      preferredOffice: [null],
      community: [null, [Validators.required]],
      profile: [null, [Validators.required]],
      isReferred: [null]
    });
  }

  reset(): void {
    this.searchValue = '';
    this.searchValueStatus = '';
    this.search();
  }

  search(): void {
    const filterFunc = (item) => {
      return (this.listOfSearchCandidates.length ? this.listOfSearchCandidates.some(candidates => item.name.indexOf(candidates) !== -1) : true) &&
        (replaceAccent(item.name.toString().toUpperCase() + item.lastName.toString().toUpperCase()).indexOf(replaceAccent(this.searchValue.toUpperCase())) !== -1);
    };
    const data = this.filteredCandidates.filter(item => filterFunc(item));
    this.listOfDisplayData = data.sort((a, b) => (this.sortValue === 'ascend') ? (a[this.sortName] > b[this.sortName] ? 1 : -1) : (b[this.sortName] > a[this.sortName] ? 1 : -1));
    this.nameDropdown.nzVisible = false;
  }

  searchStatus(): void {
    const filterFunc = (item) => {
      return (this.listOfSearchCandidates.length ? this.listOfSearchCandidates.some(p => item.status.indexOf(p) !== -1) : true) &&
        (item.status === this.searchValueStatus)
    };
    const data = this.filteredCandidates.filter(item => filterFunc(item));
    this.listOfDisplayData = data.sort((a, b) => (this.sortValue === 'ascend') ? (a[this.sortName] > b[this.sortName] ? 1 : -1) : (b[this.sortName] > a[this.sortName] ? 1 : -1));
    this.searchValueStatus = '';
    this.statusDropdown.nzVisible = false;
  }

  sort(sortName: string, value: string): void {
    this.sortName = sortName;
    this.sortValue = value;
    this.search();
  }

  showEditModal(modalContent: TemplateRef<{}>, id: number): void {
    //Edit Consultant Modal
    this.resetForm();
    this.getSkills();
    if (this.completeSkillList.length == 0) this.skills.forEach(sk => this.completeSkillList.push(sk));
    this.editingCandidateId = id;
    this.isEdit = true;
    this.controlArray = [];
    this.controlEditArray = [];
    let editedCandidate: Candidate = this.filteredCandidates.filter(candidate => candidate.id == id)[0];
    this.fillCandidateForm(editedCandidate);

    const modal = this.facade.modalService.create({
      nzTitle: 'Edit Candidate',
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
            this.app.showLoading();
            modal.nzFooter[1].loading = true;
            let isCompleted: boolean = true;
            for (const i in this.validateForm.controls) {
              this.validateForm.controls[i].markAsDirty();
              this.validateForm.controls[i].updateValueAndValidity();
              if ((!this.validateForm.controls[i].valid) &&
                (this.validateForm.controls[i] != this.validateForm.controls['phoneNumberPrefix'])) isCompleted = false;
            }
            if (isCompleted) {
              let candidateSkills: CandidateSkill[] = [];
              this.controlEditArray.forEach(skillEdit => {
                let skill: CandidateSkill = {
                  candidateId: id,
                  candidate: null,
                  skillId: skillEdit.id,
                  skill: null,
                  rate: this.validateForm.controls[skillEdit.controlInstance[1]].value,
                  comment: this.validateForm.controls[skillEdit.controlInstance[2]].value
                }
                candidateSkills.push(skill);
              });
              this.controlArray.forEach(skillControl => {
                let skill: CandidateSkill = {
                  candidateId: id,
                  candidate: null,
                  skillId: this.validateForm.controls[skillControl.controlInstance[0]].value,
                  skill: null,
                  rate: this.validateForm.controls[skillControl.controlInstance[1]].value,
                  comment: this.validateForm.controls[skillControl.controlInstance[2]].value
                }
                candidateSkills.push(skill);
              });
              editedCandidate = {
                id: 0,
                name: this.validateForm.controls['name'].value.toString(),
                lastName: this.validateForm.controls['lastName'].value.toString(),
                dni: this.validateForm.controls['dni'].value,
                emailAddress: this.validateForm.controls['email'].value ? this.validateForm.controls['email'].value.toString() : null,
                phoneNumber: '(' + this.validateForm.controls['phoneNumberPrefix'].value.toString() + ')',
                linkedInProfile: this.validateForm.controls['linkedin'].value === null ? null : this.validateForm.controls['linkedin'].value.toString(),
                candidateSkills: candidateSkills,
                additionalInformation: this.validateForm.controls['additionalInformation'].value === null ? null : this.validateForm.controls['additionalInformation'].value.toString(),
                englishLevel: this.validateForm.controls['englishLevel'].value,
                status: this.validateForm.controls['status'].value,
                preferredOfficeId: this.validateForm.controls['preferredOffice'].value,
                recruiter: new Consultant(this.validateForm.controls['recruiter'].value, null, null),
                contactDay: new Date(),
                profile: new CandidateProfile(this.validateForm.controls['profile'].value),
                community: new Community(this.validateForm.controls['community'].value),
                isReferred: this.validateForm.controls['isReferred'].value
                // contactDay: this.validateForm.controls['contactDay'].value
              }
              if (this.validateForm.controls['phoneNumber'].value) {
                editedCandidate.phoneNumber += this.validateForm.controls['phoneNumber'].value.toString();
              }
              this.facade.candidateService.update<Candidate>(id, editedCandidate)
                .subscribe(res => {
                  this.getCandidates();
                  this.app.hideLoading();
                  this.facade.toastrService.success('Candidate was successfully edited!');
                  modal.destroy();
                }, err => {
                  this.app.hideLoading();
                  modal.nzFooter[1].loading = false;
                  if (err.message != undefined) this.facade.toastrService.error(err.message);
                  else this.facade.toastrService.error('The service is not available now. Try again later.');
                })
            }
            else modal.nzFooter[1].loading = false;
            this.app.hideLoading();
          }
        }],
    });
  }

  showDetailsModal(candidateID: number, modalContent: TemplateRef<{}>): void {
    this.emptyCandidate = this.filteredCandidates.filter(candidate => candidate.id == candidateID)[0];
    this.detailsModal.showModal(modalContent, this.emptyCandidate.name + ' ' + this.emptyCandidate.lastName);
  }

  showDeleteConfirm(candidateID: number): void {
    let candidateDelete: Candidate = this.filteredCandidates.filter(candidate => candidate.id == candidateID)[0];
    this.facade.modalService.confirm({
      nzTitle: 'Are you sure you want to delete ' + candidateDelete.name + ' ' + candidateDelete.lastName + '?',
      nzContent: '',
      nzOkText: 'Yes',
      nzOkType: 'danger',
      nzCancelText: 'No',
      nzOnOk: () => this.facade.candidateService.delete<Candidate>(candidateID)
        .subscribe(res => {
          this.getCandidates();
          this.facade.toastrService.success('Candidate was deleted!');
        }, err => {
          if (err.message != undefined) this.facade.toastrService.error(err.message);
          else this.facade.toastrService.error('The service is not available now. Try again later.');
        })
    });
  }

  addField(e?: MouseEvent): void {
    if (e) {
      e.preventDefault();
    }
    const id = (this.controlArray.length > 0) ? this.controlArray[this.controlArray.length - 1].id + 1 : 0;

    const control = {
      id,
      controlInstance: [`skill${id}`, `slidder${id}`, `comment${id}`]
    };

    if (id > 0) {
      let skills = this.skills;
      let newSetOfSkills: Skill[] = [];
      let skill: Skill = this.skills.filter(s => s.id == this.validateForm.controls[`skill${id - 1}`].value)[0];
      skills.forEach(sk => {
        if (sk != skill) newSetOfSkills.push(sk);
      });
      this.skills = newSetOfSkills;
    }

    if (this.editingCandidateId > 0) this.removeCandidateSkills();

    const index = this.controlArray.push(control);
    this.validateForm.addControl(this.controlArray[index - 1].controlInstance[0], new FormControl(null, Validators.required));
    this.validateForm.addControl(this.controlArray[index - 1].controlInstance[1], new FormControl(10));
    this.validateForm.addControl(this.controlArray[index - 1].controlInstance[2], new FormControl(null, Validators.required));
  }

  removeCandidateSkills() {
    let skills: Skill[] = [];
    this.completeSkillList.forEach(sk => {
      let exists: boolean = false;
      this.controlEditArray.forEach(control => {
        if (this.validateForm.controls[control.controlInstance[0]].value == sk.name) exists = true;
      });
      this.controlArray.forEach(control => {
        if (this.validateForm.controls[control.controlInstance[0]].value == sk.id) exists = true;
      });
      if (!exists && skills.filter(s => s.id == sk.id).length == 0) skills.push(sk);
    });
    this.skills = skills;
  }

  removeField(i: { id: number, controlInstance: string[] }, e: MouseEvent, isEdit: boolean): void {
    e.preventDefault();
    let skillList: Skill[] = [];
    this.completeSkillList.forEach(sk => skillList.push(sk));
    if (isEdit) {
      if (this.controlEditArray.length >= 1) {
        if (this.validateForm.controls[i.controlInstance[0]].value != null) {
          this.skills.push(skillList.filter(skill => skill.name == this.validateForm.controls[i.controlInstance[0]].value)[0]);
          this.skills.sort((a, b) => (a.id > b.id ? 1 : -1));
        }
        let j: number = 0;
        const index = this.controlEditArray.indexOf(i);
        this.controlEditArray.splice(index, 1);
        for (j; j < 3; j++) this.validateForm.removeControl(i.controlInstance[j]);
      }
    }
    else {
      if (this.controlArray.length >= 1) {
        if (this.validateForm.controls[i.controlInstance[0]].value != null) {
          this.skills.push(skillList.filter(skill => skill.id == this.validateForm.controls[i.controlInstance[0]].value)[0]);
          this.skills.sort((a, b) => (a.id > b.id ? 1 : -1));
        }
        let j: number = 0;
        const index = this.controlArray.indexOf(i);
        this.controlArray.splice(index, 1);
        for (j; j < 3; j++) this.validateForm.removeControl(i.controlInstance[j]);
      }
    }
  }

  getFormControl(name: string): AbstractControl {
    return this.validateForm.controls[name];
  }

  fillCandidateForm(candidate: Candidate) {
    //let statusIndex = this.statusList.filter(status => status.name.toLowerCase() === candidate.status.toLowerCase())[0].id;
    this.validateForm.controls['dni'].setValue(candidate.dni);
    this.validateForm.controls['name'].setValue(candidate.name);
    this.validateForm.controls['lastName'].setValue(candidate.lastName);
    this.validateForm.controls['email'].setValue(candidate.emailAddress);
    this.validateForm.controls['linkedin'].setValue(candidate.linkedInProfile);
    this.validateForm.controls['phoneNumberPrefix'].setValue(candidate.phoneNumber.substring(1, candidate.phoneNumber.indexOf(')')));
    this.validateForm.controls['phoneNumber'].setValue(candidate.phoneNumber.split(')')[1]);
    this.validateForm.controls['additionalInformation'].setValue(candidate.additionalInformation);
    this.validateForm.controls['recruiter'].setValue(candidate.recruiter.id);
    this.validateForm.controls['preferredOffice'].setValue(candidate.preferredOfficeId);
    this.validateForm.controls['englishLevel'].setValue(candidate.englishLevel);
    this.validateForm.controls['status'].setValue(candidate.status);
    this.validateForm.controls['community'].setValue(candidate.community.id);
    this.validateForm.controls['profile'].setValue(candidate.profile.id);
    this.validateForm.controls['isReferred'].setValue(candidate.isReferred);

    if (candidate.candidateSkills.length > 0) {
      candidate.candidateSkills.forEach(skill => {
        const id = (this.controlEditArray.length > 0) ? this.controlEditArray[this.controlEditArray.length - 1].id + 1 : 0;

        const control = {
          id: skill.skillId,
          controlInstance: [`skillEdit${id}`, `slidderEdit${id}`, `commentEdit${id}`]
        };

        const index = this.controlEditArray.push(control);
        this.validateForm.addControl(this.controlEditArray[index - 1].controlInstance[0], new FormControl(skill.skill.name));
        this.validateForm.addControl(this.controlEditArray[index - 1].controlInstance[1], new FormControl(skill.rate));
        this.validateForm.addControl(this.controlEditArray[index - 1].controlInstance[2], new FormControl(skill.comment, Validators.required));
      });
    }
  }

  dniChanged(){
    this.isDniValid = false;
    this.changeFormStatus(false);
  }

  changeFormStatus(enable: boolean){
    for (const i in this.validateForm.controls) {
      if(this.validateForm.controls[i] != this.validateForm.controls['dni']){
        if(enable) this.validateForm.controls[i].enable();
        else this.validateForm.controls[i].disable();
      }
    }
  }

  getStatus(status: number): string {
    return this.statusList.filter(st => st.id === status)[0].name;
  }

}
