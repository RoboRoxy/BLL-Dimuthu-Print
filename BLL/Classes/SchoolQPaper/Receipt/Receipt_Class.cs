using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Data.SchoolQPaper.SchoolQPaper_entities;
using BLL.Classes.Exceptions;

namespace BLL.Classes.SchoolQPaper.Receipt
{
    public class Receipt_Class
    {
        public void Delete(SchoolQPaper_entities entities, int RECEIPT_id)
        {
            bool dispose = entities == null;
            entities = entities ?? new SchoolQPaper_entities();

            System.Data.Entity.DbContextTransaction trans = null;
            if (dispose)
                trans = entities.Database.BeginTransaction();

            entities.TRN_Receipt_PayType.ToList().ForEach(r =>
            {
                if (r.TRN_Receipt_MO_Info.Count != 0)
                {
                    new TRN_Receipt_MO_Info_Class().Delete(entities, r.TRN_Receipt_MO_Info.FirstOrDefault().RECEIPTMO_id);
                }
                if (r.TRN_Receipt_CHQ_Info.Count != 0)
                {
                    new TRN_Receipt_CHQ_Info_Class().Delete(entities, r.TRN_Receipt_CHQ_Info.FirstOrDefault().RECEIPTCHQ_id);
                }
                new TRN_Receipt_PayType_Class().Delete(entities, r.RECEIPTPAYTYP_id);
            });

            entities.TRN_Receipt_D.ToList().ForEach(r =>
            {
                new TRN_Receipt_D_Class().Delete(entities, r.RECEIPTD_id);
            });

            new TRN_Receipt_H_Class().Delete(entities, RECEIPT_id);

            new TRN_Receivable_Class().Delete(entities, entities.TRN_Receivable.Where(x => x.RECEIVABLES_doc_id == RECEIPT_id && x.DOCU_id == Misc.Properties.DBs.SchoolQPaper.dbo.MST_Document.Records.Receipt).FirstOrDefault().RECEIVABLES_id);

            if (dispose)
            {
                trans.Commit();
                trans.Dispose();
                entities.Dispose();
            }
        }

        public TRN_Receipt_H Save(SchoolQPaper_entities entities, string RECEIPT_code, DateTime RECEIPT_date,
            DateTime RECEIPT_tran_date, decimal RECEIPT_amount, string RECEIPT_remarks, string RECEIPT_font, int? SCHL_id,
            int? AGENT_id,
            Data.Grid_DS.DS_Receipt DS_Receipt_Obj)
        {
            bool dispose = entities == null;
            entities = entities ?? new SchoolQPaper_entities();

            TRN_Receipt_H receipth_rec = null;

            System.Data.Entity.DbContextTransaction trans = null;
            if (dispose)
                trans = entities.Database.BeginTransaction();

            try
            {
                RECEIPT_code = new Document.Document_Class().GetDocumentCode(entities, Misc.Properties.DBs.SchoolQPaper.dbo.MST_Document.Records.Receipt);

                receipth_rec = new TRN_Receipt_H_Class().Insert(entities,
                    RECEIPT_code,
                    RECEIPT_date,
                    RECEIPT_tran_date,
                    RECEIPT_amount,
                    RECEIPT_remarks,
                    RECEIPT_font,
                    SCHL_id,
                    AGENT_id);

                DS_Receipt_Obj.OutstandingInvoices.ToList().ForEach(r =>
                {
                    if (r.RECEIPTD_amount != 0)
                    {
                        new TRN_Receipt_D_Class().Insert(entities,
                            r.RECEIPTD_amount,
                            r.RECEIPTD_doc_id,
                            receipth_rec.RECEIPT_id,
                            r.DOCU_id);

                        var outstanding_receivable_rec = entities.TRN_Receivable.Where(x => x.RECEIVABLES_doc_id == r.RECEIPTD_doc_id && x.DOCU_id == r.DOCU_id).FirstOrDefault();

                        if (outstanding_receivable_rec.RECEIVABLES_balance - r.RECEIPTD_amount < 0)
                        {
                            throw new AppErrorException("Invalid Receipt Amount", "The receipt amount exceeds the outstanding balance on " + r.RECEIPTD_doc_text + ".");
                        }

                        new TRN_Receivable_Class().Update(entities,
                            outstanding_receivable_rec.RECEIVABLES_id,
                            outstanding_receivable_rec.RECEIVABLES_doc_id,
                            outstanding_receivable_rec.RECEIVABLES_value,
                            outstanding_receivable_rec.RECEIVABLES_balance - r.RECEIPTD_amount,
                            outstanding_receivable_rec.RECEIVABLES_ref_id,
                            outstanding_receivable_rec.DOCU_id);

                        new TRN_Receivable_Class().Insert(entities,
                            receipth_rec.RECEIPT_id,
                            r.RECEIPTD_amount,
                            0,
                            outstanding_receivable_rec.RECEIVABLES_id,
                            Misc.Properties.DBs.SchoolQPaper.dbo.MST_Document.Records.Receipt);
                    }
                });

                DS_Receipt_Obj.PayTypes.ToList().ForEach(r =>
                {
                    var receiptpaytype_rec = new TRN_Receipt_PayType_Class().Insert(entities,
                        r.RECEIPTPAYTYP_amount,
                        r.PAYTYP_id,
                        receipth_rec.RECEIPT_id);

                    if (r.PAYTYP_id == Misc.Properties.DBs.SchoolQPaper.dbo.MST_PayType.Records.MO)
                    {
                        var moneyorderinfo_rec = DS_Receipt_Obj.MoneyOrderInfo.Where(x => x.PayTypes_Id == r.Id).FirstOrDefault();
                        new TRN_Receipt_MO_Info_Class().Insert(entities,
                            moneyorderinfo_rec.RECEIPTMO_date,
                            moneyorderinfo_rec.RECEIPTMO_no,
                            moneyorderinfo_rec.RECEIPTMO_office,
                            receiptpaytype_rec.RECEIPTPAYTYP_id);
                    }
                    else if (r.PAYTYP_id == Misc.Properties.DBs.SchoolQPaper.dbo.MST_PayType.Records.Cheque)
                    {
                        var chequeinfo_rec = DS_Receipt_Obj.ChequeInfo.Where(x => x.PayTypes_Id == r.Id).FirstOrDefault();
                        new TRN_Receipt_CHQ_Info_Class().Insert(entities,
                            chequeinfo_rec.RECEIPTCHQ_chq_no,
                            chequeinfo_rec.RECEIPTCHQ_date,
                            receiptpaytype_rec.RECEIPTPAYTYP_id);
                    }
                });

                if (dispose)
                    trans.Commit();
            }
            catch (Exception ex)
            {
                if (dispose)
                    trans.Rollback();
                throw ex;
            }

            if (dispose)
            {
                trans.Dispose();
                entities.Dispose();
            }
            return receipth_rec;
        }
    }
}
