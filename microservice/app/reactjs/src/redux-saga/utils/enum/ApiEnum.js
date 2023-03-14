export const API_HOME_TEST_GET =
  "/api/saas/shopindo/collection/get-product-by-collectionId";
export const API_HOME_TEST_POST = "";
export const API_HOME_TEST_GET_ASYN_AWAIT = "";
export const API_HOME_TEST_POST_ASYN_AWAIT = "";
// url which mean the host backend using to call api
export const ADSITE = "/api/maintain-service/ad-site";
//AdGroup Api
export const ADGROUP_API = "/api/maintain-service/ad-group-type";
//Inventory Api
export const MmInventoryUnit = "/api/maintain-service/mm-inventory-unit";
//Inventory
export const MmInventory = "/api/maintain-service/mm-inventory";
// Inventory type
export const MmInventoryType = "/api/maintain-service/mm-inventory-type";
export const CmPositionPersion = "/api/maintain-service/cm-position-person";
// Ad Color
export const AdColor = "/api/maintain-service/ad-color";
// bank
export const CmBank = "/api/maintain-service/cm-bank";
export const category_MmInventoryType = "/api/maintain-service/category";
export const TEST_API = "/api/maintain-service/test/test-error";
// upload file
export const TEST_UPLOAD_FILE = "/api/file/upload-file-validate";
// approve process - luồng phê duyệt default
export const APPROVE_PROCESS =
  "/api/production-management-service/workflow-default";
//Work (ds công việc)
export const WORK_API = "/api/production-management-service/work";
// tài liệu sop
export const DOCUMENT_SOP = "/api/production-management-service/sop";
//WorkUnit
export const WORKUNIT = "api/production-management-service/workunit";

//danh sách theo user id
export const GET_LIST_USER = "/account-manage/get-department-jobtitle-by-users";
// cong viec
export const WORK = "/api/work-service/work/";

//--------------WORKCENTER API------------
export const GET_ALL_WORKCENTER =
  "/api/production-management-service/workcenter/get-all";
export const GET_DETAIL_WORKCENTER =
  "/api/production-management-service/workcenter/get-detail/";
export const CREATE_WORKCENTER =
  "/api/production-management-service/workcenter/create-workcenter";
export const EDIT_WORKCENTER =
  "/api/production-management-service/workcenter/update-workcenter";
export const DELETE_WORKCENTER =
  "/api/production-management-service/workcenter/delete-workcenter/";
export const GET_TREE_WORKAREA =
  "/api/production-management-service/workcenter/get-tree-workarea";

//--------------END WORKCENTER API------------
// WorkArea
export const WORK_AREA = "/api/production-management-service/workarea";
// Common API

export const COMMON = "/api/production-management-service/common";

//material-management-service
export const MATERIAL_MANAGEMENT =
  "/api/material-management-service/finighedgoods";

// quản lý sop servie
export const GET_ALL_DOCUMENT_SOP =
  "/api/production-management-service/sop/get-all";
export const CREATE_DOCUMENT_SOP =
  "/api/production-management-service/sop/create-sop";
export const UPDATE_DOCUMENT_SOP =
  "/api/production-management-service/sop/update-sop";
export const DELETE_DOCUMENT_SOP =
  "/api/production-management-service/sop/delete-sop/";
export const GET_DETAIL_DOCUMENT_SOP =
  "/api/production-management-service/sop/get-detail/";

// DROPDOWN COMMON
export const GET_ALL_DROPDOWN =
  "/api/production-management-service/common/get-work-by-type";
export const GET_ALL_DROPDOWN_BY_CODE =
  "/api/production-management-service/common/work-common-dropdown-by-code";

export const GET_ALL_DROPDOWNPRODUCT =
  "/api/material-management-service/finighedgoods/get-product-dropdow";
export const GET_ALL_DROPDOWN_MACHINE =
  "/api/maintenance-management-service/machine/get-all-dropdown";
export const GET_ALL_DROPDOWN_MODEL =
  "/api/material-management-service/product/get-dropdown-model";
