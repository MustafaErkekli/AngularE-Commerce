import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IPagination } from '../shared/models/IPagination';
import { IBrand } from '../shared/models/IBrand';
import { IProductType } from '../shared/models/IProductType';
import { map } from 'rxjs';
import { ShopParams } from '../shared/models/shopParams';
import { IProduct } from '../shared/models/IProduct';
import { environment } from '../../environments/environment';


@Injectable({
  providedIn: 'root'
})
export class ShopService {

  baseUrl=environment.apiUrl;
  
  constructor(private http:HttpClient) { }

  getProducts(shopParams:ShopParams){
    let params=new HttpParams();
    if(shopParams.brandId!==0){
      params=params.append('brandId',shopParams.brandId.toString());
    }
    if(shopParams.typeId!==0){
      params=params.append('typeId',shopParams.typeId.toString());
    }
    if(shopParams.search){
      params=params.append('search',shopParams.search);
    }
      params=params.append('sort',shopParams.sort);
      params=params.append('pageIndex',shopParams.pageNumber.toString());
      params=params.append('pageIndex',shopParams.pageSize.toString());
    
   return this.http.get<IPagination>(this.baseUrl + 'products',{observe:'response',params}).
   pipe(
    map(response=>{
      return response.body;
    })
   );
  }
  getProduct(id:number){
    return this.http.get<IProduct>(this.baseUrl+'products/'+id)
  }
  getBrands(){
    return this.http.get<IBrand[]>(this.baseUrl+'products/brands');
  }
  getTypes(){
    return this.http.get<IProductType[]>(this.baseUrl+'products/types');
  }

}
