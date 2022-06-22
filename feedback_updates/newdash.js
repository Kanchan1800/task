var page=0
var limit=6
var data;
let totalpage;
async function getapi(url) {
   const response = await fetch(url);// Storing response
    data = await response.json();// Storing data in form of JSON
    console.log(data);
    const start = Date.now();
    //show (data)
    pagination()
    const duration = Date.now() - start;
    totalpage=Math.ceil(data.length/limit)
    console.log(duration);
}
// Calling that async function
getapi('cards.json');

function pagination(){
    let newlimit=limit*page+limit
    if(newlimit>data.length){
        newlimit=data.length;
        document.querySelector('.next').classList.add('disbut')
    }
    view(data.slice(limit*page,newlimit))
    console.log('first limit:'+limit*page)
    console.log("new limit"+ newlimit)
}

function nextt(){
    if(page<totalpage)
    page=page+1;
    document.querySelector('.prev').classList.remove('disbut')
    pagination();  
}
function prevv(){
    document.querySelector('.next').classList.remove('disbut')
    page=page-1;
    let newlimit=limit*page+limit
    console.log('page no:'+page)
    console.log('1st lim'+(limit*page))
    console.log('2nd lim'+(limit*page+limit))
    view(data.slice(limit*page,limit*page+limit))
    
    if(limit*page<=0){
        document.querySelector('.prev').classList.add('disbut')
    }
    else{
        document.querySelector('.prev').classList.remove('disbut')
    }
}
if(limit*page<=0){
    document.querySelector('.prev').classList.add('disbut')
}



function show(cards)
{
    for(const i of cards){
        const container=document.querySelector('.container') 
        const card=document.createElement('div')
        card.classList.add('card')
        const card_info=document.createElement('div')
        card_info.classList.add('card_info')
        const card_top=document.createElement('div')
        card_top.classList.add('card_top')
        const course_i=document.createElement('img')
        course_i.setAttribute('src',i.image)
        course_i.classList.add('course_id')
        const fav=document.createElement('img')
        fav.setAttribute('src',"images/favourite.svg")
        fav.classList.add('fav')
        const card_content=document.createElement('div')
        card_content.classList.add('card_content')
        card_content.innerHTML=`<h3>${i.title}</h3>
        <p>${i.subject}</p><p>${i.index}</p>
        <input list="name" name="name" id="browser1" placeholder="${i.input_placeholder}">
                            <datalist id="">
                              <option value="Alabama">
                              <option value="Firefox">
                              <option value="Chrome">
                              <option value="Opera">
                              <option value="Safari">
                            </datalist>
        <div class="course_dates">
            <p>${i.students} </p>
                            
            <p> <span class="dash"> </span> ${i.dates}</p>
        </div> 
        `
        card_top.appendChild(course_i)
        
        card_top.appendChild(card_content)
        card_top.appendChild(fav)
        card_info.appendChild(card_top)
        const hr=document.createElement('hr')
        hr.classList.add('card_hr')
        card_info.appendChild(hr)
        const card_footer=document.createElement('div')
        card_footer.classList.add('card_footer')
        card_footer.innerHTML=
        `
                    <img src="images/preview.svg" alt="">
                    <img src="images/manage course.svg" alt="">
                    <img src="images/grade submissions.svg" alt="">
                    <img src="images/reports.svg" alt="">
        `
        card_info.appendChild(card_footer)
        card.appendChild(card_info)
        container.appendChild(card)
    
    
    }
}

function view(cards)
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
                <img class="fav" onclick="togg(this)" src=${card.fav=='on'?"images/favourite.svg":"images/blank_star.svg"} alt="">
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
    let hicon=document.querySelector('.hamburger');
    if (x.style.display === "block") {
      x.style.display = "none";
    //   hicon.style.filter='unset';
    hicon.setAttribute('src','images/hamburger-menu.svg')
    } else {
      x.style.display = "block";
    //   hicon.style.filter='grayscale(1)';
      hicon.setAttribute('src','images/hamburger_white.svg')
    }
  }


//   function mouse_out() {
//     var x = document.getElementById("myLinks");
//     // if (x.style.display === "block") {
//     //   x.style.display = "none";
//     // } else {
//       x.style.display = "none";
//     // }
//   }  

function togg(e){
    let image=document.querySelector('.fav')
    let source='images/blank_star.svg';
    let star='images/favourite.svg';
    console.log(e.src.slice(39,59))
    if(e.src.slice(39,59)==star)
    e.setAttribute('src',source)
    else{
        e.setAttribute('src',star)
    }
    
}
function subcontent(e){
    let sub=document.querySelector(e)
    let disp=sub.style.display
    if(sub.style.display=='none'){
        sub.style.display='block'
    }
    else{
        sub.style.display='none'
    }
}
let a;
async function getalerts(url) {
    const response = await fetch(url);// Storing response
    a = await response.json();// Storing data in form of JSON
     console.log(a);
 
 }
 // Calling that async function
 getalerts('alerts.json');

 function alert_div(){
    const x=document.querySelector('#alert_div');
    let z=document.querySelector('.badge1')
    let y=document.querySelector('.badge1').textContent;
    let hicon=document.querySelector('.alerts');
    let d=`<h1>${y} Alert${parseInt(y)>1?"s":""}:</h1>`;
    
    let htmlCode = ``;

    a.forEach(function(alert) {
   htmlCode =
    htmlCode +
    `<div class="alert_message">
    <h5>${alert.content}</h5>
    <span class="alert_status">${alert.logo}</span>
    </div>
    <div class="alert_course"><span>${alert.course==""?'':'Course'}</span><b>${alert.course}</b></div>
    <div class="alert_class"><span>${alert.class==""?'':'Class'}</span><b>${alert.class}</b></div>
    <div class="alert_date">${alert.date}</div>
    `
    });
    x.innerHTML=htmlCode;
    if (x.style.display == "block") {
        x.style.display = "none";
        z.style.display='block';
        hicon.setAttribute('src','images/alerts.svg');
      } else {
        x.style.display = "block";
        z.style.display='none';
        hicon.setAttribute('src','images/alerts_white.svg');
      }
}  