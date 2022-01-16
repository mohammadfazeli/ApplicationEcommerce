import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IProduct } from './models/IProduct';
import { apiUrl } from './apiInfo';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  title = 'Farhad Appication Ecommerce';
  products: IProduct[] = [];

  constructor(private http: HttpClient) {}
  ngOnInit(): void {
    this.http.get(`${apiUrl}/product`).subscribe(
      (response: any) => {
        console.log(response);
        this.products=response;
      },
      (error) => {
        console.log(error);
      }
    );
  }
}
