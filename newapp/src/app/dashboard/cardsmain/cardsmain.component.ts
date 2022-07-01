import { HtmlParser } from '@angular/compiler';
import { Component, OnInit,Input,Output,EventEmitter } from '@angular/core';
import { DataService } from 'src/app/core/data.service';
import { ICards } from 'src/app/shared/interface';
@Component({
  selector: 'app-cardsmain',
  templateUrl: './cardsmain.component.html',
  styleUrls: ['./cardsmain.component.scss'],

})
export class CardsmainComponent implements OnInit {

      constructor( private dataService:DataService) { }

      cards:ICards[]=[];

      ngOnInit(): void {
      this.dataService.getCards()
      .subscribe((cards: ICards[]) =>
                                      {this.cards = cards;
                                        this.filteredcards=cards}
                  );
      }


filteredcards:ICards[]=[];

  filter(data: string) {
    console.log(data)
    if (data) {
      console.log(data)

          this.filteredcards = this.cards.filter((cardd: ICards) => { console.log(data)
            return cardd.title.toLowerCase().indexOf(data.toLowerCase()) > -1 || cardd.subject.toLowerCase().indexOf(data.toLowerCase()) > -1
        });

    } else {
        // this.dataService.getCards()
        // .subscribe((cards: ICards[]) => this.cards = cards);;
        this.filteredcards =this.cards;
    }
  }


}
