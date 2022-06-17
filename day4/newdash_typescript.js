// import  Cards  from './interface/interface' 
// import {Card_Footer_logo} from './types'
// async function getapi(url) {
//      const response = await fetch(url);// Storing response
//      var data = await response.json();// Storing data in form of JSON
//      console.log(data);
//      view(data)
//  }
//  // Calling that async function
//  getapi('cards.json')
var c = [
    {
        image: 'images/imageMask-1.svg',
        title: 'Acceleration',
        subject: 'Physics | Grade 7+2',
        index: '4 Units 24 Lessons 24 Topics',
        input_placeholder: "Mr. Frank's Class B",
        students: '50 Students',
        dates: '21-Jan-2020 - 21-Aug-2020',
        preview: 'images/preview.svg',
        manage_course: 'images/preview.svg',
        grade_sub: 'images/grade submissions.svg',
        reports: 'images/reports.svg'
    },
    {
        image: 'images/imageMask-1.png',
        title: 'Displacement, Velocity and Speed',
        subject: 'Physics 2 | Grade 6 +3',
        index: '2 Units 15 Lessons 20 Topics',
        input_placeholder: "No Classes",
        students: '',
        dates: '',
        preview: 'images/preview.svg',
        manage_course: 'images/preview.svg',
        grade_sub: 'images/grade submissions.svg',
        reports: 'images/reports.svg'
    },
    {
        image: 'images/imageMask-3.png',
        title: 'Introduction to Biology: Micro organisms and how they affec...',
        subject: 'Biology | Grade 4+1',
        index: '5 Units 16 Lessons 22 Topics',
        input_placeholder: "All Classes",
        students: '500 Students',
        dates: '',
        preview: 'images/preview.svg',
        manage_course: 'images/preview.svg',
        grade_sub: 'images/grade submissions.svg',
        reports: 'images/reports.svg'
    },
    {
        image: 'images/imageMask-2.png',
        title: 'Introduction to High School Mathematics',
        subject: 'Mathematics | Grade 8+3',
        index: '4 Units 24 Lessons 24 Topics',
        input_placeholder: "Mr. Frank's Class A",
        students: '50 Students',
        dates: ' 14-Oct-2019 - 20-Oct-2020',
        preview: 'images/preview.svg',
        manage_course: 'images/preview.svg',
        grade_sub: 'images/grade submissions.svg',
        reports: 'images/reports.svg'
    },
];
function view(cards) {
    var htmlCode = "";
    cards.forEach(function (card) {
        htmlCode =
            htmlCode +
                "\n     <div class=\"card\">\n         <div class=\"card_info\">\n             <div class=\"card_top\">\n                 <img class=\"course_i\" src=".concat(card.image, " alt=\"\">\n                 <div class=\"card_content\">\n                     <h3>").concat(card.title, "</h3>\n                     <p>").concat(card.subject, "</p>\n                     <p>\n                         <b style=\"margin-left: 0px;\">").concat(card.units, "</b> Units \n                         <b>").concat(card.lessons, "</b> Lessons \n                         <b>").concat(card.topics, "</b>Topics\n                     </p>\n                     <input list=\"name\" name=\"name\" id=\"browser1\" placeholder=\"").concat(card.input_placeholder, "\">\n                         <datalist id=\"name\">\n                           <option value=\"").concat(card.input_placeholder, "\">\n                           <option value=\"Firefox\">\n                           <option value=\"Chrome\">\n                           <option value=\"Opera\">\n                           <option value=\"Safari\">\n                         </datalist>\n                     <div class=\"course_dates\">\n                         <p>").concat(card.students, "</p>\n                         \n                         <p>\n                          <span class=\"dash\">").concat(card.dash, "</span> ").concat(card.dates, "</p>\n                     </div>    \n                 </div>\n                 <img class=\"fav\" src=\"images/favourite.svg\" alt=\"\">\n             </div>\n             <hr style=\"margin-top:16px\">\n             <div class=\"card_footer\">\n                 <img ").concat(card.p1, " src=\"images/preview.svg\" alt=\"\">\n                 <img ").concat(card.p2, " src=\"images/manage course.svg\" alt=\"\">\n                 <img ").concat(card.p3, " src=\"images/grade submissions.svg\" alt=\"\">\n                 <img ").concat(card.p4, " src=\"images/reports.svg\" alt=\"\">\n             </div>\n \n         </div>\n     </div>\n   ");
    });
    var contain = document.querySelector(".container");
    contain.innerHTML = htmlCode;
}
view(c);
function myFunction() {
    var x = document.getElementById("myLinks");
    var hicon = document.querySelector('.hamburger');
    if (x.style.display === "block") {
        x.style.display = "none";
        hicon.style.filter = 'unset';
    }
    else {
        x.style.display = "block";
        hicon.style.filter = 'grayscale(1)';
    }
}
function alert_div() {
    var a = ['Subscribe', 'Complete your profile', 'Update'];
    var x = document.querySelector('#alert_div');
    var z = document.querySelector('.badge1');
    var y = document.querySelector('.badge1').textContent;
    var hicon = document.querySelector('.alerts');
    var d = "<h1>".concat(y, " Alert").concat(parseInt(y) > 1 ? "s" : "", ":</h1>");
    for (var i = 0; i < parseInt(y); i++) {
        d = d + "\n     <p>".concat(a[i], "</p>\n     ");
    }
    x.innerHTML = d;
    if (x.style.display === "block") {
        x.style.display = "none";
        hicon.style.filter = 'unset';
    }
    else {
        x.style.display = "block";
        hicon.style.filter = 'grayscale(1)';
    }
}
