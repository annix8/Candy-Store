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
            foreach (var combobox in form.Controls.OfType<ComboBox>())
            {
                combobox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                combobox.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
        }

        public static Form GetFormOfType<T>() where T : new()
        {
            var form = Application.OpenForms.OfType<T>().FirstOrDefault();

            form = form == null ? new T() : form;

            return form as Form;
        }
    }
}
