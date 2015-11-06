using PAT.Common.GUI.Drawing;
using PAT.Common.Utility;
using PAT.GUI.KWSNDrawing;
using PAT.KWSN.Model;
using PAT.Module.KWSN;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tools.Diagrams;


namespace PAT.GUI.ModuleGUI.KWSNDrawing
{
    public partial class WSNConfigForm : Form
    {
        public static String TAG = "WSNConfigForm";
        private int mNumberSensors;
        private int mNumberPackets;
        private int mAvgBufferSensor;

        public enum EditPropertyType
        {
            // Sensor
            SensorMaxSendingRate,
            SensorMaxProcessingRate,

            // Channel
            ChannelMaxSendingRate,
        };


        private const char Delete = (char)8;
        private IConfigurationForm configListener;
        private LTSCanvas mCanvas;

        public WSNConfigForm(IConfigurationForm configListener, LTSCanvas canvas, WSNExtendInfo extendInfo)
        {
            this.mCanvas = canvas;
            this.configListener = configListener;
            InitializeComponent();

            // init value
            InitDefaultValue(extendInfo);
            LoadSensorListInfo();
            LoadChannelListInfo();

        }

        private void InitDefaultValue(WSNExtendInfo info)
        {
            // init ComboBox
            cmxBufferType.Items.Add(EditPropertyType.SensorMaxSendingRate.ToString());
            cmxBufferType.Items.Add(EditPropertyType.SensorMaxProcessingRate.ToString());
            cmxBufferType.Items.Add(EditPropertyType.ChannelMaxSendingRate.ToString());
            cmxBufferType.SelectedIndex = 0;

            if (info != null)
            {
                // set amount packets
                txtNumberOfPackets.Text = info.mNumberPacket.ToString();
                txtSenrMaxBSize.Text = info.mSensorMaxBufferSize.ToString();
                txtSenrMaxQSize.Text = info.mSensorMaxQueueSize.ToString();
                txtChanlMaxBSize.Text = info.mChannelMaxBufferSize.ToString();
            }
        }

        private void LoadSensorListInfo()
        {
            List<WSNSensor> mList = new List<WSNSensor>();

            foreach (LTSCanvas.CanvasItemData item in mCanvas.itemsList)
            {
                if ((item.Item is WSNSensor))
                    mList.Add(item.Item as WSNSensor);
            }

            var source = new BindingSource();
            source.DataSource = mList;
            mGridSensor.DataSource = source;

            mGridSensor.Columns["ID"].ReadOnly = true;
            mGridSensor.Columns["ID"].DisplayIndex = 0;
            mGridSensor.Columns["ID"].Width = 50;

            mGridSensor.Columns["NodeType"].Visible = false;
            mGridSensor.Columns["CongestionLevel"].Visible = false;
            mGridSensor.Columns["IsInitialState"].Visible = false;
            mGridSensor.Columns["IsVResizable"].Visible = false;
            mGridSensor.Columns["X"].Visible = false;
            mGridSensor.Columns["Y"].Visible = false;
            mGridSensor.Columns["Width"].Visible = false;
            mGridSensor.Columns["Height"].Visible = false;
            mGridSensor.Columns["ActualWidth"].Visible = false;
            mGridSensor.Columns["ActualHeight"].Visible = false;
            mGridSensor.Columns["Container"].Visible = false;
            mGridSensor.Columns["AbsoluteX"].Visible = false;
            mGridSensor.Columns["AbsoluteY"].Visible = false;
            mGridSensor.Columns["Border"].Visible = false;
            mGridSensor.Columns["Padding"].Visible = false;
            mGridSensor.Columns["KeepAspectRatio"].Visible = false;
            mGridSensor.Columns["IsHResizable"].Visible = false;
            mNumberSensors = mGridSensor.RowCount;
            //mNumberPackets = int.Parse(txtNumberOfPackets.Text);
            
            // Make dropdown list for sensor type
            DataGridViewComboBoxColumn cmbSensorType = new DataGridViewComboBoxColumn();
            cmbSensorType.HeaderText = "NodeType";
            cmbSensorType.DisplayIndex = 1;
            cmbSensorType.DataSource = Enum.GetValues(typeof(SensorType));
            cmbSensorType.DataPropertyName = "NodeType";
            mGridSensor.Columns.Add(cmbSensorType);

            // Make dropdown list for congestion level
            DataGridViewComboBoxColumn cmbCNGLevel = new DataGridViewComboBoxColumn();
            cmbCNGLevel.HeaderText = "CongestionLevel";
            cmbCNGLevel.DisplayIndex = 5;
            cmbCNGLevel.DataSource = Enum.GetValues(typeof(CGNLevel));
            cmbCNGLevel.DataPropertyName = "CongestionLevel";
            mGridSensor.Columns.Add(cmbCNGLevel);
        }

