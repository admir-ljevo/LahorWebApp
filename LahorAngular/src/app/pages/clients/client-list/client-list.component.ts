import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ClientsService } from 'src/app/services/ClientsService';
import { MyConfig } from 'src/app/shared/MyConfig';

@Component({
  selector: 'app-client-list',
  templateUrl: './client-list.component.html',
  styleUrls: ['./client-list.component.scss'],
})
export class ClientsListComponent implements OnInit {
  clients: any;
  baseUrl = MyConfig.address_server_base;
  imgSrc: any = '../../../assets/images/others/blank-user.jpg';
  constructor(private router: Router, private clientsService: ClientsService) {}

  ngOnInit(): void {
    this.getClients();
  }

  getClients() {
    this.clientsService.getClients().subscribe((data) => {
      this.clients = data;
    });
  }

  public createImageUrl = (imgSrc: string) => {
    if (imgSrc != null) {
      return MyConfig.address_server_base + imgSrc;
    }
    return this.imgSrc;
  };
}
