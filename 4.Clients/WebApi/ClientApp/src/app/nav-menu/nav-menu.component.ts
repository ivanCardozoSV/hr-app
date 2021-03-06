import { Component, TemplateRef } from '@angular/core';
import { JwtHelper } from 'angular2-jwt';
import { Router } from '@angular/router';
import { GoogleSigninComponent } from '../login/google-signin.component';
import { AppComponent } from '../app.component';
import { User } from 'src/entities/user';
import { FacadeService } from '../services/facade.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css'],
  providers: [GoogleSigninComponent]
})
export class NavMenuComponent {
  constructor(private jwtHelper: JwtHelper, private _appComponent: AppComponent, private router: Router, private google: GoogleSigninComponent,
    private facade: FacadeService) { }

  isExpanded = false;
  currentUser: User;

  logoStyle = {
    'width': '10%',
    'height': '10%'
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  isUserAuthenticated() {
    this.currentUser = JSON.parse(localStorage.getItem('currentUser'));
    return this.google.isUserAuthenticated();
  }
  

  isUserRole(roles: string[]): boolean {
    return this._appComponent.isUserRole(roles);
  }

  openLogin(modalContent: TemplateRef<{}>){
    const modal = this.facade.modalService.create({
      nzTitle: null,
      nzContent: modalContent,
      nzClosable: false,
      nzFooter: null
    });
  }

  logout() {
    //localStorage.clear();
    this.google.logout();
  }

}
