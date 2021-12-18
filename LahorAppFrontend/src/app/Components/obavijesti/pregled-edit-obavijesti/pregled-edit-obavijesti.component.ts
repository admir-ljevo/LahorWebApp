import {Component, Input, OnInit} from '@angular/core';
import {Obavijest} from "../../../Model/Obavijest";
import {ResponseModel} from "../../../Model/ResponseModel";
import {MyConfig} from "../../../MyConfig";
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-pregled-edit-obavijesti',
  templateUrl: './pregled-edit-obavijesti.component.html',
  styleUrls: ['./pregled-edit-obavijesti.component.css']
})
export class PregledEditObavijestiComponent implements OnInit {

  @Input()
  urediObavijest:Obavijest;
  constructor(private httpClient:HttpClient) { }

  ngOnInit(): void {
  }

  snimi() {
    this.httpClient.post<ResponseModel>(MyConfig.adresa_servera+ "Obavijest/UpdateObavijest/" + this.urediObavijest.id, this.urediObavijest
    ).subscribe((data:any) =>{
      console.log("Obavijest uspješno modifikovana "+data.dataSet)
      this.urediObavijest.prikazi = false;
    });
  }
}
