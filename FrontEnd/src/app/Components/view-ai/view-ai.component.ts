import { Component, Injectable, OnInit } from '@angular/core';
import { NavBarComponent } from '../nav-bar/nav-bar.component';
import { BehaviorSubject } from 'rxjs';
import { environment } from "../../../environments/environment";

@Injectable()
export class DataSharingService {
    public isUserLoggedIn: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
}

@Component({
  selector: 'app-view-ai',
  templateUrl: './view-ai.component.html',
  styleUrls: ['./view-ai.component.css']
})

export class ViewAIComponent implements OnInit {

  constructor(private navBarComponent: NavBarComponent) {}
  
  array: any;
  url: string = environment.url_BackEnd;

  ngOnInit(): void {

    this.array = localStorage.getItem('IntelligenceArtificial');

    this.array = JSON.parse(this.array);

    console.log(this.array);
    

    if (localStorage.getItem("token")) {
      this.navBarComponent.refreshComponent();
    }

  }
  
}
