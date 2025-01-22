import { Component } from '@angular/core';
import { BasicModule } from '../../../../../core/basic.module';
import { ToolbarModule } from 'primeng/toolbar';
import { SelectButton } from 'primeng/selectbutton';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';
import { PalceChartComponent } from './chart/palce-chart.component';
import { PalceGridComponent } from './grid/palce-grid.component';
import { PlacetModel } from '../../../models/queries/place-model';
import { TreeNode } from 'primeng/api';
import { PlaceService } from '../../../apis/place.service';
import { finalize } from 'rxjs';
import { openDialog, PageDialogConfig } from '../../../../../core/components/page-dialog/page-dialog.component';
import { CreatePlacePageComponent } from '../create-place/create-place-page.component';
import { EditPlacePageComponent } from '../edit-place/edit-place-page.component';
import { openConfirmDeleteDialog } from '../../../../../core/components/confirm-dialog/confirm-dialog.component';

@Component({
    selector: 'app-place-list-page',
    standalone: true,
    imports: [BasicModule,
        ToolbarModule,
        SelectButton,
        PalceChartComponent,
        PalceGridComponent
    ],
    providers: [DialogService],
    templateUrl: './place-list-page.component.html',
    styleUrl: './place-list-page.component.scss'
})
export class PlaceListPageComponent {

    isLoading = false;

    stateOptions: any[] = [
        { label: 'Chart', value: 'chart', icon: 'pi pi-sitemap' },
        { label: 'Grid', value: 'grid', icon: 'pi pi-align-justify' }
    ];
    selectedShowType: string = 'chart';

    places?: TreeNode<PlacetModel>[];

    ref: DynamicDialogRef | undefined;

    constructor(private placeService: PlaceService,
        public dialogService: DialogService,
    ) {

    }

    ngOnInit() {
        this.fetchData();
    }

    fetchData() {
        this.isLoading = true;
        this.placeService.getAllTree()
            .pipe(finalize(() => {
                this.isLoading = false;
            }))
            .subscribe(response => {
                this.places = response;
            });
    }

    openAdd(parentItem: PlacetModel) {
        const config: PageDialogConfig = {
            extraData: parentItem,
            component: CreatePlacePageComponent,
            header: 'Add New Place',
            description: 'this is a desciption of the add Place page',
            isFullScreen: false,
        };
        this.ref = openDialog(config, this.dialogService);
        this.ref.onClose.subscribe((result: any) => {
            if (result) {
                this.fetchData();
                // this.messageService.add({ severity: 'info', summary: 'Product Selected', detail: product.name });
            }
        });
    }

    openAddPosition() {
        const config: PageDialogConfig = {
            component: CreatePlacePageComponent,
            header: 'Add New Place',
            description: 'this is a desciption of the add Place page',
            isFullScreen: false,
        };
        this.ref = openDialog(config, this.dialogService);
        this.ref.onClose.subscribe((result: any) => {
            if (result) {
                this.fetchData();
                // this.messageService.add({ severity: 'info', summary: 'Product Selected', detail: product.name });
            }
        });
    }

    openEdit(item: PlacetModel) {
        const config: PageDialogConfig = {
            extraData: item,
            component: EditPlacePageComponent,
            header: 'Edit Place',
            description: 'this is a desciption of the Edit Place',
            isFullScreen: false,
        };
        this.ref = openDialog(config, this.dialogService);
        this.ref.onClose.subscribe((result: any) => {
            if (result) {
                this.fetchData();
                // this.messageService.add({ severity: 'info', summary: 'Product Selected', detail: product.name });
            }
        });
    }

    deleteItem(item: PlacetModel) {
        //TODO: translate
        this.ref = openConfirmDeleteDialog(`Are you sure you want to delete ${item.placeTitle}?`, this.dialogService);

        this.ref.onClose.subscribe((result: any) => {
            if (result) {
                this.isLoading = true;
                this.placeService.delete(item.id)
                    .pipe(finalize(() => {
                        this.isLoading = false;
                    }))
                    .subscribe(response => {
                        this.fetchData();
                    });
            }
        });
    }

}
