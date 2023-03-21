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
    public class ReceiptDetailManager : IReceiptDetailService
    {
        IReceiptDetailDal _receiptDetailDal;

        public ReceiptDetailManager(IReceiptDetailDal receiptDetailDal)
        {
            _receiptDetailDal = receiptDetailDal;
        }

        public ReceiptDetail GetById(int id)
        {
            return _receiptDetailDal.GetById(id);
        }

        public List<ReceiptDetail> GetList()
        {
            return _receiptDetailDal.GetListAll();
        }

        public void TAdd(ReceiptDetail t)
        {
            _receiptDetailDal.Insert(t);
        }

        public void TDelete(ReceiptDetail t)
        {
            _receiptDetailDal.Delete(t);
        }

        public void TUpdate(ReceiptDetail t)
        {
            _receiptDetailDal.Update(t);
        }
    }
}
