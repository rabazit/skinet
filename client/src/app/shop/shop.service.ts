import { ShopParams } from '../shared/models/shopParams';
import { IType } from '../shared/models/productType';
import { IBrand } from '../shared/models/brand';

import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IPagination } from '../shared/models/pagination';
import { map } from 'rxjs/operators';





@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient ) { }

  getProducts(shopParams: ShopParams) {
    let params = new HttpParams();

    if (shopParams.brandId !== 0) {
      params = params.append('brandId', shopParams.brandId.toString());
    }
    if (shopParams.typeId !== 0) {
      params = params.append('typeId', shopParams.typeId.toString());
    }
    if (shopParams.search) {
      params = params.append('Search', shopParams.search);
    }

    params = params.append('sort', shopParams.sort);
    params = params.append('PageIndex', shopParams.pageNumber.toString());
    params = params.append('PageSize', shopParams.pageSize.toString());

    return this.http.get<IPagination>(this.baseUrl + 'products', {observe: 'response',  params})
                    .pipe(map(response => {
                      return response.body;
                    }));
  }

  getBrabds() {
   return  this.http.get<IBrand[]>(this.baseUrl + 'products/brands');
  }

  getTypes() {
    return  this.http.get<IType[]>(this.baseUrl + 'products/types');
   }
}
