using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evo.Mes.Sop.Application.Common.Status
{
    public static class MachineStatus
    {
        public const int SanSangSuDung = 1;
        public const int DangSuDung = 2;
        public const int BaoTri = 3;
        public const int SuaChua = 4;
        public const int Huy = 5;
    }
    public static class TableTypeFile
    {
        public const int Machine = 1;
    }
    public static class TypeFile
    {
        public const int Excel = 1;
        public const int Word = 2;
        public const int Img = 3;
        public const int Another = 4;
        public const int PDF = 5;

    }
    public static class ModalStauts
    {
        public const int CREATE = 1; // tạo mới
        public const int UPDATE = 2; // cập nhật
        public const int GETDETAIL = 3; // xem chi tiết
    }
    public static class GetDetailWorkUnitMachine
    {
        public const int Success = 1;
        public const int NullRequest = 2;
    }
    public enum DropdownType
    {
        MachineType = 1,// lay danh sach drop down trong bang machine type
        Machine = 2,//lay danh sach drop down trong bang machine
        MachineV2 = 3,//lay danh sach drop down machinecode+machinename trong bang machine         
    }
    public enum getCodeType
    {
        Machine = 1, //get code may moc
        Period = 2, //get code chu ky bao duong
        MaintanceSchedule = 3, //get code lich bao duong
    }


    public enum MaintenanceScheduleStatus
    {
        Unfulfilled = 1, // chua thuc hien
        Processing = 2, // dang thuc hien
        Done = 3, // da thuc hien
        Skip = 4 // bo qua
    }

    public enum MachineStateAfterRepair
    {
        ready = 1,
        repair = 2,
        cancel = 3,
    }

    public enum TableName
    {
        Machine = 1,//may moc
        Machinetype = 2,//loai may moc
    }
}
