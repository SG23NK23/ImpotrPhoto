using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Импорт_изображений
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void yachtBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.yachtBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.yACHTSDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "yACHTSDataSet.Yacht". При необходимости она может быть перемещена или удалена.
            this.yachtTableAdapter.Fill(this.yACHTSDataSet.Yacht);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] masimgname = Directory.GetFiles("Photo");
            for(int i = 0;i<masimgname.Length;i++)
            {
                string fName = Path.GetFileNameWithoutExtension(masimgname[i].ToUpper());
                yachtBindingSource.Filter = "ModelName='" + fName + "'";
                if(yachtBindingSource.Count >0)
                {
                    photoPictureBox.Load(masimgname[i]);
                    photoPictureBox.Refresh();
                    yachtBindingSource.EndEdit();
                }
            }

            this.yachtTableAdapter.Update(this.yACHTSDataSet.Yacht);   
        }
    }
}
