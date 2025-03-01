import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ProfessorService } from '../services/professor.service';

@Component({
  selector: 'app-professor',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './professor.component.html',
  styleUrls: ['./professor.component.css']
})
export class ProfessorComponent implements OnInit {
  professors: any[] = [];

  constructor(private professorService: ProfessorService) {}

  ngOnInit(): void {
    this.loadProfessors();
  }

  loadProfessors(): void {
    this.professorService.getProfessors().subscribe(data => {
      this.professors = data;
    });
  }

  deleteProfessor(id: string): void {
    if (confirm('Tem certeza que deseja excluir este professor?')) {
      this.professorService.deleteProfessor(id).subscribe({
        next: () => {
          this.loadProfessors();
        },
        error: err => {
          console.error('Erro ao excluir professor:', err);
          alert('Erro ao excluir professor.');
        }
      });
    }
  }
}
