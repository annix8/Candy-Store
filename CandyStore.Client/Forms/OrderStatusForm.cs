using CandyStore.Client.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CandyStore.Client.Forms
{
    public partial class OrderStatusForm : Form
    {
        public OrderStatusForm()
        {
            InitializeComponent();

            CandyStoreUtil.MakeLabelsTransparent(this);
        }

        private void OrderStatusForm_Load(object sender, EventArgs e)
        {

        }
    }
}
