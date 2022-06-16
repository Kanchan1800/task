const img=document.querySelector('.urlimg');
const fcolor=document.querySelector('.fcolor');
const fwidth=document.querySelector('.fwidth');
const image=document.querySelector('.mypic');
let url = "";
let width = 10;
let color = "#000000";

function updates(urlimg,fcolor,fwidth){
    image.style.display = "block";
    image.style.borderStyle = "solid";
    image.style.backgroundImage = "url(" + url + ")";
    image.style.borderWidth = width + "px";
    image.style.borderColor = color; 
    
}
img.addEventListener("change", () => {
    url = img.value;
    updates(url, width, color);
})

fwidth.addEventListener("change", () => {
    width = fwidth.value;
    updates(url, width, color);
})

fcolor.addEventListener("change", () => {
    color = fcolor.value;
    updates(url, width, color);
})
