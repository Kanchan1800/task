import  Cards  from './interface/interface' 
import {Card_Footer_logo} from './types'

async function getapi(url) {
     const response = await fetch(url);// Storing response
     var data = await response.json();// Storing data in form of JSON
     console.log(data);
     view(data)
 }
 // Calling that async function
 getapi('cards.json')
 
 function view(cards:Cards[])
 {
  let htmlCode = ``;
  cards.forEach(function(card) {
    htmlCode =
     htmlCode +
     `
     <div class="card">
         <div class="card_info">
             <div class="card_top">
                 <img class="course_i" src=${card.image} alt="">
                 <div class="card_content">
                     <h3>${card.title}</h3>
                     <p>${card.subject}</p>
                     <p>
                         <b style="margin-left: 0px;">${card.units}</b> Units 
                         <b>${card.lessons}</b> Lessons 
                         <b>${card.topics}</b>Topics
                     </p>
                     <input list="name" name="name" id="browser1" placeholder="${card.input_placeholder}">
                         <datalist id="name">
                           <option value="${card.input_placeholder}">
                           <option value="Firefox">
                           <option value="Chrome">
                           <option value="Opera">
                           <option value="Safari">
                         </datalist>
                     <div class="course_dates">
                         <p>${card.students}</p>
                         
                         <p>
                          <span class="dash">${card.dash}</span> ${card.dates}</p>
                     </div>    
                 </div>
                 <img class="fav" src="images/favourite.svg" alt="">
             </div>
             <hr style="margin-top:16px">
             <div class="card_footer">
                 <img ${card.p1} src="images/preview.svg" alt="">
                 <img ${card.p2} src="images/manage course.svg" alt="">
                 <img ${card.p3} src="images/grade submissions.svg" alt="">
                 <img ${card.p4} src="images/reports.svg" alt="">
             </div>
 
         </div>
     </div>
   `;
 });
 
 const contain = document.querySelector(".container");
 
 contain.innerHTML = htmlCode;
 
 }
 
 function myFunction() {
     var x = document.getElementById("myLinks");
     let hicon=document.querySelector('.hamburger') as HTMLImageElement;
     if (x.style.display === "block") {
       x.style.display = "none";
       hicon.style.filter='unset';
     } else {
       x.style.display = "block";
       hicon.style.filter='grayscale(1)';
     }
   }
 function alert_div(){
     let a=['Subscribe','Complete your profile','Update']
     const x=document.querySelector('#alert_div') as HTMLDivElement;
     let z=document.querySelector('.badge1')
     let y=document.querySelector('.badge1').textContent;
     let hicon=document.querySelector('.alerts') as HTMLImageElement;
     let d=`<h1>${y} Alert${parseInt(y)>1?"s":""}:</h1>`;
     
     for (let i=0;i<parseInt(y);i++)
     {
     d=d+`
     <p>${a[i]}</p>
     `
     }
     x.innerHTML=d;
     if (x.style.display === "block") {
         x.style.display = "none";
         hicon.style.filter='unset';
       } else {
         x.style.display = "block";
         
         hicon.style.filter='grayscale(1)';
       }
 }  