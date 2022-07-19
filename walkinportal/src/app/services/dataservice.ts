import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class dataservice {
  constructor(private httpClient: HttpClient) { }

  public getWalkin(){
    return this.httpClient.get("https://localhost:7051/walkin");
  }
  public getWalkinId(id:any){
    // let url="http://localhost:3000/walkin/"+id;
    let url="https://localhost:7051/walkin/"+id;
    console.log("in service " +url);
    return this.httpClient.get(url);
  }

}
