import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {LoginComponent} from "./Components/login/login.component";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent{
    title(title: any) {
        throw new Error('Method not implemented.');
    }

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
