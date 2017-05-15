using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TibiaTools.Application.Helpers.Contracts;

namespace TibiaTools.Application.Helpers
{
    /// <summary>
    /// http://stackoverflow.com/questions/38417654/winforms-how-to-register-forms-with-ioc-container
    /// </summary>
    public class FormOpener : IFormOpener
    {
        private readonly Container container;
        private readonly Dictionary<Type, dynamic> openedForms;

        public FormOpener(Container container)
        {
            this.container = container;
            this.openedForms = new Dictionary<Type, dynamic>();
        }

        public void ShowModelessForm<TForm>() where TForm : Form
        {
            var form = GetModelessForm<TForm>();

            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();
            form.BringToFront();
        }

        public TForm GetModelessForm<TForm>() where TForm : Form
        {
            if (this.openedForms.ContainsKey(typeof(TForm)))
            {
                // a form can be held open in the background, somewhat like 
                // singleton behavior, and reopened/reshown this way
                // when a form is 'closed' using form.Hide()   
                return this.openedForms[typeof(TForm)];
            }
            else
            {
                var form = this.GetTForm<TForm>();
                this.openedForms.Add(form.GetType(), form);
                // the form will be closed and disposed when form.Closed is called
                // Remove it from the cached instances so it can be recreated
                form.Closed += (s, e) => this.openedForms.Remove(form.GetType());

                form.StartPosition = FormStartPosition.CenterScreen;
                return form;
            }
        }

        public DialogResult ShowModalForm<TForm>() where TForm : Form
        {
            using (var form = this.GetTForm<TForm>())
            {
                return form.ShowDialog();
            }
        }

        private TForm GetTForm<TForm>() where TForm : Form
        {
            return this.container.GetInstance<TForm>();
        }
    }

}
