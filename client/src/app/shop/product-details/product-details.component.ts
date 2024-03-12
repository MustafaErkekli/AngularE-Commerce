import { Component, OnInit } from '@angular/core';
import { IProduct } from '../../shared/models/IProduct';
import { ShopService } from '../shop.service';
import { ActivatedRoute } from '@angular/router';
import { BreadcrumbService } from 'xng-breadcrumb';
import { BasketService } from '../../basket/basket.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrl: './product-details.component.css'
})
export class ProductDetailsComponent implements OnInit
{

  product:IProduct;
  quantity=1;
  constructor(private shopService:ShopService,
    private activateRoute:ActivatedRoute,
    private breadcrumbService:BreadcrumbService,
    private basketService:BasketService
    ){}
  ngOnInit(): void {
  this.loadProduct();
  }
  addItemToBasket(){
    this.basketService.addItemToBasket(this.product,this.quantity);
  }
  incrementQuantity(){
    this.quantity ++;
  }
  decrementQuantity(){
    if(this.quantity>1)
    this.quantity --;
  }

loadProduct(){
this.shopService.getProduct(this.activateRoute.snapshot.params['id']).subscribe(pro=>{
this.product=pro;
this.breadcrumbService.set('@shopDetail',this.product.name);
    }),
    (error:any)=>{
      console.log(error)
    }
  }
}

