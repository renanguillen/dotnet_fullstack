import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProfessorService {
  private apiUrl = 'http://localhost:5074/api/Professor';

  constructor(private http: HttpClient) {}

  getProfessors(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }

  getProfessorById(id: string): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/${id}`);
  }

  createProfessor(professor: any): Observable<any> {
    return this.http.post(this.apiUrl, professor);
  }

  updateProfessor(id: string, professor: any): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, professor);
  }

  deleteProfessor(id: string): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
