﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ERgrin.Api2;

namespace ERgrinApiClient
{
    public partial class MyForm : Form
    {
        //--------------------------------------------------------------------------------
        // Initializer
        //--------------------------------------------------------------------------------

        public MyForm()
        {
            InitializeComponent();
        }

        //--------------------------------------------------------------------------------
        // Control Event Handlers
        //--------------------------------------------------------------------------------

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;

                Reset();

                if (!myProject.LoadFile(textBox1.Text))
                    return;

                UpdateModels(myProject.Models);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("변경된 값을 기존 파일에 저장하시겠습니까?", "저장", MessageBoxButtons.OKCancel);
            if (res == DialogResult.OK)
            {
                myProject.SaveFile();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = saveFileDialog1.FileName;
                myProject.SaveFile(textBox1.Text);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var model = myProject.FindModel((string)comboBox1.SelectedItem);
            if (model != null && model.ID != selectedModel?.ID)
            {
                selectedModel = model;
                UpdateDiagrams(model);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var diagram = myProject.FindDiagram(selectedModel, (string)comboBox2.SelectedItem);
            if (diagram != null && diagram.ID != selectedDiagram?.ID)
            {
                selectedDiagram = diagram;
                myProject.SetEntities(selectedModel, diagram.Name);
                UpdateEntities(myProject.Entities);

                myProject.SetDomains(selectedModel);

                selectedEntity = null;
                myProject.SetAttribute(null);
                UpdateAttributes(myProject.Attributes);

                selectedAttribute = null;
                SetProps();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var obj = (ListBox)sender;
            IEntity entity = myProject.FindEntity((string)obj.SelectedItem);
            if (entity != null)
            {
                selectedEntity = entity;
                myProject.SetAttribute(entity);
                UpdateAttributes(myProject.Attributes);

                selectedAttribute = null;
                SetProps();
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            var obj = (ListBox)sender;
            IAttribute attribute = myProject.FindAttribute((string)obj.SelectedItem);
            if (attribute != null)
            {
                selectedAttribute = attribute;
                SetProps();
            }
        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            var item = e.ChangedItem;

            if (item != null)
            {
                string propertyName = item.PropertyDescriptor.Name;

                switch (propertyName)
                {
                    case "EntityLogicalName":
                        if (selectedEntity != null)
                        {
                            selectedEntity.LogicalName = item.Value?.ToString() ?? string.Empty;
                            int idx = listBox1.SelectedIndex;
                            UpdateEntities(myProject.Entities);
                            listBox1.SetSelected(idx, true);
                        }
                        break;
                    case "EntityPhysicalName":
                        if (selectedEntity != null)
                        {
                            selectedEntity.PhysicalName = item.Value?.ToString() ?? string.Empty;
                            int idx = listBox1.SelectedIndex;
                            UpdateEntities(myProject.Entities);
                            listBox1.SetSelected(idx, true);
                        }
                        break;
                    case "EntityDescription":
                        if (selectedEntity != null)
                        {
                            selectedEntity.Description = item.Value?.ToString() ?? string.Empty;
                            int idx = listBox1.SelectedIndex;
                            UpdateEntities(myProject.Entities);
                            listBox1.SetSelected(idx, true);
                        }
                        break;
                    case "AttributeLogicalName":
                        if (selectedAttribute != null)
                        {
                            selectedAttribute.LogicalName = item.Value?.ToString() ?? string.Empty;
                            int idx = listBox2.SelectedIndex;
                            UpdateAttributes(myProject.Attributes);
                            listBox2.SetSelected(idx, true);
                        }
                        break;
                    case "AttributePhysicalName":
                        if (selectedAttribute != null)
                        {
                            selectedAttribute.PhysicalName = item.Value?.ToString() ?? string.Empty;
                            int idx = listBox2.SelectedIndex;
                            UpdateAttributes(myProject.Attributes);
                            listBox2.SetSelected(idx, true);
                        }
                        break;
                    case "AttributeDescription":
                        if (selectedAttribute != null)
                        {
                            selectedAttribute.Description = item.Value?.ToString() ?? string.Empty;
                            int idx = listBox2.SelectedIndex;
                            UpdateAttributes(myProject.Attributes);
                            listBox2.SetSelected(idx, true);
                        }
                        break;
                    case "AttributeNullable":
                        if (selectedAttribute != null)
                        {
                            selectedAttribute.Nullable = item.Value != null ? item.Value.Equals(true) : false;
                            int idx = listBox2.SelectedIndex;
                            UpdateAttributes(myProject.Attributes);
                            listBox2.SetSelected(idx, true);
                        }
                        break;
                    case "AttributeIsKey":
                        if (selectedAttribute != null)
                        {
                            selectedAttribute.IsKey = item.Value?.Equals(true) ?? false;
                            int idx = listBox2.SelectedIndex;
                            UpdateAttributes(myProject.Attributes);
                            listBox2.SetSelected(idx, true);
                        }
                        break;
                    case "AttributeDomainName":
                        if (selectedAttribute != null)
                        {
                            selectedAttribute.DomainName = item.Value?.ToString() ?? string.Empty;
                            int idx = listBox2.SelectedIndex;
                            UpdateAttributes(myProject.Attributes);
                            listBox2.SetSelected(idx, true);
                        }
                        break;
                    case "AttributeDataType":
                        if (selectedAttribute != null)
                        {
                            selectedAttribute.PhysicalDataType = item.Value?.ToString() ?? string.Empty;
                            int idx = listBox2.SelectedIndex;
                            UpdateAttributes(myProject.Attributes);
                            listBox2.SetSelected(idx, true);
                        }
                        break;
                }
            }
        }

        //--------------------------------------------------------------------------------
        // Private Methods
        //--------------------------------------------------------------------------------

        private void Reset()
        {
            selectedModel = null;
            selectedDiagram = null;
            selectedEntity = null;
            selectedAttribute = null;

            UpdateModels(null);
            UpdateDiagrams(null);
            UpdateEntities(null);
            UpdateAttributes(null);

            SetProps();
        }

        private void UpdateModels(List<IModel> models)
        {
            comboBox1.Items.Clear();

            if (models == null)
                return;

            foreach (var model in models)
            {
                comboBox1.Items.Add(model.LogicalName);
            }
            comboBox1.SelectedIndex = 0;
        }

        private void UpdateDiagrams(IModel model)
        {
            List<IDiagram> diagrams = null;
            if (model != null)
            {
                diagrams = new List<IDiagram>();
                for (int i = 0; i < model.DiagramCount; i++)
                {
                    diagrams.Add(model.GetDiagram(i));
                }
            }

            comboBox2.Items.Clear();

            if (diagrams == null)
                return;

            foreach (var diagram in diagrams)
            {
                comboBox2.Items.Add(diagram.Name);
            }
            comboBox2.SelectedIndex = 0;
        }

        private void UpdateEntities(List<IEntity> entities)
        {
            listBox1.Items.Clear();

            if (entities == null)
                return;

            foreach (var entity in entities)
            {
                listBox1.Items.Add(entity.LogicalName);
            }
        }

        private void UpdateAttributes(List<IAttribute> attributes)
        {
            listBox2.Items.Clear();

            if (attributes == null)
                return;

            foreach (var attribute in attributes)
            {
                listBox2.Items.Add(attribute.LogicalName);
            }
        }

        private void SetProps()
        {
            propertyGrid1.SelectedObject = myProject.GetProps(selectedEntity, selectedAttribute);
        }

        //--------------------------------------------------------------------------------
        // Private Fields
        //--------------------------------------------------------------------------------

        private IModel selectedModel;
        private IDiagram selectedDiagram;
        private IEntity selectedEntity;
        private IAttribute selectedAttribute;

        private MyProject myProject = new MyProject();
    }
}
