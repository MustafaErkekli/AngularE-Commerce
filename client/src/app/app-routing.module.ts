import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ShopComponent } from './shop/shop.component';
import { ProductDetailsComponent } from './shop/product-details/product-details.component';
import { ServerErrorComponent } from './core/server-error/server-error.component';
import { NotFoundComponent } from './core/not-found/not-found.component';
import { TestErrorComponent } from './core/test-error/test-error.component';
import { AuthGuard } from './core/guards/auth.guard';


const routes: Routes = [
  {path:'',component:HomeComponent,data:{breadcrumb:'Home Page'}},
  {path:'test-error',component:TestErrorComponent,data:{breadcrumb:'Test Errors'}},
  {path:'server-error',component:ServerErrorComponent,data:{breadcrumb:'Server Error'}},
  {path:'not-found',component:NotFoundComponent,data:{breadcrumb:'Not Found'}},
  {path:'shop',component:ShopComponent,data:{breadcrumb:'Shop'}},
  {path:'shop/:id',component:ProductDetailsComponent,data:{breadcrumb:{alias:'shopDetail'}}},
  // {path:'basket',component:BasketComponent,data:{breadcrumb:{alias:'Basket'}}},
  {path:'basket',loadChildren:()=>import('./basket/basket.module').then(mod=>mod.BasketModule),data:{breadcrumb:{alias:'Basket'}}},
  {path:'checkout',canActivate:[AuthGuard],loadChildren:()=>import('./checkout/checkout.module').then(mod=>mod.CheckoutModule),data:{breadcrumb:{alias:'Basket'}}},
  {path:'account',loadChildren:()=>import('./account/account.module').then(mod=>mod.AccountModule),data:{breadcrumb:{skip:true}}},
  {path:'**',redirectTo:'',pathMatch:'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
