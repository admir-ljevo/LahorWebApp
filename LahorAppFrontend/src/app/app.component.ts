import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent{

  bracniStatusiPodaci:any;
  constructor(private httpKlijent: HttpClient) {
  }


getBracniStatus(){
    return this.bracniStatusiPodaci;
}
  testirajWebApi() :void
  {
    this.httpKlijent.get("https://localhost:44365/BracniStatusi/GetAll").subscribe(x=>{
      this.bracniStatusiPodaci = x;
    });
  }
}
