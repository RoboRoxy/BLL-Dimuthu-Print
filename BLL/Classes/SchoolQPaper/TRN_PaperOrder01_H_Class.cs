using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Data.SchoolQPaper.SchoolQPaper_entities;

namespace BLL.Classes.SchoolQPaper
{
    public class TRN_PaperOrder01_H_Class
    {
        public void Delete(SchoolQPaper_entities entities, int PPRODR01_id)
        {
            bool dispose = entities == null;
            entities = entities ?? new SchoolQPaper_entities();

            entities.TRN_PaperOrder01_H.Remove(entities.TRN_PaperOrder01_H.Find(PPRODR01_id));
            entities.SaveChanges();

            if (dispose)
                entities.Dispose();
        }

        public TRN_PaperOrder01_H Insert(SchoolQPaper_entities entities, string PPRODR01_code, DateTime PPRODR01_datetime,
            string PPRODR01_remarks, decimal PPRODR01_advanced_pay, string PPRODR01_cheque_no, string PPRODR01_mo_office, 
            int PPRODR01_additional_papers, string PPRODR01_font, decimal PPRODR01_gross_tot, decimal PPRODR01_discount_amnt, 
            decimal PPRODR01_net_tot, decimal PPRODR01_discount_percnt, string PPRODR01_telephone, string PPRODR01_train_received_by,
            string PPRODR01_train_received_by_nic, int? TRAINST_id, int SCHL_id, int DELIMETH_id, int PAYTYP_id)
        {
            bool dispose = entities == null;
            entities = entities ?? new SchoolQPaper_entities();

            TRN_PaperOrder01_H paperorder01_rec = new TRN_PaperOrder01_H();
            paperorder01_rec.PPRODR01_code = PPRODR01_code;
            paperorder01_rec.PPRODR01_datetime = PPRODR01_datetime;
            paperorder01_rec.PPRODR01_remarks = PPRODR01_remarks;
            paperorder01_rec.PPRODR01_advanced_pay = PPRODR01_advanced_pay;
            paperorder01_rec.PPRODR01_cheque_no = PPRODR01_cheque_no;
            paperorder01_rec.PPRODR01_mo_office = PPRODR01_mo_office;
            paperorder01_rec.PPRODR01_additional_papers = PPRODR01_additional_papers;
            paperorder01_rec.PPRODR01_font = PPRODR01_font;
            paperorder01_rec.PPRODR01_gross_tot = PPRODR01_gross_tot;
            paperorder01_rec.PPRODR01_discount_amnt = PPRODR01_discount_amnt;
            paperorder01_rec.PPRODR01_net_tot = PPRODR01_net_tot;
            paperorder01_rec.PPRODR01_discount_percnt = PPRODR01_discount_percnt;
            paperorder01_rec.PPRODR01_telephone = PPRODR01_telephone;
            paperorder01_rec.PPRODR01_train_received_by = PPRODR01_train_received_by;
            paperorder01_rec.PPRODR01_train_received_by_nic = PPRODR01_train_received_by_nic;
            paperorder01_rec.TRAINST_id = TRAINST_id;
            paperorder01_rec.SCHL_id = SCHL_id;
            paperorder01_rec.DELIMETH_id = DELIMETH_id;
            paperorder01_rec.PAYTYP_id = PAYTYP_id;
            entities.TRN_PaperOrder01_H.Add(paperorder01_rec);
            entities.SaveChanges();

            if (dispose)
                entities.Dispose();
            return paperorder01_rec;
        }

        public TRN_PaperOrder01_H Update(SchoolQPaper_entities entities, int PPRODR01_id, string PPRODR01_code, DateTime PPRODR01_datetime,
            string PPRODR01_remarks, decimal PPRODR01_advanced_pay, string PPRODR01_cheque_no, string PPRODR01_mo_office,
            int PPRODR01_additional_papers, string PPRODR01_font, decimal PPRODR01_gross_tot, decimal PPRODR01_discount_amnt,
            decimal PPRODR01_net_tot, decimal PPRODR01_discount_percnt, string PPRODR01_telephone, string PPRODR01_train_received_by,
            string PPRODR01_train_received_by_nic, int? TRAINST_id, int SCHL_id, int DELIMETH_id, int PAYTYP_id)
        {
            bool dispose = entities == null;
            entities = entities ?? new SchoolQPaper_entities();

            TRN_PaperOrder01_H paperorder01_rec = entities.TRN_PaperOrder01_H.Find(PPRODR01_id);
            paperorder01_rec.PPRODR01_code = PPRODR01_code;
            paperorder01_rec.PPRODR01_datetime = PPRODR01_datetime;
            paperorder01_rec.PPRODR01_remarks = PPRODR01_remarks;
            paperorder01_rec.PPRODR01_advanced_pay = PPRODR01_advanced_pay;
            paperorder01_rec.PPRODR01_cheque_no = PPRODR01_cheque_no;
            paperorder01_rec.PPRODR01_mo_office = PPRODR01_mo_office;
            paperorder01_rec.PPRODR01_additional_papers = PPRODR01_additional_papers;
            paperorder01_rec.PPRODR01_font = PPRODR01_font;
            paperorder01_rec.PPRODR01_gross_tot = PPRODR01_gross_tot;
            paperorder01_rec.PPRODR01_discount_amnt = PPRODR01_discount_amnt;
            paperorder01_rec.PPRODR01_net_tot = PPRODR01_net_tot;
            paperorder01_rec.PPRODR01_discount_percnt = PPRODR01_discount_percnt;
            paperorder01_rec.PPRODR01_telephone = PPRODR01_telephone;
            paperorder01_rec.PPRODR01_train_received_by = PPRODR01_train_received_by;
            paperorder01_rec.PPRODR01_train_received_by_nic = PPRODR01_train_received_by_nic;
            paperorder01_rec.TRAINST_id = TRAINST_id;
            paperorder01_rec.SCHL_id = SCHL_id;
            paperorder01_rec.DELIMETH_id = DELIMETH_id;
            paperorder01_rec.PAYTYP_id = PAYTYP_id;
            entities.SaveChanges();

            if (dispose)
                entities.Dispose();
            return paperorder01_rec;
        }
    }
}
