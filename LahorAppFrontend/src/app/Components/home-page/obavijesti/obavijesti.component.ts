
import {Component, Input, OnInit} from '@angular/core';

@Component({
  selector: 'app-obavijesti',
  templateUrl: './obavijesti.component.html',
  styleUrls: ['./obavijesti.component.css']
})
export class ObavijestiComponent implements OnInit {
  @Input()
  prikazObav:any;
  constructor() { }

  ngOnInit(): void {
  }

}
