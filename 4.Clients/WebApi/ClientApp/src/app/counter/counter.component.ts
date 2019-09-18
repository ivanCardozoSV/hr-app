import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-counter-component',
  templateUrl: './counter.component.html'
})
export class CounterComponent {
  public currentCount = 0;

  constructor(private toastr: ToastrService) {}

  public incrementCounter() {
    this.currentCount++;
  }

  showToaster(title:string = 'Título', text:string = 'Mensaje', type:string = 'i') {
    if(type === 'i') 
      this.toastr.info(text, title);
    
    else if(type === 's') 
      this.toastr.success(text, title);
    
    else if(type === 'w') 
      this.toastr.warning(text, title);
    
    else if(type === 'e') 
      this.toastr.error(text, title);  

    else  //default info
      this.toastr.info(text, title);

  }

  showInfo() {
    this.toastr.info('Hello world!', 'Info');
  }

  showSuccess() {
    this.toastr.success('Hello world!', 'Success');
  }

  showWarning() {
    this.toastr.warning('Hello world!', 'Warning');
  }

  showError() {
    this.toastr.error('Hello world!', 'Error');
  }
}
