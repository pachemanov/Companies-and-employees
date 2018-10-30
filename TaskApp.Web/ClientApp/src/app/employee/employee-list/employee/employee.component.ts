import { Component, OnInit, Input } from '@angular/core';
import { Employee } from '../../employee.model';
import { Router } from '@angular/router';
import { ExperienceLevel } from '../../experienceLevel.enum';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {
  @Input() employee: Employee;
  level = ExperienceLevel;

  constructor(private router: Router) { }

  ngOnInit() {
  }

  navigatoToEdit(){
    this.router.navigate([`company/${this.employee.companyId}/employee-edit/${this.employee.employeeId}`]);
  }
}
