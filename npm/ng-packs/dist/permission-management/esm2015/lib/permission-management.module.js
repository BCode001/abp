/**
 * @fileoverview added by tsickle
 * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
 */
import { CoreModule } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { NgModule } from '@angular/core';
import { NgxsModule } from '@ngxs/store';
import { PermissionManagementComponent } from './components/permission-management.component';
import { PermissionManagementState } from './states/permission-management.state';
import { PerfectScrollbarModule } from 'ngx-perfect-scrollbar';
export class PermissionManagementModule {
}
PermissionManagementModule.decorators = [
    { type: NgModule, args: [{
                declarations: [PermissionManagementComponent],
                imports: [CoreModule, ThemeSharedModule, NgxsModule.forFeature([PermissionManagementState]), PerfectScrollbarModule],
                exports: [PermissionManagementComponent],
            },] }
];
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoicGVybWlzc2lvbi1tYW5hZ2VtZW50Lm1vZHVsZS5qcyIsInNvdXJjZVJvb3QiOiJuZzovL0BhYnAvbmcucGVybWlzc2lvbi1tYW5hZ2VtZW50LyIsInNvdXJjZXMiOlsibGliL3Blcm1pc3Npb24tbWFuYWdlbWVudC5tb2R1bGUudHMiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6Ijs7OztBQUFBLE9BQU8sRUFBRSxVQUFVLEVBQUUsTUFBTSxjQUFjLENBQUM7QUFDMUMsT0FBTyxFQUFFLGlCQUFpQixFQUFFLE1BQU0sc0JBQXNCLENBQUM7QUFDekQsT0FBTyxFQUFFLFFBQVEsRUFBRSxNQUFNLGVBQWUsQ0FBQztBQUN6QyxPQUFPLEVBQUUsVUFBVSxFQUFFLE1BQU0sYUFBYSxDQUFDO0FBQ3pDLE9BQU8sRUFBRSw2QkFBNkIsRUFBRSxNQUFNLDhDQUE4QyxDQUFDO0FBQzdGLE9BQU8sRUFBRSx5QkFBeUIsRUFBRSxNQUFNLHNDQUFzQyxDQUFDO0FBQ2pGLE9BQU8sRUFBRSxzQkFBc0IsRUFBRSxNQUFNLHVCQUF1QixDQUFDO0FBTy9ELE1BQU0sT0FBTywwQkFBMEI7OztZQUx0QyxRQUFRLFNBQUM7Z0JBQ1IsWUFBWSxFQUFFLENBQUMsNkJBQTZCLENBQUM7Z0JBQzdDLE9BQU8sRUFBRSxDQUFDLFVBQVUsRUFBRSxpQkFBaUIsRUFBRSxVQUFVLENBQUMsVUFBVSxDQUFDLENBQUMseUJBQXlCLENBQUMsQ0FBQyxFQUFFLHNCQUFzQixDQUFDO2dCQUNwSCxPQUFPLEVBQUUsQ0FBQyw2QkFBNkIsQ0FBQzthQUN6QyIsInNvdXJjZXNDb250ZW50IjpbImltcG9ydCB7IENvcmVNb2R1bGUgfSBmcm9tICdAYWJwL25nLmNvcmUnO1xuaW1wb3J0IHsgVGhlbWVTaGFyZWRNb2R1bGUgfSBmcm9tICdAYWJwL25nLnRoZW1lLnNoYXJlZCc7XG5pbXBvcnQgeyBOZ01vZHVsZSB9IGZyb20gJ0Bhbmd1bGFyL2NvcmUnO1xuaW1wb3J0IHsgTmd4c01vZHVsZSB9IGZyb20gJ0BuZ3hzL3N0b3JlJztcbmltcG9ydCB7IFBlcm1pc3Npb25NYW5hZ2VtZW50Q29tcG9uZW50IH0gZnJvbSAnLi9jb21wb25lbnRzL3Blcm1pc3Npb24tbWFuYWdlbWVudC5jb21wb25lbnQnO1xuaW1wb3J0IHsgUGVybWlzc2lvbk1hbmFnZW1lbnRTdGF0ZSB9IGZyb20gJy4vc3RhdGVzL3Blcm1pc3Npb24tbWFuYWdlbWVudC5zdGF0ZSc7XG5pbXBvcnQgeyBQZXJmZWN0U2Nyb2xsYmFyTW9kdWxlIH0gZnJvbSAnbmd4LXBlcmZlY3Qtc2Nyb2xsYmFyJztcblxuQE5nTW9kdWxlKHtcbiAgZGVjbGFyYXRpb25zOiBbUGVybWlzc2lvbk1hbmFnZW1lbnRDb21wb25lbnRdLFxuICBpbXBvcnRzOiBbQ29yZU1vZHVsZSwgVGhlbWVTaGFyZWRNb2R1bGUsIE5neHNNb2R1bGUuZm9yRmVhdHVyZShbUGVybWlzc2lvbk1hbmFnZW1lbnRTdGF0ZV0pLCBQZXJmZWN0U2Nyb2xsYmFyTW9kdWxlXSxcbiAgZXhwb3J0czogW1Blcm1pc3Npb25NYW5hZ2VtZW50Q29tcG9uZW50XSxcbn0pXG5leHBvcnQgY2xhc3MgUGVybWlzc2lvbk1hbmFnZW1lbnRNb2R1bGUge31cbiJdfQ==