import { Component, OnInit, TemplateRef } from '@angular/core';
import { AppComponent } from '../app.component';
import { FacadeService } from '../services/facade.service';
import { FormGroup, FormBuilder, Validators, FormControl, AbstractControl } from '@angular/forms';
import { SettingsComponent } from '../settings/settings.component';
import { trimValidator } from '../directives/trim.validator';
import { Role } from 'src/entities/role';
import { Employee } from 'src/entities/employee';
import { filter } from 'rxjs/operators';

@Component({
  selector: 'app-role',
  templateUrl: './role.component.html',
  styleUrls: ['./role.component.css']
})
export class RoleComponent implements OnInit {
  roles: Role[] = [];
  roleForm: FormGroup;
  employeesWithDeleteRole: Employee[] = [];

  constructor(private fb: FormBuilder, private facade: FacadeService) { }

  ngOnInit() {
    this.getRoles();

    this.roleForm = this.fb.group({
      name: [null, [Validators.required, trimValidator]],
      isActive: [null, [Validators.required]]
    });
  }


  getRoles() {
    this.facade.RoleService.get<Role>()
      .subscribe(res => {
        this.roles = res;
      }, err => {
        console.log(err);
      });
  }

  showDeleteConfirm(role: Role) {
    this.getEmployeesWithDeleteRole(role);
    this.facade.modalService.confirm({
      nzTitle: 'Are you sure you want to delete  ' + role.name + '?',
      nzContent: '',
      nzOkText: 'Yes',
      nzOkType: 'danger',
      nzCancelText: 'No',
      nzOnOk: () => {
        if (this.employeesWithDeleteRole.length > 0) {
          this.facade.toastrService.error("Unable to delete: there are employees with this role assigned");
        }
        else {
          this.facade.RoleService.delete<Role>(role.id).subscribe(res => {
            this.getRoles();
            this.facade.toastrService.success('Role was deleted!');
          }, err => {
            if (err.message != undefined) this.facade.toastrService.error(err.message);
            else this.facade.toastrService.error("The service is not available now. Try again later.");
          })
        }
      }
    });
  }

  getEmployeesWithDeleteRole(role: Role) {
    this.facade.employeeService.get<Employee>("GetAll")
      .subscribe(res => {
        this.employeesWithDeleteRole = res.filter(e => e.role.id == role.id);
      }, err => {
        console.log(err);
      });
  }

  showAddModal(modalContent: TemplateRef<{}>) {
    this.roleForm.reset();
    this.roleForm.controls["isActive"].setValue("true");
    const modal = this.facade.modalService.create({
      nzTitle: 'Add New Role',
      nzContent: modalContent,
      nzClosable: true,
      nzWidth: '50%',
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
            for (let role in this.roleForm.controls) {
              this.roleForm.controls[role].markAsDirty();
              this.roleForm.controls[role].updateValueAndValidity();
              if (!this.roleForm.controls[role].valid) isCompleted = false;
            }
            if (isCompleted) {
              let addRole: Role = {
                id: 0,
                name: this.roleForm.controls["name"].value,
                isActive: this.roleForm.controls["isActive"].value,
              }
              this.facade.RoleService.add<Role>(addRole).subscribe(res => {
                this.getRoles();
                this.facade.toastrService.success('Role was successfully created!');
                modal.destroy();
              }, err => {
                if (err.message != undefined) this.facade.toastrService.error(err.message);
                else this.facade.toastrService.error("The service is not available now. Try again later.");
              })
            }
            else modal.nzFooter[1].loading = false;
          }
        }

      ]
    });
  }

  showEditModal(modalContent: TemplateRef<{}>, role: Role) {
    this.roleForm.reset();
    this.fillRoleForm(role);
    const modal = this.facade.modalService.create({
      nzTitle: 'Edit Role',
      nzContent: modalContent,
      nzClosable: true,
      nzWidth: '60%',
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
            for (const i in this.roleForm.controls) {
              this.roleForm.controls[i].markAsDirty();
              this.roleForm.controls[i].updateValueAndValidity();
              if (!this.roleForm.controls[i].valid) isCompleted = false;
            }
            if (isCompleted) {
              let editRole: Role = role;
              editRole.name = this.roleForm.controls["name"].value;
              editRole.isActive = this.roleForm.controls["isActive"].value;
              this.facade.RoleService.update<Role>(role.id, editRole).subscribe(res => {
                this.getRoles();
                this.facade.toastrService.success('Role was successfully edited!');
                modal.destroy();
              }, err => {
                if (err.message != undefined) this.facade.toastrService.error(err.message);
                else this.facade.toastrService.error("The service is not available now. Try again later.");
              })
            }
            else modal.nzFooter[1].loading = false;
          }
        }]
    });
  }

  fillRoleForm(role: Role) {
    this.roleForm.controls["name"].setValue(role.name);
    this.roleForm.controls["isActive"].setValue(role.isActive.toString());
  }

}
