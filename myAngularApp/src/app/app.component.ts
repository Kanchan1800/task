import { Component,OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  template:`
   <router-outlet></router-outlet>
`,
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  title = 'Hello World ';
  // constructor() {
  //   this.title = 'Hello World ';
  // }

  ngOnInit(){
   this.title = 'Hello World kanchan';
  }
}
