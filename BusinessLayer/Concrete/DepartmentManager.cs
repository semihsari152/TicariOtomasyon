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
    public class DepartmentManager : IDepartmentService
    {

        IDepartmentDal _departmentDal;

        public DepartmentManager(IDepartmentDal departmentDal)
        {
            _departmentDal = departmentDal;
        }


        public Department GetById(int id)
        {
            return _departmentDal.GetById(id);
        }

        public List<Department> GetList()
        {
            return _departmentDal.GetListAll();
        }

        public void TAdd(Department t)
        {
            _departmentDal.Insert(t);
        }

        public void TDelete(Department t)
        {
            _departmentDal.Update(t);
        }

        public void TUpdate(Department t)
        {
            _departmentDal.Update(t);
        }
    }
}
