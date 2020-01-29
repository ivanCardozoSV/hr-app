import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { AppConfig } from '../app-config/app.config';
import { tap, catchError } from 'rxjs/operators';
import { Router } from '@angular/router';
import { ErrorResponse } from '../../entities/ErrorResponse';

@Injectable()
export class BaseService {
  public headers: HttpHeaders;
  public headersWithAuth: HttpHeaders;
  public token: string;
  public apiUrl: string;

  constructor(private router: Router, private config: AppConfig, public http: HttpClient) {    
    let user = JSON.parse(localStorage.getItem('currentUser'));
    this.token = user != null ? user.Token : null;
    this.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });
    this.headersWithAuth = new HttpHeaders({
      "Authorization": "Bearer " + this.token,
      "Content-Type": "application/json"
    });
    this.http = http;
    this.apiUrl = this.config.getConfig('apiUrl');
  }

  public get<T>(urlAdd?:string): Observable<T[]> {    
    const url = urlAdd == undefined ? this.apiUrl : `${this.apiUrl}/${urlAdd}`;
    return this.http.get<T[]>(url, 
      {headers: this.headersWithAuth, observe: "body"})
      .pipe(
        tap(entities => { }),
        catchError(this.handleErrors)
      );
  }

  public getByID<T>(id: number): Observable<T> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.get<T>(url, {
      headers: this.headersWithAuth
    })
      .pipe(
        catchError(this.handleErrors)
      );
  }

  public add<T>(entity: T): Observable<T> {
    return this.http.post<T>(this.apiUrl, entity, {
      headers: this.headersWithAuth
    })
      .pipe(
        catchError(this.handleErrors)
      );
  }

  public update<T>(id, entity: T): Observable<any> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.put(url, entity, {
      headers: this.headersWithAuth
    }).pipe(
      tap(_ => { }),
      catchError(this.handleErrors)
    );
  }

  public delete<T>(id): Observable<T> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.delete<T>(url, {
      headers: this.headersWithAuth
    })
      .pipe(
        catchError(this.handleErrors)
      );
  }

  public getErrorMessage(error): string {
    console.log(error);
    let errorMessage = '';
    if (!error && !error.error) {

      for (var msg in error.error) {
        errorMessage = errorMessage.concat(msg);
      }
    }
    else errorMessage = "An error has occurred";

    return errorMessage;
  }

  public handleErrors(error) {

    //Cuando el error que devuelve el BE es un 400 (Bad Request), los errores llegan en formato key/value
    if (error.error != null && error.error != undefined && error.status != 400) {
      return throwError(error.error as ErrorResponse);
    }

    else if (error.status === 400) {
      let errMessage = this.getErrorMessage(error);

      let err: ErrorResponse = {
        additionalData: {},
        errorCode: error.status,
        message: errMessage
      }
      return throwError(err);
    }

    else {
      let err: ErrorResponse = {
        additionalData: {},
        errorCode: error.status,
        message: error.message
      }
      return throwError(err);
    }
  }
}
