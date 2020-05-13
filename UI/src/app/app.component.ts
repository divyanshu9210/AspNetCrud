import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  numbers: number[];
  title = 'Aman';

  public ngOnInit(): void {
    this.numbers = [];
    for(let i = 0; i < 10; i++) {
      this.numbers.push(i + 1);
    }
  }
}
