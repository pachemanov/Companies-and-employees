import { Component, OnInit } from '@angular/core';
import { Company } from '../company.model';
import { CompanyService } from '../company.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-company-create',
  templateUrl: './company-create.component.html',
  styleUrls: ['./company-create.component.css']
})
export class CompanyCreateComponent implements OnInit {
  model = new Company('');
  isValidForm = true;
  constructor(private service: CompanyService,
  private router: Router) { }

  ngOnInit() {
  }

  newCompany(){
    console.log(this.model);
    this.service.create(this.model)
    .subscribe((result: Company) => {
      console.log("Created company");
      console.log(result)
      this.router.navigate(['company-list']);
    }, error  => {
      console.log(error);
      this.isValidForm = false;
    });
  }
}