export const GET_ALL_DROPDOWN_MATERIAL =
  "/api/material-management-service/common/get-work-by-type";
export const GET_ALL_DROPDOWN_LOCATION_BY_LEVEL =
  "/api/material-management-service/common/get-location-by-level";
export const GET_ALL_DROPDOWN_LOCATION_TYPE_CHECKING =
  "/api/material-management-service/common/get-dropdown-location-kk";
export const GET_ALL_DROPDOWN_LEVEL_CHECKING =
  "/api/material-management-service/common/get-dropdown-locationlevel";
export const GET_ALL_DROPDOWN_MACHINE_TYPE =
  "/api/maintenance-management-service/machine/get-by-type/";
export const GET_ALL_DROPDOWN_MACHINE_TYPE_V2 =
  "/api/maintenance-management-service/machine/get-by-typeV2";
export const EXPORT_MACHINE_API =
  "/api/maintenance-management-service/machine/export-file";
export const MACHINE_UPLOAD_FILE_API =
  "/api/upload/file/upload-file-validate";
// dropdown for production requirment
export const GET_ALL_DROPDOWN_PRODUCTION =
  "/api/production-management-service/common/work-common-dropdown-by-code";
export const GET_ALL_DROPDOWN_CALENDAR_MANAGER =
  "/api/production-management-service/common/get-work-by-type";

// APPROVER PROCESS
export const GET_LIST_APPROVE_PROCESS =
  "/api/production-management-service/workflow-default/get-all";
export const CREATE_APPROVE_PROCESS =
  "/api/production-management-service/workflow-default/create-workflow-default";
export const EDIT_APPROVE_PROCESS =
  "/api/production-management-service/workflow-default/update-workflow-default";
export const DELETE_APPROVE_PROCESS =
  "/api/production-management-service/workflow-default/delete-workflow-default";
export const GET_APPROVE_PROCESS_BYID =
  "/api/production-management-service/workflow-default/get-detail";

// IDENTITY SERVICE
export const GET_LIST_DEPARTMENT =
  "/api/identity/account-manage/get-list-department";
export const GET_LIST_DEPARTMENT_BY_STRINGUSERID =
  "/api/identity/account-manage/get-department-jobtitle-by-users";
export const GET_LIST_USER_BY_DEPARTMENT =
  "/api/identity/account-manage/get-list-user-by-list-department";
export const GET_LIST_USER_FOR_DEPARTMENT_BY_STRING_USERID =
  "/api/identity/account-manage/get-list-user-for-department-by-users";

// WORK AREA
export const GET_LIST_WORK_AREA =
  "/api/production-management-service/workarea/get-all";
export const CREATE_WORK_AREA =
  "/api/production-management-service/workarea/create-workarea";
export const EDIT_WORK_AREA =
  "/api/production-management-service/workarea/update-workarea";
export const DELETE_WORK_AREA =
  "/api/production-management-service/workarea/delete-workarea";
export const GET_WORK_AREA_BYID =
  "/api/production-management-service/workarea/get-detail";

//--------------TIME SHIF MANAGER API------------
export const GET_ALL_TIMESHIF_MANAGER =
  "/api/production-management-service/shift-management/get-all";
export const GET_DETAIL_TIMESHIF_MANAGER =
  "/api/production-management-service/shift-management/get-detail/";
export const CREATE_TIMESHIF_MANAGER =
  "/api/production-management-service/shift-management/create-shift-management";
export const EDIT_TIMESHIF_MANAGER =
  "/api/production-management-service/shift-management/update-shift-management";
export const DELETE_TIMESHIF_MANAGER =
  "/api/production-management-service/shift-management/delete-shift-management/";

//--------------TIMESCHEDULE MANAGER API------------
export const GET_ALL_TIMESCHEDULE_MANAGER =
  "/api/production-management-service/calendarmanagement/get-all";
export const GET_DETAIL_TIMESCHEDULE_MANAGER =
  "/api/production-management-service/calendarmanagement/get-calendarmanagement/";
