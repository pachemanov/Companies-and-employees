import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EmployeeService } from '../employee.service';
import { Employee } from '../employee.model';
import { ExperienceLevel } from '../experienceLevel.enum';
import { Company } from '../../company/company.model';
import { CompanyService } from '../../company/company.service';

@Component({
  selector: 'app-employee-create',
  templateUrl: './employee-create.component.html',
  styleUrls: ['./employee-create.component.css']
})
export class EmployeeCreateComponent implements OnInit {
  companyId: number;
  model = new Employee();
  company: Company;
  expLevel = ['A', 'B', 'C', 'D'];
  isValidForm = true;


  constructor(private actRoute: ActivatedRoute, 
    private router: Router, 
    private service: EmployeeService,
    private cService: CompanyService) { 
    }

  ngOnInit() {
    this.actRoute.params.subscribe(param => {
      let companyId = +param['id'];
      this.cService.get(companyId)
      .subscribe((result: Company) => this.company = result, 
        error => console.log(error));
    });
  }

  checkForm(){
    if(this.model.firstName == ''){
      this.isValidForm = false;
      console.log()
    }

    if(this.model.lastname == ''){
      this.isValidForm = false;
    }

    if(this.model.salary == 0){
      this.isValidForm = false;
    }

    if(this.model.vacationDays == 0){
      this.isValidForm = false;
    }
  }

  newEmployee(){
      this.model.companyId = this.company.companyId;
      this.service.create(this.model)
      .subscribe((result: Employee) => {
        this.router.navigate([`company-option/${this.company.companyId}`]);
      }, 
      error => {
        console.log(error);
        this.isValidForm = false;
      });
  }
}
