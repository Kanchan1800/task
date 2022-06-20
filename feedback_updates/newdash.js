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
    const start = Date.now();
    show (data)
   
    //view(data)
    const duration = Date.now() - start;
   
    console.log(duration);
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
    let hicon=document.querySelector('.hamburger');
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
    const x=document.querySelector('#alert_div');
    let z=document.querySelector('.badge1')
    let y=document.querySelector('.badge1').textContent;
    let hicon=document.querySelector('.alerts');
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

//   function mouse_out() {
//     var x = document.getElementById("myLinks");
//     // if (x.style.display === "block") {
//     //   x.style.display = "none";
//     // } else {
//       x.style.display = "none";
//     // }
//   }  


  
