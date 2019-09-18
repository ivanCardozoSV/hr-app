import { Component, OnInit } from '@angular/core';
import { AppComponent } from 'src/app/app.component';

@Component({
  selector: 'app-unauthorized',
  templateUrl: './unauthorized.component.html',
  styleUrls: ['./unauthorized.component.css'],
  providers: [AppComponent]
})
export class UnauthorizedComponent implements OnInit {

  constructor(private app: AppComponent) { }

  ngOnInit() {
    this.app.renderBgImage();
  }

}
