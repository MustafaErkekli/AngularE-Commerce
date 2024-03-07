import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';


@Component({
  selector: 'app-pager',
  templateUrl: './pager.component.html',
  styleUrl: './pager.component.css'
})
export default class PagerComponent implements OnInit{
  @Input()totalCount!:number;
  @Input()pageSize!:number;
  @Output()pageChanged=new EventEmitter();


  constructor(){}
  ngOnInit(): void {
  
  }
   onPagerChanged(event:any){
   this.pageChanged.emit(event.page);
}
}