import { Component, OnInit } from '@angular/core';
import { BasketService } from './basket/basket.service';
import { AccountService } from './account/account.service';


@Component({
  selector: 'app-first',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',


})
export class AppComponent implements OnInit {
  title = 'E-Commerce';
  constructor(
    private basketService: BasketService,
    private accountService:AccountService
    ) {}

  ngOnInit(): void {
   this.loadBasket();
   this.loadCurrentUser();
  }

  loadCurrentUser(){
    
     const token=localStorage.getItem('token');
     this.accountService.loadCurrentUser(token).subscribe(()=>{
        console.log('loaded user');
      },
      error=>{
        console.log(error);
        
      })
    

  }
  loadBasket(){
    const basketId = localStorage.getItem('baskey_id');
    if (basketId) {
      this.basketService.getBasket(basketId).subscribe(() => {
        console.log('initiliazie_basket');
      });
    }
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