export const CREATE_TIMESCHEDULE_MANAGER =
  "/api/production-management-service/calendarmanagement/create-calendarmanagement";
export const EDIT_TIMESCHEDULE_MANAGER =
  "/api/production-management-service/calendarmanagement/update-calendarmanagement";
export const DELETE_TIMESCHEDULE_MANAGER =
  "/api/production-management-service/calendarmanagement/delete-calendarmanagement/";
export const GET_DROPDOWN_WORKARAE_MANAGER =
  "/api/production-management-service/calendarmanagement/get-dropdown-workarea";

//--------------END TIME SHIF MANAGER API------------

//--------------GROUP WORK DAY API------------
export const GET_ALL_GROUP_WORKDAY =
  "/api/production-management-service/group-workday/get-all";
export const GET_DETAIL_GROUP_WORKDAY =
  "/api/production-management-service/group-workday/get-detail/";
export const CREATE_GROUP_WORKDAY =
  "/api/production-management-service/group-workday/create-group-workday";
export const EDIT_GROUP_WORKDAY =
  "/api/production-management-service/group-workday/update-group-workday";
export const DELETE_GROUP_WORKDAY =
  "/api/production-management-service/group-workday/delete-group-workday/";

//--------------END GROUP WORK DAY API------------

// WORK UNIT
export const GET_LIST_WORK_UNIT =
  "/api/production-management-service/workunit/get-all";
export const CREATE_WORK_UNIT =
  "/api/production-management-service/workunit/create-workunit";
export const EDIT_WORK_UNIT =
  "/api/production-management-service/workunit/update-workunit";
export const DELETE_WORK_UNIT =
  "/api/production-management-service/workunit/delete-workunit";
export const GET_WORK_UNIT_BYID =
  "/api/production-management-service/workunit/get-detail";
export const GET_DROPDOWN_WORKCENTER =
  "/api/production-management-service/workunit/get-all-workcenter-by-workarea";

//--------------TIME MANAGER TYPE API------------
export const GET_ALL_TIME_MANAGER_TYPE =
  "/api/production-management-service/work-day-type/get-all";
export const GET_DETAIL_TIME_MANAGER_TYPE =
  "/api/production-management-service/work-day-type/get-detail/";
export const CREATE_TIME_MANAGER_TYPE =
  "/api/production-management-service/work-day-type/create-work-day-type";
export const EDIT_TIME_MANAGER_TYPE =
  "/api/production-management-service/work-day-type/update-work-day-type";
export const DELETE_TIME_MANAGER_TYPE =
  "/api/production-management-service/work-day-type/delete-work-day-type/";

//--------------TIME MANAGER TYPE API------------

export const GET_ALL_CALENDER_BY_YEAR_MONTH =
  "/api/production-management-service/calendar-setting/get-all";
export const SAVE_ALL_CALENDER_BY_YEAR_MONTH =
  "/api/production-management-service/calendar-setting/create-and-update-calendar-setting";

//--------------WORKER API------------
export const GET_ALL_WORKER_API =
  "/api/production-management-service/worker/get-all";
export const CREATE_WORKER_API =
  "/api/production-management-service/worker/create-worker";
export const UPDATE_WORKER_API =
  "/api/production-management-service/worker/update-worker";
export const DELETE_WORKER_API =
  "/api/production-management-service/worker/delete-worker/";
export const GET_DETAIL_WORKER_API =
  "/api/production-management-service/worker/get-detail/";
export const CREATE_ACCOUNT =
  "/api/production-management-service/worker/create-account";
export const RESET_PASSWORD_ACCOUNT =
  "/api/production-management-service/worker/account-reset-password";
export const WORKER_UPLOAD_FILE_API =
  "/api/upload/file/upload-file-validate";
//--------------WORKER Skill API------------
export const GET_ALL_WORKER_SKILL_API =
  "/api/production-management-service/worker-skill/get-all";
export const CREATE_WORKER_SKILL_API =
  "/api/production-management-service/worker-skill/create-worker-skill";
