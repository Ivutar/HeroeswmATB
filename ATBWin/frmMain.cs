using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using ATB.Data;

namespace ATB.Win
{
    public partial class frmMain : Form
    {
        int hilightid = 0;
        StateManager mgr = new StateManager();
        BindingList<Unit> listOfUnits = new BindingList<Unit>();

        public frmMain()
        {
            InitializeComponent();
            DoInit();
            DoBind();
            DoShow();
        }

        void DoInit()
        {
            //кто на поле
            //пусто

            //кто в запасе
            dgvFull.DataSource = listOfUnits;
        }

        void DoUndo()
        {
            mgr.Undo();
        }

        void DoRedo()
        {
            mgr.Redo();
        }

        void DoMove()
        {
            mgr.Move(txtComment.Text == "" ? "полный ход" : txtComment.Text);
            txtComment.Text = "";
        }

        void DoWait()
        {
            mgr.Wait(txtComment.Text == "" ? "ожидание" : txtComment.Text);
            txtComment.Text = "";
        }

        void DoBind()
        {
            dgvAll.DataSource = mgr.CurrentState.Units;
        }

        void DoShow()
        {
            DoShow(false);
        }

        //если scroll равно true то промотать все старые ходы
        void DoShow(bool scroll)
        {
            //список ходов
            List<UnitMove> list = mgr.CurrentState.GetLine(100);
            //hilightid = list[0].unit.id;

            //добавить в список все ходы и промотать все старые ходы
            int topindex = listBox1.TopIndex;
            int oldmoves = 0;
            listBox1.Items.Clear();
            foreach (UnitMove um in list)
            {
                listBox1.Items.Add(um);
                if (um.old)
                    oldmoves++;
            }
            if (scroll)
            {
                listBox1.TopIndex = oldmoves;
                if (listBox1.Items.Count > 0)
                    listBox1.SelectedIndex = oldmoves; //грязный хак, чтобы подсветить отряд, чей ход следующий
            }
            else
                listBox1.TopIndex = topindex;

            //активность кнопок
            button1.Enabled = mgr.CanUndo;
            button2.Enabled = mgr.CanRedo;
        }

        //отмена
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DoUndo();
                DoBind();
                DoShow();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //отмена "отмены"
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DoRedo();
                DoBind();
                DoShow();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //ход
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DoMove();
                DoBind();
                DoShow(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //полуход
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                DoWait();
                DoBind();
                DoShow(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //удалить выделенный отряд
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvAll.SelectedRows.Count > 0)
                {
                    List<int> ids = new List<int>();
                    foreach (DataGridViewRow row in dgvAll.SelectedRows)
                        if (row.DataBoundItem is Unit)
                        {
                            Unit unit = (Unit)row.DataBoundItem;
                            mgr.Remove(unit.id);
                        }

                    DoBind();
                    DoShow();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //добавить выбранные отряды после самого первого в очереди
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvFull.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow row in dgvFull.SelectedRows)
                        if (row.DataBoundItem is Unit)
                        {
                            Unit unit = (Unit)row.DataBoundItem;
                            mgr.AddAfterFirst(unit, (int)numericUpDown1.Value);
                        }

                    DoBind();
                    DoShow();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //отобразить элемент в списке ходов
        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index <= -1)
                return;

            UnitMove um = (UnitMove)((ListBox)sender).Items[e.Index];
            bool red = hilightid == um.unit.id;

            using (Font fnt = new Font(e.Font, um.old ? FontStyle.Bold : 0))
            {
                //e.DrawBackground();

                //if (hilight)
                //    e.Graphics.FillRectangle(new SolidBrush(Color.Silver), e.Bounds);

                Brush myBrush = red ? Brushes.Red : Brushes.Black;
                e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
                    fnt, myBrush, e.Bounds, StringFormat.GenericDefault);

                //e.DrawFocusRectangle();
            }

        }

        //изменить характеристики отряда
        private void dgvAll_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                State state = mgr.CurrentState;
                state.Units = (List<Unit>)dgvAll.DataSource;
                mgr.CurrentState = state;

                DoShow();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //подсветить выбранный отряд
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                hilightid = -1;

                if (listBox1.SelectedItem is UnitMove)
                    hilightid = ((UnitMove)listBox1.SelectedItem).unit.id;

                DoShow();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region [ menu ]

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Stream stream = null;
                    try
                    {
                        IFormatter formatter = new BinaryFormatter();
                        stream = new FileStream(
                            saveFileDialog1.FileName,
                            FileMode.Create,
                            FileAccess.Write,
                            FileShare.None);

                        //mgr
                        formatter.Serialize(stream, mgr);

                        //full units list
                        formatter.Serialize(stream, listOfUnits);
                    }
                    finally
                    {
                        if (stream != null)
                            stream.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Stream stream = null;
                    try
                    {
                        IFormatter formatter = new BinaryFormatter();
                        stream = new FileStream(
                            openFileDialog1.FileName,
                            FileMode.Open,
                            FileAccess.Read,
                            FileShare.Read);

                        //mgr
                        mgr = (StateManager)formatter.Deserialize(stream);

                        //full units list
                        listOfUnits = (BindingList<Unit>)formatter.Deserialize(stream);

                        //корявенько -> перенести в Bind
                        hilightid = 0;
                        dgvFull.DataSource = listOfUnits;
                        txtComment.Text = "";

                        DoBind();
                        DoShow();
                    }
                    finally
                    {
                        if (stream != null)
                            stream.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void геройToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmHero frm = new frmHero();
                frm.Show(mgr);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void видыОтрядовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmUnits frm = new frmUnits();
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion
    }
}
