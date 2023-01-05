using System.ComponentModel.DataAnnotations;

namespace MSS_API.Dto.Enums
{
    public enum DepartmentType : byte
    {
        [Display(Name = "EngineeringDept", Description = "Engineering Department")]
        EngineeringDept = 0,
        // Engineering design, Engineering, R&D

        [Display(Name = "InfastructureDept", Description = "Infastructure Department")]
        InfastructureDept = 1,
        // HR, IT

        [Display(Name = "FinancingDept", Description = "Financing Department")]
        FinancingDept = 2,
        // Sales & Marketing, Purchasing, Finance

        [Display(Name = "FactoryDept", Description = "Factory Department")]
        FactoryDept = 3,
    }
    //get String value
    //ServiceType = Enum.GetName(typeof(ServiceType), serviceCreate.ServiceType),

    //byte to enum value
    //ServiceType = (ServiceType)cp.ServiceType,

    //enum value to byte
    //ServiceType = (byte)ServiceType.Temporary,
}
