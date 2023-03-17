import { Component, OnInit } from '@angular/core';
import {LevelOfServiceExecutionService} from "../../../services/LevelOfServiceExecutionService";
import {Router} from "@angular/router";
import {LevelOfServiceExecution} from "../../../models/level-of-service-execution";

@Component({
  selector: 'app-level-of-service-execution-add',
  templateUrl: './level-of-service-execution-add.component.html',
  styleUrls: ['./level-of-service-execution-add.component.scss']
})
export class LevelOfServiceExecutionAddComponent implements OnInit {
  levelOfServiceExecution: LevelOfServiceExecution = new LevelOfServiceExecution();
  constructor(private levelOfServiceExecutionService: LevelOfServiceExecutionService, private router: Router) { }

  ngOnInit(): void {
  }

  addLevelOfServiceExecution(){
    this.levelOfServiceExecutionService.post(this.levelOfServiceExecution).subscribe(data => {
      this.router.navigateByUrl("/level-of-service-execution");
    })
  }

}
