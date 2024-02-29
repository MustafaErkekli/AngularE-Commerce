import { IProductType } from './../shared/models/IProductType';
import { Component, OnInit } from '@angular/core';
import { IProduct } from '../shared/models/IProduct';
import { ShopService } from './shop.service';
import { response } from 'express';
import { IBrand } from '../shared/models/IBrand';
import { error } from 'console';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrl: './shop.component.css'
})
export class ShopComponent implements OnInit {

  products:IProduct[]=[];
  brands:IBrand[]=[];
  types:IProductType[]=[];
  brandIdSelected:number =0;
  typeIdSelected:number =0;
  sortSelecetd='name';
  sortOptions=[
    {name:'Alphabetical',value:'name'},
    {name:'Low to High',value:'priceAsc'},
    {name:'High to Low',value:'priceDesc'}
  ];
  constructor(private shopService:ShopService){}
  ngOnInit(): void {
    this.getProduct();
    this.getBrands();
    this.getTypes();
  }

  getProduct(){
    this.shopService.getProducts(this.brandIdSelected,this.typeIdSelected,this.sortSelecetd).subscribe({next:(response:any)=>{
      this.products=response.data;
      console.log(this.products);
    },
    error:(err:any)=>{
      console.log(err);
    }});
  }
  getBrands(){
      this.shopService.getBrands().subscribe(response=>{
      var firstItem={id:0,name:'All'}
      this.brands=[firstItem,...response];
    },
    err=>{
      console.log(err);
    });
  }
  getTypes(){
      this.shopService.getTypes().subscribe(response=>{
      var firstItem={id:0,name:'All'}
      this.types=[firstItem,...response];
    },
    err=>{
      console.log(err);
    });
  }
  onBrandSelected(brandId:number){
    this.brandIdSelected=brandId;
    this.getProduct();

  }
  onTypeSeleceted(typeId:number){
    this.typeIdSelected=typeId;
    this.getProduct();
  }
  onSortSelected(sort:string){
   this.sortSelecetd=sort;
   this.getProduct();
  }
}
