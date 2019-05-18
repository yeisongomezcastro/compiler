﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LecturaDeTextos.Transversal;
using LecturaDeTextos.AnalizadorLexico;
using LecturaDeTextos.AnalizadorSintactico;

namespace LecturaDeTextos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        
        private void buttonCargarConsola_Click_1(object sender, EventArgs e)
        {

            if (!(textBoxPorConsola.Text == ""))
            {
                Cache cache = Cache.obtenerCache();
                string[] aLines = textBoxPorConsola.Text.Split('\r');

                string cadena = "";
                foreach (string line in aLines)
                {
                    cadena += line;
                }

                string[] lineas = cadena.Split('\n');
                for (int ins = 0; ins < lineas.Length; ins++)
                {
                    cache.agregarLinea(new Linea(ins + 1, lineas.ElementAt(ins)));
                }
                MessageBox.Show("Se cargo correctamente la chache");

            }
            else
            {
                MessageBox.Show("no se ha ingresado texto, intentelo de nuevo");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // CODIGO
            AnalisisLexico analex = new AnalisisLexico();
            ComponenteLexico tmp = analex.analizar();

            while (!"@EOF@".Equals(tmp.Lexema))
            {
                MessageBox.Show(tmp.Imprimir());
                tmp = analex.analizar();
            }
            
        }

        private void buttonRestablecer_Click(object sender, EventArgs e)
        {
            textBoxPorConsola.Clear();
            TablaLiterales.limpiarTabla();
            TablaMaestro.limpiarTabla();
            TablaDummy.limpiarTabla();
            Transversal.TablaSimbolos.limpiarTabla();
            Cache.obtenerCache().limpiarCache();
            MessageBox.Show("Analisís restablecido.");




        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // CODIGO
            AnalisisLexico analex = new AnalisisLexico();
            ComponenteLexico tmp = analex.analizar();

            while (!"@EOF@".Equals(tmp.Lexema))
            {
                MessageBox.Show(tmp.Imprimir());
                tmp = analex.analizar();
                //analix.analizar();

            }
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // CODIGO
                AnalisisSintatico analix = new AnalisisSintatico();
                analix.analizar();

        }
    }
}
