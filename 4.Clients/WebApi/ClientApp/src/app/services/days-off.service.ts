import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AppConfig } from '../app-config/app.config';
import { BaseService } from './base.service';
import { Router } from '@angular/router';
import { Observable, forkJoin } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { DaysOff } from 'src/entities/days-off';

@Injectable()
export class DaysOffService extends BaseService {
  private baseUrl: string = 'http://localhost:61059/';  
  public headers: HttpHeaders;

  constructor(router: Router, config: AppConfig, http: HttpClient) {
    super(router, config, http);
    this.apiUrl += 'daysOff';
    this.headers = new HttpHeaders({ 'Content-Type': 'application/json' });
  }

  public getByDNI(dni: Number): Observable<any>{
    return this.http.get(this.baseUrl
      + 'api/DaysOff/getbydni?dni=' + dni, { headers: this.headers, observe: "response" })
      .pipe(
        tap(data => {}),
        catchError(this.handleErrors)
      );
  }
}