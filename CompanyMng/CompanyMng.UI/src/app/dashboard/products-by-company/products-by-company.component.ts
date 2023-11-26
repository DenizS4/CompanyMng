import {Component, OnInit} from '@angular/core';
import {Client} from "../../shared/Api";


@Component({
  selector: 'app-products-by-company',
  templateUrl: './products-by-company.component.html',
  styleUrls: ['./products-by-company.component.css']
})
export class ProductsByCompanyComponent implements OnInit{

  products: any = [];

  constructor(private service: Client) {
  }
  ngOnInit(): void {
    this.service.getLatestProduct().subscribe(data => {
      this.products = data;
    })
  }

}
