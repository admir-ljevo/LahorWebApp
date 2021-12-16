import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {
  prikazObav:boolean=true;
  constructor(private router:Router,private route:ActivatedRoute) { }

  ngOnInit(): void {
  }

    OnLogOut() {
    localStorage.clear();
    this.router.navigateByUrl("/login");

  }

  prikazObavijesti() {
    this.router.navigate(['obavijesti'],{relativeTo:this.route})
  }
}
