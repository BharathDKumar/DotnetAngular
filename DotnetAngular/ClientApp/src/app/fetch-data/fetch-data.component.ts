import { Component, OnInit } from '@angular/core';
import { IAddress } from '../models/address';
import { HttpService } from '../services/Http.service';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html',
  styleUrls: ['./fetch-data.component.scss']
})
export class FetchDataComponent implements OnInit {
  public addresses: IAddress[] = [];

  constructor(private httpServie: HttpService) {
  }

  ngOnInit(): void {
    this.httpServie.get<IAddress[]>('plots').subscribe(result => {
      this.addresses = result;
    })
  }
  requestEmail(address:IAddress){
    this.httpServie.post('plots/requestEmail',address).subscribe(result => {
    })
  }

}