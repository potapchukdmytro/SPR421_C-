namespace asyncUI
{
    public partial class Form1 : Form
    {
        private bool increase = true;
        private bool isLoading = false;

        Random rnd = new Random();
        int min = 1;
        int max = 10;

        public Form1()
        {
            InitializeComponent();
        }

        private void Loading()
        {
            isLoading = true;
            while (isLoading)
            {
                if (increase)
                {
                    loading.Increment(1);
                    if (loading.Value == 100)
                    {
                        increase = false;
                    }
                }
                else
                {
                    loading.Increment(-1);
                    if (loading.Value == 0)
                    {
                        increase = true;
                    }
                }
                Thread.Sleep(16);
            }
        }

        private Task<int> GenerateRandomNumberAsync(int min = 0, int max = 100)
        {
            return Task.Run(() =>
            {
                var rnd = new Random();
                Thread.Sleep(5000);
                return rnd.Next(min, max);
            });
        }

        private async void btnRandom_Click(object sender, EventArgs e)
        {
            Task.Run(() => { Loading(); });
            int number = await GenerateRandomNumberAsync(50, 500);
            isLoading = false;
            labelRandom.Text = number.ToString();
        }

        private void ShowResult(int number, TimeSpan time)
        {
            double result = time.TotalSeconds;

            switch(number)
            {
                case 1:
                    result1.Text += result.ToString();
                    break;
                case 2:
                    result2.Text += result.ToString();
                    break;
                case 3:
                    result3.Text += result.ToString();
                    break;
                case 4:
                    result4.Text += result.ToString();
                    break;
                case 5:
                    result5.Text += result.ToString();
                    break;
            }
        }

        private Task HorseRunAsync(ProgressBar horse)
        {
            return Task.Run(() =>
            {
                DateTime timeStart = DateTime.Now;
                while (horse.Value < 100)
                {
                    Invoke(() =>
                    {
                        horse.Increment(rnd.Next(min, max));
                    });
                    Thread.Sleep(500);
                }
                DateTime timeEnd = DateTime.Now;
                TimeSpan result = timeEnd - timeStart;

                int number = horse.Tag != null ? int.Parse(horse.Tag.ToString() ?? "0") : 0;
                ShowResult(number, result);
            });
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            HorseRunAsync(horse1);
            HorseRunAsync(horse2);
            HorseRunAsync(horse3);
            HorseRunAsync(horse4);
            HorseRunAsync(horse5);
        }
    }
}
