﻿using DatabaseLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrganizationManagement.MeasureUnitsEdit
{
    public partial class EditMeasureUnitForm : Form
    {
        private int unitID;
        public EditMeasureUnitForm(DataTable measureunitsData)
        {
            InitializeComponent();

            if (measureunitsData.Rows.Count > 0)
            {
                unitID = Convert.ToInt32(measureunitsData.Rows[0]["UnitID"]);
                okeiField.Text = measureunitsData.Rows[0]["okeiID"].ToString();
                nameField.Text = measureunitsData.Rows[0]["Name"].ToString();
                fullnameField.Text = measureunitsData.Rows[0]["FullName"].ToString();
                fractionalCheckBox.Checked = Convert.ToBoolean(measureunitsData.Rows[0]["Fractional"]);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string name = nameField.Text;
            string okeiID = okeiField.Text;
            string fullname = fullnameField.Text;
            bool fractional = fractionalCheckBox.Checked;

            MeasureUnit.Update(unitID, Convert.ToInt32(okeiID), name, fullname, fractional);
            Close();
        }
    }
}
