import {Component, OnInit} from '@angular/core';
import {
  AddProductCommand,
  Client,
  Companies,
  DeleteProductCommand,
  Products,
  UpdateProductCommand
} from "../shared/Api";

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit{
  Prd = new Products();
  companies: any = [];
  products: any = [];
  ModalTitle = "";
  ActivateAddEdit = 0;
  constructor(private service: Client){
  }

  ngOnInit(): void {
    this.getProducts();
    this.getCompanies();
  }

  getProducts(){
    this.service.product().subscribe(data => {
      this.products = data;
    });
  }

  getCompanies(){
    this.service.company().subscribe(data => {
      this.companies = data;
    });
  }

  addProducts(item: any){
    const dto = new AddProductCommand({
      product: item
    });
    this.service.addProduct(dto).subscribe(data =>{
      window.location.reload();
    });
  }
  updateProducts(item: any){
    const dto = new UpdateProductCommand({
      product: item,
      id: item.id
    });
    this.service.updateProduct(dto).subscribe(data =>{
      window.location.reload();
    })
  }
  deleteProduct(item: any){
    const dto = new DeleteProductCommand({
      product: item,
      id: item.id
    });
    if(confirm("Are you sure?")) {
      this.service.deleteProduct(dto).subscribe(data => {
        alert("Deleted successfully");
        this.getProducts();
      });
    }
  }

  addClick() {
    this.ModalTitle = "Add Products";
    this.ActivateAddEdit = 0;
  }
  editClick(item: any) {
    this.products= item;
    this.ModalTitle = "Edit Products";
    this.ActivateAddEdit = 1;
  }
  closeClick() {
    this.ActivateAddEdit = 2;
    this.getProducts();
  }

}
