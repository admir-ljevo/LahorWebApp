import {Component, OnInit, TemplateRef} from '@angular/core';
import {Router} from "@angular/router";
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";
import {Observable} from "rxjs";
import {LevelOfServiceExecutionService} from "../../../services/LevelOfServiceExecutionService";

@Component({
  selector: 'app-level-of-service-execution-list',
  templateUrl: './level-of-service-execution-list.component.html',
  styleUrls: ['./level-of-service-execution-list.component.scss']
})
export class LevelOfServiceExecutionListComponent implements OnInit {
  levelsOfServiceExecution$!:Observable<any[]>;
  selectedLevel: any = null;
  basicModalCloseResult: string = '';
  constructor(private levelOfServiceExecutionService: LevelOfServiceExecutionService, private router: Router,
              private modalService: NgbModal) { }

  ngOnInit(){
    this.getAll();
  }
  openBasicModal(content: TemplateRef<any>,x:any) {
    this.selectedLevel=x;
    this.modalService.open(content, {}).result.then((result:any) => {
      this.basicModalCloseResult = "Modal closed" + result
    }).catch((res:any)=>console.log(res));
  }
  getAll() {
    this.levelsOfServiceExecution$ = this.levelOfServiceExecutionService.getAll();
  }

  deleteLevel(modal: any){
    this.levelOfServiceExecutionService.delete(this.selectedLevel).subscribe(data => {
      this.getAll();
    })
    modal.close('by: save button');
  }

}
