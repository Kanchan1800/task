import { Component, OnInit,Input,Output,EventEmitter } from '@angular/core';

@Component({
  selector: 'app-cardfilter',
  templateUrl: './cardfilter.component.html',
  styleUrls: ['./cardfilter.component.scss']
})
export class CardfilterComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
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
