using System;
using System.Collections.Generic;
using Evo.Mes.Sop.Application.Common.Query;
namespace Application.GetMap
{
    public class MaChineGetMap
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Productioncompanyby { get; set; }

        public string Model { get; set; }

        public string Providedby { get; set; }

        public string Productionfrom { get; set; }

        public DateTime? Yearproduce { get; set; }

        public string Serinumber { get; set; }

        public string Unit { get; set; }

        public string? UnitName { get; set; }

        public string Capacity { get; set; }

        public double? Price { get; set; }

        public int? Depreciationtime { get; set; }

        public int? Maintancetime { get; set; }

        public int? Status { get; set; }

        public Guid? WorkAreaId { get; set; }
        public string WorkAreaName { get; set; }
        public Guid? Machinetype { get; set; }
        public string MachinetypeName { get; set; }

        public double? Heigh { get; set; }

        public double? Width { get; set; }

        public double? Length { get; set; }

        public List<ArrayFileObjectDetail> ArrayFile { get; set; }
    }
    public class MaChineGetMapDetail
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Productioncompanyby { get; set; }

        public string Model { get; set; }

        public string Providedby { get; set; }

        public string Productionfrom { get; set; }

        public DateTime? Yearproduce { get; set; }

        public string Serinumber { get; set; }

        public string Unit { get; set; }

        public string Capacity { get; set; }

        public double? Price { get; set; }

        public int? Depreciationtime { get; set; }

        public int? Maintancetime { get; set; }

        public int? Status { get; set; }

        public Guid? WorkAreaId { get; set; }

        public Guid? Machinetype { get; set; }

        public double? Heigh { get; set; }

        public double? Width { get; set; }

        public double? Length { get; set; }

        public List<ArrayFileObjectDetail> ArrayFile { get; set; }
    }
    public class ArrayFileObjectDetail
    {
        public Guid Id { get; set; }

        public int Type { get; set; }

        public string Url { get; set; }

        public int Tabletype { get; set; }

        public Guid Belongto { get; set; }
    }
    public class MaChineDropdownGetMap
    {
        public string Label { get; set; }
        public string Value { get; set; }
        public string Code { get; set; }
    }
    // form request để lấy danh sách máy móc 
    public class MachinePagingRequest : PagingQuery
    {
    }

    // form request để tạo hoặc cập nhật máy móc
    public class MachineFormRequest
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Productioncompanyby { get; set; }

        public string Model { get; set; }

        public string Providedby { get; set; }

        public string Productionfrom { get; set; }

        public DateTime? Yearproduce { get; set; }

        public string Serinumber { get; set; }

        public string Unit { get; set; }
        public string UnitName { get; set; }
        public string Capacity { get; set; }

        public double? Price { get; set; }

        public int? Depreciationtime { get; set; }

        public int? Maintancetime { get; set; }

        public int? Status { get; set; }

        public Guid? WorkAreaId { get; set; }
        public string WorkAreaName { get; set; }
        public Guid? Machinetype { get; set; }

        public double? Heigh { get; set; }

        public double? Width { get; set; }

        public double? Length { get; set; }

        public List<ArrayFileForFormRequestMachine> ArrayFile { get; set; }
    }
    // array file để tạo hoặc cập nhật 
    public class ArrayFileForFormRequestMachine
    {
        public Guid? Id { get; set; }

        public int Type { get; set; }

        public string Url { get; set; }

        public int Tabletype { get; set; }

        public Guid Belongto { get; set; }
    }
    public class MachineBomRequest
    {
        public List<string> listMachineCode { get; set; }
    }
    public class MachineBomGetMap
    {
        public string MachineCode { get; set; }
        public string MachineName { get; set; }
        public string Capacity { get; set; }
        public int Status { get; set; }
        public string Note { get; set; }
    }
    public class MachineInWorkUnitGetMap
    {
        public string MachineId { get; set; }
        public string MachineCode { get; set; }
        public string MachineName { get; set; }
        public string MachineTypeName { get; set; }
        public string MachineTypeId { get; set; }
    }
    public class MachineTypeInStepProcessGetMap
    {
        public string MachineTypeId { get; set; }
        public string MachineTypeName { get; set; }
    }
    public class DetailMachineByMachineCode
    {
        public string MachineId { get; set; }
        public string MachineName { get; set; }
        public string MachineCode { get; set; }
        public string MachineTypeId { get; set; }
        public string MachineTypeName { get; set; }

        public string Wattage { get; set; }
        public int type { get; set; }
    }
}
