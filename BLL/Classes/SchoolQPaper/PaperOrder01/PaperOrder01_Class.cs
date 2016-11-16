using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Data.SchoolQPaper.SchoolQPaper_entities;
using BLL.Data.Grid_DS;

namespace BLL.Classes.SchoolQPaper.PaperOrder01
{
    public class PaperOrder01_Class
    {
        public void Delete(SchoolQPaper_entities entities, int PPRODR01_id)
        {
            bool dispose = entities == null;
            entities = entities ?? new SchoolQPaper_entities();

            System.Data.Entity.DbContextTransaction trans = null;
            if (dispose)
                trans = entities.Database.BeginTransaction();

            entities.TRN_PaperOrder01_D.Where(x => x.PPRODR01_id == PPRODR01_id).ToList().ForEach(r =>
            {
                new TRN_PaperOrder01_D_Class().Delete(entities, r.PPRODR01D_id);
            });
            new TRN_PaperOrder01_H_Class().Delete(entities, PPRODR01_id);

            int RECEIVABLES_id = entities.TRN_Receivable.Where(x => x.RECEIVABLES_doc_id == PPRODR01_id && x.DOCU_id == Misc.Properties.DBs.SchoolQPaper.dbo.MST_Document.Records.Up_to_O_L_Invoice).FirstOrDefault().RECEIVABLES_id;
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

        public TRN_PaperOrder01_H Save(SchoolQPaper_entities entities, string PPRODR01_code, DateTime PPRODR01_datetime,
            string PPRODR01_remarks, decimal PPRODR01_advanced_pay, string PPRODR01_cheque_no, string PPRODR01_mo_office, 
            int PPRODR01_additional_papers, string PPRODR01_font, decimal PPRODR01_gross_tot, decimal PPRODR01_discount_amnt, 
            decimal PPRODR01_net_tot, decimal PPRODR01_discount_percnt, string PPRODR01_telephone, string PPRODR01_train_received_by, 
            string PPRODR01_train_received_by_nic, Tuple<int?, string>  MST_TrainStation_rec, int SCHL_id, int DELIMETH_id,
            int PAYTYP_id,
            List<PaperOrderD_Rec> PaperOrderD_Recs)
        {
            bool dispose = entities == null;
            entities = entities ?? new SchoolQPaper_entities();

            TRN_PaperOrder01_H paperorder01_rec = null;

            System.Data.Entity.DbContextTransaction trans = null;
            if(dispose)
                trans = entities.Database.BeginTransaction();

            try
            {
                if (MST_TrainStation_rec.Item1 != null && MST_TrainStation_rec.Item1 == 0)
                {
                    var trainstation_rec = new MST_TrainStation_Class().Insert(entities, MST_TrainStation_rec.Item2, PPRODR01_font);
                    MST_TrainStation_rec = new Tuple<int?, string>(trainstation_rec.TRAINST_id, trainstation_rec.TRAINST_name);
                }
                    
                PPRODR01_code = new Document.Document_Class().GetDocumentCode(entities, Misc.Properties.DBs.SchoolQPaper.dbo.MST_Document.Records.Up_to_O_L_Invoice);
                paperorder01_rec = new TRN_PaperOrder01_H_Class().Insert(entities, 
                    PPRODR01_code, 
                    PPRODR01_datetime, 
                    PPRODR01_remarks, 
                    PPRODR01_advanced_pay,
                    PPRODR01_cheque_no,
                    PPRODR01_mo_office, 
                    PPRODR01_additional_papers, 
                    PPRODR01_font, 
                    PPRODR01_gross_tot,
                    PPRODR01_discount_amnt,
                    PPRODR01_net_tot,
                    PPRODR01_discount_percnt,
                    PPRODR01_telephone,
                    PPRODR01_train_received_by,
                    PPRODR01_train_received_by_nic,
                    MST_TrainStation_rec.Item1,
                    SCHL_id, 
                    DELIMETH_id,
                    PAYTYP_id);

                PaperOrderD_Recs.ForEach(r =>
                {
                    new TRN_PaperOrder01_D_Class().Insert(entities, r.PPRODR01D_paper_qty, r.PPRODR01D_ignore_qty, r.GRADE_id, r.SUBJ_id, paperorder01_rec.PPRODR01_id);
                });

                new TRN_Receivable_Class().Insert(entities,
                    paperorder01_rec.PPRODR01_id,
                    PPRODR01_net_tot,
                    PPRODR01_net_tot,
                    null,
                    Misc.Properties.DBs.SchoolQPaper.dbo.MST_Document.Records.Up_to_O_L_Invoice);

                if (PPRODR01_advanced_pay != 0)
                {
                    DS_Receipt DS_Receipt_Obj = new DS_Receipt();
                    DS_Receipt_Obj.OutstandingInvoices.AddOutstandingInvoicesRow(paperorder01_rec.PPRODR01_id,
                        Misc.Properties.DBs.SchoolQPaper.dbo.MST_Document.Records.Up_to_O_L_Invoice,
                        PPRODR01_code,
                        PPRODR01_advanced_pay,
                        PPRODR01_net_tot,
                        SCHL_id,
                        "",
                        "",
                        Settings.Default.CurrentFont);

                    int PayTypes_Id = DS_Receipt_Obj.PayTypes.AddPayTypesRow(PAYTYP_id,
                        "",
                        PPRODR01_advanced_pay,
                        "",
                        "").Id;

                    if (PAYTYP_id == Misc.Properties.DBs.SchoolQPaper.dbo.MST_PayType.Records.Cheque)
                    {
                        DS_Receipt_Obj.ChequeInfo.AddChequeInfoRow(PayTypes_Id,
                            PPRODR01_cheque_no,
                            DateTime.Now);
                    }
                    else if (PAYTYP_id == Misc.Properties.DBs.SchoolQPaper.dbo.MST_PayType.Records.MO)
                    {
                        DS_Receipt_Obj.MoneyOrderInfo.AddMoneyOrderInfoRow(PayTypes_Id,
                            DateTime.Now,
                            PPRODR01_cheque_no,
                            PPRODR01_mo_office);
                    }

                    new Receipt.Receipt_Class().Save(entities,
                        "",
                        PPRODR01_datetime,
                        PPRODR01_datetime,
                        PPRODR01_advanced_pay,
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
            return paperorder01_rec;
        }

        public TRN_PaperOrder01_H Update(SchoolQPaper_entities entities, int PPRODR01_id, string PPRODR01_code, DateTime PPRODR01_datetime,
            string PPRODR01_remarks, decimal PPRODR01_advanced_pay, string PPRODR01_cheque_no, string PPRODR01_mo_office,
            int PPRODR01_additional_papers, string PPRODR01_font, decimal PPRODR01_gross_tot, decimal PPRODR01_discount_amnt,
            decimal PPRODR01_net_tot, decimal PPRODR01_discount_percnt, string PPRODR01_telephone, string PPRODR01_train_received_by,
            string PPRODR01_train_received_by_nic, Tuple<int?, string> MST_TrainStation_rec, int SCHL_id, int DELIMETH_id,
            int PAYTYP_id,
            List<PaperOrderD_Rec> PaperOrderD_Recs)
        {
            bool dispose = entities == null;
            entities = entities ?? new SchoolQPaper_entities();

            TRN_PaperOrder01_H paperorder01_rec = null;

            System.Data.Entity.DbContextTransaction trans = null;
            if (dispose)
                trans = entities.Database.BeginTransaction();
            
            try
            {
                if (MST_TrainStation_rec.Item1 != null && MST_TrainStation_rec.Item1 == 0)
                {
                    var trainstation_rec = new MST_TrainStation_Class().Insert(entities, MST_TrainStation_rec.Item2, PPRODR01_font);
                    MST_TrainStation_rec = new Tuple<int?, string>(trainstation_rec.TRAINST_id, trainstation_rec.TRAINST_name);
                }

                paperorder01_rec = new TRN_PaperOrder01_H_Class().Update(entities,
                    PPRODR01_id,
                    PPRODR01_code,
                    PPRODR01_datetime,
                    PPRODR01_remarks,
                    PPRODR01_advanced_pay,
                    PPRODR01_cheque_no,
                    PPRODR01_mo_office,
                    PPRODR01_additional_papers,
                    PPRODR01_font,
                    PPRODR01_gross_tot,
                    PPRODR01_discount_amnt,
                    PPRODR01_net_tot,
                    PPRODR01_discount_percnt,
                    PPRODR01_telephone,
                    PPRODR01_train_received_by,
                    PPRODR01_train_received_by_nic,
                    MST_TrainStation_rec.Item1,
                    SCHL_id,
                    DELIMETH_id,
                    PAYTYP_id);

                entities.TRN_PaperOrder01_D.Where(x => x.PPRODR01_id == PPRODR01_id).ToList().ForEach(r =>
                {
                    new TRN_PaperOrder01_D_Class().Delete(entities, r.PPRODR01D_id);
                });

                int RECEIVABLES_id = entities.TRN_Receivable.Where(x => x.RECEIVABLES_doc_id == PPRODR01_id && x.DOCU_id == Misc.Properties.DBs.SchoolQPaper.dbo.MST_Document.Records.Up_to_O_L_Invoice).FirstOrDefault().RECEIVABLES_id;
                entities.TRN_Receivable.Where(x => x.RECEIVABLES_ref_id != null && x.RECEIVABLES_ref_id == RECEIVABLES_id && x.DOCU_id == Misc.Properties.DBs.SchoolQPaper.dbo.MST_Document.Records.Receipt).ToList().ForEach(r =>
                {
                    new Receipt.Receipt_Class().Delete(entities, r.RECEIVABLES_doc_id);
                });
                new TRN_Receivable_Class().Delete(entities, RECEIVABLES_id);

                PaperOrderD_Recs.ForEach(r =>
                {
                    new TRN_PaperOrder01_D_Class().Insert(entities, r.PPRODR01D_paper_qty, r.PPRODR01D_ignore_qty, r.GRADE_id, r.SUBJ_id, paperorder01_rec.PPRODR01_id);
                });

                new TRN_Receivable_Class().Insert(entities,
                    paperorder01_rec.PPRODR01_id,
                    PPRODR01_net_tot,
                    PPRODR01_net_tot,
                    null,
                    Misc.Properties.DBs.SchoolQPaper.dbo.MST_Document.Records.Up_to_O_L_Invoice);

                if (PPRODR01_advanced_pay != 0)
                {
                    DS_Receipt DS_Receipt_Obj = new DS_Receipt();
                    DS_Receipt_Obj.OutstandingInvoices.AddOutstandingInvoicesRow(paperorder01_rec.PPRODR01_id,
                        Misc.Properties.DBs.SchoolQPaper.dbo.MST_Document.Records.Up_to_O_L_Invoice,
                        PPRODR01_code,
                        PPRODR01_advanced_pay,
                        PPRODR01_net_tot,
                        SCHL_id,
                        "",
                        "",
                        Settings.Default.CurrentFont);

                    int PayTypes_Id = DS_Receipt_Obj.PayTypes.AddPayTypesRow(PAYTYP_id,
                        "",
                        PPRODR01_advanced_pay,
                        "",
                        "").Id;

                    if (PAYTYP_id == Misc.Properties.DBs.SchoolQPaper.dbo.MST_PayType.Records.Cheque)
                    {
                        DS_Receipt_Obj.ChequeInfo.AddChequeInfoRow(PayTypes_Id,
                            PPRODR01_cheque_no,
                            DateTime.Now);
                    }
                    else if (PAYTYP_id == Misc.Properties.DBs.SchoolQPaper.dbo.MST_PayType.Records.MO)
                    {
                        DS_Receipt_Obj.MoneyOrderInfo.AddMoneyOrderInfoRow(PayTypes_Id,
                            DateTime.Now,
                            PPRODR01_cheque_no,
                            PPRODR01_mo_office);
                    }

                    new Receipt.Receipt_Class().Save(entities,
                        "",
                        PPRODR01_datetime,
                        PPRODR01_datetime,
                        PPRODR01_advanced_pay,
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
            return paperorder01_rec;
        }
    }

    public class PaperOrderD_Rec
    {
        public int PPRODR01D_paper_qty { get; set; }
        public bool PPRODR01D_ignore_qty { get; set; }
        public int GRADE_id { get; set; }
        public int SUBJ_id { get; set; }
    }
}
