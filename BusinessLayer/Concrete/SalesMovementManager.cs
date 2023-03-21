using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class SalesMovementManager : ISalesMovementService
    {
        ISalesMovementDal _salesMovementDal;

        public SalesMovementManager(ISalesMovementDal salesMovementDal)
        {
            _salesMovementDal = salesMovementDal;
        }

        public SalesMovement GetById(int id)
        {
            return _salesMovementDal.GetById(id);
        }

        public List<SalesMovement> GetList()
        {
            return _salesMovementDal.GetListAll();
        }

        public void TAdd(SalesMovement t)
        {
            _salesMovementDal.Insert(t);
        }

        public void TDelete(SalesMovement t)
        {
            _salesMovementDal.Delete(t);
        }

        public void TUpdate(SalesMovement t)
        {
            _salesMovementDal.Update(t);
        }
    }
}
