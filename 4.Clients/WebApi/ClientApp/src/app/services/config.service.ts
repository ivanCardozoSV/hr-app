import { Injectable, Inject } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';

const apiUrl = "http://localhost:61059/api/Configs";

const httpOptions = {
  headers: new HttpHeaders({'Content-Type': 'application/json'})
}

@Injectable()
export class ConfigService {
  http: HttpClient;
  private headers: HttpHeaders;
  private baseUrl: string;

  constructor(@Inject('BASE_URL') baseUrl: string, http: HttpClient) {
    this.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });
    this.http = http;
    this.baseUrl = baseUrl;
  }

  getSkillTypes(): Observable<any[]> {
    return this.http.get<any[]>(apiUrl + '/SkillTypes')
      .pipe(
        tap(skills => {}),
        catchError(this.handleError('getSkillTypes', []))
      );
  }

  getStatusTypes(): Observable<any[]> {
    return this.http.get<any[]>(apiUrl + '/StageStatusTypes')
      .pipe(
        tap(statuses => {}),
        catchError(this.handleError('getStatusTypes', []))
      );
  }

  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      return of(result as T);
    };
  }

}
