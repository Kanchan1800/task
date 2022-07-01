import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';
import { map, catchError } from 'rxjs/operators';

import { IAlerts,IAnnounce, ICards } from '../shared/interface'
import { throwError } from 'rxjs';

@Injectable()
export class DataService {


  baseUrl: string = 'assets/';

  constructor(private http: HttpClient) { }

  getAlerts() : Observable<IAlerts[]> {
      return this.http.get<IAlerts[]>(this.baseUrl + 'alerts.json').pipe(catchError(this.handleError) );
  }
  getAnnouncements() : Observable<IAnnounce[]> {
    return this.http.get<IAnnounce[]>(this.baseUrl + 'announce.json').pipe(catchError(this.handleError) );
}
getCards() :Observable<ICards[]>{
  return this.http.get<ICards[]>(this.baseUrl+'cards.json').pipe(catchError(this.handleError));
}


  private handleError(error: any) {
    console.error('server error:', error);
    if (error.error instanceof Error) {
        const errMessage = error.error.message;
        return throwError(() => new Error(errMessage))
        // Use the following instead if using lite-server
        // return Observable.throw(err.text() || 'backend server error');
    }
    return throwError(() => new Error(error || 'Node.js server error'))
    //return Observable.throw(error || 'Node.js server error');
  }

}
