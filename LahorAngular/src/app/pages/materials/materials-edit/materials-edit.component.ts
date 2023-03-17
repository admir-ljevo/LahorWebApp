import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";
import {MaterialsService} from "../../../services/MaterialsService";

@Component({
  selector: 'app-materials-edit',
  templateUrl: './materials-edit.component.html',
  styleUrls: ['./materials-edit.component.scss']
})
export class MaterialsEditComponent implements OnInit {

  constructor(private route: ActivatedRoute, private router: Router,
              private materialsService: MaterialsService) { }
  private id: number;
  sub: any;
  material: any;

  ngOnInit(): void {
   this.sub = this.route.params.subscribe(params=>{
     this.id =+params['id'];
    })
    this.getMaterialById();
  }

  getMaterialById(){
    this.material = this.materialsService.getById(this.id).subscribe(data=>{
      this.material=data;
    })
  }


  editMaterial() {
    this.materialsService.update(this.material);
    this.router.navigateByUrl('materials');
  }
}
