import { Component, OnInit } from '@angular/core';
import { ICustomer } from '../shared/interface';
import { DataService } from '../core/data.service';


@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.scss']
})
export class CustomersComponent implements OnInit {
  title: string='';
  people: ICustomer[]=[];
  isVisible = true;//yeh false kiya toh html ke andar ka title hide ho jayega--property binding!!!!

  changeVisibility() {
    this.isVisible = !this.isVisible;
  }
  constructor(private dataService: DataService) {

  }

  ngOnInit() {
    this.title = 'Customers';
    this.dataService.getCustomers()
        .subscribe((customers: ICustomer[]) => this.people = customers);
  }
}
