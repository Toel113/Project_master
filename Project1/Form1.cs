using EasyModbus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Project1
{
    public partial class Form1 : Form
    {
        ModbusServer server;

        public Form1()
        {
            InitializeComponent();
            btnStop.Enabled = false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            server = new ModbusServer();
            server.Listen();
            lblStatus.Text = "Start Server.";
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            timer.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            server.StopListening();
            server = null;
            lblStatus.Text = "Stop Server.";
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            timer.Stop();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            int add1 = 1;
            int add2 = 2;

            Random rnd = new Random();
            int value1 = rnd.Next(0,101);
            float value2 = (float)rnd.Next(-3300, 11000) / 100;
            int value3 = rnd.Next(0, 2);

            txtHoldRegi1.Text = value1.ToString();
            ModbusServer.HoldingRegisters resg = server.holdingRegisters;
            resg[add1] = (short)value1;

            txtHoldRegi2.Text= value2.ToString();
            ModbusServer.HoldingRegisters regi = server.holdingRegisters;
            regi[add2] = (short)(value2 * 100);

            txtCoil.Text = value3.ToString();
            bool val = false;
            if ( txtCoil.Text == "1")
            {
                val = true;
            }
            ModbusServer.Coils regs = server.coils;
            regs[add1] = val;

        }

    }
}
