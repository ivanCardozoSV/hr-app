import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FacadeService } from 'src/app/services/facade.service';
import { Process } from 'src/entities/process';

const ERROR_STATUS = 'error';
const PROCESS_STATUS = 'process';

@Component({
  selector: 'app-process-steps',
  templateUrl: './process-steps.component.html',
  styleUrls: ['./process-steps.component.css']
})
export class ProcessStepsComponent implements OnInit {
  
  processID: number = 0;
  process: Process = null;
  processStatus: string = 'process';
  states = ['error','finish','process','wait'];
  currentStagePosition: number = 0;

  selectedView = 'vertical';

  constructor(private route: ActivatedRoute, private facade: FacadeService) { }

  ngOnInit(): void {
    this.processID = this.route.snapshot.params['id'];
    this.getProcessByID(this.processID);
  }

  getProcessByID(id) {
    this.facade.processService.getByID<Process>(id)
            .subscribe(res => {
              this.process = res;
              console.log(res);
              //this.checkStatusOfProcess();
            }, err => {
              console.log(err);
            })
  }

  getStatusColor(status: string) {
    console.log(status);
    switch(status.toLowerCase()) {
      case "finish":
        return 'green';
      case "process":
        return 'blue'
      case "wait":
        return 'gray';
      case "error":
        return 'red';
      default:
        return 'blue';  
    }
  }

}
