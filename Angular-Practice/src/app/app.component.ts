import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'Angular-Practice';
  name = "";
  isVisible = false;
  ngOnInit(): void {
      if(this.name.length == 0)
      {
        this.isVisible = false;
      }
      else{
        this.isVisible = true;
      }
  }
}
