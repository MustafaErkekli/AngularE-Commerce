import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit{

  slides: any[] = new Array(3).fill({id: -1, src: '', title: '', subtitle: ''});

  constructor() {}

  ngOnInit(): void {
    this.slides[0] = {
      src: 'assets/imgages/slide.jpg',
    };
    this.slides[1] = {
      src: 'assets/imgages/slide.jpg',
    }
    this.slides[2] = {
      src: 'assets/imgages/slide.jpg',
    }
  }

  onItemChange($event: any): void {
    console.log('Carousel onItemChange', $event);
  }
}
