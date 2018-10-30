import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EmployeeService } from '../employee.service';
import { CompanyService } from '../../company/company.service';
import { Company } from '../../company/company.model';
import { Employee } from '../employee.model';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent implements OnInit {
  company: Company;
  employees: Employee[];

  constructor(private actRoute: ActivatedRoute, 
    private router: Router,
    private service: EmployeeService,
    private cService: CompanyService) { 
    }

    ngOnInit() {
      this.actRoute.params.subscribe(param => {
        let companyId = +param['id'];
        
        this.service.allByCompany(companyId)
        .subscribe((result: Employee[]) => this.employees = result, 
          error => console.log(error));

        this.cService.get(companyId)
        .subscribe((result: Company) => this.company = result, 
          error => console.log(error));
      });
    }

    backToOptions(){
      this.router.navigate([`company-option/${this.company.companyId}`]);
    }
}
