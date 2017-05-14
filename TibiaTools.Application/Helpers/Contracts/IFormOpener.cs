using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TibiaTools.Application.Helpers.Contracts
{
    public interface IFormOpener
    {
        void ShowModelessForm<TForm>() where TForm : Form;
        DialogResult ShowModalForm<TForm>() where TForm : Form;
        TForm GetModelessForm<TForm>() where TForm : Form;
    }
}
