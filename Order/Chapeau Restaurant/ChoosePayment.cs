﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChapeauLogic;
using ChapeauModel;

namespace Chapeau_Restaurant
{
    public partial class Choosepayment : Form
    {
        PaymentForm pf;
        PaymentService ps;
        Order Order;
        public Choosepayment(Order o, PaymentForm paymentForm)
        {
            pf = paymentForm;
            InitializeComponent();
            this.Order = o;
        }
        private void PerformPayment()
        {
            
            ps = new PaymentService();
            ps.UpdateOrderStatusAndTip(this.Order );
            MessageBox.Show("Payment confirmed");
            this.Hide();
            pf.orderForm.Show();
            pf.orderForm.LoadTables();
        }

        private void VisaBtn_Click(object sender, EventArgs e)
        {
            Order.paymentType = PaymentType.Visa; 
            PerformPayment();
        }

        private void PinBtn_Click(object sender, EventArgs e)
        {
            Order.paymentType = PaymentType.Pin;
            PerformPayment();
        }

        private void CashBtn_Click(object sender, EventArgs e)
        {
            Order.paymentType = PaymentType.Cash;
            PerformPayment();
        }

        private void AmericanBtn_Click(object sender, EventArgs e)
        {
            Order.paymentType = PaymentType.AmericanExpress;
            PerformPayment();
        }
    }
}