export const UPDATE_WORKER_SKILL_API =
  "/api/production-management-service/worker-skill/update-worker-skill";
export const DELETE_WORKER_SKILL_API =
  "/api/production-management-service/worker-skill/delete-worker-skill/";
export const GET_DETAIL_WORKER_SKILL_API =
  "/api/production-management-service/worker-skill/get-detail/";
//-------------- Skill API------------
export const GET_ALL_SKILL_API =
  "/api/production-management-service/skill/get-all";
export const CREATE_SKILL_API =
  "/api/production-management-service/skill/create-skill";
export const UPDATE_SKILL_API =
  "/api/production-management-service/skill/update-skill";
export const DELETE_SKILL_API =
  "/api/production-management-service/skill/delete-skill/";
export const GET_DETAIL_SKILL_API =
  "/api/production-management-service/skill/get-detail/";

//-------------- Machine API------------
export const GET_ALL_MACHINES_API =
  "/api/maintenance-management-service/machine/get-all";
export const CREATE_MACHINE_API =
  "/api/maintenance-management-service/machine/create";
export const UPDATE_MACHINE_API =
  "/api/maintenance-management-service/machine/update";
export const DELETE_MACHINE_API =
  "/api/maintenance-management-service/machine/delete/";
export const GET_DETAIL_MACHINE_API =
  "/api/maintenance-management-service/machine/get-detail/";


//-------------- Machine category API------------
export const GET_ALL_MACHINE_TYPES_API =
  "/api/maintenance-management-service/machine-type/get-all";
export const CREATE_MACHINE_TYPE_API =
  "/api/maintenance-management-service/machine-type/create";
export const UPDATE_MACHINE_TYPE_API =
  "/api/maintenance-management-service/machine-type/update";
export const DELETE_MACHINE_TYPE_API =
  "/api/maintenance-management-service/machine-type/delete/";
export const GET_DETAIL_MACHINE_TYPE_API =
  "/api/maintenance-management-service/machine-type/get-detail/";

//-------------- Product API------------
export const GET_ALL_PRODUCT_API =
  "/api/production-management-service/product/get-all";
export const CREATE_PRODUCT_API =
  "/api/production-management-service/product/create-product";
export const UPDATE_PRODUCT_API =
  "/api/production-management-service/product/update-product";
export const DELETE_PRODUCT_API =
  "/api/production-management-service/product/delete-product/";
export const GET_DETAIL_PRODUCT_API =
  "/api/production-management-service/product/get-detail/";
export const GET_CODE_API = "/api/production-management-service/product/get-code";

//-------------- Model API------------
export const GET_ALL_MODEL_API =
  "/api/production-management-service/model/get-all";
export const CREATE_MODEL_API =
  "/api/production-management-service/model/create-model";
export const UPDATE_MODEL_API =
  "/api/production-management-service/model/update-model";
export const DELETE_MODEL_API =
  "/api/production-management-service/model/delete-model/";
export const GET_DETAIL_MODEL_API =
  "/api/production-management-service/model/get-detail/";

//-------------- Accessories type API------------
export const GET_ALL_ACCESSORIES_TYPE_API =
  "/api/material-management-service/accessories-type/get-all";
export const CREATE_ACCESSORIES_TYPE_API =
  "/api/material-management-service/accessories-type/create-accessories-type";
export const UPDATE_ACCESSORIES_TYPE_API =
  "/api/material-management-service/accessories-type/update-accessories-type";
export const DELETE_ACCESSORIES_TYPE_API =
  "/api/material-management-service/accessories-type/delete-accessories-type/";
export const GET_DETAIL_ACCESSORIES_TYPE_API =
  "/api/material-management-service/accessories-type/get-accessories-type/";

//--------------- Code api ----------------------
export const GET_CODE_API_FROM_MATERIAL =
  "/api/material-management-service/common/get-code";

//-------------- Accessories API------------

