import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { BreadcrumbService } from 'xng-breadcrumb';

@Component({
  selector: 'app-section-header',
  templateUrl: './section-header.component.html',
  styleUrl: './section-header.component.css'
})
export class SectionHeaderComponent implements OnInit {

breadcrumbs$:Observable<any[]>;

  constructor(private breadcrumpService:BreadcrumbService){}

  ngOnInit(): void {
    this.breadcrumbs$=this.breadcrumpService.breadcrumbs$;
  }

}
