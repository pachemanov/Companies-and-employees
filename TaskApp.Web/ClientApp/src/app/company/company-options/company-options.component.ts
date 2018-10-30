import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { CompanyService } from '../company.service';
import { Company } from '../company.model';

@Component({
  selector: 'app-company-options',
  templateUrl: './company-options.component.html',
  styleUrls: ['./company-options.component.css']
})
export class CompanyOptionsComponent implements OnInit {
  private currentId: number;
  private company: Company;
  constructor(private actRoute: ActivatedRoute, private router: Router, private service: CompanyService) { }

  ngOnInit() {
    this.actRoute.params.subscribe(param => {
      this.currentId = +param['id'];
      this.service.get(this.currentId)
      .subscribe((result: Company) => {
        this.company = result, error => console.log(error)
      });
    });
  }

  deleteCompany(){
    this.service.delete(this.currentId).subscribe(result => {
      this.router.navigate(['company-list']);
    }, error => console.log(error));
  }

  editCompany(){
    this.router.navigate(['company-list']);
  }

  addEmployee(){
    this.router.navigate([`company/${this.currentId}/employee-create`]);
  }

  viewEmployees(){
    this.router.navigate([`company/${this.currentId}/employee-list`]);
  }
}
