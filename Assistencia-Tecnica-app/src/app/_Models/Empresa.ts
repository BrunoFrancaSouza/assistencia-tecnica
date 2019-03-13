import { Usuario } from './Usuario';

export interface Empresa {
    Id: number;
    RazaoSocial: string;
    NomeFantasia: string;
    CNPJ: string;
    Setor: string;
    Endereco: string;
    Email: string;
    Telefone: string;
    Ativo: boolean;
    DataAlteracao: Date | string;
    AlteradoPor: string;

    Usuarios: Usuario[];
}
