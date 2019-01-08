using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommonLibrary
{
    public static class FormClass
    {
        public static void AddDatagridButtons(DataGridView dataGridView, int totalButtons = 1, bool lockDataGrid = false)
        {
            if (totalButtons < 1 || totalButtons > 3) { throw new MethodAccessException();}
        
            if(totalButtons == 1)
            {
                DataGridViewButtonColumn editBtn = new DataGridViewButtonColumn();

                dataGridView.Columns.Add(editBtn);
                editBtn.HeaderText = "";
                editBtn.Text = "edit";
                editBtn.Name = "EditButton";
                editBtn.ReadOnly = true;
                editBtn.UseColumnTextForButtonValue = true;
                editBtn.Resizable = DataGridViewTriState.False;
            }

            if(totalButtons == 2)
            {
                DataGridViewButtonColumn editBtn = new DataGridViewButtonColumn();
                dataGridView.Columns.Add(editBtn);
                editBtn.HeaderText = "";
                editBtn.Text = "edit";
                editBtn.Name = "EditButton";
                editBtn.ReadOnly = true;
                editBtn.UseColumnTextForButtonValue = true;
                editBtn.Resizable = DataGridViewTriState.False;

                DataGridViewButtonColumn viewBtn = new DataGridViewButtonColumn();
                dataGridView.Columns.Add(viewBtn);
                viewBtn.HeaderText = "";
                viewBtn.Text = "view";
                viewBtn.Name = "ViewButton";
                viewBtn.ReadOnly = true;
                viewBtn.UseColumnTextForButtonValue = true;
                viewBtn.Resizable = DataGridViewTriState.False;
            }

            if (totalButtons == 3)
            {
                DataGridViewButtonColumn editBtn = new DataGridViewButtonColumn();
                dataGridView.Columns.Add(editBtn);
                editBtn.HeaderText = "";
                editBtn.Text = "edit";
                editBtn.Name = "EditButton";
                editBtn.ReadOnly = true;
                editBtn.UseColumnTextForButtonValue = true;
                editBtn.Resizable = DataGridViewTriState.False;

                DataGridViewButtonColumn viewBtn = new DataGridViewButtonColumn();
                dataGridView.Columns.Add(viewBtn);
                viewBtn.HeaderText = "";
                viewBtn.Text = "view";
                viewBtn.Name = "ViewButton";
                viewBtn.ReadOnly = true;
                viewBtn.UseColumnTextForButtonValue = true;
                viewBtn.Resizable = DataGridViewTriState.False;

                DataGridViewButtonColumn deleteBtn = new DataGridViewButtonColumn();
                dataGridView.Columns.Add(deleteBtn);
                deleteBtn.HeaderText = "";
                deleteBtn.Text = "delete";
                deleteBtn.Name = "DeleteButton";
                deleteBtn.ReadOnly = true;
                deleteBtn.UseColumnTextForButtonValue = true;
                deleteBtn.Resizable = DataGridViewTriState.False;
            }

            if(lockDataGrid == true)
            {
                dataGridView.ReadOnly = true;
                dataGridView.AllowUserToAddRows = false;
                dataGridView.AllowUserToDeleteRows = false;
                dataGridView.AllowUserToOrderColumns = true;
                dataGridView.AllowUserToResizeRows = false;
                dataGridView.AllowUserToResizeColumns = true;
                dataGridView.AutoResizeColumns();
            }
        }
    }
}
