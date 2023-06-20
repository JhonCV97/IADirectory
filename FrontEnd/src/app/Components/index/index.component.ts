import { Component, OnInit, Injectable  } from '@angular/core';
import { NavBarComponent } from '../nav-bar/nav-bar.component';
import { BehaviorSubject } from 'rxjs';

declare var M: any;

@Injectable()
export class DataSharingService {
    public isUserLoggedIn: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
    public isUserRegister: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
}

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})

export class IndexComponent implements OnInit{

  constructor(private navBarComponent: NavBarComponent) {}

  token: any;

  ngOnInit() {
    document.addEventListener('DOMContentLoaded', function() {
      const elems = document.querySelectorAll('.sidenav');
      const instances = M.Sidenav.init(elems);
    });

    const elem = document.querySelector('.carousel');
    const instance = M.Carousel.init(elem,{
      indicators: true,
      duration: 400,
    });

    setInterval(() => {
      if (!instance.pressed) {
        instance.next();
      }
    }, 4000);

    this.token! = localStorage.getItem("token");

    if (this.token) {
      this.navBarComponent.refreshComponent();
    }

  }
}
