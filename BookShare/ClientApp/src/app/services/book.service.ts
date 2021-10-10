import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class BookService {
  _baseURL:string = "api/Books";

  constructor(private  http:HttpClient) { }
}