//-------------- Unit API------------
export const GET_ALL_Unit_API = "/api/material-management-service/unit/get-all";
export const CREATE_Unit_TYPE_API =
  "/api/material-management-service/unit/create";
export const UPDATE_Unit_TYPE_API =
  "/api/material-management-service/unit/update";
export const DELETE_Unit_TYPE_API =
  "/api/material-management-service/unit/delete/";
export const GET_DETAIL_Unit_TYPE_API =
  "/api/material-management-service/unit/get-detail/";

//-------------- ConvertUnit API------------
export const GET_ALL_CONVERT_UNIT_API =
  "/api/material-management-service/convert-unit/get-all";
export const CREATE_CONVERT_UNIT_API =
  "/api/material-management-service/convert-unit/create-convertUnit";
export const UPDATE_CONVERT_UNIT_API =
  "/api/material-management-service/convert-unit/update-convertUnit";
export const DELETE_CONVERT_UNIT_API =
  "/api/material-management-service/convert-unit/delete-convertUnit/";
export const GET_DETAIL_CONVERT_UNIT_API =
  "/api/material-management-service/convert-unit/get-detail/";
//-------------- NCCInformation API------------
export const GET_ALL_NCCINFORMATION_API =
  "/api/material-management-service/partner/get-all";
export const CREATE_NCCINFORMATION_API =
  "/api/material-management-service/partner/create-partner";
export const UPDATE_NCCINFORMATION_API =
  "/api/material-management-service/partner/update-partner";
export const DELETE_NCCINFORMATION_API =
  "/api/material-management-service/partner/delete-partner/";
export const GET_DETAIL_NCCINFORMATION_API =
  "/api/material-management-service/partner/get-detail/";

//-------------- Location level API------------
export const GET_ALL_LOCATION_LEVEL_API =
  "/api/material-management-service/location-level/get-all";
export const CREATE_LOCATION_LEVEL_API =
  "/api/material-management-service/location-level/create";
export const UPDATE_LOCATION_LEVEL_API =
  "/api/material-management-service/location-level/update";
export const DELETE_LOCATION_LEVEL_API =
  "/api/material-management-service/location-level/delete/";
export const GET_DETAIL_LOCATION_LEVEL_API =
  "/api/material-management-service/location-level/get-detail/";
//-------------- Location API------------
export const GET_ALL_LOCATION_API =
  "/api/material-management-service/location/get-all";
export const CREATE_LOCATION_API =
  "/api/material-management-service/location/create-location";
export const UPDATE_LOCATION_API =
  "/api/material-management-service/location/update-location";
export const DELETE_LOCATION_API =
  "/api/material-management-service/location/delete-location/";
export const GET_DETAIL_LOCATION_API =
  "/api/material-management-service/location/get-detail/";
//--------------- Sloc Code api ----------------------
export const GET_SLOC_CODE_API_FROM_MATERIAL =
  "/api/material-management-service/location/get-sloccode";

//--------------- WareHouse api ----------------------
export const GET_SHIFTMENT_INFORMATION_BY_PACKAGE_CODE =
  "/api/material-management-service/warehouse/get-warehouse/";
export const UPDATE_TEMPORY =
  "/api/material-management-service/warehouse/update-temporary";
export const PRINT_ALL_TEM =
  "/api/material-management-service/warehouse/print-many-tem";
export const PRINT_TEM =
  "/api/material-management-service/warehouse/print-once-tem";
export const RE_PRINT_TEM =
  "/api/material-management-service/warehouse/reprint-tem";
export const IMPORT_PACKAGE =
  "/api/material-management-service/warehouse/to-receive";
export const GET_PACKAGE_TYPE_INFORMATION =
  "/api/material-management-service/warehouse/get-pack-by";

//---------------------Storage Tranfer API--------------------------------
export const GET_PACKAGE_INFO_BY_PACK_CODE =
  "/api/material-management-service/transfer-warehouse/get-package-info-by-code/";
export const GET_WAREHOUSE_TRANFER_NOTE =
  "/api/material-management-service/transfer-warehouse/get-warehouse-transfer-note";
