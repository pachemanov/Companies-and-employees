import { Injectable } from '@angular/core';

@Injectable()
export class Company {

  public companyId: number;

  public creationDate: Date;

  constructor(
    public name: string
  ) { }

}