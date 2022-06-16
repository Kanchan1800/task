const container=document.querySelector('.container')
const button=document.querySelector('button')
const mytext=document.querySelector('.mytext')
function showtext(){
    const text=document.querySelector('.text')
    // const newtext=document.createElement('h5');
    if(text.style.display ==="block"){
        text.style.display ="none"
        button.innerText="Show Text"
        text.innerText="Hello,How are you?"
    }
    else{
         text.style.display ="block"
         text.innerText+=mytext.value;
        //  newtext.innerHTML=mytext.value;
        //  container.appendChild(newtext)
        button.innerText="Hide Text"
    }
    
}
button.addEventListener("onclick",()=>{
    showtext();
})
mytext.addEventListener("change",()=>{
    showtext();
})