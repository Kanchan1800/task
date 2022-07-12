import { Component, Input, OnInit,Output,EventEmitter } from '@angular/core';


@Component({
  selector: 'app-me',
  template:`
  <h4>Kanchan:Message from parent{{childMessage}}</h4>

  <button (click)="sendMessage()">Send Message to parent using output and event emitter</button><br><br><br>
  <input type='text' [(ngModel)]="filter"/><br>
  `,
  styleUrls: ['./me.component.css']
})
export class MeComponent implements OnInit {

  constructor() {

    console.log(this._filter);
  }
  kanchantext='My name is kanchan'
  @Input() childMessage:string | undefined;

  ngOnInit(): void {
  }

  messageviaoutput: string = "Hola Mundo!"

  @Output() messageEvent = new EventEmitter<string>();

  sendMessage() {
    this.messageEvent.emit(this.messageviaoutput)
  }

  private _filter: string='';
  @Input() get filter() {
      return this._filter;
  }

  set filter(val: string) {// jaise hi value change hoga input ka set filter call hoga and voh _filter ka value define karega
      this._filter = val;
      this.changed.emit(this.filter); //Raise changed event joh ki child se parent me pass hoga yeh value
  }

  @Output() changed: EventEmitter<string> = new EventEmitter<string>(); // yaha pe changed event banaya hai joh set filter me use kiya hai!


}
