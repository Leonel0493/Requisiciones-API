using Requisiciones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Requisiciones.DTO
{
    public class Employees_DTO
    {
        private readonly RequisitionsDbContext _dbContext;

        public Employees_DTO(RequisitionsDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public Employees Authentication(string user, string password)
        {
            Employees employee = null;
            try
            {
                employee = _dbContext.Employees.FirstOrDefault(x => x.esActivo == true && x.usuario == user && x.clave == password);

                return employee;
            }
            catch(Exception e)
            {
                employee = null;
                return employee;
            }
        }

        public Employees GetEmployee(int id)
        {
            Employees employees = null;
            try
            {
                employees = _dbContext.Employees.FirstOrDefault(x => x.idEmpleado == id);

                return employees;
            }
            catch(Exception e)
            {
                employees = null;
                return employees;
            }
        }

        public List<Employees> GetAllEmployees()
        {
            List<Employees> lstEmployees = null;
            try
            {
                lstEmployees = _dbContext.Employees.ToList();

                return lstEmployees;
            }
            catch(Exception e)
            {
                lstEmployees = null;
                return lstEmployees;
            }
        }

        public bool SaveEmployee(Employees employee)
        {
            try
            {
                if (String.IsNullOrEmpty(employee.nombres) || String.IsNullOrEmpty(employee.apellidos) || String.IsNullOrEmpty(employee.usuario) || String.IsNullOrEmpty(employee.clave)
                || employee.idPuesto <= 0)
                    return false;

                if (_dbContext.Employees.Count(x => x.usuario == employee.usuario) > 0)
                    return false;

                _dbContext.Employees.Add(employee);
                _dbContext.SaveChanges();

                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public bool UpdateEmployee(int id, Employees employee)
        {
            try
            {
                if (employee.idEmpleado != id)
                    return false;

                _dbContext.Entry(employee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _dbContext.SaveChanges();

                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public bool DeleteEmployee(int id)
        {
            try
            {
                var employee = _dbContext.Employees.FirstOrDefault(x => x.idEmpleado == id);

                if (employee == null)
                    return false;

                _dbContext.Employees.Remove(employee);
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
