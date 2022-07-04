using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Inventory_Sytem.Models;
using Inventory_Sytem.Repositories;

namespace Inventory_Sytem.Forms {
    public partial class frmProduct : Form {

        private ProductRepository PR = new ProductRepository();

        public frmProduct() {
            InitializeComponent();
        }

        private async void frmProduct_Load(object sender, EventArgs e) {
            var Products = await PR.GetProducts();

            foreach (var item in Products) {
                dtProducts.Rows.Add(item.Id, item.Name, item.Price, item.Quantity, item.Category.Name, item.Description);
            }

        }

        private void txIdProduct_TextChanged(object sender, EventArgs e) {

        }
    }
}
