﻿using System;
using System.Collections.Generic;
using System.Linq;
using PCCC.DAL;
using System.Windows.Forms;
using PCCC.Models.AutoGenerated;

namespace PCCC.Repositories
{
    class DAO_Pictures: Repository<Picture>
    {
        public List<Picture> All()
        {
            var listPicture = from a in dataContext.Pictures select a;
            return listPicture.ToList();
        }
        public bool ThemHinh(int id, string sPic, string detail, int idFor)
        {
            try
            {
                Picture pi = new Picture();
                pi.ID = id;
                pi.SPicture = sPic;
                pi.Detail = detail;
                pi.IDFormula = idFor;
                dataContext.Pictures.InsertOnSubmit(pi);
                dataContext.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Dữ liệu không hợp lệ. Xin vui lòng kiểm tra lại!");
                return false;
            }
        }
        public bool SuaHinh(int id, string sPic, string detail, int idFor)
        {
            try
            {
                Picture pi = dataContext.Pictures.Single(x => x.ID == id);
                pi.SPicture = sPic;
                pi.Detail = detail;
                pi.IDFormula = idFor;
                dataContext.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Dữ liệu không hợp lệ. Xin vui lòng kiểm tra lại!");
                return false;
            }
        }
        public bool XoaHinh(int id)
        {
            try
            {
                Picture pi = dataContext.Pictures.Single(i => i.ID == id);
                dataContext.Pictures.DeleteOnSubmit(pi);
                dataContext.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Dữ liệu không hợp lệ. Xin vui lòng kiểm tra lại!");
                return false;
            }
        }
    }
}
