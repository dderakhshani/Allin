import { Component, OnInit } from '@angular/core';
import { BasicModule } from '../../../../../core/basic.module';

import { TreeNode } from 'primeng/api';
import { ButtonModule } from 'primeng/button';
import { TreeTableModule } from 'primeng/treetable';
import { CommonModule } from '@angular/common';
import { NodeService } from './services/nodeservice';
import { TimelineModule } from 'primeng/timeline';


interface Column {
  field: string;
  header: string;
}

@Component({
  selector: 'app-item-categories-list',
  templateUrl: './item-categories-list.component.html',
  styleUrl: './item-categories-list.component.scss',
  standalone: true,
  imports: [BasicModule, CommonModule, TreeTableModule, TimelineModule],
  providers: [NodeService]

})
export class ItemCategoriesListComponent implements OnInit {

  files!: TreeNode[];

  cols!: Column[];

  constructor(private nodeService: NodeService) { }

  ngOnInit() {
    // this.nodeService.getFilesystem().then((files) => (this.files = files));
    // this.cols = [
    //     { field: 'name', header: 'Name' },
    //     { field: 'size', header: 'Size' },
    //     { field: 'type', header: 'Type' },
    //     { field: '', header: '' }
    // ];
  }

}
