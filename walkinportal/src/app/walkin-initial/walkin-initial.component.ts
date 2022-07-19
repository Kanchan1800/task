import { Component, OnInit } from '@angular/core';
import { dataservice } from '../services/dataservice';
import { Router } from '@angular/router';

@Component({
  selector: 'app-walkin-initial',
  templateUrl: './walkin-initial.component.html',
  styleUrls: ['./walkin-initial.component.scss']
})
export class WalkinInitialComponent implements OnInit {

  constructor(private router: Router,private dataservice: dataservice) { }
 walkins:any;
  ngOnInit(){
    this.dataservice.getWalkin().subscribe((data)=>{
      console.log(data);
      this.walkins = data;
      for (let w of this.walkins)
      {
        console.log(w.Title)
      }
    });

  }


}