        private void LoadChannelListInfo()
        {
            List<WSNChannel> mList = new List<WSNChannel>();

            foreach (Route route in mCanvas.diagramRouter.routes)
            {
                if ((route is WSNChannel))
                    mList.Add(route as WSNChannel);
            }

            var source = new BindingSource();
            source.DataSource = mList;
            mGridChannel.DataSource = source;

            mGridChannel.Columns["ID"].ReadOnly = true;
            mGridChannel.Columns["ID"].DisplayIndex = 0;
            mGridChannel.Columns["ID"].Width = 50;

            mGridChannel.Columns["Type"].Visible = false;
            mGridChannel.Columns["BroadcastId"].Visible = false;
            mGridChannel.Columns["FromSensorName"].ReadOnly = true;
            mGridChannel.Columns["ToSensorName"].ReadOnly = true;
            mGridChannel.Columns["CurrentState"].Visible = false;
            mGridChannel.Columns["Neighbor"].Visible = false;
            mGridChannel.Columns["Transition"].Visible = false;
            mGridChannel.Columns["NailSelected"].Visible = false;
            mGridChannel.Columns["SegmentSelected"].Visible = false;
            mGridChannel.Columns["From"].Visible = false;
            mGridChannel.Columns["To"].Visible = false;
            mGridChannel.Columns["CongestionLevel"].Visible = false;

            mGridChannel.Columns["FromSensorName"].DisplayIndex = 1;
            mGridChannel.Columns["ToSensorName"].DisplayIndex = 2;

            // Make dropdown list for congestion level
            DataGridViewComboBoxColumn cmbCNGLevel = new DataGridViewComboBoxColumn();
            cmbCNGLevel.HeaderText = "CongestionLevel";
            cmbCNGLevel.DataSource = Enum.GetValues(typeof(CGNLevel));
            cmbCNGLevel.DataPropertyName = "CongestionLevel";
            mGridChannel.Columns.Add(cmbCNGLevel);
        }

        private bool checkEmptyField()
        {
            return txtNumberOfPackets.Text.Length > 0
                && txtSenrMaxBSize.Text.Length > 0
                && txtSenrMaxQSize.Text.Length > 0
                && txtChanlMaxBSize.Text.Length > 0;
        }

        private void txtMaxSizeOfSensor_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void txtMaxSizeOfChannel_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void txtTimeOfProcessing_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void txtSendingRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Check configure
            if (checkEmptyField())
            {
                try
                {
                    WSNExtendInfo info = new WSNExtendInfo();
                    info.mNumberSensor = mNumberSensors;
                    info.mNumberPacket = Int32.Parse(txtNumberOfPackets.Text);
                    info.mSensorMaxBufferSize = Int32.Parse(txtSenrMaxBSize.Text);
                    info.mSensorMaxQueueSize = Int32.Parse(txtSenrMaxQSize.Text);
                    info.mChannelMaxBufferSize = Int32.Parse(txtChanlMaxBSize.Text);

                    // 20151028-lqv-update ID-s
                    info.mID = DateTime.Now.Ticks;
                    // 20151028-lqv-update ID-e

                    configListener.Save(info);

                    mAvgBufferSensor = info.mSensorMaxBufferSize;
                    string id = info.mID.ToString();
                    MessageBox.Show("Suffix of configuration ID: " + id.Substring(id.Length - 4, 4));
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error");
                }
            }
            else
            {
                MessageBox.Show("Please enter all field empty", "Alert");
            }
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            if (verifyModel())
                MessageBox.Show("Model is OK", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Model require only source and only sink", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private bool verifyModel()
        {
            int numOfSource = 0;
            int numOfSink = 0;

            foreach (LTSCanvas.CanvasItemData item in mCanvas.itemsList)
            {
                if ((item.Item is WSNSensor))
                    if ((item.Item as WSNSensor).NodeType == SensorType.Source)
                        numOfSource++;
                    else if ((item.Item as WSNSensor).NodeType == SensorType.Sink)
                        numOfSink++;
            }

            return numOfSource > 0 && numOfSink > 0;
        }

        private void btn_apply_Click(object sender, EventArgs e)
        {

            do
            {
                int fixedVal = 0;
                EditPropertyType editType = (EditPropertyType)Enum.Parse(typeof(EditPropertyType), cmxBufferType.Text, true);

                try
                {
                    fixedVal = Int32.Parse(txtFixed.Text);
                }
                catch (Exception ex)
                {
                    DevLog.d(TAG, ex.ToString());
                    MessageBox.Show("Value format is incorrect!", "Parse error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                String columnEdited = null;
                DataGridView gridView = null;
                switch (editType)
                {
                    // For sensor
                    case EditPropertyType.SensorMaxSendingRate:
                        columnEdited = "SendingRate";
                        gridView = mGridSensor;
                        break;

                    case EditPropertyType.SensorMaxProcessingRate:
                        columnEdited = "ProcessingRate";
                        gridView = mGridSensor;
                        break;

                    // For channel
                    case EditPropertyType.ChannelMaxSendingRate:
                        columnEdited = "SendingRate";
                        gridView = mGridChannel;
                        break;

                    default:
                        break;
                }

                if (columnEdited == null || gridView == null)
                    break;

                changeValue(fixedVal, columnEdited, gridView);
            } while (false);
        }

        private void changeValue(Int32 fixedVal, String columnName, DataGridView gridView)
        {
            int l = gridView.Rows.Count;
            for (int i = 0; i < l; ++i)
            {
                DataGridViewRow d = (DataGridViewRow)gridView.Rows[i];
                d.Cells[columnName].Value = fixedVal;
            }
        }
    }
}