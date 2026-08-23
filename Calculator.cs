using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyProjectCalculation
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }
        string LastTypeAddOfCalculation="";

        bool CheckLastAddForPoint(Button Number)
        {
            string[] operation = { "*", "+", "-", "/", "%" };

            if (txtviewTheArithmeticOperation.Text.Length == 0)
            {
                txtviewTheArithmeticOperation.Text += "0.";
                return false;
            }
            string LastAdd = txtviewTheArithmeticOperation.Text.Substring(txtviewTheArithmeticOperation.Text.Length - 1);
            foreach (string s in operation)
            {
                if (LastAdd == s)
                {
                    Number.Tag = "0.";
                    txtviewTheArithmeticOperation.Text += Number.Tag.ToString();
                    Number.Tag = ".";

                    return false;
                }
            }
            txtviewTheArithmeticOperation.Text += Number.Tag.ToString();

            return true;
        }
        void AddNumberTotxtToCalculation(Button Number)
        {
            txtviewTheArithmeticOperation.Text += Number.Tag.ToString();
            
        }
        void TypeOfCalculation(Button type)
        {

            LastTypeAddOfCalculation = type.Tag.ToString();
            txtviewTheArithmeticOperation.Text += type.Tag.ToString();

        }
        private void btnType_Click(object sender, EventArgs e)
        {
            TypeOfCalculation((Button)sender);
            GetTheResult(txtviewTheArithmeticOperation);

        }

        private void btn_Click(object sender, EventArgs e)
        {
            AddNumberTotxtToCalculation((Button)sender);
            GetTheResult(txtviewTheArithmeticOperation);

        }
       
        void  GetTheResult(TextBox lint,bool ForEqual=false)
        {
            if (txtviewTheArithmeticOperation.Text.Length == 0) return;
            
            try {
                string Expression = txtviewTheArithmeticOperation.Text;

                DataTable table = new DataTable();
                object Result = table.Compute(Expression, "");
                double FinalResult=Convert.ToDouble(Result);

                if (ForEqual)
                {
                    txtviewTheArithmeticOperation.Text = FinalResult.ToString("G10");
                    txtHideResult.Text = "";
                    return;
                }
                txtHideResult.Text = FinalResult.ToString("G10");
            }
            catch(Exception ex)
            {
                if(ForEqual)
                MessageBox.Show("Sorry the Calculation is incorrect.\nPlease check the numbers and parentheses.", "Calculation Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);

                txtHideResult.Text = "";
            }
            
           


        }
        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            txtviewTheArithmeticOperation.Text = "";
            txtHideResult.Text = "";
            LastTypeAddOfCalculation = "";

        }
        void GetLastIndexAfterDelete(string txt)
        {
            
            if ((txt[txt.Length - 1]) == Convert.ToChar(LastTypeAddOfCalculation))
            {
                string st = txtviewTheArithmeticOperation.Text;
                int length = txtviewTheArithmeticOperation.Text.Length;

                char[] Operations = { '/', '+', '-', '&', '*', '(', ')' };
                for (int i = length - 1; i >= 0; i--)
                {
                    for (int j = 0; 7>j; j++)
                    {
                        if ((st[i]) == (Operations[j]))
                        {
                            LastTypeAddOfCalculation = Operations[j].ToString();
                            return;
                        }
                    }
                }
                LastTypeAddOfCalculation = "";
            }
        }
        private void pbDelete_Click(object sender, EventArgs e)
        {
            if (txtviewTheArithmeticOperation.Text.Length > 0)
            {
                    string txt = txtviewTheArithmeticOperation.Text;

                txtviewTheArithmeticOperation.Text = txtviewTheArithmeticOperation.Text.Remove(txtviewTheArithmeticOperation.Text.Length - 1);
                GetTheResult(txtviewTheArithmeticOperation);

                if (LastTypeAddOfCalculation != "")
                {
                    GetLastIndexAfterDelete(txt);
                }


                if (txtviewTheArithmeticOperation.Text.Length ==0)
                    txtHideResult.Text = "";

            }
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            GetTheResult(txtviewTheArithmeticOperation,true);

        }
        void ChechForArcForBeating()
        {
           

            string text = txtviewTheArithmeticOperation.Text;
            int openCount = text.Count(f => f == '(');
            int CloseCount = text.Count(f => f == ')');

            if (text.Length == 0)
            {
                txtviewTheArithmeticOperation.Text += "(";
                LastTypeAddOfCalculation = "(";
            }
            else
            {



                char LastChar=text[text.Length-1];
                if ((openCount > CloseCount) && (char.IsDigit(LastChar) || LastChar == ')'))
                {
                    txtviewTheArithmeticOperation.Text += ")";
                    LastTypeAddOfCalculation = ")";
                }
                else if (char.IsDigit(LastChar))
                {
                    txtviewTheArithmeticOperation.Text += "*(";
                    LastTypeAddOfCalculation = "(";
                }
                else if (LastChar == ')')
                {
                    txtviewTheArithmeticOperation.Text += "*(";
                    LastTypeAddOfCalculation = "(";
                }
                else
                {
                    txtviewTheArithmeticOperation.Text += "(";
                    LastTypeAddOfCalculation = "(";

                }
            }
        }
        private void btnArcOfbeating_Click(object sender, EventArgs e)
        {
            ChechForArcForBeating();
            GetTheResult(txtviewTheArithmeticOperation);


        }

        private void btnPoint_Click(object sender, EventArgs e)
        {
            CheckLastAddForPoint((Button)sender);
        }

        int GetTheIndexOfLastOperation()
        {

            int index = default;
            string text = txtviewTheArithmeticOperation.Text;
            return (index = text.LastIndexOf(Convert.ToChar(LastTypeAddOfCalculation)));

        }
        
        void MinusOrPlus()
        {


            if (string.IsNullOrEmpty(txtviewTheArithmeticOperation.Text))
            {
                txtviewTheArithmeticOperation.Text= "-";
            }

          
           
            else if (LastTypeAddOfCalculation != "")
            {
                int Index = GetTheIndexOfLastOperation();
                try
                {

                    
                    if ((txtviewTheArithmeticOperation.Text[Index - 1]) == '-')
                        txtviewTheArithmeticOperation.Text = txtviewTheArithmeticOperation.Text.Remove(Index, 1);

                    else if ((txtviewTheArithmeticOperation.Text[Index + 1]) == '-')
                        txtviewTheArithmeticOperation.Text = txtviewTheArithmeticOperation.Text.Remove(Index + 1, 1);
                    else
                        txtviewTheArithmeticOperation.Text = txtviewTheArithmeticOperation.Text.Insert(Index + 1, "-");
                }
                catch (Exception ex)
                {

                    if ((txtviewTheArithmeticOperation.Text[Index]) == '(')
                        txtviewTheArithmeticOperation.Text = txtviewTheArithmeticOperation.Text.Insert(Index + 1, "-");
                    else if ((txtviewTheArithmeticOperation.Text[Index]) == ')')
                    {
                        txtviewTheArithmeticOperation.Text = txtviewTheArithmeticOperation.Text.Insert(Index + 1, "*(-");
                        LastTypeAddOfCalculation = "(";
                    }
                    else
                        txtviewTheArithmeticOperation.Text = txtviewTheArithmeticOperation.Text.Insert(Index + 1, "-");
                }
            }
            else if ((txtviewTheArithmeticOperation.Text[0]) == '-')
            {
                txtviewTheArithmeticOperation.Text = txtviewTheArithmeticOperation.Text.Remove(0, 1);
            }
            else if (LastTypeAddOfCalculation == "")
            {
                txtviewTheArithmeticOperation.Text = txtviewTheArithmeticOperation.Text.Insert(0, "-");
            }

            txtHideResult.Text = txtviewTheArithmeticOperation.Text;
           
        }

        Control sender;
        void ChangeBackcolor()
        {

            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                sender.BackColor = colorDialog1.Color;
            }

        }
        void ChangeForecolor()
        {     

            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                sender.ForeColor = colorDialog1.Color;
            }        

        }
        private void btnMinusOrPlus_Click(object sender, EventArgs e)
        {

            MinusOrPlus();
            GetTheResult(txtviewTheArithmeticOperation);

        }

        private void Calculator_Load(object sender, EventArgs e)
        {

        }

        private void changeForeColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeForecolor();
        }

        private void changeBackColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeBackcolor();
        }

        private void changeBackColorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ChangeBackcolor();

        }

        private void Allbtn_MouseHover(object sender, EventArgs e)
        {
            this.sender = (Control)sender;

        }

    }
}
