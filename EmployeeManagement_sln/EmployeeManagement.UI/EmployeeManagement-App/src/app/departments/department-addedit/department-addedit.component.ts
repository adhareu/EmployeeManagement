import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FormsModule, FormBuilder,FormGroup,Validators,ReactiveFormsModule, FormControl  } from '@angular/forms';
import { HttpService } from '../../services/http.service';
import { environment } from '../../../environments/environment';
import { FormService } from '../../services/form.service';
import { AlertService } from '../../services/alert.service';
import { Department } from '../../Models/Department.Model';
@Component({
  selector: 'app-department-addedit',
  imports: [FormsModule,ReactiveFormsModule],
  templateUrl: './department-addedit.component.html',
  styleUrl: './department-addedit.component.css',
  standalone:true
})
export class DepartmentAddeditComponent implements OnInit {
title='Create New Deparment';
departmentForm: FormGroup;
constructor(private route: ActivatedRoute,
  private httpService:HttpService, 
  private formBuilder: FormBuilder,
  private formService:FormService, private alertService:AlertService ){
  this.departmentForm=this.formBuilder.group(
    {
      id:[],
      name:[
        '',
        [
          Validators.required,
          Validators.maxLength(50),
          Validators.minLength(1),
        ]
      ]
    }
  );
}
ngOnInit(): void {
  this.route.paramMap.subscribe((params) => {
  
    this.getdata(params.get('id'));
    console.log(params);
  });
}
getdata(id:any)
{
  if (typeof id == undefined || id == '' || id == null || id==0) return;
  this.httpService.get(environment.base_Url,"departments/"+id).subscribe(
      (res:any)=>{
        this.title='Edit Deparment';
        const departmentResponse= res as Department;
        this.departmentForm.patchValue(departmentResponse);
      }
    );
}
onSubmit()
{
  if(this.departmentForm.valid)
  {
    if(this.formService.isEdit(this.departmentForm.get('id') as FormControl) ){
      console.log(this.departmentForm.value);

      this.httpService.put(environment.base_Url,'departments',this.departmentForm.value,null)
      .subscribe((res:any)=>{
        
          if(res.success)
          {
            this.alertService.success(res.message);
          }else
          {
           
            this.alertService.error(res.message);
          }
            
      });
    }else
    {
      console.log('Post Method called');
      this.httpService.post(environment.base_Url,'departments',this.departmentForm.value)
      .subscribe((res:any)=>{
        console.log(res);
        if(res.success)
        {
          this.alertService.success(res.message);
        }else
          this.alertService.error(res.message);
      });
    }
  }else
  {
    this.departmentForm.markAllAsTouched();
  }
}
}
