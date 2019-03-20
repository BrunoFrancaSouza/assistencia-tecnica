import { MatPaginatorIntl } from '@angular/material';

export function MatPaginatorIntlPtBR() {

    const customPaginatorIntl = new MatPaginatorIntl();

    customPaginatorIntl.itemsPerPageLabel = 'Itens por página';
    customPaginatorIntl.nextPageLabel     = 'Próxima página';
    customPaginatorIntl.previousPageLabel = 'Página anterior';
    // customPaginatorIntl.lastPageLabel     = 'lastPageLabel';

    return customPaginatorIntl;
}
