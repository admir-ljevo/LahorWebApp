import { Component, OnInit } from '@angular/core';
import {Router} from "@angular/router";
import {MaterialsService} from "../../../services/MaterialsService";
import {MaterialModel} from "../../../models/material-model";
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";

@Component({
  selector: 'app-materials-add',
  templateUrl: './materials-add.component.html',
  styleUrls: ['./materials-add.component.scss']
})
export class MaterialsAddComponent implements OnInit {

  material: MaterialModel = new MaterialModel()
  constructor(private router: Router, private materialsService: MaterialsService,
              private modalService: NgbModal) { }

  ngOnInit(): void {
  }

  addMaterial() {
    this.materialsService.post(this.material).subscribe(data=>{
      this.router.navigateByUrl('/materials');
    })
  }



}