export const CREATE_PACKAGE_TO_WAREHOUSETRANS_API =
  "/api/material-management-service/transfer-warehouse/add-package-to-warehousetrans";
export const DELETE_PACKAGE_TO_WAREHOUSETRANS_API =
  "/api/material-management-service/transfer-warehouse/transfer-note-remove-package";
export const PICKUP_GOODS_PACKAGE_TO_TRANS_API =
  "/api/material-management-service/transfer-warehouse/pickup-goods";
export const STORE_GOODS_PACKAGE_TO_TRANS_API =
  "/api/material-management-service/transfer-warehouse/store-goods";
export const DONE_NOTE_PACKAGE_TO_TRANS_API =
  "/api/material-management-service/transfer-warehouse/done-note/";
//--------------- storeBill api ----------------------
// api lấy danh sách package đang ở khu nhân hàng
export const GET_PACKAGE_FROM_STATION_NHAN_HANG =
  "/api/material-management-service/store-bill/get-store-bill-ticket";
// api lưu lại phiếu cất hàng
export const SAVE_STORE_BILL_TICKET =
  "/api/material-management-service/store-bill/save-store-bill-ticket";
// lấy thông tin phiếu cất hàng
export const GET_STORE_BILL_TICKET =
  "/api/material-management-service/store-bill/get-store-bill";
// Hoàn thành cất hàng
export const COMPLETE_STORE_BILL_TICKET =
  "/api/material-management-service/store-bill/complete-store-bill";
// scan package code để lấy thông tin chi tiết
export const SCAN_PACKAGE_CODE =
  "/api/material-management-service/store-bill/get-package-info/";
// hoàn thành cất hàng vào vị trí
export const COMPLETE_STORE_PACKAGE =
  "/api/material-management-service/store-bill/save-storage-info";

export const CHECK_IF_LOCATION_EXIST =
  "/api/material-management-service/store-bill/check-if-location-exist/";

//-------------- Delivery order API------------
export const GET_ALL_DELIVERY_ORDER_API =
  "/api/material-management-service/deliveryorder/get-all";
export const CREATE_DELIVERY_ORDER_API =
  "/api/material-management-service/deliveryorder/create-deliveryorder";
export const UPDATE_DELIVERY_ORDER_API =
  "/api/material-management-service/deliveryorder/update-deliveryorder";
export const DELETE_DELIVERY_ORDER_API =
  "/api/material-management-service/deliveryorder/delete-deliveryorder/";
export const GET_DETAIL_DELIVERY_ORDER_API =
  "/api/material-management-service/deliveryorder/get-detail/";
export const GET_INFO_DELIVERY_ORDER_API =
  "/api/material-management-service/deliveryorder/get-info/";
//--------------- PackageInfo api ----------------------
export const GET_ALL_PACKAGEINFO_API =
  "/api/material-management-service/packageinfo/get-all";
export const CREATE_PACKAGEINFO_API =
  "/api/material-management-service/packageinfo/create-packageinfo";
export const UPDATE_PACKAGEINFO_API =
  "/api/material-management-service/packageinfo/update-packageinfo";
export const DELETE_PACKAGEINFO_API =
  "/api/material-management-service/packageinfo/delete-packageinfo/";
export const GET_DETAIL_PACKAGEINFO_API =
  "/api/material-management-service/packageinfo/get-detail/";
export const GET_PICKING_LIST_BY_USER =
  "/api/material-management-service/transfer-Picking-list/get-picking-by-user";
export const PICKING_LIST_NEXT_LOCATION =
  "/api/material-management-service/transfer-Picking-list/next-localtion";
export const PICKING_LIST_DONE_LOCATION =
  "/api/material-management-service/transfer-Picking-list/done-pickup";
export const TAKEN_PACKAGE_GET_DETAIL_BY_PACKAGE_CODE_API = "/api/material-management-service/packageinfo/get-detail/"
//--------------- Request Form ----------------------
export const GET_ALL_REQUESTFORM_API =
  "/api/material-management-service/transfer-request/get-all";
