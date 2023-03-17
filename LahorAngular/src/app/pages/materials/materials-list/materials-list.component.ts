import {Component, OnInit, TemplateRef} from '@angular/core';
import {Router} from "@angular/router";
import {MaterialsService} from "../../../services/MaterialsService";
import {Observable} from "rxjs";
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";

@Component({
  selector: 'app-materials-list',
  templateUrl: './materials-list.component.html',
  styleUrls: ['./materials-list.component.scss']
})
export class MaterialsListComponent implements OnInit {

  materials$: Observable<any[]>;
  basicModalCloseResult: string = '';
  selectedMaterial: any;
  changeDirection: boolean = false;
  sortDir: string= 'asc';
  sortCol: string = 'name';
  nameFilter: string = '';
  tableHeadingColor: string;
  constructor(private router: Router,private modalService: NgbModal , private materialsService: MaterialsService) { }

  ngOnInit(): void {
    this.getMaterials();
    this.tableHeadingColor = '#4e42f7'
  }

  sortData(event: Event){
    this.sortCol === (event.target as Element).id? this.changeDirection=true: this.changeDirection=false;
    this.sortCol = (event.target as Element).id;
    if(this.changeDirection && this.sortDir==="asc")
      this.sortDir="desc"
    else if(this.changeDirection && this.sortDir==="desc")
      this.sortDir="asc";
    else this.sortDir="asc";
    const tableHeader = document.getElementById((event.target as Element).id);
    const tableHeaders = document.getElementsByTagName("th");
    // @ts-ignore
    for (const th of tableHeaders) {
      if(th.id != (event.target as Element).id)
        th.style.color="gray";
    }
    // @ts-ignore
    tableHeader.style.color='#4e42f7';
    this.getMaterials();
  }


  addMaterial(){
    this.router.navigateByUrl('materials/materials-add')
  }

  getMaterials(){
    this.materials$ = this.materialsService.getMaterialsSorted(this.sortCol,this.sortDir, this.nameFilter);
  }

  openBasicModal(content: TemplateRef<any>,x:any){
    this.selectedMaterial = x;
    this.modalService.open(content, {}).result.then((result:any) => {
      this.basicModalCloseResult = "Modal closed" + result
    }).catch((res:any)=>console.log(res));
  }

  deleteMaterial(modal: any) {
    this.materialsService.delete(this.selectedMaterial).subscribe(data=>{
      this.getMaterials();
    })
    modal.close('by: save button');
  }

  editMaterial(material: any) {
    this.router.navigate(['materials/materials-edit/', material.id]);
  }

}
