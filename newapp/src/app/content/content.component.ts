import { Component, OnInit } from '@angular/core';
import { HeaderComponent } from '../dashboard/header/header.component';
import { SimpleChanges } from '@angular/core';

@Component({
  selector: 'app-content',
  templateUrl: './content.component.html',
  styleUrls: ['./content.component.scss']
})
export class ContentComponent implements OnInit {

  constructor() {

   }



  ngOnInit(): void {
    this.changecontentclass();
  }



  changecontentclass(){
    let nav1 =document.getElementsByClassName('nav_item') as HTMLCollection
    for (let i = 0; i < nav1.length; i++) {
      nav1[i].classList.remove('active')}
    let currentnav=document.getElementById('nav_content') as HTMLUListElement;
    currentnav.classList.add('active');
  }



}
