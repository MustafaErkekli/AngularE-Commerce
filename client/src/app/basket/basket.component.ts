import { Component, OnInit } from '@angular/core';
import { Basket, IBasket, IBasketItem } from '../shared/models/basket';
import { BasketService } from './basket.service';
import { Observable } from 'rxjs';
import { NgFor, NgIf } from '@angular/common';


@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrl: './basket.component.css',
  // standalone: true,
  // imports:[
  //   NgIf,
  //   NgFor
  // ]
})
export class BasketComponent implements OnInit{

  basket$:Observable<IBasket>;
  basket:Basket;
constructor(private basketService:BasketService){}

  ngOnInit(): void {
   this.basket$=this.basketService.basket$;
   this.basket$.subscribe(response=>{
    this.basket=response;
   });
  }
 removeBasketItem(item:IBasketItem){
this.basketService.removeItemFromBasket(item);
 }
 incrementItemQuantity(item:IBasketItem){
this.basketService.incrementItemQuantity(item);
 }
 decrementItemQuantity(item:IBasketItem){
  this.basketService.decrementItemQuantity(item);
 }
}
