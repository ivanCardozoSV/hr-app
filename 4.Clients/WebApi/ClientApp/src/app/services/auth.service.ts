import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AppConfig } from '../app-config/app.config';
import { BaseService } from './base.service';
import { Router } from '@angular/router';
import { catchError, tap } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService extends BaseService {

  constructor(router: Router, config: AppConfig, http: HttpClient) {
    super(router, config, http);
    this.apiUrl += 'Auth';
  }

  public authenticate(userName: string, password: string): Observable<any> {
    let user = {UserName : userName , Password : password};
    return this.http.post(this.apiUrl + '/login', user)
      .pipe(
        tap(data => {}),
        catchError(this.handleErrors)
      );
  }

  public externalLogin(token: string): Observable<any> { 
    let body = {token : token};
    return this.http.post(this.apiUrl + '/loginExternal', body)
      .pipe(
        tap(data => {}),
        catchError(this.handleErrors)
      );
  }
}
