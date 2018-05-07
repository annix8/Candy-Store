using CandyStore.Client.Util;
using System.Windows.Forms;

namespace CandyStore.Client.Forms
{
    public partial class OrderForm : Form
    {
        public OrderForm()
        {
            InitializeComponent();

            CandyStoreUtil.MakeLabelsTransparent(this);
        }

        private void OrderForm_Load(object sender, System.EventArgs e)
        {

        }
    }
}
