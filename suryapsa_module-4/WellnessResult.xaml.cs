namespace suryapsa_module_4;

public partial class WellnessResult : ContentPage
{
	
    string gender;
    int wellnessscore;
    string status;

    public WellnessResult( string genderselected,int score)
	{
		InitializeComponent();
		
         this.gender = genderselected;
        this.wellnessscore=score;

        WellnessScore.Text = $"Your Score is {wellnessscore.ToString()}";
        Statuscalculation();

    }

    private void Statuscalculation()
    {
        if (wellnessscore > 80 && wellnessscore < 100)
        {
            Status.Text = "Excellent";
        }
        else if (wellnessscore > 60 && wellnessscore < 79)
        {
            Status.Text = "Good";
        }
        else if (wellnessscore > 40 && wellnessscore < 59)
        {
            Status.Text = "Fair";
        }
        else if (wellnessscore > 0 && wellnessscore < 39)
        {
            Status.Text = "Poor";
        }
        status= $"Status is {Status.Text}";
    }

    public void RecommendationBtnClicked(object sender, EventArgs e)
	{
		Navigation.PushAsync(new Recommendations(gender,Status.Text));
	}
    private void BacktohomeClicked(object sender, EventArgs e)
    {
        Navigation.PopToRootAsync();

    }
}