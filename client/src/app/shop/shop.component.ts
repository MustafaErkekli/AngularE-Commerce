import { IProductType } from './../shared/models/IProductType';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { IProduct } from '../shared/models/IProduct';
import { ShopService } from './shop.service';
import { response } from 'express';
import { IBrand } from '../shared/models/IBrand';
import { error } from 'console';
import { ShopParams } from '../shared/models/shopParams';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrl: './shop.component.css'
})
export class ShopComponent implements OnInit {

  @ViewChild('search',{static:true}) searchTerm!:ElementRef;

  products:IProduct[]=[];
  brands:IBrand[]=[];
  types:IProductType[]=[];
  shopParams=new ShopParams();
  totalCount:number=0;
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
    this.shopService.getProducts(this.shopParams).subscribe({next:(response:any)=>{
      this.products=response.data;
      this.shopParams.pageNumber=response.pageIndex;
      this.shopParams.pageSize=response.pageSize;
      this.totalCount=response.count;
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
    this.shopParams.brandId=brandId;
    this.shopParams.pageNumber=1;
    this.getProduct();

  }
  onTypeSeleceted(typeId:number){
    this.shopParams.typeId=typeId;
    this.shopParams.pageNumber=1;
    this.getProduct();
  }
  onSortSelected(sort:string){
   this.shopParams.sort=sort;
   this.getProduct();
  }
  onPageChange(event:any){
    if(this.shopParams.pageNumber!==event)
    {
       this.shopParams.pageNumber=event;
       this.getProduct();
    }
 
  }
  onSearch(){
    this.shopParams.search=this.searchTerm.nativeElement.value;
    this.shopParams.pageNumber=1;
    this.getProduct();
  }
  onReset(){
    this.searchTerm.nativeElement.value="";
    this.shopParams=new ShopParams();
    this.getProduct();
    }
}
