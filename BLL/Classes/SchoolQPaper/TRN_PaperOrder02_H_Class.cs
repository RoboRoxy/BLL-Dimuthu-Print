using BLL.Data.SchoolQPaper.SchoolQPaper_entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Classes.SchoolQPaper
{
    public class TRN_PaperOrder02_H_Class
    {
        public void Delete(SchoolQPaper_entities entities, int PPRODR02_id)
        {
            bool dispose = entities == null;
            entities = entities ?? new SchoolQPaper_entities();

            entities.TRN_PaperOrder02_H.Remove(entities.TRN_PaperOrder02_H.Find(PPRODR02_id));
            entities.SaveChanges();

            if (dispose)
                entities.Dispose();
        }

        public TRN_PaperOrder02_H Insert(SchoolQPaper_entities entities, string PPRODR02_code, DateTime PPRODR02_datetime,
            string PPRODR02_remarks, decimal PPRODR02_advanced_pay, string PPRODR02_cheque_no, string PPRODR02_mo_office, 
            string PPRODR02_font, decimal PPRODR02_gross_tot, decimal PPRODR02_discount_amnt, decimal PPRODR02_net_tot, 
            decimal PPRODR02_discount_percnt, string PPRODR02_telephone, string PPRODR02_train_received_by,
            string PPRODR02_train_received_by_nic, int? TRAINST_id, int SCHL_id, int DELIMETH_id, int PAYTYP_id)
        {
            bool dispose = entities == null;
            entities = entities ?? new SchoolQPaper_entities();

            TRN_PaperOrder02_H paperorder02_rec = new TRN_PaperOrder02_H();
            paperorder02_rec.PPRODR02_code = PPRODR02_code;
            paperorder02_rec.PPRODR02_datetime = PPRODR02_datetime;
            paperorder02_rec.PPRODR02_remarks = PPRODR02_remarks;
            paperorder02_rec.PPRODR02_advanced_pay = PPRODR02_advanced_pay;
            paperorder02_rec.PPRODR02_cheque_no = PPRODR02_cheque_no;
            paperorder02_rec.PPRODR02_mo_office = PPRODR02_mo_office;
            paperorder02_rec.PPRODR02_font = PPRODR02_font;
            paperorder02_rec.PPRODR02_gross_tot = PPRODR02_gross_tot;
            paperorder02_rec.PPRODR02_discount_amnt = PPRODR02_discount_amnt;
            paperorder02_rec.PPRODR02_net_tot = PPRODR02_net_tot;
            paperorder02_rec.PPRODR02_discount_percnt = PPRODR02_discount_percnt;
            paperorder02_rec.PPRODR02_telephone = PPRODR02_telephone;
            paperorder02_rec.PPRODR02_train_received_by = PPRODR02_train_received_by;
            paperorder02_rec.PPRODR02_train_received_by_nic = PPRODR02_train_received_by_nic;
            paperorder02_rec.TRAINST_id = TRAINST_id;
            paperorder02_rec.SCHL_id = SCHL_id;
            paperorder02_rec.DELIMETH_id = DELIMETH_id;
            paperorder02_rec.PAYTYP_id = PAYTYP_id;
            entities.TRN_PaperOrder02_H.Add(paperorder02_rec);
            entities.SaveChanges();

            if (dispose)
                entities.Dispose();
            return paperorder02_rec;
        }

        public TRN_PaperOrder02_H Update(SchoolQPaper_entities entities, int PPRODR02_id, string PPRODR02_code, DateTime PPRODR02_datetime,
            string PPRODR02_remarks, decimal PPRODR02_advanced_pay, string PPRODR02_cheque_no, string PPRODR02_mo_office,
            string PPRODR02_font, decimal PPRODR02_gross_tot, decimal PPRODR02_discount_amnt, decimal PPRODR02_net_tot,
            decimal PPRODR02_discount_percnt, string PPRODR02_telephone, string PPRODR02_train_received_by,
            string PPRODR02_train_received_by_nic, int? TRAINST_id, int SCHL_id, int DELIMETH_id, int PAYTYP_id)
        {
            bool dispose = entities == null;
            entities = entities ?? new SchoolQPaper_entities();

            TRN_PaperOrder02_H paperorder02_rec = entities.TRN_PaperOrder02_H.Find(PPRODR02_id);
            paperorder02_rec.PPRODR02_code = PPRODR02_code;
            paperorder02_rec.PPRODR02_datetime = PPRODR02_datetime;
            paperorder02_rec.PPRODR02_remarks = PPRODR02_remarks;
            paperorder02_rec.PPRODR02_advanced_pay = PPRODR02_advanced_pay;
            paperorder02_rec.PPRODR02_cheque_no = PPRODR02_cheque_no;
            paperorder02_rec.PPRODR02_mo_office = PPRODR02_mo_office;
            paperorder02_rec.PPRODR02_font = PPRODR02_font;
            paperorder02_rec.PPRODR02_gross_tot = PPRODR02_gross_tot;
            paperorder02_rec.PPRODR02_discount_amnt = PPRODR02_discount_amnt;
            paperorder02_rec.PPRODR02_net_tot = PPRODR02_net_tot;
            paperorder02_rec.PPRODR02_discount_percnt = PPRODR02_discount_percnt;
            paperorder02_rec.PPRODR02_telephone = PPRODR02_telephone;
            paperorder02_rec.PPRODR02_train_received_by = PPRODR02_train_received_by;
            paperorder02_rec.PPRODR02_train_received_by_nic = PPRODR02_train_received_by_nic;
            paperorder02_rec.TRAINST_id = TRAINST_id;
            paperorder02_rec.SCHL_id = SCHL_id;
            paperorder02_rec.DELIMETH_id = DELIMETH_id;
            paperorder02_rec.PAYTYP_id = PAYTYP_id;
            entities.SaveChanges();

            if (dispose)
                entities.Dispose();
            return paperorder02_rec;
        }
    }
}
