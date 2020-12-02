using EzeilsData.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EzeilsData
{
    public partial class EZeilsService : Form
    {
        public EZeilsService()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timerEZeils.Enabled = true;
            timerEZeils.Start();
            while (timerEZeils.Enabled)
            {
                ProductManage productManage = new ProductManage();
                productManage.UpdateProduct();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timerEZeils.Enabled = false;
            timerEZeils.Stop();
        }

        private void EZeilsService_Load(object sender, EventArgs e)
        {
            timerEZeils.Enabled = true;
            timerEZeils.Start();
            while (timerEZeils.Enabled)
            {
                ProductManage productManage = new ProductManage();
                productManage.UpdateProduct();
            }
        }
    }
}
