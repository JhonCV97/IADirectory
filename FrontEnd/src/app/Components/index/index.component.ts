import { Component, OnInit } from '@angular/core';

declare var M: any;

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent implements OnInit{
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
  }
}
