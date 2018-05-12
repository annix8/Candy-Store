using CandyStore.Client.OrderServiceProxy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CandyStore.Client.Util
{
    public static class CandyStoreUtil
    {
        public static void MakeLabelsTransparent(Form form)
        {
            foreach (var label in form.Controls.OfType<Label>())
            {
                if (label.Tag?.ToString().ToLower() == "visible")
                {
                    continue;
                }
                label.BackColor = Color.Transparent;
            }
        }

        public static void SetAutoCompleteOnComboBoxes(Form form)
        {
            foreach(var combobox in form.Controls.OfType<ComboBox>())
            {
                combobox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                combobox.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
        }

        public static DataTable ConvertOrderDtoListToDataTable(List<OrderDto> list)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add(nameof(OrderDto.Supplier));
            dt.Columns.Add(nameof(OrderDto.OrderedDate));
            dt.Columns.Add(nameof(OrderDto.ExpectedDate));
            dt.Columns.Add(nameof(OrderDto.Status));
            dt.Columns.Add(nameof(OrderDto.Products));

            foreach (var item in list)
            {
                var row = dt.NewRow();

                row[nameof(OrderDto.Supplier)] = item.Supplier;
                row[nameof(OrderDto.OrderedDate)] = item.OrderedDate;
                row[nameof(OrderDto.ExpectedDate)] = item.ExpectedDate;
                row[nameof(OrderDto.Status)] = item.Status;
                row[nameof(OrderDto.Products)] = item.Products;

                dt.Rows.Add(row);
            }

            return dt;
        }
    }
}
