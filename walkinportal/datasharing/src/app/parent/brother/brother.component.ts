import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-brother',
  template:`
  Arvind:Message from parent {{childMessage}}
  `,
  styleUrls: ['./brother.component.css']
})
export class BrotherComponent implements OnInit {

  constructor() { }
  @Input() childMessage:string|undefined;
  ngOnInit(): void {
  }

}
