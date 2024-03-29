import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormControl, FormGroup, Validators} from "@angular/forms";
import {AddUserCommand, Client, Users} from "../shared/Api";

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit{
  user = new Users();
  type: string = "password";
  isText = false;
  eyeIcon: string = "fa-eye-slash";
  signupForm!: FormGroup;

  constructor(private fb: FormBuilder, private service: Client) {
  }
  ngOnInit(): void {
    this.signupForm = this.fb.group({
      firstname: ["",Validators.required],
      lastname: ["",Validators.required],
      email: ["",Validators.required],
      username: ["",Validators.required],
      password: ["",Validators.required]
    });
  }
  hideShowPass() {
    this.isText = !this.isText;
    this.isText ? this.eyeIcon = "fa-eye" : this.eyeIcon = "fa-eye-slash";
    this.isText ? this.type = "text" : this.type = "password"
  }
  addUsers(item: any){
    item.roles = 1;
    const dto = new AddUserCommand({
      user:item
    });
    this.service.addUser(dto).subscribe(data =>{
      alert("Added successfully");
    });
  }
  onSummit(){
    if(this.signupForm.valid){
      this.addUsers(this.user);
    }
    else{
      this.validateAllFormFields(this.signupForm);
      alert("Invalid credentials")
    }

  }
  private validateAllFormFields(formGroup:FormGroup){
    Object.keys(formGroup.controls).forEach(field => {
      const control = formGroup.get(field);
      if(control instanceof FormControl){
        control.markAsDirty({onlySelf:true});
      }
      else if(control instanceof FormGroup){
        this.validateAllFormFields(control);
      }
    });
  }

}
