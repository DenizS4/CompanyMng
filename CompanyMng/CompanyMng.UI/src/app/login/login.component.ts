import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormControl, FormGroup, Validators} from "@angular/forms";
import {Client} from "../shared/Api";
import {Router} from "@angular/router";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit{
  type: string = "password";
  isLogged: boolean = false;
  role: any;
  username: string = "";
  password: string = "";
  isText = false;
  eyeIcon: string = "fa-eye-slash";
  loginForm!: FormGroup;
  constructor(private fb: FormBuilder, private service: Client,private router: Router) {
  }
  ngOnInit(){
    this.loginForm = this.fb.group({
      username: ["",Validators.required],
      password: ["",Validators.required]
    });
  }
  hideShowPass() {
    this.isText = !this.isText;
    this.isText ? this.eyeIcon = "fa-eye" : this.eyeIcon = "fa-eye-slash";
    this.isText ? this.type = "text" : this.type = "password"
  }
  onSummit(){
    if(this.loginForm.valid){
      this.service.authUser(this.username, this.password).subscribe(x => {
        if(x){
          this.isLogged = true;
          localStorage.setItem('isLogged', JSON.stringify(this.isLogged));
          localStorage.setItem("username", this.username);
          this.router.navigate(['/dashboard']);
        }
        else
        {
          localStorage.setItem('isLogged', JSON.stringify(this.isLogged));
          alert("Invalid credentials");
        }
      })
    }
    else{
      this.validateAllFormFields(this.loginForm);
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
