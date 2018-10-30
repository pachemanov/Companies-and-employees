import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Company } from '../company.model';
import { CompanyService } from '../company.service';

@Component({
  selector: 'app-company-edit',
  templateUrl: './company-edit.component.html',
  styleUrls: ['./company-edit.component.css']
})
export class CompanyEditComponent implements OnInit {
  model = new Company('');

  constructor(private actRoute: ActivatedRoute,
  private service: CompanyService,
  private router: Router) { }

  ngOnInit() {
    this.actRoute.params.subscribe(param => {
      let currentId = +param['id'];
      this.service.get(currentId)
        .subscribe((result: Company) => {
          this.model = result;
        }, error => console.log(error));
    });
  }

  editCompany(){
    console.log(this.model);
    this.service.update(this.model)
    .subscribe((result: Company) => {
      this.router.navigate([`company-option/${this.model.companyId}`]);
    }, error  => console.log(error));
  }
}
