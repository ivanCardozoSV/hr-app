import { Component, OnInit } from '@angular/core';
import { AppComponent } from '../app.component';

@Component({
  selector: 'app-not-found',
  templateUrl: './not-found.component.html',
  styleUrls: ['./not-found.component.css'],
  providers: [AppComponent]
})
export class NotFoundComponent implements OnInit {

  constructor(private app: AppComponent) { }

  ngOnInit() {
    this.app.renderBgImage();
  }

}
