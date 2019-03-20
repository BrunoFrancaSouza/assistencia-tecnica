import { Usuario } from './Usuario';

// export interface Empresa {
export class Empresa {
    id: number;
    razaoSocial: string;
    nomeFantasia: string;
    cnpj: string;
    setor: string;
    endereco: string;
    email: string;
    eelefone: string;
    ativo: boolean;
    dataAlteracao: Date | string;
    alteradoPor: string;

    usuarios: Usuario[];
}
