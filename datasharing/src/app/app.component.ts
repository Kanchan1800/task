import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  template: `
  <app-parent></app-parent>
  <app-uncle></app-uncle>
  `,
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'datasharing';
}
