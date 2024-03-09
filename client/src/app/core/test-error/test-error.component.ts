import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from '../../../environments/environment';
import { response } from 'express';
import { error } from 'console';

@Component({
  selector: 'app-test-error',
  templateUrl: './test-error.component.html',
  styleUrl: './test-error.component.css'
})
export class TestErrorComponent implements OnInit {
  baseUrl=environment.apiUrl;
  validationError:any;
constructor(private  http:HttpClient){}

  ngOnInit(): void {
  
  }

  get400ValidationError(){
    this.http.get(this.baseUrl+'products/fortytwo').subscribe(response=>{
      console.log(response)
    },
    error=>{
  console.log(error)
  this.validationError=error.errors.id;
    });
  }

  get500Error(){
    this.http.get(this.baseUrl+'buggy/servererror').subscribe({next:(response:any)=>{
      console.log(response)
    },
    error:(err:any)=>{
  console.log(err)
    }});
  }

  get400Error(){
    this.http.get(this.baseUrl+'buggy/badrequet').subscribe(response=>{
      console.log(response)
    },
    error=>{
  console.log(error)
    });
  }

get404Error(){
  this.http.get(this.baseUrl+'buggy/badrequest').subscribe(response=>{
    console.log(response)
  },
  error=>{
console.log(error)
  });
}



}
