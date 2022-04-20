namespace test_uni
{
    public partial class Form1 : Form
    {
        Button[,] cells;
        int empty_x, empty_y;
        private void button1_Click(object sender, EventArgs e)
        {
            Button this_button = sender as Button;
            int x = 0, y = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if(cells[i,j] == this_button)
                    {
                        x = i;
                        y = j;
                    }
                }
            }
            if (
                (x == empty_x && (y == empty_y - 1 || y == empty_y + 1))
                ||    // left or right
                (y == empty_y && (x == empty_x - 1 || x == empty_x + 1))
                )
            {
                // MessageBox.Show("همسایه");
                cells[empty_x,empty_y].Text = this_button.Text;
                this_button.Text = "16";
                cells[empty_x, empty_y].Show();
                this_button.Hide();
                empty_x = x;
                empty_y = y;
            }
        }
        public Form1()
        {
            InitializeComponent();
            cells = new Button[4, 4] { { button1, button2 ,button3 ,button4 },
                                       { button5, button6 ,button7 ,button8 },
                                           { button9, button10 ,button11 ,button12 },
                                                { button13, button14 ,button15 ,button16 }};

            Random r = new Random();
            int[] a = new int[16];
            int x = 1;
            for (int i = 0; i < 16; i++)
            {
                do
                {
                    x = r.Next(1, 17); //0 ta 16
                } while (a.Contains(x));
                a[i] = x;
            }
            for (int i = 0; i < 16; i++)
            {
                Console.WriteLine(a[i]);
            }
            int index = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if(a[index] == 16)
                    {
                        cells[i , j] . Hide();
                        empty_x = i;
                        empty_y = j;    
                    }
                    cells[i, j].Text = Convert.ToString(a[index]);
                    cells[i, j].Font = new Font("Arial", 20);
                    index++;
                    
                    Check();
                }
            }
        }
        public void Check()
        {
            if (
                    button1.Text == "1" && button2.Text == "2" && button3.Text == "3" && button4.Text == "4" &&
                    button5.Text == "5" && button6.Text == "6" && button7.Text == "7" && button8.Text == "8" &&
                    button9.Text == "9" && button10.Text == "10" && button11.Text == "11" && button12.Text == "12" &&
                    button13.Text == "13" && button14.Text == "14" && button15.Text == "15"
                )
            {
                MessageBox.Show("You Win");
            }
        }
        
    }

}
