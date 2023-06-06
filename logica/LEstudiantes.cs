using data;
using LinqToDB;
using logica.Library;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace logica
{
    public class LEstudiantes: Librarys
    {
        private List<TextBox> listTextBox;
        private List<Label> listLabel;
        private PictureBox image;
        private Bitmap _imaBitmap;
        private DataGridView _dataGridView;
        private NumericUpDown _NumericUpDown;
        private Paginador<estudiante> _paginador;
        private string _accion = "insert";

        private Librarys librarys;
        public LEstudiantes(List<TextBox> listTextBox, List<Label> listLabel, object[] objects)
        {
            this.listTextBox = listTextBox;
            this.listLabel = listLabel;
            librarys = new Librarys();
            image = (PictureBox)objects[0];
            _imaBitmap = (Bitmap)objects[1];
            _dataGridView = (DataGridView)objects[2];
            _NumericUpDown = (NumericUpDown)objects[3];
            Restablecer();
        }
        public void Registrar()
        {
            if (listTextBox[0].Text.Equals(""))
            {
                listLabel[0].Text = "El campo nid es requerido";
                listLabel[0].ForeColor = Color.Red;
                listLabel[0].Focus();
            }
            else
            {
                if (listTextBox[1].Text.Equals(""))
                {
                    listLabel[1].Text = "El campo nombre es requerido";
                    listLabel[1].ForeColor = Color.Red;
                    listLabel[1].Focus();
                }
                else
                {
                    if (listTextBox[2].Text.Equals(""))
                    {
                        listLabel[2].Text = "El campo apellido es requerido";
                        listLabel[2].ForeColor = Color.Red;
                        listLabel[2].Focus();
                    }
                    else
                    {
                        if (listTextBox[3].Text.Equals(""))
                        {
                            listLabel[3].Text = "El campo email es requerido";
                            listLabel[3].ForeColor = Color.Red;
                            listLabel[3].Focus();
                        }
                        else
                        {
                            if (textBoxEvent.ComprobarFormatoEmail(listTextBox[3].Text))
                            {
                                var user = _estudiante.Where(u => u.email.Equals(listTextBox[3].Text)).ToList();
                                if (user.Count.Equals(0))
                                {
                                    Save();
                                }
                                else
                                {
                                    if (user[0].id.Equals(_idEstudiante))
                                    {
                                        Save();
                                    }
                                    else
                                    {
                                        listLabel[3].Text = "El email ya está registrado";
                                        listLabel[3].ForeColor = Color.Red;
                                        listLabel[3].Focus();
                                    }

                                    
                                }
                                
                            }
                            else
                            {
                                listLabel[3].Text = "email no válido";
                                listLabel[3].ForeColor = Color.Red;
                                listLabel[3].Focus();
                            }
                        }
                    }
                }
            }
        }

        private void Save()
        {

            BeginTransactionAsync();
            try
            {
                var imageArray = uploadImage.ImageToByte(image.Image);

                switch (_accion)
                {
                    case "insert":
                        _estudiante.Value(e => e.nid, listTextBox[0].Text)
                        .Value(e => e.nombre, listTextBox[1].Text)
                        .Value(e => e.apellido, listTextBox[2].Text)
                        .Value(e => e.email, listTextBox[3].Text)
                        .Insert();
                        break;
                    case "update":
                        _estudiante.Where(u => u.id.Equals(_idEstudiante))
                        .Set(e => e.nid, listTextBox[0].Text)
                        .Set(e => e.nombre, listTextBox[1].Text)
                        .Set(e => e.apellido, listTextBox[2].Text)
                        .Set(e => e.email, listTextBox[3].Text)
                        .Update();
                        break;
                }


                CommitTransaction();
                Restablecer();
            }
            catch (Exception)
            {
                RollbackTransaction();

            }
        }
        private int _reg_por_pagina = 2, _num_pagina=1;
        public void SearchStudent(string campo)
        {
            List<estudiante> query = new List<estudiante>();
            int Inicio = (_num_pagina - 1) * _reg_por_pagina;
            if (campo.Equals(""))
            {
                query = _estudiante.ToList();
            }
            else
            {
                query = _estudiante.Where(c => c.nid.StartsWith(campo) || c.nombre.StartsWith(campo) || c.apellido.StartsWith(campo)).ToList();
            }
            if(0<query.Count) {
                _dataGridView.DataSource = query.Select(c => new
                {
                    c.id,
                    c.nid,
                    c.nombre,
                    c.apellido,
                    c.email
                }).Skip(Inicio).Take(_reg_por_pagina).ToList();
                _dataGridView.Columns[0].Visible = false;
                _dataGridView.Columns[1].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                _dataGridView.Columns[3].DefaultCellStyle.BackColor = Color.WhiteSmoke;

            }
            else
            {
                _dataGridView.DataSource = query.Select(c => new
                {
                    c.nid,
                    c.nombre,
                    c.apellido,
                    c.email
                }).ToList();
            }
        }

        private int _idEstudiante = 0;
        public void GetEstudiante()
        {
            _accion = "update";
            _idEstudiante = Convert.ToInt16(_dataGridView.CurrentRow.Cells[0].Value);
            listTextBox[0].Text = Convert.ToString(_dataGridView.CurrentRow.Cells[1].Value);
            listTextBox[1].Text = Convert.ToString(_dataGridView.CurrentRow.Cells[2].Value);
            listTextBox[2].Text = Convert.ToString(_dataGridView.CurrentRow.Cells[3].Value);
            listTextBox[3].Text = Convert.ToString(_dataGridView.CurrentRow.Cells[4].Value);
        }
        private List<estudiante> listEstudiante;

        public void Paginador(string metodo)
        {
            switch (metodo)
            {
                case "primero":
                    _num_pagina = _paginador.primero();
                    break;
                case "anterior":
                    _num_pagina = _paginador.anterior();
                    break;
                case "siguiente":
                        _num_pagina = _paginador.siguiente();
                    break;
                case "ultimo":
                    _num_pagina = _paginador.ultimo();
                    break;
                
            }
            SearchStudent("");
        }

        private void Restablecer()
        {
            _idEstudiante = 0;
            _accion = "insert";
            _num_pagina = 1;
            image.Image = _imaBitmap;
            listLabel[0].Text = "Nid";
            listLabel[1].Text = "Nombre";
            listLabel[2].Text = "Apellido";
            listLabel[3].Text = "Email";
            listLabel[0].ForeColor = Color.LightSlateGray;
            listLabel[1].ForeColor = Color.LightSlateGray;
            listLabel[2].ForeColor = Color.LightSlateGray;
            listLabel[3].ForeColor = Color.LightSlateGray;
            listTextBox[0].Text = "";
            listTextBox[1].Text = "";
            listTextBox[2].Text = "";
            listTextBox[3].Text = "";
            listEstudiante = _estudiante.ToList();
            if(0 < listEstudiante.Count)
            {
                _paginador = new Paginador<estudiante>(listEstudiante, listLabel[4], _reg_por_pagina);
            }
            SearchStudent("");
        }
    }
}
