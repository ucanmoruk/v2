﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace mKYS.Raporlar.Cosmoliz
{
    public partial class UGD2 : DevExpress.XtraReports.UI.XtraReport
    {
        public UGD2()
        {
            InitializeComponent();
        }
        public static string tID;


        public void bilgi()
        {
            pID.Value = tID;
        }
    }
}
