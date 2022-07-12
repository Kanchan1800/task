import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  constructor() { }
  isActive=true;

  ngOnInit(): void {
    this.changedashboardclass();
  }



  changedashboardclass(){
    let nav1 =document.getElementsByClassName('nav_item') as HTMLCollection
    for (let i = 0; i < nav1.length; i++) {
      nav1[i].classList.remove('active')}


    let currentnav=document.getElementById('nav_dashboard') as HTMLUListElement;
    currentnav.classList.add('active');
  }

}
