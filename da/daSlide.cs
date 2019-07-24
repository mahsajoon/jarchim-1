using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using Jarchim.Models;
using Jarchim.Models.database;

namespace Jarchim.da
{
    public class daSlide
    {
        JarchimDb Db = new JarchimDb();

        static int RefNumber = 100;

        public List<mSlider> fSliderList()
        {
            var vSlider = (from a in Db.tbl_slider
                          select new mSlider
                          {
                              slider_id = a.slider_id,
                              slider_img = a.slider_img,
                              slider_link = a.slider_link,
                              slider_sort = a.slider_sort
                          }).OrderByDescending(b => b.slider_id);
            return vSlider.ToList();
        }

        public bool InsertSlider(mSlider pSliders)
        {
            try
            {
                tbl_slider s = new tbl_slider();
                Random rnd = new Random();
                s.slider_img = pSliders.slider_img;
                s.slider_link = pSliders.slider_link;
                s.slider_sort = pSliders.slider_sort;
                s.slider_id = rnd.Next();
                Db.tbl_slider.Add(s);
                return Convert.ToBoolean(Db.SaveChanges());
            }
            catch (Exception)
            {
                return false;
            }
        }

        public mSlider fGetSlider(mSlider pSlider)
        {
            try
            {

                var vSlider = (from s in Db.tbl_slider
                               where s.slider_id.Equals(pSlider.slider_id)
                              select new mSlider
                              {
                                  slider_id = s.slider_id,
                                  slider_img = s.slider_img,
                                  slider_link = s.slider_link,
                                  slider_sort = s.slider_sort
                              }).FirstOrDefault();
                return vSlider;
            }
            catch (Exception)
            {
                return null;
            }
        }


        public bool fUpdateSlider(mSlider pSlider)
        {
            try
            {
                tbl_slider s = new tbl_slider();
                s.slider_id = pSlider.slider_id;
                s.slider_img = pSlider.slider_img;
                s.slider_link = pSlider.slider_link;
                s.slider_sort = pSlider.slider_sort;
                Db.tbl_slider.Attach(s);
                Db.Entry(s).State = System.Data.Entity.EntityState.Modified;
                return Convert.ToBoolean(Db.SaveChanges());
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool fDeleteSlider(int pId)
        {
            try
            {
                var vSlider = (from a in Db.tbl_slider
                               where a.slider_id.Equals(pId)
                         select a).OrderBy(a => a.slider_id).SingleOrDefault();
                Db.tbl_slider.Remove(vSlider);
                return Convert.ToBoolean(Db.SaveChanges());
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}