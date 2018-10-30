import { Injectable } from '@angular/core';
import { ExperienceLevel } from './experienceLevel.enum';

@Injectable()
export class Employee {
  constructor() { }
  
  employeeId: number;

  firstName: string;

  lastname: string;

  experienceLevel: ExperienceLevel;

  startingDate: Date;

  salary: number;

  vacationDays: number;

  companyId: number;

}
