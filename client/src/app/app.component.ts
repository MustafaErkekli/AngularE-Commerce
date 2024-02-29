import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-first',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  title = 'E-Commerce';
  constructor(){ }

ngOnInit(): void {
  // this.http.get<IPagination>('https://localhost:44349/api/products').subscribe({next:(response:IPagination)=>{
  // this.products=response.data;
  // },
  // error:(err:any)=>{
  //   console.log(err);
  // }});
  
}

}
// subscribe((response:any)=>{
//   this.products=response.data;
//  },
//  error=>{
//    console.log(error);
//  });