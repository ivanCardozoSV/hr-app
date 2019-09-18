import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AppConfig } from '../app-config/app.config';
import { BaseService } from './base.service';
import { Router } from '@angular/router';

//const apiUrl = "http://localhost:61059/api/ProcessStage";

@Injectable()
export class StageService extends BaseService {

  constructor(router: Router, config: AppConfig, http: HttpClient) {
    super(router, config, http);
    this.apiUrl += 'ProcessStage';
  }
}
