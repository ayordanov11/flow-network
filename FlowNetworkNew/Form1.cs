using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlowNetworkNew
{
    public partial class Form1 : Form
    {
        Network network;
        Toolbox tb;

        bool loadedFromFile;
        bool savedChanges;
        FileHelper fh;

        Panel[] panels;

        List<Point> inBetweenPoints;
        Component originComponent;
        Component endComponent;
        int pipelineOrigin;
        int pipelineEnd;


        public Form1()
        {
            InitializeComponent();
            network = new Network("Flow Network");
            btnSelect.BackColor = Color.Green;
            tb = new Toolbox();
            inBetweenPoints = new List<Point>();

            loadedFromFile = false;
            savedChanges = true;
            fh = new FileHelper();

            panels = new Panel[6] { panelPump, panelSink, panelMerger, panelPipe, panelAdjSplitter, panelSplitter};

            trbrCurrentFlow.Maximum = Convert.ToInt32(nudMaxFlow.Value);
            unSelect();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnSelect.Select();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            unSelect();
        }
            
        private void unSelect()
        {
            tb.changeCurrentTool(toolsCollection.Pointer);
            nudSafetyLimit.Enabled = false;
            nudMaxFlow.Enabled = false;
            nudFuel.Enabled = false;
            trbrCurrentFlow.Enabled = false;
            changeSelectedPanel("");

            network.SelectedComponent = null;
            network.SelectedPipeline = null;
            inBetweenPoints = new List<Point>();
            originComponent = null;
            endComponent = null;
            pipelineOrigin = -1;
            pipelineEnd = -1;
            pictureBox1.Invalidate();
        }


        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            network.paint(gr);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void changeSelectedPanel(string componentName)
        {
            foreach (Panel p in panels)
            {
                if ("panel" + componentName == p.Name)
                    p.BackColor = Color.Yellow;
                else
                    p.BackColor = SystemColors.Control;
            }
        }

        private void Pump_pictureBox_Click(object sender, EventArgs e)
        {
            unSelect();
            trbrCurrentFlow.Enabled = true;
            nudMaxFlow.Enabled = true;
            tb.changeCurrentTool(toolsCollection.addPump);
            changeSelectedPanel("Pump");
        }

        private void SinkPictureBox_Click(object sender, EventArgs e)
        {
            unSelect();
            nudMaxFlow.Enabled = true;
            tb.changeCurrentTool(toolsCollection.addSink);
            changeSelectedPanel("Sink");
        }

        private void MergerPictureBox_Click(object sender, EventArgs e)
        {
            unSelect();
            nudMaxFlow.Enabled = true;
            tb.changeCurrentTool(toolsCollection.addMerger);
            changeSelectedPanel("Merger");
        }

        private void SplitterPictureBox_Click(object sender, EventArgs e)
        {
            unSelect();
            nudMaxFlow.Enabled = true;
            tb.changeCurrentTool(toolsCollection.addSplitter);
            changeSelectedPanel("Splitter");
        }

        private void pipeline_Click(object sender, EventArgs e)
        {
            unSelect();
            tb.changeCurrentTool(toolsCollection.addPipeline);
            nudSafetyLimit.Enabled = true;
            changeSelectedPanel("Pipe");
        }

        private void AdjSplitterPictureBox_Click(object sender, EventArgs e)
        {
            unSelect();
            nudFuel.Enabled = true;
            tb.changeCurrentTool(toolsCollection.addAdjustableSplitter);
            changeSelectedPanel("AdjSplitter");
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = e.Y;

            network.SelectedPipeline = null;
            network.SelectedComponent = null;

            if (tb.CurrentTool != toolsCollection.Pointer && tb.CurrentTool != toolsCollection.Remove && tb.CurrentTool != toolsCollection.addPipeline)
            {
                bool perm = true;
                x -= 25;
                y -= 25;

                if (network.ComponentsList.Count() > 0)
                {
                    foreach (Component c in network.ComponentsList)
                    {
                        if (x < c.Position.X + c.PictureSize && x > c.Position.X - c.PictureSize && y < c.Position.Y + c.PictureSize && y > c.Position.Y - c.PictureSize)
                        {
                            perm = false;
                        }
                    }
                }
                if (!perm)
                {
                    MessageBox.Show("These coordinates are already occupied!");
                }
                else
                {
                    switch (tb.CurrentTool)
                    {
                        case toolsCollection.addPump:
                            network.addComponent(new PumpSink(trbrCurrentFlow.Value, Convert.ToInt32(nudMaxFlow.Value), false, new Point(x, y)));
                            break;
                        case toolsCollection.addSink:
                            network.addComponent(new PumpSink(trbrCurrentFlow.Value, Convert.ToInt32(nudMaxFlow.Value), true, new Point(x, y)));
                            break;
                        case toolsCollection.addSplitter:
                            network.addComponent(new Splitter(new Point(x, y)));
                            break;
                        case toolsCollection.addAdjustableSplitter:
                            network.addComponent(new AdjustableSplitter(Convert.ToInt32(nudFuel.Value), new Point(x, y)));
                            break;
                        case toolsCollection.addMerger:
                            network.addComponent(new Merger(new Point(x, y)));
                            break;
                    }

                    pictureBox1.Invalidate();
                    savedChanges = false;
                }
            }
            else if (tb.CurrentTool == toolsCollection.Pointer)
            {
                Component tempComponent = network.findComponent(new Point(x, y));
                if (tempComponent != null)
                {
                    network.SelectedComponent = tempComponent;
                    pictureBox1.Invalidate();

                    if (tempComponent is PumpSink)
                    {
                        if (((PumpSink)tempComponent).IsSink == false)
                        {
                            nudMaxFlow.Enabled = true;
                            trbrCurrentFlow.Enabled = true;
                            trbrCurrentFlow.Maximum = ((PumpSink)tempComponent).MaxFlow;
                            nudMaxFlow.Value = ((PumpSink)tempComponent).MaxFlow;
                        }
                        else
                        {
                            nudMaxFlow.Enabled = true;
                        }
                    }
                    else if (tempComponent is AdjustableSplitter)
                    {
                        nudFuel.Enabled = true;
                        ((AdjustableSplitter)tempComponent).changeSplitterPercentage((int)nudFuel.Value); 
                    }
                    else
                    {
                        Pipeline tempPipeline = network.findPipeline(new Point(x,y));
                        if (tempPipeline != null)
                        {
                            nudSafetyLimit.Enabled = true;
                        }
                    }
                }
                else
                {
                    network.SelectedPipeline = network.findPipeline(new Point(x, y));
                    if (network.SelectedPipeline != null)
                    {
                        nudSafetyLimit.Enabled = true;
                    }
                    else
                    {
                        unSelect();
                        pictureBox1.Invalidate();
                    }
                }     
            }
            else if (tb.CurrentTool == toolsCollection.addPipeline)
            {
                if (originComponent==null)
                {
                    originComponent = network.findComponent(new Point(x, y));
                    pipelineOrigin = network.checkPipelineOrigin(new Point(x, y));
                    if (pipelineOrigin == -1)
                    {
                        originComponent = null;
                        MessageBox.Show("Select unocuppied output of a component.");
                    }
                }
                else
                {
                    endComponent = network.findComponent(new Point(x, y));
                    if (endComponent == null)
                    {
                        inBetweenPoints.Add(new Point(x, y));
                    }
                    else
                    {
                        if (inBetweenPoints.Count == 0) MessageBox.Show("First, you need to make some inbetween points.");
                        else
                        {
                            pipelineEnd = network.checkPipelineEnd(new Point(x, y));
                            if (pipelineEnd == -1)
                            {
                                endComponent = null;
                                MessageBox.Show("Select unocuppied input of a component.");
                            }
                            else
                            {
                                network.addPipeline(originComponent, endComponent, inBetweenPoints, Convert.ToInt32(nudSafetyLimit.Value), new int[] { pipelineOrigin, pipelineEnd });
                                originComponent = null;
                                endComponent = null;
                                pipelineOrigin = -1;
                                pipelineEnd = -1;
                                unSelect();
                                panelPipe.BackColor = SystemColors.Control;
                                nudSafetyLimit.Enabled = true;
                                pictureBox1.Invalidate();
                                savedChanges = false;
                            }
                        }
                        
                    }
                }                 
            }
            else if (tb.CurrentTool == toolsCollection.Remove)
            {
                Component tempComponent = network.findComponent(new Point(x, y));

                if (tempComponent != null)
                {
                    network.removeComponent(tempComponent);
                    pictureBox1.Invalidate();
                    savedChanges = false;
                }
                else
                {
                    Pipeline tempPipeline = network.findPipeline(new Point(x, y));
                    if (tempPipeline != null)
                    {
                        network.removePipeline(tempPipeline);
                        pictureBox1.Invalidate();
                        savedChanges = false;
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveNetwork();
        }

        private void saveNetwork()
        {
            if (loadedFromFile == false)
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Bin Files (*.bin)|*.bin";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        fh.FileName = sfd.FileName;
                        loadedFromFile = true;
                        fh.saveToFile(network);
                        savedChanges = true;
                    }
                }
            }
            else
            {
                fh.saveToFile(network);
                savedChanges = true;
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (savedChanges == false)
            {
                string messageBoxText = "You have unsaved changes to the current project. Would you like to save your changes before loading a new Network?";
                string caption = "Flow Network";
                MessageBoxButtons button = MessageBoxButtons.YesNoCancel;
                MessageBoxIcon icon = MessageBoxIcon.Warning;

                DialogResult result = MessageBox.Show(messageBoxText, caption, button, icon);

                switch (result)
                {
                    case DialogResult.Yes:
                        savedChanges = true;
                        saveNetwork();
                        loadNetwork();
                        loadedFromFile = true;
                        break;
                    case DialogResult.No:
                        loadNetwork();
                        loadedFromFile = true;
                        savedChanges = true;
                        break;
                    case DialogResult.Cancel:
                        break;
                    default:
                        break;
                }
            }
            else
            {
                loadNetwork();
                loadedFromFile = true;
                savedChanges = true;
            }
        }

        private void loadNetwork()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Bin files (*.bin)|*.bin";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    fh.FileName = ofd.FileName;
                }
            }

            try
            {
                network = fh.loadFromFile();
                pictureBox1.Invalidate();
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("The file was in an invalid format");
            }
            catch (IOException)
            {
                MessageBox.Show("Error reading from file");
            }
        }

        private void nudMaxFlow_ValueChanged(object sender, EventArgs e)
        {
            if (network.SelectedComponent is PumpSink)
            {
                if (((PumpSink)network.SelectedComponent).IsSink == false)
                {
                    if (nudMaxFlow.Value < ((PumpSink)network.SelectedComponent).CurrentFlow)
                    {
                        ((PumpSink)network.SelectedComponent).changeCurrentFlow(Convert.ToInt32(nudMaxFlow.Value));
                    }

                    trbrCurrentFlow.Maximum = (int)nudMaxFlow.Value;
                    ((PumpSink)network.SelectedComponent).changeMaxFlow(Convert.ToInt32(nudMaxFlow.Value));
                }
            }
        }

        private void trbrCurrentFlow_Scroll(object sender, EventArgs e)
        {
            if (network.SelectedComponent is PumpSink)
            {
                if (((PumpSink)network.SelectedComponent).IsSink == false)
                {
                    ((PumpSink)network.SelectedComponent).changeCurrentFlow(trbrCurrentFlow.Value);
                    savedChanges = false;
                }
            }
        }

        private void pictureBox1_Resize(object sender, EventArgs e)
        {
        }

        private void nudSafetyLimit_ValueChanged(object sender, EventArgs e)
        {
            if (network.SelectedPipeline != null)
            {
                network.SelectedPipeline.SafetyLimit = (int)nudSafetyLimit.Value;
                savedChanges = false;
            }
        }

        private void btnNewProject_Click(object sender, EventArgs e)
        {
            if (savedChanges == false)
            {
                string messageBoxText = "You have unsaved changes to the current project. Would you like to save your changes before starting a new Network?";
                string caption = "Flow Network";
                MessageBoxButtons button = MessageBoxButtons.YesNoCancel;
                MessageBoxIcon icon = MessageBoxIcon.Warning;

                DialogResult result = MessageBox.Show(messageBoxText, caption, button, icon);

                switch (result)
                {
                    case DialogResult.Yes:
                        saveNetwork();
                        loadedFromFile = false;
                        network = new Network("My network");
                        pictureBox1.Invalidate();
                        unSelect();
                        break;
                    case DialogResult.No:
                        loadedFromFile = false;
                        network = new Network("My network");
                        pictureBox1.Invalidate();
                        unSelect();
                        break;
                    case DialogResult.Cancel:
                        break;
                    default:
                        break;
                }
            }
            else
            {
                network = new Network("My network");
                pictureBox1.Invalidate();
                loadedFromFile = false;
                unSelect();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            unSelect();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            unSelect();
            tb.changeCurrentTool(toolsCollection.Remove);
        }

        private void nudFuel_ValueChanged(object sender, EventArgs e)
        {
            if (network.SelectedComponent != null)
            {
                if (network.SelectedComponent is AdjustableSplitter)
                {
                    ((AdjustableSplitter)network.SelectedComponent).changeSplitterPercentage((int)nudFuel.Value);
                    savedChanges = false;
                }
                
            }
        }
    }
}
