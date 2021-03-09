import { Injectable, isDevMode } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PracticeTable } from '../interface/practice-table';
import * as dev from 'src/environments/environment';
import * as prod from 'src/environments/environment.prod';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class PracticeService {
  constructor(private readonly http: HttpClient) {
    if (isDevMode()) {
      this.baseUrl = dev.environment.baseUrl;
    } else {
      this.baseUrl = prod.environment.baseUrl;
    }
  }

  private baseUrl: string;

  public getPracticeTable(): Observable<PracticeTable> {
    return this.http.get<PracticeTable>(this.baseUrl + 'practice');
  }
}
