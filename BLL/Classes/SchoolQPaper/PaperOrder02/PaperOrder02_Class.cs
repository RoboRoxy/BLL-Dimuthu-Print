using BLL.Data.Grid_DS;
using BLL.Data.SchoolQPaper.SchoolQPaper_entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Classes.SchoolQPaper.PaperOrder02
{
    public class PaperOrder02_Class
    {
        public void Delete(SchoolQPaper_entities entities, int PPRODR02_id)
        {
            bool dispose = entities == null;
            entities = entities ?? new SchoolQPaper_entities();

            System.Data.Entity.DbContextTransaction trans = null;
            if (dispose)
                trans = entities.Database.BeginTransaction();

            entities.TRN_PaperOrder02_D.Where(x => x.PPRODR02_id == PPRODR02_id).ToList().ForEach(r =>
            {
                new TRN_PaperOrder02_D_Class().Delete(entities, r.PPRODR02D_id);
            });
            new TRN_PaperOrder02_H_Class().Delete(entities, PPRODR02_id);

            int RECEIVABLES_id = entities.TRN_Receivable.Where(x => x.RECEIVABLES_doc_id == PPRODR02_id && x.DOCU_id == Misc.Properties.DBs.SchoolQPaper.dbo.MST_Document.Records.Up_to_A_L_Invoice).FirstOrDefault().RECEIVABLES_id;
            entities.TRN_Receivable.Where(x => x.RECEIVABLES_ref_id != null && x.RECEIVABLES_ref_id == RECEIVABLES_id && x.DOCU_id == Misc.Properties.DBs.SchoolQPaper.dbo.MST_Document.Records.Receipt).ToList().ForEach(r =>
            {
                new Receipt.Receipt_Class().Delete(entities, r.RECEIVABLES_doc_id);
            });
            new TRN_Receivable_Class().Delete(entities, RECEIVABLES_id);

            if (dispose)
            {
                trans.Commit();
                trans.Dispose();
                entities.Dispose();
            }
        }

        public TRN_PaperOrder02_H Save(SchoolQPaper_entities entities, string PPRODR02_code, DateTime PPRODR02_datetime,
            string PPRODR02_remarks, decimal PPRODR02_advanced_pay, string PPRODR02_cheque_no, string PPRODR02_mo_office, 
            string PPRODR02_font, decimal PPRODR02_gross_tot, decimal PPRODR02_discount_amnt, decimal PPRODR02_net_tot, 
            decimal PPRODR02_discount_percnt, string PPRODR02_telephone, string PPRODR02_train_received_by, 
            string PPRODR02_train_received_by_nic, Tuple<int?, string> MST_TrainStation_rec, int SCHL_id, int DELIMETH_id,
            int PAYTYP_id,
            List<PaperOrderD_Rec> PaperOrderD_Recs)
        {
            bool dispose = entities == null;
            entities = entities ?? new SchoolQPaper_entities();

            TRN_PaperOrder02_H paperorder02_rec = null;

            System.Data.Entity.DbContextTransaction trans = null;
            if (dispose)
                trans = entities.Database.BeginTransaction();

            try
            {
                if (MST_TrainStation_rec.Item1 != null && MST_TrainStation_rec.Item1 == 0)
                {
                    var trainstation_rec = new MST_TrainStation_Class().Insert(entities, MST_TrainStation_rec.Item2, PPRODR02_font);
                    MST_TrainStation_rec = new Tuple<int?, string>(trainstation_rec.TRAINST_id, trainstation_rec.TRAINST_name);
                }

                PPRODR02_code = new Document.Document_Class().GetDocumentCode(entities, Misc.Properties.DBs.SchoolQPaper.dbo.MST_Document.Records.Up_to_A_L_Invoice);
                paperorder02_rec = new TRN_PaperOrder02_H_Class().Insert(entities,
                    PPRODR02_code,
                    PPRODR02_datetime,
                    PPRODR02_remarks,
                    PPRODR02_advanced_pay,
                    PPRODR02_cheque_no,
                    PPRODR02_mo_office,
                    PPRODR02_font,
                    PPRODR02_gross_tot,
                    PPRODR02_discount_amnt,
                    PPRODR02_net_tot,
                    PPRODR02_discount_percnt,
                    PPRODR02_telephone,
                    PPRODR02_train_received_by,
                    PPRODR02_train_received_by_nic,
                    MST_TrainStation_rec.Item1,
                    SCHL_id,
                    DELIMETH_id,
                    PAYTYP_id);

                PaperOrderD_Recs.ForEach(r =>
                {
                    new TRN_PaperOrder02_D_Class().Insert(entities, r.PPRODR02D_paper_qty, r.GRADE_id, r.SUBJ_id, paperorder02_rec.PPRODR02_id);
                });

                new TRN_Receivable_Class().Insert(entities,
                    paperorder02_rec.PPRODR02_id,
                    PPRODR02_net_tot,
                    PPRODR02_net_tot,
                    null,
                    Misc.Properties.DBs.SchoolQPaper.dbo.MST_Document.Records.Up_to_A_L_Invoice);

                if (PPRODR02_advanced_pay != 0)
                {
                    DS_Receipt DS_Receipt_Obj = new DS_Receipt();
                    DS_Receipt_Obj.OutstandingInvoices.AddOutstandingInvoicesRow(paperorder02_rec.PPRODR02_id,
                        Misc.Properties.DBs.SchoolQPaper.dbo.MST_Document.Records.Up_to_A_L_Invoice,
                        PPRODR02_code,
                        PPRODR02_advanced_pay,
                        PPRODR02_net_tot,
                        SCHL_id,
                        "",
                        "",
                        Settings.Default.CurrentFont);

                    int PayTypes_Id = DS_Receipt_Obj.PayTypes.AddPayTypesRow(PAYTYP_id,
                        "",
                        PPRODR02_advanced_pay,
                        "",
                        "").Id;

                    if (PAYTYP_id == Misc.Properties.DBs.SchoolQPaper.dbo.MST_PayType.Records.Cheque)
                    {
                        DS_Receipt_Obj.ChequeInfo.AddChequeInfoRow(PayTypes_Id,
                            PPRODR02_cheque_no,
                            DateTime.Now);
                    }
                    else if (PAYTYP_id == Misc.Properties.DBs.SchoolQPaper.dbo.MST_PayType.Records.MO)
                    {
                        DS_Receipt_Obj.MoneyOrderInfo.AddMoneyOrderInfoRow(PayTypes_Id,
                            DateTime.Now,
                            PPRODR02_cheque_no,
                            PPRODR02_mo_office);
                    }

                    new Receipt.Receipt_Class().Save(entities,
                        "",
                        PPRODR02_datetime,
                        PPRODR02_datetime,
                        PPRODR02_advanced_pay,
                        "",
                        Settings.Default.CurrentFont,
                        SCHL_id,
                        null,
                        DS_Receipt_Obj);
                }

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
            return paperorder02_rec;
        }

        public TRN_PaperOrder02_H Update(SchoolQPaper_entities entities, int PPRODR02_id, string PPRODR02_code, DateTime PPRODR02_datetime,
            string PPRODR02_remarks, decimal PPRODR02_advanced_pay, string PPRODR02_cheque_no, string PPRODR02_mo_office,
            string PPRODR02_font, decimal PPRODR02_gross_tot, decimal PPRODR02_discount_amnt, decimal PPRODR02_net_tot,
            decimal PPRODR02_discount_percnt, string PPRODR02_telephone, string PPRODR02_train_received_by,
            string PPRODR02_train_received_by_nic, Tuple<int?, string> MST_TrainStation_rec, int SCHL_id, int DELIMETH_id,
            int PAYTYP_id,
            List<PaperOrderD_Rec> PaperOrderD_Recs)
        {
            bool dispose = entities == null;
            entities = entities ?? new SchoolQPaper_entities();

            TRN_PaperOrder02_H paperorder02_rec = null;
            
            System.Data.Entity.DbContextTransaction trans = null;
            if (dispose)
                trans = entities.Database.BeginTransaction();
            
            try
            {
                if (MST_TrainStation_rec.Item1 != null && MST_TrainStation_rec.Item1 == 0)
                {
                    var trainstation_rec = new MST_TrainStation_Class().Insert(entities, MST_TrainStation_rec.Item2, PPRODR02_font);
                    MST_TrainStation_rec = new Tuple<int?, string>(trainstation_rec.TRAINST_id, trainstation_rec.TRAINST_name);
                }

                paperorder02_rec = new TRN_PaperOrder02_H_Class().Update(entities,
                    PPRODR02_id,
                    PPRODR02_code,
                    PPRODR02_datetime,
                    PPRODR02_remarks,
                    PPRODR02_advanced_pay,
                    PPRODR02_cheque_no,
                    PPRODR02_mo_office,
                    PPRODR02_font,
                    PPRODR02_gross_tot,
                    PPRODR02_discount_amnt,
                    PPRODR02_net_tot,
                    PPRODR02_discount_percnt,
                    PPRODR02_telephone,
                    PPRODR02_train_received_by,
                    PPRODR02_train_received_by_nic,
                    MST_TrainStation_rec.Item1,
                    SCHL_id,
                    DELIMETH_id,
                    PAYTYP_id);

                entities.TRN_PaperOrder02_D.Where(x => x.PPRODR02_id == PPRODR02_id).ToList().ForEach(r =>
                {
                    new TRN_PaperOrder02_D_Class().Delete(entities, r.PPRODR02D_id);
                });

                int RECEIVABLES_id = entities.TRN_Receivable.Where(x => x.RECEIVABLES_doc_id == PPRODR02_id && x.DOCU_id == Misc.Properties.DBs.SchoolQPaper.dbo.MST_Document.Records.Up_to_A_L_Invoice).FirstOrDefault().RECEIVABLES_id;
                entities.TRN_Receivable.Where(x => x.RECEIVABLES_ref_id != null && x.RECEIVABLES_ref_id == RECEIVABLES_id && x.DOCU_id == Misc.Properties.DBs.SchoolQPaper.dbo.MST_Document.Records.Receipt).ToList().ForEach(r =>
                {
                    new Receipt.Receipt_Class().Delete(entities, r.RECEIVABLES_doc_id);
                });
                new TRN_Receivable_Class().Delete(entities, RECEIVABLES_id);

                PaperOrderD_Recs.ForEach(r =>
                {
                    new TRN_PaperOrder02_D_Class().Insert(entities, r.PPRODR02D_paper_qty, r.GRADE_id, r.SUBJ_id, paperorder02_rec.PPRODR02_id);
                });

                new TRN_Receivable_Class().Insert(entities,
                    paperorder02_rec.PPRODR02_id,
                    PPRODR02_net_tot,
                    PPRODR02_net_tot,
                    null,
                    Misc.Properties.DBs.SchoolQPaper.dbo.MST_Document.Records.Up_to_A_L_Invoice);

                if (PPRODR02_advanced_pay != 0)
                {
                    DS_Receipt DS_Receipt_Obj = new DS_Receipt();
                    DS_Receipt_Obj.OutstandingInvoices.AddOutstandingInvoicesRow(paperorder02_rec.PPRODR02_id,
                        Misc.Properties.DBs.SchoolQPaper.dbo.MST_Document.Records.Up_to_A_L_Invoice,
                        PPRODR02_code,
                        PPRODR02_advanced_pay,
                        PPRODR02_net_tot,
                        SCHL_id,
                        "",
                        "",
                        Settings.Default.CurrentFont);

                    int PayTypes_Id = DS_Receipt_Obj.PayTypes.AddPayTypesRow(PAYTYP_id,
                        "",
                        PPRODR02_advanced_pay,
                        "",
                        "").Id;

                    if (PAYTYP_id == Misc.Properties.DBs.SchoolQPaper.dbo.MST_PayType.Records.Cheque)
                    {
                        DS_Receipt_Obj.ChequeInfo.AddChequeInfoRow(PayTypes_Id,
                            PPRODR02_cheque_no,
                            DateTime.Now);
                    }
                    else if (PAYTYP_id == Misc.Properties.DBs.SchoolQPaper.dbo.MST_PayType.Records.MO)
                    {
                        DS_Receipt_Obj.MoneyOrderInfo.AddMoneyOrderInfoRow(PayTypes_Id,
                            DateTime.Now,
                            PPRODR02_cheque_no,
                            PPRODR02_mo_office);
                    }

                    new Receipt.Receipt_Class().Save(entities,
                        "",
                        PPRODR02_datetime,
                        PPRODR02_datetime,
                        PPRODR02_advanced_pay,
                        "",
                        Settings.Default.CurrentFont,
                        SCHL_id,
                        null,
                        DS_Receipt_Obj);
                }

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
            return paperorder02_rec;
        }
    }

    public class PaperOrderD_Rec
    {
        public int PPRODR02D_paper_qty { get; set; }
        public int GRADE_id { get; set; }
        public int SUBJ_id { get; set; }
    }
}
