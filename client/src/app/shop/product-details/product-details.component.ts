import { Component, OnInit } from '@angular/core';
import { IProduct } from '../../shared/models/IProduct';
import { ShopService } from '../shop.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrl: './product-details.component.css'
})
export class ProductDetailsComponent implements OnInit
{

  product:IProduct;
  constructor(private shopService:ShopService,private activateRoute:ActivatedRoute){}
  ngOnInit(): void {
  this.loadProduct();
  }
loadProduct(){
this.shopService.getProduct(this.activateRoute.snapshot.params['id']).subscribe(pro=>{
this.product=pro;
    }),
    (error:any)=>{
      console.log(error)
    }
  }
}

