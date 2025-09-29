
using System.Runtime.ConstrainedExecution;

namespace suryapsa_module_4;

public partial class Recommendations : ContentPage
{
	string gender_r;
	string status_r;
	public Recommendations(string gender,string status)
	{
		InitializeComponent();
		this.gender_r = gender;
		this.status_r = status;
        Recommendationlabel.Text= DisplayValues(gender_r, status_r);		
       

    }

    private string DisplayValues(string gender_r, string status_r)
    {
       if (status_r == "Excellent")
			return gender_r == "Male" ?
                "Maintain routine; include resistance training 2–3×/week; ensure protein intake." :
				 "Keep strong habits; add yoga/pilates; prioritize calcium + vitamin D.";
        if (status_r == "good")
            return gender_r == "Male" ?
                " Earlier bedtime for recovery; add 15 min light cardio/stretching; maintain hydration.":
                " Balanced breakfast; add 15 min walking; focus on iron - rich foods if feeling low.";
        if (status_r == "Fair")
            return gender_r == "Male" ?
                "Aim for +1 hour sleep; reduce caffeine after noon; schedule light mobility/easy walk.":
                "Improve sleep consistency; reduce evening screen time; add calming routines(meditation / journaling).";
        if (status_r == "Poor")
            return gender_r == "Male" ?
                "Rest today; avoid strenuous workouts; hydrate and take 20–30 min gentle walk." :
                "Prioritize rest/ self - care; short nap if possible; gentle yoga/ stretching only.";
       
        
       return "No recommendations available.";

    }

    private void BacktohomeClicked(object sender, EventArgs e)
	{
        Navigation.PopToRootAsync();
		
	}
}