export const StatusLogin = {
  USER_LOGIN_SUCCESS: 1,
  USER_LOGIN_NOT_EXITS: 2,
  USER_LOGIN_NOT_VERYFY: 3,
};

export const CookiesType = {
  mes_login_app: "mes_login_app",
};
// enum style base của select 
export const SelectFunctionStyles = {
  control: (styles, { isDisabled, isFocused, isHover }) => ({
    ...styles,
    "&:hover": {
      border: "1px solid #2684ff",
    },
    height: "40px",
    margin: "0px",
    flexWrap: "inherit",
    backgroundColor: isDisabled ? "#e9ecef" : "white",
    ...(isDisabled && {
      pointerEvents: "auto",
      cursor: "not-allowed",
    }),
    border: isFocused ? "1px solid #2684ff" : "0.px solid #CECECE",
    borderRadius: isHover ? "10px" : "",
    padding: "0",
    boxShadow: isFocused ? "0 0 2px #2684ff" : "",
  }),

  option: (styles, { isDisabled }) => {
    return {
      ...styles,
      cursor: isDisabled ? "not-allowed" : "default",
      zIndex: "9999",
      width: "100%",
      position: "relative",
    };
  },
  input: (styles, { isDisabled }) => {
    return {
      ...styles,
      cursor: isDisabled ? "not-allowed" : "default",
      color: "black",
      width: "100%",
      height: "40px",
    };
  },
  placeholder: (styles, { isDisabled }) => {
    return {
      ...styles,
      cursor: isDisabled ? "not-allowed" : "default",
      color: "#212529",
      opacity: "0.7",
      whiteSpace: "nowrap",
      overflow: "hidden",
      textOverflow: "ellipsis",
    };
  },
  singleValue: (styles, { isDisabled, isSelected }) => {
    return {
      ...styles,
      cursor: isDisabled ? "not-allowed" : "default",
      color: "black",
      width: isSelected ? "100%" : "100%",
      height: "40px",
      alignItems: "center",
      display: 'flex'
    };
  },
  menu: (styles, { isDisabled }) => {
    return {
      ...styles,
      cursor: isDisabled ? "not-allowed" : "default",
      color: "black",
      position: "absolute",
      top: "100%",
      width: "100%",
      zIndex: "5"
    };
  },
  menuPortal: base => ({ ...base, zIndex: 9999 })
};
export const SelectMutiStyles = {
  control: (styles, { isDisabled, isFocused, isHover }) => ({
    ...styles,
    "&:hover": {
      border: "1px solid #2684ff",
    },
    height: "40px",
    margin: "0px",
    flexWrap: "inherit",
    backgroundColor: isDisabled ? "#e9ecef" : "white",
    ...(isDisabled && {
      pointerEvents: "auto",
      cursor: "not-allowed",
    }),
    border: isFocused ? "1px solid #2684ff" : "0.px solid #CECECE",
    overflow: 'auto',
    position: 'relative',
  }),
  indicatorsContainer: (styles, { isDisabled }) => {
    return {
      ...styles,
      position: "sticky",
      top: 0,
    };
  },
  valueContainer: (styles, { isDisabled }) => {
    return {
      ...styles,
    };
  },
  option: (styles, { isDisabled }) => {
    return {
      ...styles,
      cursor: isDisabled ? "not-allowed" : "default",
      zIndex: "9999",
      width: "100%",
      position: "relative",
    };
  },

  input: (styles, { isDisabled }) => {
    return {
      ...styles,
      cursor: isDisabled ? "not-allowed" : "default",
      height: "32px",
    };
  },
  placeholder: (styles, { isDisabled }) => {
    return {
      ...styles,
      cursor: isDisabled ? "not-allowed" : "default",
      color: "#212529",
      opacity: "0.7",
      whiteSpace: "nowrap",
      overflow: "hidden",
      textOverflow: "ellipsis",
    };
  },
  singleValue: (styles, { isDisabled, isSelected }) => {
    return {
      ...styles,
      cursor: isDisabled ? "not-allowed" : "default",
      color: "black",
      width: isSelected ? "100%" : "100%",
      height: "40px",
      alignItems: "center",
      display: 'flex'
    };
  },
  menu: (styles, { isDisabled }) => {
    return {
      ...styles,
      cursor: isDisabled ? "not-allowed" : "default",
      color: "black",
      position: "absolute",
      top: "100%",
      width: "100%",
      zIndex: "9999"
    };
  },
  menuPortal: base => ({ ...base, zIndex: 9999 })
};
//______________________các enum để lấy dropdown hoặc gen code type___________________________________ 
// config gen này bên production v2
export const ConfigGenProduct = {
  Productionrequirement: 1,
  Model: 2,
  Product: 3,
  GenTemPackage: 4,
  GenTemPallet: 5,
  GenTemCatton: 6,
  GenTemBox: 7,
  GenWorkorder: 8,
  GenCheckpoint: 9,
  GenCodeItem: 10,
  GenChecklist: 11,
  GenLotQc: 12,
};

