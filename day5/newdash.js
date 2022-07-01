// import myJson from "./cards.json" assert { type: "json" }
// show(myJson)
/*
const cards=[
    {
        image:'images/imageMask-1.svg',
        title:'Acceleration',
        subject:'Physics | Grade 7+2',
        index:'4 Units 24 Lessons 24 Topics',
        input_placeholder:"Mr. Frank's Class B",
        students:'50 Students',
        dates: '21-Jan-2020 - 21-Aug-2020',
        preview:'images/preview.svg',
        manage_course:'images/preview.svg',
        grade_sub:'images/grade submissions.svg',
        reports:'images/reports.svg'
    },
    {
        image:'images/imageMask-1.png',
        title:'Displacement, Velocity and Speed',
        subject:'Physics 2 | Grade 6 +3',
        index:'2 Units 15 Lessons 20 Topics',
        input_placeholder:"No Classes",
        students:'',
        dates: '',
        preview:'images/preview.svg',
        manage_course:'images/preview.svg',
        grade_sub:'images/grade submissions.svg',
        reports:'images/reports.svg'
    },
    {
        image:'images/imageMask-3.png',
        title:'Introduction to Biology: Micro organisms and how they affec...',
        subject:'Biology | Grade 4+1',
        index:'5 Units 16 Lessons 22 Topics',
        input_placeholder:"All Classes",
        students:'500 Students',
        dates: '',
        preview:'images/preview.svg',
        manage_course:'images/preview.svg',
        grade_sub:'images/grade submissions.svg',
        reports:'images/reports.svg'
    },
    {
        image:'images/imageMask-2.png',
        title:'Introduction to High School Mathematics',
        subject:'Mathematics | Grade 8+3',
        index:'4 Units 24 Lessons 24 Topics',
        input_placeholder:"Mr. Frank's Class A",
        students:'50 Students',
        dates: ' 14-Oct-2019 - 20-Oct-2020',
        preview:'images/preview.svg',
        manage_course:'images/preview.svg',
        grade_sub:'images/grade submissions.svg',
        reports:'images/reports.svg'
    },

]
 
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


}*/

async function getapi(url) {
   // Storing response
    const response = await fetch(url);
   // Storing data in form of JSON
    var data = await response.json();
    console.log(data);
    //show (data)
    view(data)
}
// Calling that async function
getapi('cards.json');

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
                    <h3 tabindex="0">${card.title}</h3>
                    <p>${card.subject}</p>
                    <p>
                        <b style="margin-left: 0px;">${card.units}</b> Units 
                        <b>${card.lessons}</b> Lessons 
                        <b>${card.topics}</b>Topics
                    </p>
                    <input list="name" name="name" id="browser1" placeholder="${card.input_placeholder}" role='combo box' tabindex='0'>
                        <datalist id="name">
                          <option value="${card.input_placeholder}">
                          <option value="Mr.XYZ">
                          <option value="Mr.XYZZ">
                          <option value="MrS.AAA">
                          <option value="Mr.XYAZ">
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
    let hicon=document.querySelector('.hamburger');
    if (x.style.visibility === "visible") {
      x.style.visibility = "hidden";
      x.style.opacity=0;
    //   hicon.style.filter='unset';
    hicon.setAttribute('src','images/hamburger-menu.svg')
    } else {
      x.style.visibility = "visible";
      x.style.opacity=1;
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
let aa;
async function getalert(url) {
    const response = await fetch(url);// Storing response
    aa = await response.json();// Storing data in form of JSON
     console.log(aa);
 
 }
 getalert('alerts.json');

 function alert_div()
 {  
    
     if(document.querySelector('#announce_div').style.visibility=="visible"){
        let z=document.querySelector('.badge2')
        let hicon=document.querySelector('.announce');
        z.style.display='block';
        hicon.setAttribute('src','images/announcements.svg');
        document.querySelector('#announce_div').style.visibility="hidden";
     }
    const x=document.querySelector('#alert_div');
    let z=document.querySelector('.badge1')
    let hicon=document.querySelector('.alerts');
    
    let htmlCode = `<div class="all_alerts">`;
    aa.forEach(function(alert) {
    htmlCode = htmlCode +
    `
    <div ${alert.logo=="class='zmdi zmdi-minus-circle-outline'"?'class="alert_js alert_yellow next_alert"':'class="alert_js alert_white next_alert"'} aria-label='alert message >
    <a style='text-decoration:none;color:black'>   
    <div class="alert_message">
            <h5 tabindex="0" class='heading'>${alert.content}</h5>
            <button  style='color:#1F7A54;border:0;background-color:transparent' onclick="change_alert_logo(this)" ${alert.logo}></button>
        </div>
        <div class="alert_course"><span>${alert.course==""?'':'Course : '}</span><b>${alert.course}</b></div>
        <div class="alert_class"><span>${alert.class==""?'':'Class : '}</span><b>${alert.class}</b></div>
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
    document.querySelector('.heading').focus();
    if (x.style.visibility == "visible") {
        x.style.visibility = "hidden";
        x.style.opacity=0;
        //x.style.transition='all visibility 0s, opacity 0.5s linear';
        z.style.display='block';
        document.querySelector('.alerts').focus();
        hicon.setAttribute('src','images/alerts.svg');

      } else {
        x.style.visibility = "visible";
        x.style.opacity=1;
        z.style.display='none';
        document.querySelector('.alert_message').focus();
        hicon.setAttribute('src','images/alerts_white.svg');
      }
//
     // 


     document.onkeyup = getKey;
    //
}  

function getKey(e)
{
    // if(e.keyCode==40 )
    // {
    // document.querySelector('.heading').focus();
    // }
    if(e.keyCode==27 )
    {
    const x=document.querySelector('#alert_div');
    let z=document.querySelector('.badge1')
    let hicon=document.querySelector('.alerts');
    x.style.visibility = "hidden";
        x.style.opacity=0;
        //x.style.transition='all visibility 0s, opacity 0.5s linear';
        z.style.display='block';
        document.querySelector('.alerts').focus();
        hicon.setAttribute('src','images/alerts.svg');
    }

}



function change_alert_logo(e){
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
let announce;
async function getalerts(url) {
    const response = await fetch(url);// Storing response
    announce = await response.json();// Storing data in form of JSON
     console.log(announce);
 
 }
 // Calling that async function
 getalerts('announce.json');


function announce_div(){
    if(document.querySelector('#alert_div').style.visibility=="visible"){
        let z=document.querySelector('.badge1')
        let hicon=document.querySelector('.alerts');
        z.style.display='block';
        hicon.setAttribute('src','images/alerts.svg');
        document.querySelector('#alert_div').style.visibility="hidden";
     }
    const x=document.querySelector('#announce_div');
    let z=document.querySelector('.badge2')
    let hicon=document.querySelector('.announce');
    
    let htmlCode = `<div class="all_announce">`;

    announce.forEach(function(a) {
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
        x.style.opacity=0;
        z.style.display='block';
        hicon.setAttribute('src','images/announcements.svg');
      } else {
        x.style.visibility = "visible";
        z.style.display='none';
        x.style.opacity=1;
        hicon.setAttribute('src','images/announce_white.svg');
      }
}  

