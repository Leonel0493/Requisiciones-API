using Microsoft.EntityFrameworkCore;
using Requisiciones.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Requisiciones.DTO
{
    public class Requisitions_DTO
    {
        private readonly RequisitionsDbContext _dbContext;

        public Requisitions_DTO(RequisitionsDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public List<Requisitions> GetRequisitions(int idApplicant)
        {
            List<Requisitions> lstRequisitions = null;

            try
            {
                Employees_DTO _employeeDTO = new Employees_DTO(_dbContext);
                var employee = _employeeDTO.GetEmployee(idApplicant);

                if (employee == null || employee.esActivo == false)
                    return lstRequisitions;
                
                if (employee.idPuesto == 1)
                    lstRequisitions = _dbContext.Requisitions.FromSqlRaw("exec RequisitionByApplicant @id", new SqlParameter("id", idApplicant)).ToList();

                if(employee.idPuesto == 2)
                    lstRequisitions = _dbContext.Requisitions.FromSqlRaw("exec RequisitionByPurchases").ToList();

                return lstRequisitions;
            }
            catch(Exception e)
            {
                lstRequisitions = null;
                return lstRequisitions;
            }
        }

        public Requisitions GetRequisition(int idRequisition, int idEmployee)
        {
            Requisitions requisition = null;

            try
            {
                requisition = _dbContext.Requisitions.FirstOrDefault(x => x.idRequisicion == idRequisition);

                if (requisition == null)
                    return requisition;
                
                Employees_DTO _employeeDTO = new Employees_DTO(_dbContext);
                var employeeInfo = _employeeDTO.GetEmployee(idEmployee);

                if ((requisition.idEstado == 1 || requisition.idEstado == 3) && employeeInfo.idPuesto == 1)
                    return requisition;

                if (requisition.idEstado == 2 && employeeInfo.idPuesto == 1)
                    return requisition;

                return null;
            }
            catch(Exception e)
            {
                return null;
            }
        }

        public bool UpdateRequisition(int idRequisition, Requisitions requisition)
        {
            try
            {
                if (requisition.idRequisicion != idRequisition)
                    return false;

                _dbContext.Entry(requisition).State = EntityState.Modified;
                _dbContext.SaveChanges();

                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
    }
}
