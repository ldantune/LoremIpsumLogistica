import { CommonModule, DatePipe } from '@angular/common';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatTableModule } from '@angular/material/table';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { Endereco } from '../../models/Endereco';
import { EnderecoService } from '../../services/Endereco.service';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { CepService } from '../../services/Cep.service';
import { NgxMaskDirective } from 'ngx-mask';

@Component({
  selector: 'app-enderecos',
  templateUrl: './enderecos.component.html',
  styleUrls: ['./enderecos.component.css'],
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
    RouterModule,
    NgxMaskDirective
  ],
})
export class EnderecosComponent implements OnInit {
  id: number | undefined;
  enderecos: Endereco[] = [];
  title: string = 'Novo Endereço';
  formEndereco!: FormGroup;
  endereco = {} as Endereco;
  estadoSalvar = 'post';
  modalRef?: BsModalRef;
  cadastroId: number | undefined;
  public enderecoId = 0;
  get f(): any {
    return this.formEndereco.controls;
  }

  get modoEditar(): boolean {
    return this.estadoSalvar === 'put';
  }

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private enderecoService: EnderecoService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private cepService: CepService
  ) { }

  ngOnInit():void {
    this.route.paramMap.subscribe(params => {
      const cadastroId = params.get('id'); // Converte o id para número
      if (cadastroId) {
        this.cadastroId = +cadastroId;
        this.carregarEnderecosByCadastroId(this.cadastroId);
      }
    });
    this.validation();
  }

  private carregarEnderecosByCadastroId(id: number): void {
    this.enderecos = [];
    this.enderecoService.getEnderecosByIdCadastro(id).subscribe(
      (enderecoRetorno: Endereco[]) => {
        if (enderecoRetorno != null) {
          enderecoRetorno.forEach((endereco) => {
            this.enderecos.push(endereco);
          });
        }
      },
      (error: any) => {
        console.error(error);
      }
    );
  }

  public validation(): void {
    this.formEndereco = this.fb.group({
      cep: ['', [Validators.required]],
      tipo: ['', Validators.required],
      logradouro: ['', Validators.required],
      numero: ['', Validators.required],
      cidade: ['', Validators.required],
      uf: ['', Validators.required],
      bairro: [''],
      complemento: [''],
    });
  }

  public resetForm(): void {
    this.formEndereco.reset();
  }

  public cssValidator(campoFrom: FormControl | AbstractControl): any {
    return { 'is-invalid': campoFrom.errors && campoFrom.touched };
  }

  openModalNew(event: any, template: TemplateRef<any>) {
    this.title = 'Novo Endereço';
    this.estadoSalvar = 'post';
    event.stopPropagation();
    this.formEndereco.reset(); 

    this.formEndereco.patchValue({
      cep: '',
      tipo: '',
      logradouro: '',
      id: '',
      numero: '',
      cidade: '',
      uf: '',
      bairro: '',
      complemento: '',
    });

    
    this.modalRef = this.modalService.show(template, { class: 'modal-lg' });
  }

  cancelForm(): void {
    this.formEndereco.reset();

    this.formEndereco.patchValue({
      cep: '',
      tipo: '',
      logradouro: '',
      id: '',
      numero: '',
      cidade: '',
      uf: '',
      bairro: '',
      complemento: '',
    });

    this.modalRef?.hide();
  }

  decline(): void {
    this.modalRef?.hide();
  }

  public salvarEndereco(): void {
    this.spinner.show();
    if (this.formEndereco.valid) {
      if (this.estadoSalvar === 'post') {
        this.endereco = { ...this.formEndereco.value };

        this.endereco.tipo = +this.endereco.tipo;
        this.endereco.cadastroId = +this.cadastroId!;

        this.enderecoService.post(this.endereco).subscribe(
          (enderecoRetorno: Endereco) => {
            this.formEndereco.reset();
            this.decline();
            this.carregarEnderecosByCadastroId(this.cadastroId!);
            this.toastr.success('Endereço salvo com sucesso', 'Sucesso');
          },
          (error: any) => {
            console.error(error);
            this.spinner.hide();
            this.toastr.error('Erro ao salvar endereço', 'Erro');
          },
          () => this.spinner.hide()
        );
      } else {
        this.endereco = { id: this.endereco.id, ...this.formEndereco.value };

        this.endereco.tipo = +this.endereco.tipo;
        this.endereco.cadastroId = +this.cadastroId!;

        this.enderecoService.put(this.endereco.id, this.endereco).subscribe(
          (enderecoRetorno: Endereco) => {
            this.formEndereco.reset();
            this.decline();
            this.carregarEnderecosByCadastroId(this.cadastroId!);
            this.toastr.success('Endereco atualizado com sucesso', 'Sucesso');
          },
          (error: any) => {
            console.error(error);
            this.spinner.hide();
            this.toastr.error('Erro ao atualizar endereço', 'Erro');
          },
          () => this.spinner.hide()
        );
      }
    }
  }

  buscarCep() {
    let cep = this.formEndereco.get('cep')?.value;
    
    cep = cep.replace(/\D/g, '');

    if (cep.length === 8) {
      this.cepService.buscarCep(cep).subscribe(
        (data) => {
          if (!data.erro) {
            this.formEndereco.patchValue({
              logradouro: data.logradouro,
              bairro: data.bairro,
              cidade: data.localidade,
              uf: data.uf
            });
          } else {
            this.toastr.error('CEP não encontrado.', 'Alert');
            alert('CEP não encontrado.');
          }
        },
        (error) => {
          this.toastr.error('Erro ao buscar CEP', 'Erro');
          console.error('Erro ao buscar CEP', error);
        }
      );
    }
  }

  openModal(event: any, template: TemplateRef<any>, enderecoId: number) {
    event.stopPropagation();
    this.enderecoId = enderecoId;
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
  }

  confirm(): void {
    this.modalRef?.hide();
    this.spinner.show();
    this.enderecoService.deleteEndereco(this.enderecoId).subscribe(
      (result: any) => {
        this.toastr.success('O endereço foi deletado com sucesso.', 'Deletado!');
        this.spinner.hide();
        this.carregarEnderecosByCadastroId(this.cadastroId!);
      },
      (error: any) => {
        console.error(error);
        this.toastr.error(`Erro ao tentar deletar endereço ${this.enderecoId}`, 'Erro');
        this.spinner.hide();
      },
      () => {
        this.spinner.hide();
      }
    );
  }

  openModalEdit(event: any, template: TemplateRef<any>, enderecoId: number) {
    this.title = 'Edição Endereço';

    event.stopPropagation();
    this.formEndereco.reset(); 

    this.formEndereco.patchValue({
      cep: '',
      tipo: '',
      logradouro: '',
      numero: '',
      cidade: '',
      uf: '',
      bairro: '',
      complemento: '',
    });

    if (enderecoId != null && enderecoId != 0) {
      this.estadoSalvar = 'put';

      this.spinner.show();
      this.enderecoService.getEnderecoById(enderecoId).subscribe(
        (endereco: Endereco) => {
          this.endereco = { ...endereco };
          this.endereco.tipo = this.converterTipo(this.endereco.tipo.toString());
          this.formEndereco.patchValue(this.endereco);
        },
        (error: any) => {
          this.toastr.error('Erro ao tentar carregar endereço.', 'Erro');
          console.error(error);
        }
      )
      .add(() => this.spinner.hide());
    }

    this.modalRef = this.modalService.show(template, { class: 'modal-lg' });
  }

  converterTipo(tipo: string): number {
    switch (tipo) {
      case 'Residencial':
        return 1;
      case 'Comercial':
        return 2;
      default:
        return 0;  // Valor padrão para tipos desconhecidos
    }
  }

}
