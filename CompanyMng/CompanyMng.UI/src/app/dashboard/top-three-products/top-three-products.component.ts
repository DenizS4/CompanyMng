import {Component, OnInit} from '@angular/core';
import {Client, Products} from "../../shared/Api";

@Component({
  selector: 'app-top-three-products',
  templateUrl: './top-three-products.component.html',
  styleUrls: ['./top-three-products.component.css']
})
export class TopThreeProductsComponent implements OnInit{
  top: Products[] = [];
  name1: string  = "";
  name2: string = "";
  name3: string = "";
  amount1: number = 0;
  amount2: number = 0;
  amount3: number = 0;
  constructor(private service:Client) {
  }

  ngOnInit(): void {

    this.service.getTopProduct().subscribe(data=>{
      this.top = data;
    });
  }



}
