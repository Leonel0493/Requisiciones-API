using Requisiciones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Requisiciones.DTO
{
    public class Positions_DTO
    {
        private readonly RequisitionsDbContext _dbContext;

        public Positions_DTO(RequisitionsDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public Positions GetPosition(int id)
        {
            Positions position = null;

            try
            {
                position = _dbContext.Positions.FirstOrDefault(x => x.idPuesto == id);

                return position;
            }
            catch(Exception e)
            {
                position = null;
                return position;
            }
        }

        public List<Positions> GetPositions()
        {
            List<Positions> lstPositions = null;

            try
            {
                lstPositions = _dbContext.Positions.ToList();

                return lstPositions;
            }
            catch(Exception e)
            {
                lstPositions = null;
                return lstPositions;
            }
        }

        public bool SavePosition(Positions position)
        {
            try
            {
                if (String.IsNullOrEmpty(position.puesto))
                    return false;

                _dbContext.Positions.Add(position);
                _dbContext.SaveChanges();

                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public bool UpdatePosition(int id, Positions position)
        {
            try
            {
                if (position.idPuesto != id)
                    return false;

                _dbContext.Entry(position).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _dbContext.SaveChanges();

                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public bool DetePosition(int id)
        {
            try
            {
                var position = _dbContext.Positions.FirstOrDefault(x => x.idPuesto == id);

                if (position == null)
                    return false;

                _dbContext.Positions.Remove(position);
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
