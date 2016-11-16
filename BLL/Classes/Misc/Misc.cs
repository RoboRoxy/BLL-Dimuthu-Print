using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Classes.Misc
{
    namespace Properties
    {
        public static class PaperPrices
        {
            public static decimal AdditionalSubject = 6;
        }

        public static class Discount
        {
            public static decimal ForTransportStationaryAndOther_percent_grade_1_to_11 = 0;
            public static decimal ForTransportStationaryAndOther_percent_grade_12_to_13 = 10;
        }

        namespace DBs
        {
            namespace SchoolQPaper
            {
                public static class dbo
                {
                    public static string _name = "dbo";

                    public static class MST_Document
                    {
                        public static string _name = "MST_Document";

                        public static class Records
                        {
                            public static int Up_to_O_L_Invoice = 1; 
                            public static int Up_to_A_L_Invoice = 2;
                            public static int Receipt = 3;
                        }
                    }

                    public static class MST_Subject
                    {
                        public static string _name = "MST_Subject";

                        public static class Records
                        {
                            public static int Arts = 15;
                            public static int Dancing = 17;
                            public static int Music = 18;
                        }
                    }

                    public static class MST_PayType
                    {
                        public static string _name = "MST_PayType";

                        public static class Records
                        {
                            public static int Cash = 1;
                            public static int Cheque = 2;
                            public static int MO = 3;
                            public static int Bank = 4;
                            public static int VPP = 5;
                        }
                    }
                }
            }
        }
    }

    namespace Functions
    { }
}
