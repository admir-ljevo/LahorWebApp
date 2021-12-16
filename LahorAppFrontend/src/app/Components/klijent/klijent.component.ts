import { Component, OnInit } from '@angular/core';
import {User} from "../../Model/User";
import {UserService} from "../../services/user.service";
import {KlijentFizickoService} from "../../services/klijent-fizicko.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-klijent',
  templateUrl: './klijent.component.html',
  styleUrls: ['./klijent.component.css']
})
export class KlijentComponent implements OnInit {

  public userList: User[] = [];
  constructor(private userService:UserService,private klijentFizickoService:KlijentFizickoService,
              private router:Router) { }

  ngOnInit(): void {
  }

  getAllUser()
  {
    this.userService.getUserList().subscribe((data: User[]) => {
      this.userList = data;
    })
  }

  getKlijentById()
  {
    var id=JSON.parse(localStorage.getItem("auth-token")).korisnik.id;
    this.klijentFizickoService.getKlijentFizickoById(id);
  }
}
