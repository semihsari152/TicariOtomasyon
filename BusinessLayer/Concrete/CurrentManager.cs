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
    public class CurrentManager : ICurrentService
    {
        ICurrentDal _currentDal;

        public CurrentManager(ICurrentDal currentDal)
        {
            _currentDal = currentDal;
        }

        public Current GetById(int id)
        {
            return _currentDal.GetById(id);
        }

        public List<Current> GetList()
        {
            return _currentDal.GetListAll();
        }

        public void TAdd(Current t)
        {
            _currentDal.Insert(t);
        }

        public void TDelete(Current t)
        {
            _currentDal.Update(t);
        }

        public void TUpdate(Current t)
        {
            _currentDal.Update(t);
        }
    }
}
