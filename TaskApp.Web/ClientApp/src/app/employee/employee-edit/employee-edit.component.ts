import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { Employee } from '../employee.model';
import { Company } from '../../company/company.model';
import { ActivatedRoute, Router } from '@angular/router';
import { EmployeeService } from '../employee.service';
import { CompanyService } from '../../company/company.service';
import { ExperienceLevel } from '../experienceLevel.enum';

@Component({
  selector: 'app-employee-edit',
  templateUrl: './employee-edit.component.html',
  styleUrls: ['./employee-edit.component.css']
})
export class EmployeeEditComponent implements OnInit {
  @ViewChild('expLevel') expLevelRef: ElementRef;

  companyId: number;
  model = new Employee();
  company: Company;
  startingDate: string;
  expLevel = ['A', 'B', 'C', 'D'];
  expLevelSelect: string;
  isValidForm = true;


  constructor(private actRoute: ActivatedRoute, 
    private router: Router, 
    private service: EmployeeService,
    private cService: CompanyService) { 
      // this.keys = Object.keys(this.level).filter(Number);
    }

  ngOnInit() {
    this.actRoute.params.subscribe(param => {
      let companyId = +param['compId'];
      let employeeId = +param['empId'];

      this.service.get(employeeId)
      .subscribe((result: Employee) => {
        this.model = result;
        this.expLevelSelect = this.expLevel[this.model.experienceLevel];
        this.startingDate = this.model.startingDate.toString().split('T')[0];
      }, error => console.log(error));

      this.cService.get(companyId)
      .subscribe((result: Company) => this.company = result, 
        error => console.log(error));
    });
  }

  updateEmployee(){
    this.model.startingDate = new Date(this.startingDate);
    console.log(ExperienceLevel[this.expLevelSelect]);
    this.model.experienceLevel = ExperienceLevel[this.expLevelSelect];
    console.log(this.model);
    this.service.update(this.model)
    .subscribe((result: Employee) => {
      this.router.navigate([`company/${this.company.companyId}/employee-list`])
    }, 
    error =>{
      console.log(error);
      this.isValidForm = false;
    });
  }

  returnToList(){
    this.router.navigate([`company/${this.company.companyId}/employee-list`]);
  }

  deleteEmployee(){
    this.service.delete(this.model.employeeId)
    .subscribe((result: Employee) => {
      console.log(result);
      this.router.navigate([`company/${this.company.companyId}/employee-list`]);
    }, error => console.log(error));
  }
}
