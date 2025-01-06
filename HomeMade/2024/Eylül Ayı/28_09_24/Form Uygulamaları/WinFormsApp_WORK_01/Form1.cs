namespace WinFormsApp_WORK_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string istenenPass = "123";
            string pass = passBox.Text;
           
            string istenilenKullanici = "Eray";
            string kullanici = userBox.Text;

            if (kullanici == istenilenKullanici && istenenPass == pass)
            {
                sonucLabel.Text = "Helal Lan yusufi";
            }
            else
            {
                sonucLabel.Text = "Þifre Veya Kullanýcý adý yanlýþ";
            }


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
