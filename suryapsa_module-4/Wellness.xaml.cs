using System.Diagnostics;

namespace suryapsa_module_4;

public partial class Wellness : ContentPage
{
    private string _selectedGender = "Male"; // Default to male
    private double _wellnessScore;
    public Wellness()
	{
		InitializeComponent();
        SleepHoursSlider.Value = 7.0;
        StressLevelSlider.Value = 4.0;
        ActivityMinSlider.Value = 30.0;
        UpdateGenderSelection(_selectedGender);
    }
    private void SliderValue_Changed(object sender, ValueChangedEventArgs e)
    {
        var slider = (Slider)sender;
        if (slider == SleepHoursSlider)
        {
            SleepHoursLabel.Text = $"{e.NewValue:F1} h";
        }
        else if (slider == StressLevelSlider)
        {
            StressLevelLabel.Text = $"{e.NewValue:F1}";
        }
        else if (slider == ActivityMinSlider)
        {
            ActivityMinLabel.Text = $"{e.NewValue:F1} min";
        }
    }

    private void GenderImage_Tapped(object sender, TappedEventArgs e)
    {
        string newGender = e.Parameter.ToString();
        if (_selectedGender != newGender)
        {
            _selectedGender = newGender;
            UpdateGenderSelection(_selectedGender);
        }
    }


    private void UpdateGenderSelection(string gender)
    {
        MaleBorder.Stroke = Colors.Transparent;
        FemaleBorder.Stroke = Colors.Transparent;
        MaleBorder.StrokeThickness = 3;
        FemaleBorder.StrokeThickness = 3;

        if (gender == "Male")
        {
            MaleBorder.Stroke = Colors.CornflowerBlue;
        }
        else
        {
            FemaleBorder.Stroke = Colors.LightPink;
        }
    }

 
    private void CalculateButton_Clicked(object sender, EventArgs e)
    {
        double sleephrs = SleepHoursSlider.Value;
        double stresslevel = StressLevelSlider.Value;
        double activitymin = ActivityMinSlider.Value;

        double rawScore = (sleephrs * 8) - (stresslevel * 5) + (activitymin * 0.5);

        _wellnessScore = Math.Max(0, Math.Min(100, rawScore));

       
        int finalScore = (int)Math.Round(_wellnessScore);

        string status = GetStatus(finalScore);
        string recommendations = GetRecommendation(finalScore, _selectedGender);

   
        string genderIcon = _selectedGender == "Male" ? "♂️" : "♀️";
        DisplayAlert($"Your Wellness Score: {finalScore}", $"Status: {status}\n\nRecommendations: {recommendations}\n\nSelected Gender: {_selectedGender} {genderIcon}", "OK");
    }


    private string GetStatus(int score)
    {
        if (score >= 80) return "Excellent";
        if (score >= 60) return "Good";
        if (score >= 40) return "Fair";
        return "Poor";
    }

 
    private string GetRecommendation(int score, string gender)
    {
        if (gender == "Male")
        {
            if (score >= 80) return "Maintain routine; include resistance training 2–3× per week; ensure protein intake across meals.";
            if (score >= 60) return "Improve recovery with an earlier bedtime; add 15 min of light cardio or stretching; keep hydration steady.";
            if (score >= 40) return "Aim for +1 hour of sleep; reduce caffeine after noon; schedule light mobility or an easy walk.";
            return "Rest today; avoid strenuous workouts; focus on hydration and 20–30 min of gentle walking.";
        }
        else // Female
        {
            if (score >= 80) return "Keep strong habits; add yoga/pilates for recovery; prioritize calcium + vitamin D intake.";
            if (score >= 60) return "Boost energy with a balanced breakfast; add 15 min of walking; focus on iron-rich foods if feeling low.";
            if (score >= 40) return "Increase sleep consistency; reduce evening screen time; include calming routines like meditation or journaling.";
            return "Prioritize rest and self-care; consider a short nap if possible; gentle yoga/stretching only.";
        }
    }
}