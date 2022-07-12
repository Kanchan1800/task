"use strict";
//start moving--pending
//completef moving --resolve
//did not complete moving process -- reject

async function getjson (url:string){
    const response=await fetch(url)
    var data = await response.json();
    return await fetch(url).then((data)=>data.json());
}
getjson('cards.json').then((data)=>console.log(data));

async function getapi(url){
         const response = await fetch(url);// Storing response
         var data = await response.json();// Storing data in form of JSON
         console.log(data);
         return data
     }
 getapi('cards.json')   ;