// config gen này bên material
export const ConfigGen = {
  Package: 3,
  Storebill: 4,
  PO: 5,
  TransferRequest: 6,
  PickingList: 7,
  Whmovetransaction: 8,
};
export const ConfigGenMaintance = {
  Machine: 1,
  Period: 2,
}
// dropdown bên production
export const DropDownType = {
  WorkArea: 1,
  WorkCenter: 2,
  WorkUnit: 3,
  Worker: 4,
  Type: 5,
  Function: 6,
  GroupWorkDay: 7,
  WorkAreaOnlyChild: 8,
  Skill: 9,
  Provinces: 10,
  District: 11,
  Position: 12,
  Department: 13,
  Product: 14,
  Calendar: 15,
  BomSlot: 16,
  Sop: 17,
  ProductStatusBomCreate: 18,
  Model: 19,
  ApprvalDefaultStep: 20,
  Process: 21,
  Productionrequirement: 22,
  StepProcess: 23,
  Checkpoint: 24,
  Checklist: 25,
  Workorder: 26,
  Error: 27,
};
export const DropDownByCodeType = {
  workUnit: 3,
  workOrder: 26,
  stepByWu: 29
};
//drop down bên maintain
export const DropDownTypeMatainer = {
  MachineType: 1,
  Machine: 2,
  MachineV2: 3,
};
//drop down bên material
export const DropDownTypeMaterial = {
  Unit: 1,
  TypeMaterial: 2,
  Material: 3, //lấy drowdown material để đổ vào select
  configgenCode: 4,
  locationMotherActive: 5,
  Location: 6,
  packageType: 7,
  Partner: 8,
  PO: 9,
  Petitioner: 10,
  LocationSystem: 11,
  LocationLevel: 12, // tìm cấp bậc location
  InventoryCheckInfo: 13, // lấy danh sách dropdown mã kiểm kê
  MaterialVer2: 14, //lấy drowdown material để đổ vào multi-select
  MaterialVer3: 15,
};
//______________________các enum trạng thái popup , checkbox , baseList___________________________________ 
export const modalStatus = {
  CREATE: 1, // tạo mới
  UPDATE: 2, // cập nhật
  GETDETAIL: 3, // xem chi tiết
  ACTION: 4, //Tiến hành
  ACCEPTANCE: 5, // Nghiệm thu
  DEFAULT: 0,
};
export const DeliveryOrderStatus = {
  DaGiao: "DaGiao",
  ChuaGiao: "ChuaGiao",
};

export const CheckboxTypes = {
  Ellipse: 1, //bầu dục
  Square: 2, //vuông
  Circle: 3, //tròn
};
export const baseListData = {
  baseIndex: 1, // pageIndex goi danh sach
  baseSize: 10, // pageSize goi danh sach
  baseSearchText: "",
};

export const isFormOpen = {
  open: true,
  close: false,
};

export const TypeProductDropdown = [
  { value: 3, label: "Hàng Finish Good" },
  { value: 2, label: "Hàng Semi Finish Good" },
  { value: 4, label: "Hàng đặc biệt" },
];

export const ApprovalTypeStatus = {
  SOP: "SOP",
  BOM: "BOM",
  PROCESS: "PROCESS",
};

