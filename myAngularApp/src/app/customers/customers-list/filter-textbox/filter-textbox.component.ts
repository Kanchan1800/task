import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-filter-textbox',
  templateUrl: './filter-textbox.component.html',
  styleUrls: ['./filter-textbox.component.scss']
})
export class FilterTextboxComponent implements OnInit {

  private _filter: string='';
  @Input() get filter() {
      return this._filter;
  }

  set filter(val: string) {// jaise hi value change hoga input ka set filter call hoga and voh _filter ka value define karega
      this._filter = val;
      this.changed.emit(this.filter); //Raise changed event joh ki child se parent me pass hoga yeh value
  }

  @Output() changed: EventEmitter<string> = new EventEmitter<string>(); // yaha pe changed event banaya hai joh set filter me use kiya hai!

  private _username: string='';
  @Input() get username() {
      return this._username;
  }

  set username(val: string) {
      this._username = val;
      this.changedd.emit(this.username); //Raise changedd event
      this.textColor='green';
      if(this.username.length==0)
      this.textColor='red';
  }

  @Output() changedd: EventEmitter<string> = new EventEmitter<string>();

  textColor:string='red';
  constructor() {}

  ngOnInit() {

  }

}