export const DELETE_REQUESTFORM_API =
  "/api/material-management-service/transfer-request/delete-transfer-request/";
export const CREATE_REQUESTFORM_API =
  "/api/material-management-service/transfer-request/create-transfer-request";
export const GETDETAIL_REQUESTFORM_API =
  "/api/material-management-service/transfer-request/get-detail/";
export const UPDATE_REQUESTFORM_API =
  "/api/material-management-service/transfer-request/update-transfer-request";

//---------------- PurchaseOrder API -----------------
export const GET_ALL_PO_SAGA =
  "/api/material-management-service/purchaseorder/get-all";
export const DELETE_PO_SAGA =
  "/api/material-management-service/purchaseorder/delete-purchaseOrder/";
export const GET_DETAIL_PO_SAGA =
  "/api/material-management-service/purchaseorder/get-detail/";
export const ADD_PO_SAGA =
  "/api/material-management-service/purchaseorder/create-purchaseorder";
export const UPDATE_PO_SAGA =
  "/api/material-management-service/purchaseorder/update-purchaseorder";

//-------------- Petitioner API------------

export const GET_ALL_PETITIONER_API =
  "/api/material-management-service/petitioner/get-all";
export const CREATE_PETITIONER_API =
  "/api/material-management-service/petitioner/create";
export const UPDATE_PETITIONER_API =
  "/api/material-management-service/petitioner/update";
export const DELETE_PETITIONER_API =
  "/api/material-management-service/petitioner/delete/";
export const GET_DETAIL_PETITIONER_API =
  "/api/material-management-service/petitioner/get-detail/";

//-------------- TransferPickingList API------------

export const GET_PICKING_LIST =
  "/api/material-management-service/transfer-Picking-list/get-picking-list";
export const GET_PICKING_LIST_BY_ID =
  "/api/material-management-service/transfer-Picking-list/get-picking-list-by-code";
export const GET_PICKING_HISTORY_BY_DETAIL_ID =
  "/api/material-management-service/transfer-Picking-list/get-picking-history-by-detail-id?PickingListDetailId=";
export const ADD_PACKAGE_IN_PICK_HIS =
  "/api/material-management-service/transfer-Picking-list/Add-package-in-pick-his";
export const REMOVE_PACKAGE_IN_HIS =
  "/api/material-management-service/transfer-Picking-list/remove-package-in-his";

// Picking list
export const GET_ALL_PICKING_LIST =
  "/api/material-management-service/picking-list/get-all";
export const CREATE_PICKING_LIST =
  "/api/material-management-service/picking-list/create-picking-list";
export const DELETE_PICKING_LIST =
  "/api/material-management-service/picking-list/delete-picking-list/";
export const GET_DETAIL_PICKING_LIST =
  "/api/material-management-service/picking-list/get-detail";
export const GET_ALL_PICKING_LIST_CREATE =
  "/api/material-management-service/picking-list/get-all-transfer-request-new";

//InventoryByTime
export const EXPORT_INVENTORY_BY_TIME_TO_EXCEL =
  "/api/material-management-service/inventory-report/export-by-time";
export const GET_ALL_INVENTORY_BY_TIME_SAGA =
  "/api/material-management-service/inventory-report/inventory-by-time";

// Báo cáo tồn kho
export const GET_INVENTORY_REPORT_API =
  "/api/material-management-service/inventory-report/inventory-by-period";
export const EXPORT_INVENTORY_REPORT_PERIOD_API =
  "/api/material-management-service/inventory-report/export-by-period";

//Kiểm kê
export const GET_ALL_INVENTORY_CHECK_API =
  "/api/material-management-service/inventory-check-info/get-all";
export const CREATE_INVENTORY_CHECK_API =
  "/api/material-management-service/inventory-check-info/create-inventory-check-info";
export const START_INVENTORY_CHECK_API =
  "/api/material-management-service/inventory-check-info/start";
export const DELETE_INVENTORY_CHECK_API =
  "/api/material-management-service/inventory-check-info/delete-inventory-check-info/";
