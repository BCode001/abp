import { ToasterService } from '@abp/ng.theme.shared';
import { EventEmitter, OnChanges, OnInit, SimpleChanges, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Store } from '@ngxs/store';
export declare class ChangePasswordComponent implements OnInit, OnChanges {
    private fb;
    private store;
    private toasterService;
    protected _visible: any;
    visible: boolean;
    visibleChange: EventEmitter<boolean>;
    modalContent: TemplateRef<any>;
    form: FormGroup;
    modalBusy: boolean;
    constructor(fb: FormBuilder, store: Store, toasterService: ToasterService);
    ngOnInit(): void;
    onSubmit(): void;
    openModal(): void;
    ngOnChanges({ visible }: SimpleChanges): void;
}
