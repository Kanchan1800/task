import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DataService } from 'src/app/core/data.service';
import { IUsers } from 'src/app/shared/interface';


@Component({
  selector: 'app-login-main',
  templateUrl: './login-main.component.html',
  styleUrls: ['./login-main.component.scss']
})
export class LoginMainComponent implements OnInit {

  constructor(private router: Router,private dataservice :DataService) { }

  ngOnInit(): void {
    this.dataservice.getUsers().subscribe((users: IUsers[]) =>
    {this.user = users;}
);;
  }


 user:IUsers[]=[];

 getValues(data:any){
  console.warn(data);
  console.warn(data['choice'])
  let valid=false;
  let u=this.user.forEach((u)=>{
   if( u.username==data['username'] && u.password==data['password'])
   {console.warn('valid user');
   valid=true
   this.router.navigate(['/dashboard'])
  }
  })
  if(valid===false)
  alert('Invalid user please enter correct details')

 }
}