export const GET_DETAIL_INVENTORY_CHECK_API =
  "/api/material-management-service/inventory-check-info/get-detail/";
export const UPDATE_INVENTORY_CHECK_API =
  "/api/material-management-service/inventory-check-info/update-inventory-check-info";
export const END_INVENTORY_CHECK_API =
  "/api/material-management-service/inventory-check-info/end";

//Standardpacking
export const GET_ALL_STANDARDPAKING_SAGA =
  "/api/material-management-service/standardpacking/get-all";
export const ADD_STANDARDPAKING_SAGA =
  "/api/material-management-service/standardpacking/create-standardpacking";
export const EDIT_STANDARDPAKING_SAGA =
  "/api/material-management-service/standardpacking/update-standardpacking";
export const DELETE_STANDARDPAKING_SAGA =
  "/api/material-management-service/standardpacking/delete-standardpacking/";

//Packagetype
export const GET_ALL_PACKAGETYPE_API =
  "/api/material-management-service/packagetype/get-all";
export const CREATE_PACKAGETYPE_API =
  "/api/material-management-service/packagetype/create-packagetype";
export const UPDATE_PACKAGETYPE_API =
  "/api/material-management-service/packagetype/update-packagetype";
export const DELETE_PACKAGETYPE_API =
  "/api/material-management-service/packagetype/delete-packagetype/";
export const GET_DETAIL_PACKAGETYPE_API =
  "/api/material-management-service/packagetype/get-detail/";

// thực hiện kiểm kê
export const GET_DROPDOWN_BY_CHECK_INVENTORY_CODE =
  "/api/material-management-service/inventory-check-info/get-dropdown-by-checkinventorycode";
export const GET_lOCATION_BY_LOCATION_CHECKING_CODE =
  "/api/material-management-service/inventory-check-info/get-locations-by-locationchecking";
export const GET_INVENTORY_CHECK_BY_PACKAGE_INFO =
  "/api/material-management-service/inventory-check-info/get-info-by-packagecode";
export const GET_INVENTORY_CHECK_BY_GOOD_INFO =
  "/api/material-management-service/inventory-check-info/get-info-by-goodscode";
export const COMPLETE_INVENTORY_CHECK =
  "/api/material-management-service/inventory-check-info/complete";
export const GET_INFO_BY_SLOC_CODE = "/api/material-management-service/inventory-check-info/get-info-by-sloc";
//Movementtype
export const GET_ALL_MOVEMENTTYPE_SAGA =
  "/api/material-management-service/movementtype/get-all";
export const ADD_MOVEMENTTYPE_SAGA =
  "/api/material-management-service/movementtype/create-movementtype";
export const EDIT_MOVEMENTTYPE_SAGA =
  "/api/material-management-service/movementtype/update-movementtype";
export const DELETE_MOVEMENTTYPE_SAGA =
  "/api/material-management-service/movementtype/delete-movementtype/";

// product requirement
export const GET_ALL_PRODUCTION_REQUIRMENT_API =
  "/api/production-management-service/productionrequirement/get-all";
export const CREATE_PRODUCTION_REQUIRMENT_API =
  "/api/production-management-service/productionrequirement/create-productionrequirement";
export const UPDATE_PRODUCTION_REQUIRMENT_API =
  "/api/production-management-service/productionrequirement/update-productionrequirement";
export const DELETE_PRODUCTION_REQUIRMENT_API =
  "/api/production-management-service/productionrequirement/delete-productionrequirement/";
export const GET_DETAIL_PRODUCTION_REQUIRMENT_API =
  "/api/production-management-service/productionrequirement/get-detail/";

// get new code product requirment
export const GET_NEW_CODE_PRODUCT_API = "/api/production-management-service/common/get-code";
export const GET_NEW_CODE_MACHINE_API = "/api/maintenance-management-service/machine/get-code-machinetype";

export const GET_NEW_CODE_MAINTAINER_API = "/api/maintenance-management-service/machine/get-code"
