using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DecisionSupport
{
    public partial class Form1 : Form
    {
        //for decision tree
        const int percentSplit = 66;
        static weka.classifiers.Classifier cl = null;

        //for naive bayes        
        static weka.classifiers.Classifier cl2 = null;

        //for k-nearest neigbour
        static weka.classifiers.Classifier cl3 = null;

        //for artificial neural network
        static weka.classifiers.Classifier cl4 = null;

        //for SVM
        static weka.classifiers.Classifier cl5 = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                string filename = file.FileName;
                string filee = Path.GetFileName(filename);
                bool attributeType;
                string attributeName=" ";
                int numAttributeValue = 0;
                string attributeValueName = " ";
                
                textBox1.Text = filee + " chosen succesfully!";

                ///////Decision Tree
                weka.core.Instances insts = new weka.core.Instances(new java.io.FileReader(filename));
                

                insts.setClassIndex(insts.numAttributes() - 1);

                //find nominal or numeric attributes and create dropbox or textbox                
                int numofAttributes = insts.numAttributes() - 1;               
                for (int i=0; i<numofAttributes; i++)
                {
                    attributeType = insts.attribute(i).isNumeric();
                    attributeName = insts.attribute(i).name();                                     
                    dataGridView1.Rows.Add(attributeName);
                    if (attributeType == true)
                    {
                        

                    }
                    else
                    {
                        numAttributeValue = insts.attribute(i).numValues();
                        string[] name = new string[numAttributeValue];
                        for (int j = 0; j < numAttributeValue; j++)
                        {
                            attributeValueName = insts.attribute(i).value(j);
                            name[j] += attributeValueName;
                        }
                        DataGridViewComboBoxCell combo = new DataGridViewComboBoxCell();
                        combo.DataSource = name.ToList();
                        dataGridView1.Rows[i].Cells[1] = combo;

                    }

                }

                cl = new weka.classifiers.trees.J48();

                textBox2.Text = "Performing " + percentSplit + "% split evaluation.";

                //filling missing values
                weka.filters.Filter missingval = new weka.filters.unsupervised.attribute.ReplaceMissingValues();
                missingval.setInputFormat(insts);
                insts = weka.filters.Filter.useFilter(insts, missingval);

                weka.filters.Filter myNormalized = new weka.filters.unsupervised.instance.Normalize();
                myNormalized.setInputFormat(insts);
                insts = weka.filters.Filter.useFilter(insts, myNormalized);


                //randomize the order of the instances in the dataset.
                weka.filters.Filter myRandom = new weka.filters.unsupervised.instance.Randomize();
                myRandom.setInputFormat(insts);
                insts = weka.filters.Filter.useFilter(insts, myRandom);

                int trainSize = insts.numInstances() * percentSplit / 100;
                int testSize = insts.numInstances() - trainSize;
                weka.core.Instances train = new weka.core.Instances(insts, 0, trainSize);

                cl.buildClassifier(train);

                string str = cl.toString();

                int numCorrect = 0;
                for (int i = trainSize; i < insts.numInstances(); i++)
                {
                    weka.core.Instance currentInst = insts.instance(i);
                    double predictedClass = cl.classifyInstance(currentInst);
                    if (predictedClass == insts.instance(i).classValue())
                        numCorrect++;
                }
                textBox3.Text = numCorrect + " out of " + testSize + " correct (" +
                           (double)((double)numCorrect / (double)testSize * 100.0) + "%)";




                //////////Naive Bayes

                //dosya okuma
                weka.core.Instances insts2 = new weka.core.Instances(new java.io.FileReader(filename));
                insts2.setClassIndex(insts2.numAttributes() - 1);

                //naive bayes
                cl2 = new weka.classifiers.bayes.NaiveBayes();
                

                //filling missing values
                weka.filters.Filter missingval2 = new weka.filters.unsupervised.attribute.ReplaceMissingValues();
                missingval2.setInputFormat(insts2);
                insts2 = weka.filters.Filter.useFilter(insts2, missingval2);

                //for naive bayes
                weka.filters.Filter discrete2 = new weka.filters.unsupervised.attribute.Discretize();
                discrete2.setInputFormat(insts2);
                insts2 = weka.filters.Filter.useFilter(insts2, discrete2);

                //randomize the order of the instances in the dataset. -ortak
                weka.filters.Filter myRandom2 = new weka.filters.unsupervised.instance.Randomize();
                myRandom2.setInputFormat(insts2);
                insts2 = weka.filters.Filter.useFilter(insts2, myRandom2);

                //ortak
                int trainSize2 = insts2.numInstances() * percentSplit / 100;
                int testSize2 = insts2.numInstances() - trainSize2;
                weka.core.Instances train2 = new weka.core.Instances(insts2, 0, trainSize2);

                cl2.buildClassifier(train2);

                string str2 = cl2.toString();

                int numCorrect2 = 0;
                for (int i = trainSize2; i < insts2.numInstances(); i++)
                {
                    weka.core.Instance currentInst2 = insts2.instance(i);
                    double predictedClass2 = cl2.classifyInstance(currentInst2);
                    if (predictedClass2 == insts2.instance(i).classValue())
                        numCorrect2++;
                }
                textBox4.Text = numCorrect2 + " out of " + testSize2 + " correct (" +
                           (double)((double)numCorrect2 / (double)testSize2 * 100.0) + "%)";


                /////////K-Nearest Neigbour

                //dosya okuma
                weka.core.Instances insts3 = new weka.core.Instances(new java.io.FileReader(filename));
                insts3.setClassIndex(insts3.numAttributes() - 1);

                cl3 = new weka.classifiers.lazy.IBk();

                
                //filling missing values
                weka.filters.Filter missingval3 = new weka.filters.unsupervised.attribute.ReplaceMissingValues();
                missingval3.setInputFormat(insts3);
                insts3 = weka.filters.Filter.useFilter(insts3, missingval3);

                //Convert to dummy attribute knn,svm,neural network
                weka.filters.Filter dummy3 = new weka.filters.unsupervised.attribute.NominalToBinary();
                dummy3.setInputFormat(insts3);
                insts3 = weka.filters.Filter.useFilter(insts3, dummy3);

                //normalize numeric attribute
                weka.filters.Filter myNormalized3 = new weka.filters.unsupervised.instance.Normalize();
                myNormalized3.setInputFormat(insts3);
                insts3 = weka.filters.Filter.useFilter(insts3, myNormalized3);

                //randomize the order of the instances in the dataset.
                weka.filters.Filter myRandom3 = new weka.filters.unsupervised.instance.Randomize();
                myRandom3.setInputFormat(insts3);
                insts3 = weka.filters.Filter.useFilter(insts3, myRandom3);

                int trainSize3 = insts3.numInstances() * percentSplit / 100;
                int testSize3 = insts3.numInstances() - trainSize3;
                weka.core.Instances train3 = new weka.core.Instances(insts3, 0, trainSize3);

                cl3.buildClassifier(train3);

                string str3 = cl3.toString();

                int numCorrect3 = 0;
                for (int i = trainSize3; i < insts3.numInstances(); i++)
                {
                    weka.core.Instance currentInst3 = insts3.instance(i);
                    double predictedClass3 = cl3.classifyInstance(currentInst3);
                    if (predictedClass3 == insts3.instance(i).classValue())
                        numCorrect3++;
                }
                textBox5.Text = numCorrect3 + " out of " + testSize3 + " correct (" +
                           (double)((double)numCorrect3 / (double)testSize3 * 100.0) + "%)";

                //////////Artificial neural network
                //dosya okuma
                weka.core.Instances insts4 = new weka.core.Instances(new java.io.FileReader(filename));
                insts4.setClassIndex(insts4.numAttributes() - 1);

                cl4 = new weka.classifiers.functions.MultilayerPerceptron();

                
                //filling missing values
                weka.filters.Filter missingval4 = new weka.filters.unsupervised.attribute.ReplaceMissingValues();
                missingval4.setInputFormat(insts4);
                insts4 = weka.filters.Filter.useFilter(insts4, missingval4);

                //Convert to dummy attribute
                weka.filters.Filter dummy4 = new weka.filters.unsupervised.attribute.NominalToBinary();
                dummy4.setInputFormat(insts4);
                insts4 = weka.filters.Filter.useFilter(insts4, dummy4);

                //normalize numeric attribute
                weka.filters.Filter myNormalized4 = new weka.filters.unsupervised.instance.Normalize();
                myNormalized4.setInputFormat(insts4);
                insts4 = weka.filters.Filter.useFilter(insts4, myNormalized4);

                //randomize the order of the instances in the dataset.
                weka.filters.Filter myRandom4 = new weka.filters.unsupervised.instance.Randomize();
                myRandom4.setInputFormat(insts4);
                insts4 = weka.filters.Filter.useFilter(insts4, myRandom4);

                int trainSize4 = insts4.numInstances() * percentSplit / 100;
                int testSize4 = insts4.numInstances() - trainSize4;
                weka.core.Instances train4 = new weka.core.Instances(insts4, 0, trainSize4);

                cl4.buildClassifier(train4);

                string str4 = cl4.toString();

                int numCorrect4 = 0;
                for (int i = trainSize4; i < insts4.numInstances(); i++)
                {
                    weka.core.Instance currentInst4 = insts4.instance(i);
                    double predictedClass4 = cl4.classifyInstance(currentInst4);
                    if (predictedClass4 == insts4.instance(i).classValue())
                        numCorrect4++;
                }

                textBox6.Text = numCorrect4 + " out of " + testSize4 + " correct (" +
                            (double)((double)numCorrect4 / (double)testSize4 * 100.0) + "%)";



                ///////Support Vector Machine
                // dosya okuma
                weka.core.Instances insts5 = new weka.core.Instances(new java.io.FileReader(filename));
                insts5.setClassIndex(insts5.numAttributes() - 1);

                cl5 = new weka.classifiers.functions.SMO();

                
                //filling missing values
                weka.filters.Filter missingval5 = new weka.filters.unsupervised.attribute.ReplaceMissingValues();
                missingval5.setInputFormat(insts5);
                insts5 = weka.filters.Filter.useFilter(insts5, missingval5);

                //Convert to dummy attribute
                weka.filters.Filter dummy5 = new weka.filters.unsupervised.attribute.NominalToBinary();
                dummy5.setInputFormat(insts5);
                insts5 = weka.filters.Filter.useFilter(insts5, dummy5);

                //normalize numeric attribute
                weka.filters.Filter myNormalized5 = new weka.filters.unsupervised.instance.Normalize();
                myNormalized5.setInputFormat(insts5);
                insts5 = weka.filters.Filter.useFilter(insts5, myNormalized5);

                //randomize the order of the instances in the dataset.
                weka.filters.Filter myRandom5 = new weka.filters.unsupervised.instance.Randomize();
                myRandom5.setInputFormat(insts5);
                insts5 = weka.filters.Filter.useFilter(insts5, myRandom5);

                int trainSize5 = insts5.numInstances() * percentSplit / 100;
                int testSize5 = insts5.numInstances() - trainSize5;
                weka.core.Instances train5 = new weka.core.Instances(insts5, 0, trainSize5);

                cl5.buildClassifier(train5);

                string str5 = cl5.toString();

                int numCorrect5 = 0;
                for (int i = trainSize5; i < insts5.numInstances(); i++)
                {
                    weka.core.Instance currentInst5 = insts5.instance(i);
                    double predictedClass5 = cl5.classifyInstance(currentInst5);
                    if (predictedClass5 == insts5.instance(i).classValue())
                        numCorrect5++;
                }

                textBox7.Text = numCorrect5 + " out of " + testSize5 + " correct (" +
                            (double)((double)numCorrect5 / (double)testSize5 * 100.0) + "%)";



                string result1 = textBox3.Text;
                string output1 = result1.Split('(', ')')[1];
                output1 = output1.Remove(output1.Length - 1);
                double r1 = Convert.ToDouble(output1);

                string result2 = textBox4.Text;
                string output2 = result2.Split('(', ')')[1];
                output2 = output2.Remove(output2.Length - 1);
                double r2 = Convert.ToDouble(output2);

                string result3 = textBox5.Text;
                string output3 = result3.Split('(', ')')[1];
                output3 = output3.Remove(output3.Length - 1);
                double r3 = Convert.ToDouble(output3);

                string result4 = textBox6.Text;
                string output4 = result4.Split('(', ')')[1];
                output4 = output4.Remove(output4.Length - 1);
                double r4 = Convert.ToDouble(output4);

                string result5 = textBox7.Text;
                string output5 = result5.Split('(', ')')[1];
                output5 = output5.Remove(output5.Length - 1);
                double r5 = Convert.ToDouble(output5);


                double[] max_array = new double[] { r1, r2, r3, r4, r5 };

                double max = max_array.Max();
                if (r1 == max)
                {
                    textBox8.Text = "Best Algoritm is Decision Tree Algorithm ";
                }
                else if (r2 == max)
                {
                    textBox8.Text = "Best Algoritm is Naive Bayes Algorithm ";
                }
                else if (r3 == max)
                {
                    textBox8.Text = "Best Algoritm is K-Nearest Neighbour Algorithm ";
                }
                else if (r4 == max)
                {
                    textBox8.Text = "Best Algoritm is Artificial Neural Network Algorithm ";
                }
                else if (r5 == max)
                {
                    textBox8.Text = "Best Algoritm is Support Vector Machine Algorithm ";
                }


            }

            

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //string[] values = new string[dataGridView1.Rows.Count];
            //for(int i=0;i<dataGridView1.Rows.Count;i++)
            //{
            //    values[i] += dataGridView1.Rows[i].Cells[1].Value.GetType().ToString();

            //}

            ArrayList value = new ArrayList();
            int value2 = 0;
            string str = " ";
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                str = dataGridView1.Rows[i].Cells[1].Value.ToString();
                value2 = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value);
                if (value2 < 9999999)
                {
                    value.Add(value2);
                }
                else
                {
                    value.Add(str);
                }
            }

            //string contents = File.ReadAllText(filename);
        }
    }
}
