import { Component, OnInit } from '@angular/core';
import { IAddress } from '../models/address';
import { HttpService } from '../services/Http.service';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent implements OnInit {
  public forecasts: IAddress[] = [];

  constructor(private httpServie: HttpService) {
  }

  ngOnInit(): void {
    this.httpServie.get<IAddress[]>('plots').subscribe(result => {
      this.forecasts = result;
    })
  }

}