import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ProfessorService } from '../services/professor.service';

@Component({
  selector: 'app-professor-form',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './professor-form.component.html',
  styleUrls: ['./professor-form.component.scss'],
})
export class ProfessorFormComponent {
  professorForm!: FormGroup;
  professorId: string | null = null;
  isEditMode = false;

  constructor(
    private fb: FormBuilder,
    private professorService: ProfessorService,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.professorForm = this.fb.group({
      name: ['', [Validators.required, Validators.maxLength(100)]],
      biography: ['', [Validators.required, Validators.maxLength(1000)]]
    });

    this.professorId = this.route.snapshot.paramMap.get('id');
    if (this.professorId) {
      this.isEditMode = true;
      this.loadProfessor();
    }
  }

  cancel(): void {
    this.router.navigate(['/']);
  }

  loadProfessor(): void {
    if (!this.professorId) return;
    this.professorService.getProfessorById(this.professorId).subscribe(professor => {
      this.professorForm.patchValue({
        name: professor.name,
        biography: professor.biography
      });
    });
  }

  saveProfessor(): void {
    if (this.professorForm.invalid) return;
    const professorData = this.professorForm.value;

    if (this.isEditMode) {
      this.professorService.updateProfessor(this.professorId!, professorData).subscribe(() => {
        this.router.navigate(['/']);
      });
    } else {
      this.professorService.createProfessor(professorData).subscribe(() => {
        this.router.navigate(['/']);
      });
    }
  }
}
