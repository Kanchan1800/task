import { Component, OnInit } from '@angular/core';
import { dataservice } from 'src/app/services/dataservice';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-walkin-info',
  templateUrl: './walkin-info.component.html',
  styleUrls: ['./walkin-info.component.scss']
})
export class WalkinInfoComponent implements OnInit {

  constructor(private dataservice:dataservice,private route: ActivatedRoute) { }
  walkin:any;
  ngOnInit(): void {

    let id =  Number(this.route.snapshot.paramMap.get('id'));
    console.log(id);



    this.dataservice.getWalkinId(id).subscribe((walkin: any) => {
      console.log("in component");
      console.log(walkin);
      this.walkin = walkin;
    });


  }
 showdetails() {
  let a= document.getElementById('pre_requisites_details') as HTMLDivElement;
  a.style.display=="none"?a.style.display="block":a.style.display="none";
}
fileSelect()
{
  let inputfile=document.getElementById('upload') as HTMLInputElement
  inputfile.click();
}
showRolesDescription(e:any){

  let description=document.getElementById(e+'description') as HTMLDivElement;
  description.style.display=="none"?description.style.display="block":description.style.display="none";

}

}
