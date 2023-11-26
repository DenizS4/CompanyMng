import { Component, OnInit } from '@angular/core';
import {
  faBox,
  faBuilding,
  faUser
} from '@fortawesome/free-solid-svg-icons';
import {Client} from "../../shared/Api";

@Component({
  selector: 'app-topwidgets',
  templateUrl: './topwidgets.component.html',
  styleUrls: ['./topwidgets.component.css']
})
export class TopwidgetsComponent implements OnInit{

  UserCount: number = 0;
  ProductCount: number = 0;
  CompanyCount: number = 0;
  faBox = faBox;
  faBuilding = faBuilding;
  faUser = faUser;

  constructor(private service: Client) {
  }

  ngOnInit(): void {
    this.service.getTotalCompany().subscribe(data => {
      this.CompanyCount = data;
    });
    this.service.getTotalProduct().subscribe(data => {
      this.ProductCount = data;
    });
    this.service.getTotalUsers().subscribe(data => {
      this.UserCount = data;
    });
  }


}
