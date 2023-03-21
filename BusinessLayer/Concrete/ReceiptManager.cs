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
    public class ReceiptManager : IReceiptService
    {
        IReceiptDal _receiptDal;

        public ReceiptManager(IReceiptDal receiptDal)
        {
            _receiptDal = receiptDal;
        }

        public Receipt GetById(int id)
        {
            return _receiptDal.GetById(id);
        }

        public List<Receipt> GetList()
        {
            return _receiptDal.GetListAll();
        }

        public void TAdd(Receipt t)
        {
            _receiptDal.Insert(t);
        }

        public void TDelete(Receipt t)
        {
            _receiptDal.Delete(t);
        }

        public void TUpdate(Receipt t)
        {
            _receiptDal.Update(t);
        }
    }
}
