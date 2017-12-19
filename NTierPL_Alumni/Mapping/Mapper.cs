using NTierBLL_Alumni.Models;
using NTierDAL_Alumni.Models;
using NTierPL_Alumni.Models;
using NTierPL_Alumni.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NTierPL_Alumni.Mapping
{
    public static class Mapper
    {
        public static AlumniPO MapAlumniDOtoPO(AlumniDO frmAlumniDO)
        {
            //the method holds info of an AlumniDataObject and pass on an info
            //that is being converted to a presentation object.

            AlumniPO toAlumniPO = new AlumniPO();
            toAlumniPO.RecordID = frmAlumniDO.RecordID;
            toAlumniPO.CompleteName = frmAlumniDO.CompleteName;
            toAlumniPO.YearGraduated = frmAlumniDO.YearGraduated;
            toAlumniPO.Position = frmAlumniDO.Position;
            toAlumniPO.Company = frmAlumniDO.Company;
            toAlumniPO.ContactNumber = frmAlumniDO.ContactNumber;
            toAlumniPO.DepartmentID = frmAlumniDO.DepartmentID;
            toAlumniPO.Department = frmAlumniDO.Department.DeptName;
            return toAlumniPO;
        }

        public static AlumniDO MapAlumniPOtoDO(AlumniPO frmAlumniPO)
        {
            AlumniDO toAlumniDO = new AlumniDO();
            toAlumniDO.RecordID = frmAlumniPO.RecordID;
            toAlumniDO.CompleteName = frmAlumniPO.CompleteName;
            toAlumniDO.YearGraduated = frmAlumniPO.YearGraduated;
            toAlumniDO.Position = frmAlumniPO.Position;
            toAlumniDO.Company = frmAlumniPO.Company;
            toAlumniDO.ContactNumber = frmAlumniPO.ContactNumber;
            toAlumniDO.DepartmentID = frmAlumniPO.DepartmentID;
            return toAlumniDO;
        }

        public static AlumniBO MapAlumniDOtoBO(AlumniDO frmAlumniDO)
        {
            AlumniBO toAlumniBO = new AlumniBO();
            toAlumniBO.RecordID = frmAlumniDO.RecordID;
            toAlumniBO.CompleteName = frmAlumniDO.CompleteName;
            toAlumniBO.YearGraduated = frmAlumniDO.YearGraduated;
            toAlumniBO.Position = frmAlumniDO.Position;
            toAlumniBO.Company = frmAlumniDO.Company;
            toAlumniBO.ContactNumber = frmAlumniDO.ContactNumber;
            toAlumniBO.DepartmentID = frmAlumniDO.DepartmentID;
            return toAlumniBO;
        }

        public static AlumniDO MapAlumniBOtoDO(AlumniBO frmAlumniBO)
        {
            AlumniDO toAlumniDO = new AlumniDO();
            toAlumniDO.RecordID = frmAlumniBO.RecordID;
            toAlumniDO.CompleteName = frmAlumniBO.CompleteName;
            toAlumniDO.YearGraduated = frmAlumniBO.YearGraduated;
            toAlumniDO.Position = frmAlumniBO.Position;
            toAlumniDO.Company = frmAlumniBO.Company;
            toAlumniDO.ContactNumber = frmAlumniBO.ContactNumber;
            toAlumniDO.DepartmentID = frmAlumniBO.DepartmentID;
            return toAlumniDO;
        }

        public static AlumniPO MapAlumniBOtoPO(AlumniBO frmAlumniBO)
        {
            AlumniPO toAlumniPO = new AlumniPO();
            toAlumniPO.RecordID = frmAlumniBO.RecordID;
            toAlumniPO.CompleteName = frmAlumniBO.CompleteName;
            toAlumniPO.YearGraduated = frmAlumniBO.YearGraduated;
            toAlumniPO.Position = frmAlumniBO.Position;
            toAlumniPO.Company = frmAlumniBO.Company;
            toAlumniPO.ContactNumber = frmAlumniBO.ContactNumber;
            toAlumniPO.DepartmentID = frmAlumniBO.DepartmentID;
            return toAlumniPO;
        }

        public static DepartmentPO MapDepartmentDOtoPO(DepartmentDO frmDepartmentDO)
        {
            DepartmentPO toDepartmentPO = new DepartmentPO();
            toDepartmentPO.DeptID = frmDepartmentDO.DeptID;
            toDepartmentPO.DeptName = frmDepartmentDO.DeptName;
            toDepartmentPO.Description = frmDepartmentDO.Description;
            toDepartmentPO.DeptHead = frmDepartmentDO.DeptHead;
            toDepartmentPO.DeptHeadSpecialization = frmDepartmentDO.DeptHeadSpecialization;
            toDepartmentPO.AlumniCount = frmDepartmentDO.AlumniCount;
            return toDepartmentPO;
        }

        public static DepartmentDO MapDepartmentPOtoDO(DepartmentPO frmDepartmentPO)
        {
            DepartmentDO toDepartmentDO = new DepartmentDO();
            toDepartmentDO.DeptID = frmDepartmentPO.DeptID;
            toDepartmentDO.DeptName = frmDepartmentPO.DeptName;
            toDepartmentDO.Description = frmDepartmentPO.Description;
            toDepartmentDO.DeptHead = frmDepartmentPO.DeptHead;
            toDepartmentDO.DeptHeadSpecialization = frmDepartmentPO.DeptHeadSpecialization;
            toDepartmentDO.AlumniCount = frmDepartmentPO.AlumniCount;
            return toDepartmentDO;
        }

        public static DepartmentBO MapDepartmentDOtoBO(DepartmentDO frmDepartmentDO)
        {
            DepartmentBO toDepartmentBO = new DepartmentBO();
            toDepartmentBO.DeptID = frmDepartmentDO.DeptID;
            toDepartmentBO.DeptName = frmDepartmentDO.DeptName;
            toDepartmentBO.Description = frmDepartmentDO.Description;
            toDepartmentBO.DeptHead = frmDepartmentDO.DeptHead;
            toDepartmentBO.DeptHeadSpecialization = frmDepartmentDO.DeptHeadSpecialization;
            toDepartmentBO.AlumniCount = frmDepartmentDO.AlumniCount;
            return toDepartmentBO;
        }

        public static DepartmentDO MapDepartmentBOtoDO(DepartmentBO frmDepartmentBO)
        {
            DepartmentDO toDepartmentDO = new DepartmentDO();
            toDepartmentDO.DeptID = frmDepartmentBO.DeptID;
            toDepartmentDO.DeptName = frmDepartmentBO.DeptName;
            toDepartmentDO.Description = frmDepartmentBO.Description;
            toDepartmentDO.DeptHead = frmDepartmentBO.DeptHead;
            toDepartmentDO.DeptHeadSpecialization = frmDepartmentBO.DeptHeadSpecialization;
            toDepartmentDO.AlumniCount = frmDepartmentBO.AlumniCount;
            return toDepartmentDO;
        }

        public static DepartmentPO MapDepartmentBOtoPO(DepartmentBO frmDepartmentBO)
        {
            DepartmentPO toDepartmentPO = new DepartmentPO();
            toDepartmentPO.DeptID = frmDepartmentBO.DeptID;
            toDepartmentPO.DeptName = frmDepartmentBO.DeptName;
            toDepartmentPO.Description = frmDepartmentBO.Description;
            toDepartmentPO.DeptHead = frmDepartmentBO.DeptHead;
            toDepartmentPO.DeptHeadSpecialization = frmDepartmentBO.DeptHeadSpecialization;
            toDepartmentPO.AlumniCount = frmDepartmentBO.AlumniCount;
            return toDepartmentPO;
        }
        
        public static UserPO MapUserDOtoPO(UserDO frmUserDO)
        {
            UserPO toUserPO = new UserPO();
            toUserPO.UserID = frmUserDO.UserID;
            toUserPO.CompleteName = frmUserDO.CompleteName;
            toUserPO.UserName = frmUserDO.UserName;
            toUserPO.Password = frmUserDO.Password;
            toUserPO.RoleID = frmUserDO.RoleID;
            return toUserPO;
        }

        public static UserDO MapUserPOtoDO(UserPO frmUserPO)
        {
            UserDO toUserDO = new UserDO();
            toUserDO.UserID = frmUserPO.UserID;
            toUserDO.CompleteName = frmUserPO.CompleteName;
            toUserDO.UserName = frmUserPO.UserName;
            toUserDO.Password = frmUserPO.Password;
            toUserDO.RoleID = frmUserPO.RoleID;
            return toUserDO;
        }

        public static RolePO MapRoleDOtoPO(RoleDO frmRoleDO)
        {
            RolePO toRolePO = new RolePO();
            toRolePO.RoleID = frmRoleDO.RoleID;
            toRolePO.Name = frmRoleDO.Name;
            toRolePO.Description = frmRoleDO.Description;
            return toRolePO;
        }
    }
} 