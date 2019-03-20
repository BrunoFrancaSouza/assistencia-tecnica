import { Empresa } from './Empresa';

// export interface Usuario {
export class Usuario {
    id: number;
    userName: string;
    senha: string;
    nome: string;
    sobrenome: string;
    email: string;
    perfil: string;
    ativo: boolean;
    dataAlteracao: Date | string;
    alteradoPor: string;

    empresaId: number;
    empresa: Empresa;
}
