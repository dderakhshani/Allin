import { Component } from '@angular/core';
import { BasicModule } from '../../../../core/basic.module';
import { MultiSelectModule } from 'primeng/multiselect';
import { DragDropModule } from 'primeng/dragdrop';
import { FormBuilder } from '@angular/forms';
import { Select } from 'primeng/select';
import { FloatLabel } from 'primeng/floatlabel';

interface Level {
    name: number;
    code: number;
}

@Component({
    selector: 'app-properties-category',
    standalone: true,
    imports: [BasicModule,
        MultiSelectModule,
        DragDropModule,
        FloatLabel,
        Select
    ],
    templateUrl: './properties-category.component.html',
    styleUrl: './properties-category.component.scss'
})
export class PropertiesCategoryComponent {
    isLoading = false;

    selectedCities: any[] = [];
    levels: Level[] | undefined;

    tempNo: number = 0;

    draggedBlock = null;
    starter: number = 1;

    form = this.fb.group({
        title: this.fb.control<string | null>(null),
        type: this.fb.control<number | null>(null),
    })

    constructor(public fb: FormBuilder,
    ) { }

    selectedLevel: Level | undefined;
    ngOnInit() {

        this.isLoading = true;
        this.levels = [
            { name: 1, code: 1 },
            { name: 2, code: 2 },
            { name: 3, code: 3 },
            { name: 4, code: 4 },
            { name: 5, code: 5 }
        ];

    }

    addItem() {
        this.tempNo += 1;
        this.selectedCities.push({ name: this.tempNo, code: this.tempNo });
    }

    // نمونه کد درگ دراپ
    // dragStart(block: any, indu: any) {
    //     this.draggedBlock = block;
    //     this.starter = indu;
    //     console.log("Start: " + indu);
    // }

    // dragEnd() {
    //     this.draggedBlock = null;
    // }

    // drop(event: any, indu: any) {
    //     console.log("Drop: " + indu);
    //     this.selectedCities.splice(this.starter, 1);
    //     this.selectedCities.splice(indu, 0, this.draggedBlock);
    // }

    onSelectLevel() {

    }
}
