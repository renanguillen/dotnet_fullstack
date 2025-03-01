import { Routes } from '@angular/router';
import { ProfessorComponent } from './professor/professor.component';
import { ProfessorFormComponent } from './professor-form/professor-form.component';

export const routes: Routes = [
  { path: '', component: ProfessorComponent },
  { path: 'professor/create', component: ProfessorFormComponent },
  { path: 'professor/edit/:id', component: ProfessorFormComponent }
];
