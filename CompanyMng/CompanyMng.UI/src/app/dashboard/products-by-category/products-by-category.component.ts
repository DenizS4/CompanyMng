import {Component, OnInit} from '@angular/core';
import {Client} from "../../shared/Api";

@Component({
  selector: 'app-products-by-category',
  templateUrl: './products-by-category.component.html',
  styleUrls: ['./products-by-category.component.css']
})
export class ProductsByCategoryComponent implements OnInit{

  users:any = [];

  constructor(private service:Client) {
  }

  ngOnInit(): void {
    this.service.getLatestUser().subscribe(data => {
      this.users = data;
    })
  }

}
