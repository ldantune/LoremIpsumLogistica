import { Component, OnInit, TemplateRef } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatTableModule } from '@angular/material/table';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Cadastro } from '../../models/Cadastro';
import { CadastroService } from '../../services/CadastroService';
import { CommonModule, DatePipe } from '@angular/common';
import { MatSelectModule } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import {
  AbstractControl,
  FormBuilder,
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-cadastros',
  templateUrl: './cadastros.component.html',
  styleUrls: ['./cadastros.component.css'],
  standalone: true,
  imports: [
    MatTableModule,
    MatCardModule,
    CommonModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  providers: [DatePipe],
})
export class CadastrosComponent implements OnInit {
  title: string = 'Novo Cadastro';
  form!: FormGroup;
  cadastro = {} as Cadastro;
  estadoSalvar = 'post';
  modalRef?: BsModalRef;
  public cadastros: Cadastro[] = [];
  public cadastroId = 0;

  get f(): any {
    return this.form.controls;
  }

  get modoEditar(): boolean {
    return this.estadoSalvar === 'put';
  }

  constructor(
    private fb: FormBuilder,
    private cadastroService: CadastroService,
    private modalService: BsModalService,
    private datePipe: DatePipe,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
  ) {}

  ngOnInit() {
    this.carregarCadastros();
    this.validation();
  }

  private carregarCadastros(): void {
    this.cadastros = [];
    this.cadastroService.getCadastros().subscribe(
      (cadastroRetorno: Cadastro[]) => {
        console.log(cadastroRetorno);
        if (cadastroRetorno != null) {
          cadastroRetorno.forEach((cadastro) => {
            this.cadastros.push(cadastro);
          });
        }
      },
      (error: any) => {
        console.error(error);
      }
    );
  }

  cancelForm(): void {
    this.form.reset();

    this.form.patchValue({
      dataNascimento: '',
      nome: '',
      sexo: '',
      id: '',
    });

    this.modalRef?.hide();
  }

  decline(): void {
    this.modalRef?.hide();
  }

  openModal(event: any, template: TemplateRef<any>, cadastroId: number) {
    event.stopPropagation();
    this.cadastroId = cadastroId;
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
  }

  confirm(): void {
    this.modalRef?.hide();
    this.spinner.show();
    this.cadastroService.deleteCadastro(this.cadastroId).subscribe(
      (result: any) => {
        console.log(result);
        this.toastr.success('O cadastro foi deletado com sucesso.', 'Deletado!');
        this.spinner.hide();
        this.carregarCadastros();
      },
      (error: any) => {
        console.error(error);
        this.toastr.error(`Erro ao tentar deletar cadastro ${this.cadastroId}`, 'Erro');
        this.spinner.hide();
      },
      () => {
        this.spinner.hide();
      }
    );
  }

  public validation(): void {
    this.form = this.fb.group({
      nome: ['', [Validators.required]],
      sexo: ['', Validators.required],
      dataNascimento: ['', Validators.required],
    });
  }

  openModalNew(event: any, template: TemplateRef<any>) {
    event.stopPropagation();

    this.estadoSalvar = 'post';
    this.form.reset(); 

    this.form.patchValue({
      dataNascimento: '',
      nome: '',
      sexo: '',
      id: ''
    });
    this.modalRef = this.modalService.show(template, { class: 'modal-lg' });
  }

  openModalEdit(event: any, template: TemplateRef<any>, cadastroId: number) {
    this.title = 'Edição Cadastro';

    event.stopPropagation();
    this.form.reset(); 

    this.form.patchValue({
      dataNascimento: '',
      nome: '',
      sexo: '',
    });

    if (cadastroId != null && cadastroId != 0) {
      this.estadoSalvar = 'put';

      this.spinner.show();
      this.cadastroService.getCadastroById(cadastroId).subscribe(
        (cadastro: Cadastro) => {
          this.cadastro = { ...cadastro };
          this.form.patchValue(this.cadastro);
        },
        (error: any) => {
          this.toastr.error('Erro ao tentar carregar cadastro.', 'Erro');
          console.error(error);
        }
      )
      .add(() => this.spinner.hide());
    }

    this.modalRef = this.modalService.show(template, { class: 'modal-lg' });
  }

  public resetForm(): void {
    this.form.reset();
  }

  public cssValidator(campoFrom: FormControl | AbstractControl): any {
    return { 'is-invalid': campoFrom.errors && campoFrom.touched };
  }

  public salvarCadastro(): void {
    this.spinner.show();
    if (this.form.valid) {
      if (this.estadoSalvar === 'post') {
        this.cadastro = { ...this.form.value };

        this.cadastroService.post(this.cadastro).subscribe(
          (cadastroRetorno: Cadastro) => {
            this.form.reset();
            this.decline();
            this.carregarCadastros();
            this.toastr.success('Cadastro salvo com sucesso', 'Sucesso');
          },
          (error: any) => {
            console.error(error);
            this.spinner.hide();
            this.toastr.error('Erro ao salvar cadastro', 'Erro');
          },
          () => this.spinner.hide()
        );
      } else {
        this.cadastro = { id: this.cadastro.id, ...this.form.value };
        this.cadastroService.put(this.cadastro.id, this.cadastro).subscribe(
          (cadastroRetorno: Cadastro) => {
            this.form.reset();
            this.decline();
            this.carregarCadastros();
            this.toastr.success('Cadastro atualizado com sucesso', 'Sucesso');
          },
          (error: any) => {
            console.error(error);
            this.spinner.hide();
            this.toastr.error('Erro ao atualizar cadastro', 'Erro');
          },
          () => this.spinner.hide()
        );
      }
    }
  }

}
