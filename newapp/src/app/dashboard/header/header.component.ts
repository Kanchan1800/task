import { Component, OnInit } from '@angular/core';
import { DataService } from 'src/app/core/data.service';
import { IAlerts,IAnnounce } from 'src/app/shared/interface';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  constructor(private dataService:DataService,private router:Router ) { }
  isActive=false;
  isActiveContent=false;
  isActiveUsers=false;
  isActiveReports=false;
  isActiveAdmin=false;

  alerts:IAlerts[]=[];
  announcements:IAnnounce[]=[];
  ngOnInit(): void {
    this.dataService.getAlerts()
    .subscribe((alerts: IAlerts[]) => this.alerts = alerts);

    this.dataService.getAnnouncements()
    .subscribe((announcements: IAnnounce[]) => this.announcements = announcements);
  }



   alert_div()
  {
     let announce_div =document.querySelector('#announce_div') as HTMLDivElement
      if(announce_div.style.visibility =="visible"){
         let z=document.querySelector('.badge2') as HTMLSpanElement
         let hicon=document.querySelector('.announce') as HTMLImageElement;
         z.style.display='block';
         hicon.setAttribute('src','../assets/images/announcements.svg');
         announce_div.style.visibility="hidden";
      }
     let x=document.querySelector('#alert_div') as HTMLDivElement;
     let z=document.querySelector('.badge1')as HTMLSpanElement
     let hicon=document.querySelector('.alerts') as HTMLImageElement;

     let htmlCode = `<div class="all_alerts">`;
     this.alerts.forEach(function(alert) {
     htmlCode = htmlCode +
     `
     <div ${alert.logo=="class='zmdi zmdi-minus-circle-outline'"?'class="alert_js alert_yellow next_alert"':'class="alert_js alert_white next_alert"'} aria-label='alert message >
     <a style='text-decoration:none;color:black'>
     <div class="alert_message">
             <h5 tabindex="0" class='heading'>${alert.content}</h5>
             <button  style='color:#1F7A54;border:0;background-color:transparent' (click)="change_alert_logo(this)" ${alert.logo}></button>
         </div>
         <div class="alert_course"><span>${alert.course==""?'':'Course : '}</span><b>${alert.course}</b></div>
         <div class="alert_class"><span></span><b>${alert.class}</b></div>
         <div class="alert_date">${alert.date}</div>
         <hr style="margin:0px">
         </a>
     </div>
     `
     });
     htmlCode = htmlCode+`</div ></ul>`;
     htmlCode=htmlCode+
     `
     <button class="alertdiv_button">SHOW ALL</button>
     `

     x.innerHTML=htmlCode;
     if (x.style.visibility == "visible") {
         x.style.visibility = "hidden";
         x.style.opacity='0';
         z.style.display='block';
         hicon.setAttribute('src','../assets/images/alerts.svg');

       } else {
         x.style.visibility = "visible";
         x.style.opacity='1';
         z.style.display='none';
         hicon.setAttribute('src','../assets/images/alerts_white.svg');
       }
 }

  change_alert_logo(e:any){
  //let alert_js=document.querySelector('.alert_js')
  if(e.classList.contains('zmdi-minus-circle-outline'))
  {
  e.classList.remove('zmdi-minus-circle-outline');
  e.classList.add('zmdi-check-circle');
  // alert_js.classList.remove('alert_yellow');
  // alert_js.classList.add('alert_white');
  }
  else if(e.classList.contains('zmdi-check-circle'))
  {
  e.classList.remove('zmdi-check-circle');
  e.classList.add('zmdi-minus-circle-outline');
  // alert_js.classList.remove('alert_white');
  // alert_js.classList.add('alert_yellow');

  }

}
announce_div(){
  let alert_div =document.querySelector('#alert_div') as HTMLDivElement
  if(alert_div.style.visibility=="visible"){
      let z=document.querySelector('.badge1') as HTMLSpanElement
      let hicon=document.querySelector('.alerts') as HTMLImageElement;
      z.style.display='block';
      hicon.setAttribute('src','../assets/images/alerts.svg');
      alert_div.style.visibility="hidden";
   }
  const x=document.querySelector('#announce_div') as HTMLDivElement;
  let z=document.querySelector('.badge2') as HTMLSpanElement
  let hicon=document.querySelector('.announce') as HTMLImageElement;

  let htmlCode = `<div class="all_announce">`;

  this.announcements.forEach(function(a) {
 htmlCode =
  htmlCode +
  `
  <div ${a.logo=="class='zmdi zmdi-minus-circle-outline'"?'class="alert_js alert_yellow"':'class="alert_js alert_white"'}>
      <div class="announce_message">
          <div>
              <p style="margin:0;font-size:12px">PA : <b>${a.pa}</b></p>
              <h5 style="padding-top:5px;font-size:14px">${a.content}</h5>
          </div>
          <button  style='color:#1F7A54;border:0;background-color:transparent' onclick="change_alert_logo(this)" ${a.logo}></button>
      </div>
      <div class="announce_course"><span>${a.course==""?'':'Course : '}</span>${a.course}</div>
      <div class="announce_date">
              <div><span>${a.files==""?'':'Files : '}</span>${a.files}</div>
              <div>${a.date}</div>
      </div>
      <hr style="margin:0px">
  </div>
  `
  });
  htmlCode = htmlCode+`</div >`;
  htmlCode=htmlCode+
  `
  <div style="display:flex">
  <button class="alertdiv_button">SHOW ALL</button>
  <button class="alertdiv_button">CREATE ONE</button>
  <div>
  `
  x.innerHTML=htmlCode;
  if (x.style.visibility == "visible") {
      x.style.visibility = "hidden";
      x.style.opacity='0';
      z.style.display='block';
      hicon.setAttribute('src','../assets/images/announcements.svg');
    } else {
      x.style.visibility = "visible";
      z.style.display='none';
      x.style.opacity='1';
      hicon.setAttribute('src','../assets/images/announce_white.svg');
    }
}

myFunction(){
  var x = document.getElementById("myLinks") as HTMLDivElement;
    let hicon=document.querySelector('.hamburger') as HTMLImageElement;
    if (x.style.visibility === "visible") {
      x.style.visibility = "hidden";
      x.style.opacity='0';
    //   hicon.style.filter='unset';
    hicon.setAttribute('src','../assets/images/hamburger-menu.svg')
    } else {
      x.style.visibility = "visible";
      x.style.opacity='1';
    //   hicon.style.filter='grayscale(1)';
      hicon.setAttribute('src','../assets/images/hamburger_white.svg')
    }
}

 subcontent(e:any){
  let sub=document.querySelector(e)
  if(sub.style.display=='none'){
      sub.style.display='block'
  }
  else{
      sub.style.display='none'
  }
}
changecontentclass(){
  let nav1=document.querySelector('#nav_dashboard') as HTMLUListElement;
  let currentnav=document.getElementById('nav_content') as HTMLUListElement;
  nav1.classList.remove('active');
  currentnav.classList.add('active');
  this.router.navigate(['/content']);
}


}
