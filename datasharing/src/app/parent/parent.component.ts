import { Component, AfterViewInit, ViewChild } from '@angular/core';
import { MeComponent } from './me/me.component';
import { DataService } from '../data.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-parent',
  templateUrl:'./parent.component.html',
  styleUrls: ['./parent.component.css']
})
export class ParentComponent implements AfterViewInit {


  messagefromkanchan:string|undefined;
  parentMessage=" hello kanchan"
  parentMessageToBro="Hello arvind"
  @ViewChild(MeComponent) child:any;
  ngAfterViewInit(): void {
    this.messagefromkanchan=this.child.kanchantext;
  }
  kanchanmessageusingoutput:string|undefined;

  receiveMessage($event:any) {
    this.kanchanmessageusingoutput = $event
  }
  messagefrombrother:string |undefined;
  subscription: Subscription |any;

  constructor(private data: DataService) { }

  ngOnInit() {
    this.subscription = this.data.currentMessage.subscribe(message => this.messagefrombrother = message)
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

  filter_msg:string|undefined
  filter($event:any){
    this.filter_msg=$event
console.log($event)
  }

}
